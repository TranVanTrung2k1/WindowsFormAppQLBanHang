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
    public partial class FKhachHang : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;
        private DataView dataview_gridview = new DataView();
        
        public FKhachHang()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(set_background);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataToGridViewKhachHang(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select_tblKhachHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();

                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        using(DataTable dt_gridView = new DataTable())
                        {
                            dt_gridView.Clear();
                            adapter.Fill(dt_gridView);
                            if (dt_gridView.Rows.Count > 0)
                            {
                                dataview_gridview = dt_gridView.DefaultView;
                                if (!string.IsNullOrEmpty(filter))
                                {
                                    dataview_gridview.RowFilter = filter;
                                }
                                dtGV_KhachHang.DataSource = dataview_gridview;
                            }
                            else
                            {
                                MessageBox.Show("Không tồn tại bản ghi!");
                            }
                            }
                        }
                    }
                }
            }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataToGridViewKhachHang();
            if (!cB_1.Checked || !cB_2.Checked || !cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = false;
            }
        }

        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_MaKH_tblKhachHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maKH", tB_MaKhachHang.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();
                    
                    if(id == null)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            
                            command.CommandText = "Select_tblKhachHang";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using(DataTable dt_KhachHang = new DataTable("tblKhachHang"))
                            {
                                adapter.Fill(dt_KhachHang);
                                using(DataSet dataSet = new DataSet())
                                {                              
                                    string cB_text = "";
                                    if(cB_1.Checked)
                                    {
                                        cB_text += cB_1.Text;
                                    }
                                    if (cB_2.Checked)
                                    {
                                        cB_text += "; " + cB_2.Text;
                                    }
                                    if (cB_3.Checked)
                                    {
                                        cB_text += "; " + cB_3.Text;
                                    }


                                    //string cB_text = cB_1.Text + "; " + cB_2.Text + "; " + cB_3.Text;

                                    dataSet.Tables.Add(dt_KhachHang);
                                    DataRow row = dt_KhachHang.NewRow();
                                    row["iMaKH"] = tB_MaKhachHang.Text;
                                    row["sTenKH"] = tB_TenKhachHang.Text;
                                    row["sDiaChi"] = tB_DiaChi.Text;
                                    row["sDienThoai"] = tB_Sdt.Text;
                                    row["sGhiChu"] = cB_1.Text;

                                    dt_KhachHang.Rows.Add(row);

                                    command.CommandText = "Insert_tblKhachHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maKH", tB_MaKhachHang.Text);
                                    command.Parameters.AddWithValue("@tenKH", tB_TenKhachHang.Text);
                                    command.Parameters.AddWithValue("@diaChi", tB_DiaChi.Text);
                                    command.Parameters.AddWithValue("@sdt", tB_Sdt.Text);
                                    command.Parameters.AddWithValue("@ghiChu", cB_text);
                                    
                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblKhachHang");
                                    MessageBox.Show("Thêm mới thành công!");
                                    LoadDataToGridViewKhachHang();  
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã khách hàng: " + tB_MaKhachHang.Text + " đã tồn tại! Không thể thêm mới");
                    }
                }
            }
        }

        private void btn_UpdateKhachHang_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select_tblKhachHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        using(DataTable dt_KhachHang = new DataTable("tblKhachHang"))
                        {
                            adapter.Fill(dt_KhachHang);
                            using(DataSet dataSet = new DataSet())
                            {
                                dataSet.Tables.Add(dt_KhachHang);

                                dt_KhachHang.PrimaryKey = new DataColumn[] { dt_KhachHang.Columns["iMakH"] };
                                DataRow row = dt_KhachHang.Rows.Find(tB_MaKhachHang.Text);
                                row["sTenKH"] = tB_TenKhachHang.Text;
                                row["sDiaChi"] = tB_DiaChi.Text;
                                row["sDienThoai"] = tB_Sdt.Text;

                                command.CommandText = "Update_tblKhachHang";
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@maKH", tB_MaKhachHang.Text);
                                command.Parameters.AddWithValue("@tenKH", tB_TenKhachHang.Text);
                                command.Parameters.AddWithValue("@diaChi", tB_DiaChi.Text);
                                command.Parameters.AddWithValue("@sdt", tB_Sdt.Text);

                                adapter.UpdateCommand = command;
                                adapter.Update(dataSet, "tblKhachHang");
                                MessageBox.Show("Cập nhật thành công!");
                                LoadDataToGridViewKhachHang();
                            }
                        }
                    }
                }
            }
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

        private void dtGV_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_KhachHang.CurrentRow.Index;

            tB_MaKhachHang.Text = dataview_gridview[index]["iMaKH"].ToString();
            tB_TenKhachHang.Text = dataview_gridview[index]["sTenKH"].ToString();
            tB_DiaChi.Text = dataview_gridview[index]["sDiaChi"].ToString();
            tB_Sdt.Text = dataview_gridview[index]["sDienThoai"].ToString();
            tB_MaKhachHang.ReadOnly = true;
        }

        private void btn_XoaKhachHang_Click(object sender, EventArgs e)
        {
            int index = dtGV_KhachHang.CurrentRow.Index;
            try
            {
                DialogResult dialogDelete = MessageBox.Show(" Bạn có muốn xoá " + tB_MaKhachHang.Text + " thật không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogDelete == DialogResult.Yes)
                {
                    using(SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using(SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblKhachHang";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using(DataTable dt_KhachHang = new DataTable("tblKhachHang"))
                                {
                                    adapter.Fill(dt_KhachHang);
                                    using(DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_KhachHang);

                                        dt_KhachHang.PrimaryKey = new DataColumn[] { dt_KhachHang.Columns["iMaKH"] };
                                        DataRow row = dt_KhachHang.Rows.Find(tB_MaKhachHang.Text);
                                        row.Delete();

                                        command.CommandText = "Delete_tblKhachHang";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maKH", tB_MaKhachHang.Text);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblKhachHang");
                                        MessageBox.Show("Đã xoá thành công!");
                                        LoadDataToGridViewKhachHang();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("đã có lỗi xảy ra! " + ex.Message);
            }
        }

        private void CheckRangBuocKhachHang(string maKH)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocKhachHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maKH", maKH);

                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();
                    if(exist)
                    {
                        throw new Exception("Ràng buộc khách hàng " + maKH + " có phát sinh hoá đơn không xoá được");
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            tB_MaKhachHang.Text = tB_TenKhachHang.Text = tB_DiaChi.Text = tB_Sdt.Text = String.Empty;

            tB_MaKhachHang.Focus();
            tB_MaKhachHang.ReadOnly = false;
        }

        private void btn_InDSKH_Click(object sender, EventArgs e)
        {
            string reportFilter = "NOT(ISNULL({Select_tblKhachHang.iMaKH}))";
            if (!string.IsNullOrEmpty(tB_MaKhachHang.Text))
            {
                reportFilter += string.Format(" AND {0} LIKE '*{1}*'", "ToText(({Select_tblKhachHang.iMaKH}))", tB_MaKhachHang.Text);
            }

            FReports fReports_KhachHang = new FReports();
            fReports_KhachHang.Show();
            fReports_KhachHang.ShowReport_KhachHang(reportFilter);
        }

        private void cB_1_CheckedChanged(object sender, EventArgs e)
        {
            //if (!cB_1.Checked)
            //{
            //    btn_ThemKhachHang.Enabled = false;
            //}
            //if (!cB_2.Checked)
            //{
            //    btn_ThemKhachHang.Enabled = false;
            //}
            //if (!cB_3.Checked)
            //{
            //    btn_ThemKhachHang.Enabled = false;
            //}
            if (!cB_1.Checked || !cB_2.Checked || !cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = false;
            }
            if (cB_1.Checked || cB_2.Checked || cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = true;
            }
        }

        private void cB_2_CheckedChanged(object sender, EventArgs e)
        {
            if (!cB_1.Checked || !cB_2.Checked || !cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = false;
            }
            if (cB_1.Checked || cB_2.Checked || cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = true;
            }
        }

        private void cB_3_CheckedChanged(object sender, EventArgs e)
        {
            if (!cB_1.Checked || !cB_2.Checked || !cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = false;
            }
            if (cB_1.Checked || cB_2.Checked || cB_3.Checked)
            {
                btn_ThemKhachHang.Enabled = true;
            }
        }
    }
}
