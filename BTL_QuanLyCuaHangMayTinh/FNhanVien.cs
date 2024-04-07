using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BTL_QuanLyCuaHangMayTinh
{
    public partial class FNhanVien : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;
        private DataView dataview_gridview = new DataView();
        private string gioitinh = "";
        public FNhanVien()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(set_background);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataToGridViewNhanVien(string filter = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblNhanVien";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using(DataTable dt_NhanVien = new DataTable())
                            {
                                dt_NhanVien.Clear();
                                adapter.Fill(dt_NhanVien);
                                if(dt_NhanVien.Rows.Count > 0)
                                {
                                    dataview_gridview = dt_NhanVien.DefaultView;

                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridview.RowFilter = filter;
                                    }
                                    dtGV_NhanVien.DataSource =  dataview_gridview;
                                }
                                else
                                {
                                    MessageBox.Show("Không tồn tại dữ liệu!");
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataToGridViewNhanVien();
        }

        private void CheckrBGioiTinh()
        {
            if(rB_Nam.Checked == true)
            {
                gioitinh = "Nam";
            }
            if(rB_Nu.Checked == true)
            {
                gioitinh = "Nữ";
            }
        }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {         
            CheckrBGioiTinh();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Check_MaNV_tblNhanVien";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);

                        connection.Open();
                        var id = command.ExecuteScalar();
                        connection.Close();

                        if(id == null)
                        {
                            using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                command.CommandText = "Select_tblNhanVien";
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Clear();
                                using(DataTable dt_NhanVien = new DataTable("tblNhanVien"))
                                {
                                    adapter.Fill(dt_NhanVien);
                                    using(DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_NhanVien);
                                        DataRow row = dt_NhanVien.NewRow();
                                        row["iMaNV"] = tB_MaNV.Text;
                                        row["sTenNV"] = tB_TenNV.Text;
                                        row["sDiaChi"] = tB_DiaChi.Text;
                                        row["sDienThoai"] = tB_Sdt.Text;
                                        row["dNgaySinh"] = dateTimePicker_NgaySinh.Value.ToString("yyyy/MM/d");
                                        row["sGioiTinh"] = gioitinh;
                                        row["dNgayVaoLam"] = dateTimePicker_NgayVaoLam.Value.ToString("yyyy/MM/d");
                                        row["fLuongCoBan"] = tB_LuongCB.Text;
                                        row["fPhuCap"] = tB_PhuCap.Text;

                                        dt_NhanVien.Rows.Add(row);

                                        command.CommandText = "Insert_tblNhanVien";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);
                                        command.Parameters.AddWithValue("@tenNV", tB_TenNV.Text);
                                        command.Parameters.AddWithValue("@diaChi", tB_DiaChi.Text);
                                        command.Parameters.AddWithValue("@sdt", tB_Sdt.Text);
                                        command.Parameters.AddWithValue("@ngaySinh", dateTimePicker_NgaySinh.Value.ToString("yyyy/MM/d"));
                                        command.Parameters.AddWithValue("@gioiTinh", gioitinh);
                                        command.Parameters.AddWithValue("@ngayVaoLam", dateTimePicker_NgayVaoLam.Value.ToString("yyyy/MM/d"));
                                        command.Parameters.AddWithValue("@luongCB", tB_LuongCB.Text);
                                        command.Parameters.AddWithValue("@phuCap", tB_PhuCap.Text);

                                            adapter.InsertCommand = command;
                                            adapter.Update(dataSet, "tblNhanVien");
                                            MessageBox.Show("Thêm mới thành công!");
                                            LoadDataToGridViewNhanVien();
                                        }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã nhân viên " + tB_MaNV.Text + " đã tồn tại, không thể thêm mới!");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_UpdateNV_Click(object sender, EventArgs e)
        {
            CheckrBGioiTinh();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblNhanVien";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using(DataTable dt_NhanVien = new DataTable("tblNhanVien"))
                            {
                                adapter.Fill(dt_NhanVien);
                                using(DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_NhanVien);

                                    dt_NhanVien.PrimaryKey = new DataColumn[] { dt_NhanVien.Columns["iMaNV"] };
                                    DataRow row = dt_NhanVien.Rows.Find(tB_MaNV.Text);
                                    row["sTenNV"] = tB_TenNV.Text;
                                    row["sDiaChi"] = tB_DiaChi.Text;
                                    row["sDienThoai"] = tB_Sdt.Text;
                                    row["dNgaySinh"] = dateTimePicker_NgaySinh.Value.ToString("yyyy/MM/d");
                                    row["sGioiTinh"] = gioitinh;
                                    row["dNgayVaoLam"] = dateTimePicker_NgayVaoLam.Value.ToString("yyyy/MM/d");
                                    row["fLuongCoBan"] = tB_LuongCB.Text;
                                    row["fPhuCap"] = tB_PhuCap.Text;


                                    command.CommandText = "Update_tblNhanVien";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);
                                    command.Parameters.AddWithValue("@tenNV", tB_TenNV.Text);
                                    command.Parameters.AddWithValue("@diaChi", tB_DiaChi.Text);
                                    command.Parameters.AddWithValue("@sdt", tB_Sdt.Text);
                                    command.Parameters.AddWithValue("@ngaySinh", dateTimePicker_NgaySinh.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@gioiTinh", gioitinh);
                                    command.Parameters.AddWithValue("@ngayVaoLam", dateTimePicker_NgayVaoLam.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@luongCB", tB_LuongCB.Text);
                                    command.Parameters.AddWithValue("@phuCap", tB_PhuCap.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblNhanVien");
                                    MessageBox.Show("Cập nhật thành công!");
                                    LoadDataToGridViewNhanVien();
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra! " + ex.Message);
            }

        }

        private void dtGV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_NhanVien.CurrentRow.Index;

            tB_MaNV.Text = dataview_gridview[index]["iMaNV"].ToString();
            tB_MaNV.ReadOnly = true;
            tB_TenNV.Text = dataview_gridview[index]["sTenNV"].ToString();
            tB_DiaChi.Text = dataview_gridview[index]["sDiaChi"].ToString();
            tB_Sdt.Text = dataview_gridview[index]["sDienThoai"].ToString();
            tB_LuongCB.Text = dataview_gridview[index]["fLuongCoBan"].ToString();
            tB_PhuCap.Text = dataview_gridview[index]["fPhuCap"].ToString();
            dateTimePicker_NgaySinh.Text = dataview_gridview[index]["dNgaySinh"].ToString();
            dateTimePicker_NgayVaoLam.Text = dataview_gridview[index]["dNgayVaoLam"].ToString();
            if(string.Equals((dataview_gridview[index]["sGioiTinh"].ToString().ToLower()), "nam")) 
            {
                rB_Nam.Checked = true;
            }
            else
            {
                rB_Nu.Checked = true;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            tB_MaNV.Text = tB_TenNV.Text = tB_Sdt.Text = tB_DiaChi.Text = tB_LuongCB.Text = tB_PhuCap.Text = String.Empty;

            dateTimePicker_NgaySinh.ResetText();
            dateTimePicker_NgayVaoLam.ResetText();
            rB_Nam.ResetText();
            rB_Nu.ResetText();
            tB_MaNV.Focus();
            tB_MaNV.ReadOnly = false;
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            int index = dtGV_NhanVien.CurrentRow.Index;
            try
            {
                DialogResult dialogDeleteNV = MessageBox.Show("Bạn có muốn xoá mã nhân viên: " + tB_MaNV.Text + "thật không!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogDeleteNV == DialogResult.Yes)
                {
                    CheckRangBuocNhanVienNhapKho(tB_MaNV.Text);
                    CheckRangBuocNhanVienXuatHang(tB_MaNV.Text);
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using(SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblNhanVien";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using(DataTable dt_NhanVien = new DataTable("tblNhanVien"))
                                {
                                    adapter.Fill(dt_NhanVien);
                                    using(DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_NhanVien);
                                        dt_NhanVien.PrimaryKey = new DataColumn[] { dt_NhanVien.Columns["iMaNV"] };
                                        DataRow row = dt_NhanVien.Rows.Find(tB_MaNV.Text);
                                        row.Delete();

                                        command.CommandText = "Delete_tblNhanVien";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblNhanVien");
                                        MessageBox.Show("Đã xoá thành công!");
                                        LoadDataToGridViewNhanVien();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra!" + ex.Message);
            }
        }

        private void CheckRangBuocNhanVienNhapKho(string maNV)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocNhanVien_NhapKho";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNV", maNV);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();

                    if(exist)
                    {
                        throw new Exception("Ràng buộc mã Nhân viên " + maNV + " có phát sinh nhập kho không xoá được!");
                    }
                }
            }
        }
        private void CheckRangBuocNhanVienXuatHang(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocNhanVien_XuatHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNV", maNV);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();

                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã Nhân viên " + maNV + " có phát sinh xuất Hàng không xoá được!");
                    }
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string filter = "iMaNV IS NOT NULL";
            if (!string.IsNullOrEmpty(tB_MaNV.Text))
            {
                filter += string.Format(" AND Convert(iMaNV, System.String) LIKE '%{0}%'", tB_MaNV.Text);
            }
            if(!string.IsNullOrEmpty(tB_TenNV.Text))
            {
                filter += string.Format(" AND sTenNV LIKE '%{0}%'", tB_TenNV.Text);
            }
            if (!string.IsNullOrEmpty(tB_DiaChi.Text))
            {
                filter += string.Format(" AND sDiaChi LIKE '%{0}%'", tB_DiaChi.Text);
            }
            if (!string.IsNullOrEmpty(tB_Sdt.Text))
            {
                filter += string.Format(" AND sDienThoai LIKE '%{0}%'", tB_Sdt.Text);
            }
            LoadDataToGridViewNhanVien(filter);
        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(gradient_rectangle, Color.FromArgb(227, 227, 227), Color.FromArgb(57, 128, 227), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        public int TuoiNV()
        {
            TimeSpan khoangCach = DateTime.Now.Subtract(dateTimePicker_NgaySinh.Value);
            int tuoi = (int)(khoangCach.TotalDays / 365);
            return tuoi;
        }
        private void btn_CallReportShow_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(tuoi.ToString());

            string reportFilter = "NOT(ISNULL({Select_tblNhanVien.iMaNV}))";
            if (!string.IsNullOrEmpty(dateTimePicker_NgaySinh.Text))
            {
                reportFilter += string.Format(" AND {0} > {1}", "DateDiff('d', {Select_tblNhanVien.dNgaySinh}, CurrentDate) / 365", TuoiNV());
            }

            FReports fReports = new FReports();
            fReports.Show();
            fReports.ShowReport_NhanVien(reportFilter);
        }

        private void btn_CallShowNVLuongCB_Click(object sender, EventArgs e)
        {
            string reportFilter = "NOT(ISNULL({Select_tblNhanVien.iMaNV}))";
            if (!string.IsNullOrEmpty(tB_LuongCB.Text))
            {
                reportFilter += string.Format(" AND {0} > {1}", "{Select_tblNhanVien.fLuongCoBan}", Convert.ToInt32(tB_LuongCB.Text));
            }

            FReports fReports = new FReports();
            fReports.Show();
            fReports.ShowReport_NhanVien(reportFilter);
        }

        private void btn_CallShowNv_Click(object sender, EventArgs e)
        {
            string reportFilter = "NOT(ISNULL({Select_tblNhanVien.iMaNV}))";
            if (!string.IsNullOrEmpty(tB_LuongCB.Text))
            {
                reportFilter += string.Format(" AND {0} = {1}", "{Select_tblNhanVien.iMaNV}", Convert.ToInt32(tB_MaNV.Text));
            }
            
            FReports fReports = new FReports();
            fReports.Show();
            fReports.ShowReport_NhanVien(reportFilter);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            // Nếu ít nhất một GroupBox có RadioButton được chọn
            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            bool groupBox1Checked = groupBox1.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox2Checked = groupBox2.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            bool groupBox3Checked = groupBox3.Controls.OfType<RadioButton>().Any(rb => rb.Checked);

            if (groupBox1Checked && groupBox2Checked && groupBox3Checked)
            {
                // Enable nút
                btn_ThemNV.Enabled = true;
            }
            else
            {
                // Disable nút
                btn_ThemNV.Enabled = false;
            }
        }

        private void tB_MaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
