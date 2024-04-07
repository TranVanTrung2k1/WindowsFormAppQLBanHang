using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace BTL_QuanLyCuaHangMayTinh
{
    public partial class FDonDatHang : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;
        private DataView dataview_gridviewHoaDon = new DataView();
        private DataView dataview_gridviewDSHoaDon = new DataView();
        //private DataTable dt_ComboboxMaHoaDon = new DataTable();
        //private DataTable dt_ComboboxMaHang = new DataTable();

        public FDonDatHang()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataToGridViewDonDatHang(string filter = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblDonDatHang_tblChiTietDatHang";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_HoaDon = new DataTable())
                            {
                                dt_HoaDon.Clear();
                                adapter.Fill(dt_HoaDon);
                                dtGV_DonDatHang.AutoGenerateColumns = false;

                                if (dt_HoaDon.Rows.Count > 0)
                                {
                                    dataview_gridviewHoaDon = dt_HoaDon.DefaultView;
                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridviewHoaDon.RowFilter = filter;
                                    }
                                    dtGV_DonDatHang.DataSource = dataview_gridviewHoaDon;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData_Combobox_MaHoaDonn()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblDonDatHang_NoPara";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_ComboboxMaHoaDon = new DataTable())
                            {
                                adapter.Fill(dt_ComboboxMaHoaDon);
                                if (dt_ComboboxMaHoaDon.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt_ComboboxMaHoaDon.Rows)
                                    {
                                        cB_MaHoaDon.Items.Add(row["iSoHD"]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("không tồn tại bản ghi nào!");
                                }
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadData_Combobox_MaHang()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        if (!string.IsNullOrEmpty(cB_MaHoaDon.Text))
                        {
                            command.CommandText = "Select_tblChiTietDatHang";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_ComboboxMaHang = new DataTable())
                                {
                                    adapter.Fill(dt_ComboboxMaHang);
                                    if (dt_ComboboxMaHang.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt_ComboboxMaHang.Rows)
                                        {
                                            //cB_MaHoaDon.Items.Add(row["iSoHD"]);
                                            //cB_MaHang.Items.Remove(row["sMaHang"]);
                                            cB_MaHang.Items.Add(row["sMaHang"]);
                                            //dt_ComboboxMaHang.Rows.Remove(row);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("không tồn tại bản ghi nào!");
                                    }
                                }
                            }
                        }
                        else
                        {
                            command.CommandText = "Select_tblChiTietDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_ComboboxMaHang = new DataTable())
                                {
                                    adapter.Fill(dt_ComboboxMaHang);
                                    if (dt_ComboboxMaHang.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt_ComboboxMaHang.Rows)
                                        {
                                            //cB_MaHoaDon.Items.Add(row["iSoHD"]);

                                            cB_MaHang.Items.Add(row["sMaHang"]);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("không tồn tại bản ghi nào!");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FDonDatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKinhDoanhMayTinhDataSet.Select_tblDonDatHang_tblChiTietDatHang' table. You can move, or remove it, as needed.
            //this.select_tblDonDatHang_tblChiTietDatHangTableAdapter.Fill(this.quanLyKinhDoanhMayTinhDataSet.Select_tblDonDatHang_tblChiTietDatHang);
            LoadDataToGridViewDonDatHang();
            LoadData_Combobox_MaHoaDonn();
            LoadData_Combobox_MaHang();
            LoadDataToGridViewDSHD();
        }

        private void cB_MaHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            cB_MaHang.Items.Clear();
            LoadData_Combobox_MaHang();
        }

        private void cB_MaHoaDon_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cB_MaHoaDon.Text))
            {
                LoadData_Combobox_MaHang();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select_tblDonDatHang_tblChiTietDatHang1";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tB_MaNV.Text = reader["iMaNV"].ToString();
                        tB_MaKH.Text = reader["iMaKH"].ToString();
                        tB_TongTien.Text = reader["fTongTienHD"].ToString();
                        dateTimePicker_NgayOrder.Text = reader["dNgayDatHang"].ToString();
                        dateTimePicker_NgayGiao.Text = reader["dNgayGiaoHang"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void cB_MaHang_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select_tblChiTietDatHang_getdata";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tB_GiaBan.Text = reader["fGiaBan"].ToString();
                        tB_SoLuong.Text = reader["iSoLuongMua"].ToString();
                        tB_GiamGia.Text = reader["fMucGiamGia"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cB_MaHoaDon.Text = tB_MaKH.Text = tB_MaNV.Text = tB_TongTien.Text = tB_SoLuong.Text = tB_GiamGia.Text = tB_GiaBan.Text = cB_MaHang.Text = string.Empty;
            dateTimePicker_NgayGiao.ResetText();
            dateTimePicker_NgayOrder.ResetText();

            cB_MaHoaDon.Focus();
        }

        private void btn_ThemDonDatHang_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_MaHD_DonDatHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();

                    if (id == null)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblDonDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_DonDatHang = new DataTable("tblDonDatHang"))
                            {
                                adapter.Fill(dt_DonDatHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_DonDatHang);
                                    DataRow row = dt_DonDatHang.NewRow();
                                    row["iSoHD"] = cB_MaHoaDon.Text;
                                    row["iMaNV"] = tB_MaNV.Text;
                                    row["iMaKH"] = tB_MaKH.Text;
                                    row["dNgayDatHang"] = dateTimePicker_NgayOrder.Value.ToString("yyyy/MM/d");
                                    row["dNgayGiaoHang"] = dateTimePicker_NgayGiao.Value.ToString("yyyy/MM/d");
                                    row["fTongTienHD"] = tB_TongTien.Text;

                                    dt_DonDatHang.Rows.Add(row);

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Insert_tblDonDatHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);
                                    command.Parameters.AddWithValue("@maKH", tB_MaKH.Text);
                                    command.Parameters.AddWithValue("@ngayDat", dateTimePicker_NgayOrder.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@ngayGiao", dateTimePicker_NgayGiao.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@tongTien", tB_TongTien.Text);

                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblDonDatHang");
                                    MessageBox.Show("Thêm mới thành công!");
                                    LoadDataToGridViewDonDatHang();
                                    cB_MaHoaDon.Items.Clear();
                                    LoadData_Combobox_MaHoaDonn();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma hoá đơn " + cB_MaHoaDon.Text + " da ton tai");
                        return;
                    }
                }
            }
        }

        private void btn_UpdateDonDatHang_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblDonDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_DonDatHang = new DataTable("tblDonDatHang"))
                            {
                                adapter.Fill(dt_DonDatHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_DonDatHang);

                                    dt_DonDatHang.PrimaryKey = new DataColumn[] { dt_DonDatHang.Columns["iSoHD"] };
                                    DataRow row = dt_DonDatHang.Rows.Find(cB_MaHoaDon.Text);
                                    row["iMaNV"] = tB_MaNV.Text;
                                    row["iMaKH"] = tB_MaKH.Text;
                                    row["dNgayDatHang"] = dateTimePicker_NgayOrder.Value.ToString("yyyy/MM/d");
                                    row["dNgayGiaoHang"] = dateTimePicker_NgayGiao.Value.ToString("yyyy/MM/d");
                                    row["fTongTienHD"] = tB_TongTien.Text;




                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Update_tblDonDatHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);
                                    command.Parameters.AddWithValue("@maKH", tB_MaKH.Text);
                                    command.Parameters.AddWithValue("@ngayDat", dateTimePicker_NgayOrder.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@ngayGiao", dateTimePicker_NgayGiao.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@tongTien", tB_TongTien.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblDonDatHang");
                                    MessageBox.Show("Cập nhật đơn hàng thành công!");
                                    LoadDataToGridViewDonDatHang();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("da co loi xay ra!" + ex);
            }
        }

        private void btn_XoaDonDatHang_Click(object sender, EventArgs e)
        {
            int index = dtGV_DonDatHang.CurrentRow.Index;
            string maHD = dataview_gridviewHoaDon[index]["iSoHD"].ToString();
            try
            {
                DialogResult dialog_delete =
                    MessageBox.Show("Co muon xoa Ma Hoá Đơn " + maHD + " that khong", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog_delete == DialogResult.Yes)
                {
                    CheckRangBuocDonDatHang(maHD);

                    //khai bao connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblDonDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_DonDatHang = new DataTable("tblDonDatHang"))
                                {
                                    adapter.Fill(dt_DonDatHang);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_DonDatHang);
                                        dt_DonDatHang.PrimaryKey = new DataColumn[]
                                        {
                                            dt_DonDatHang.Columns["iSoHD"]
                                        };
                                        DataRow row = dt_DonDatHang.Rows.Find(maHD);
                                        row.Delete();

                                        command.CommandText = "Delete_tblDonDatHang";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maHD", maHD);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblDonDatHang");
                                        MessageBox.Show("xoa thanh cong!");
                                        LoadDataToGridViewDonDatHang();
                                        cB_MaHoaDon.Items.Clear();
                                        LoadData_Combobox_MaHoaDonn();
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
            catch (Exception ex)
            {
                string errorStr = ex.Message;
                if (errorStr.Contains("FK_"))
                {
                    MessageBox.Show("ràng buộc không xoá được!");
                }
                else
                {
                    MessageBox.Show("da co loi xay ra! " + ex);
                }
            }
        }

        private void CheckRangBuocDonDatHang(string maHD)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocDonDatHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maHD", maHD);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();
                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã hoá đơn " + maHD + " có phát sinh xuất hàng không xoá được!");
                    }
                }
            }
        }

        private void btn_ThemChiTietDonHang_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_MaHD_MaHang_tblChiTietDatHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();

                    if (id == null)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblChiTietDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_ChiTietDatHang = new DataTable("tblChiTietDatHang"))
                            {
                                adapter.Fill(dt_ChiTietDatHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_ChiTietDatHang);
                                    DataRow row = dt_ChiTietDatHang.NewRow();
                                    row["iSoHD"] = cB_MaHoaDon.Text;
                                    row["sMaHang"] = cB_MaHang.Text;
                                    row["fGiaBan"] = tB_GiaBan.Text;
                                    row["iSoLuongMua"] = tB_SoLuong.Text;
                                    row["fMucGiamGia"] = tB_GiamGia.Text;

                                    dt_ChiTietDatHang.Rows.Add(row);

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Insert_tblChiTietDatHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);
                                    command.Parameters.AddWithValue("@giaBan", tB_GiaBan.Text);
                                    command.Parameters.AddWithValue("@soLuong", tB_SoLuong.Text);
                                    command.Parameters.AddWithValue("@giamGia", tB_GiamGia.Text);


                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblChiTietDatHang");
                                    MessageBox.Show("Thêm mới thành công!");
                                    LoadDataToGridViewDonDatHang();
                                    cB_MaHang.Items.Clear();
                                    LoadData_Combobox_MaHoaDonn(); 
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma hoá đơn " + cB_MaHoaDon.Text + " da ton tai");
                        return;
                    }
                }
            }
        }

        private void btn_UpdateChiTietDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblChiTietDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_ChiTietDatHang = new DataTable("tblChiTietDatHang"))
                            {
                                adapter.Fill(dt_ChiTietDatHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_ChiTietDatHang);

                                    dt_ChiTietDatHang.PrimaryKey = new DataColumn[] { dt_ChiTietDatHang.Columns["iSoHD"], dt_ChiTietDatHang.Columns["sMaHang"] };
                                    object[] primaryKeyValues = new object[] { cB_MaHoaDon.Text, cB_MaHang.Text };
                                    DataRow row = dt_ChiTietDatHang.Rows.Find(primaryKeyValues);
                                    
                                    row["fGiaBan"] = tB_GiaBan.Text;
                                    row["iSoLuongMua"] = tB_SoLuong.Text;
                                    row["fMucGiamGia"] = tB_GiamGia.Text;




                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Update_tblChiTietDatHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);
                                    command.Parameters.AddWithValue("@giaBan", tB_GiaBan.Text);
                                    command.Parameters.AddWithValue("@soLuong", tB_SoLuong.Text);
                                    command.Parameters.AddWithValue("@giamGia", tB_GiamGia.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblChiTietDatHang");
                                    MessageBox.Show("Cập nhật Chi Tiet thành công!");
                                    LoadDataToGridViewDonDatHang();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("da co loi xay ra!" + ex);
            }
        }

        private void btn_XoaChiTietDonHang_Click(object sender, EventArgs e)
        {
            int index = dtGV_DonDatHang.CurrentRow.Index; 
            try
            {
                DialogResult dialog_delete =
                    MessageBox.Show("Co muon xoa Chi Tiết Hoá Đơn " + cB_MaHang.Text +" "+ cB_MaHang.Text + " that khong", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog_delete == DialogResult.Yes)
                {
                    //khai bao connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblChiTietDatHang_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_ChiTietDatHang = new DataTable("tblChiTietDatHang"))
                                {
                                    adapter.Fill(dt_ChiTietDatHang);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_ChiTietDatHang);
                                        dt_ChiTietDatHang.PrimaryKey = new DataColumn[]
                                        {
                                            dt_ChiTietDatHang.Columns["iSoHD"],
                                            dt_ChiTietDatHang.Columns["sMaHang"]
                                        };
                                        
                                        object[] primaryKeyColumns = new object[] { cB_MaHoaDon.Text , cB_MaHang.Text }; 

                                        DataRow row = dt_ChiTietDatHang.NewRow();
                                        row = dt_ChiTietDatHang.Rows.Find(primaryKeyColumns);
                                        row.Delete();
                                        
                                        command.CommandText = "Delete_tblChiTietDatHang";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maHD", cB_MaHoaDon.Text);
                                        command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblChiTietDatHang");
                                        MessageBox.Show("xoa thanh cong!");
                                        LoadDataToGridViewDonDatHang();
                                        cB_MaHang.Items.Clear();
                                        LoadData_Combobox_MaHang();
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
            catch (Exception ex)
            {
                string errorStr = ex.Message;
                if (errorStr.Contains("FK_"))
                {
                    MessageBox.Show("ràng buộc không xoá được!");
                }
                else
                {
                    MessageBox.Show("da co loi xay ra! " + ex);
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string filter = "iSoHD IS NOT NULL";
            if (!string.IsNullOrEmpty(cB_MaHoaDon.Text))
            {
                filter += string.Format(" AND Convert(iSoHD, System.String) LIKE '%{0}%'", cB_MaHoaDon.Text);
            }
            if (!string.IsNullOrEmpty(tB_MaNV.Text))
            {
                filter += string.Format(" AND Convert(iMaNV, System.String) LIKE '%{0}%'", tB_MaNV.Text);
            }
            if (!string.IsNullOrEmpty(tB_MaKH.Text))
            {
                filter += string.Format(" AND Convert(iMaKH, System.String) LIKE '%{0}%'", tB_MaKH.Text);
            }
            if (!string.IsNullOrEmpty(cB_MaHang.Text))
            {
                filter += string.Format(" AND sMaHang LIKE '%{0}%'", cB_MaHang.Text);
            }
            if (!string.IsNullOrEmpty(tB_GiaBan.Text))
            {
                filter += string.Format(" AND Convert(fGiaBan, System.String) LIKE '%{0}%'", tB_GiaBan.Text);
            }
            if (!string.IsNullOrEmpty(tB_SoLuong.Text))
            {
                filter += string.Format(" AND Convert(iSoLuongMua, System.String) LIKE '%{0}%'", tB_SoLuong.Text);
            }
            if (!string.IsNullOrEmpty(tB_GiamGia.Text))
            {
                filter += string.Format(" AND Convert(fMucGiamGia, System.String) LIKE '%{0}%'", tB_GiamGia.Text);
            }
            LoadDataToGridViewDonDatHang(filter);
        }

        private void LoadDataToGridViewDSHD(string filter = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_DSDonDatHang";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@fromDate", dateTimePicker_StartDateCheck.Value.ToString("yyyy/MM/d"));
                        command.Parameters.AddWithValue("@toDate", dateTimePicker_EndDateCheck.Value.ToString("yyyy/MM/d"));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_DSHoaDon = new DataTable())
                            {
                                dt_DSHoaDon.Clear();
                                adapter.Fill(dt_DSHoaDon);
                                if (dt_DSHoaDon.Rows.Count > 0)
                                {
                                    dataview_gridviewDSHoaDon = dt_DSHoaDon.DefaultView;
                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridviewDSHoaDon.RowFilter = filter;
                                        dtGV_DSHD.AutoGenerateColumns = false;
                                    }
                                    dtGV_DSHD.DataSource = dataview_gridviewDSHoaDon;
                                }
                                else
                                {
                                    //MessageBox.Show("Không tồn tại bản ghi!");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_HienHoaDon_Click(object sender, EventArgs e)
        {
            LoadDataToGridViewDSHD();
        }

        private void dtGV_DonDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_DonDatHang.CurrentRow.Index;

            cB_MaHoaDon.Text = dataview_gridviewHoaDon[index]["iSoHD"].ToString();
            tB_MaNV.Text = dataview_gridviewHoaDon[index]["iMaNV"].ToString();
            tB_MaKH.Text = dataview_gridviewHoaDon[index]["iMaKH"].ToString();
            tB_TongTien.Text  = dataview_gridviewHoaDon[index]["fTongTienHD"].ToString();
            cB_MaHang.Text = dataview_gridviewHoaDon[index]["sMaHang"].ToString();
            tB_GiaBan.Text = dataview_gridviewHoaDon[index]["fGiaBan"].ToString();
            tB_SoLuong.Text = dataview_gridviewHoaDon[index]["iSoLuongMua"].ToString();
            tB_GiamGia.Text = dataview_gridviewHoaDon[index]["fMucGiamGia"].ToString();

            dateTimePicker_NgayOrder.Text = dataview_gridviewHoaDon[index]["dNgayDatHang"].ToString();
            dateTimePicker_NgayGiao.Text = dataview_gridviewHoaDon[index]["dNgayGiaoHang"].ToString();

        }

        private void dtGV_DSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_DSHD.CurrentRow.Index;

            cB_MaHoaDon.Text = dataview_gridviewDSHoaDon[index]["iSoHD"].ToString();
        }

        private void btn_InDSHD_Click(object sender, EventArgs e)
        {
            string reportFilter = "NOT(ISNULL({Reports_DonDatHang.iSoHD}))";
            if (!string.IsNullOrEmpty(cB_MaHoaDon.Text))
            {
                reportFilter += string.Format(" AND {0} LIKE '*{1}*'", "ToText(({Reports_DonDatHang.iSoHD}))", cB_MaHoaDon.Text);
            }

            FReports fReports_DonDatHang = new FReports();
            fReports_DonDatHang.Show();
            fReports_DonDatHang.ShowReport_DonDatHang(reportFilter);
            
            
        }
    }
}
