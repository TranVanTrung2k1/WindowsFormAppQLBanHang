using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLyCuaHangMayTinh
{
    public partial class FDonNhapKho : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;
        private DataView dataview_gridviewHoaDon = new DataView();
        private DataView dataview_gridviewDSHoaDon = new DataView();

        public FDonNhapKho()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(set_background);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataToGridViewDonNhapKho(string filter = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblDonNhapKho_tblChiTietNhapKho";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_HoaDon = new DataTable())
                            {
                                dt_HoaDon.Clear();
                                adapter.Fill(dt_HoaDon);
                                if (dt_HoaDon.Rows.Count > 0)
                                {
                                    dataview_gridviewHoaDon = dt_HoaDon.DefaultView;
                                    dtGV_DonNhapKho.AutoGenerateColumns = false;

                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridviewHoaDon.RowFilter = filter;
                                    }
                                    dtGV_DonNhapKho.DataSource = dataview_gridviewHoaDon;
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
        private void tB_MaHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void FDonNhapKho_Load(object sender, EventArgs e)
        {
            LoadDataToGridViewDonNhapKho();
            LoadDataToComboBoxMaHoaDon();
            LoadData_Combobox_MaHang();
            LoadDataToGridViewDSHD();
        }

        private void dtGV_DonNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_DonNhapKho.CurrentRow.Index;
            cB_MaHang.Text = dataview_gridviewHoaDon[index]["sMaHang"].ToString();
            cB_MaHoaDon.Text = dataview_gridviewHoaDon[index]["iSoNK"].ToString();
            tB_MaNV.Text = dataview_gridviewHoaDon[index]["iMaNV"].ToString();
            tB_TongSoLuong.Text = dataview_gridviewHoaDon[index]["fTongSoLuong"].ToString();
            tB_GiaNhap.Text = dataview_gridviewHoaDon[index]["fGiaNhap"].ToString();
            tB_SoLuong.Text = dataview_gridviewHoaDon[index]["fSoLuongNhap"].ToString();
            dateTimePicker_NgayNhap.Text = dataview_gridviewHoaDon[index]["dNgayNhapHang"].ToString();
        }

        private void LoadDataToComboBoxMaHoaDon()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblDonNhapKho";
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
                                        cB_MaHoaDon.Items.Add(row["iSoNK"]);
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
                            command.CommandText = "Select_tblChiTietNhapKho";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
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
                            command.CommandText = "Select_tblChiTietNhapKho_NoPara";
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
                    command.CommandText = "Select_tblDonNhapKho_tblChiTietNhapKho1";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tB_MaNV.Text = reader["iMaNV"].ToString();
                        tB_TongSoLuong.Text = reader["fTongSoLuong"].ToString();
                        dateTimePicker_NgayNhap.Text = reader["dNgayNhapHang"].ToString();
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
                    command.CommandText = "Select_tblChiTietNhapKho_Para";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tB_GiaNhap.Text = reader["fGiaNhap"].ToString();
                        tB_SoLuong.Text = reader["fSoLuongNhap"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cB_MaHoaDon.Text = cB_MaHang.Text = tB_MaNV.Text = tB_SoLuong.Text = tB_GiaNhap.Text = tB_TongSoLuong.Text = String.Empty;
            dateTimePicker_NgayNhap.ResetText();

            cB_MaHoaDon.Focus();
        }

        private void btn_ThemDonNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_SoNK_tblDonNhapKho";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();

                    if (id == null)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblDonNhapKho";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_DonNhapKho = new DataTable("tblDonNhapKho"))
                            {
                                adapter.Fill(dt_DonNhapKho);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_DonNhapKho);
                                    DataRow row = dt_DonNhapKho.NewRow();
                                    row["iSoNK"] = cB_MaHoaDon.Text;
                                    row["iMaNV"] = tB_MaNV.Text;
                                    row["dNgayNhapHang"] = dateTimePicker_NgayNhap.Value.ToString("yyyy/MM/d");
                                    row["fTongSoLuong"] = tB_TongSoLuong.Text;

                                    dt_DonNhapKho.Rows.Add(row);

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Insert_tblDonNhapKho";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);                          
                                    command.Parameters.AddWithValue("@ngayNhap", dateTimePicker_NgayNhap.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@tongSoLuong", tB_TongSoLuong.Text);

                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblDonNhapKho");
                                    MessageBox.Show("Thêm mới thành công!");
                                    LoadDataToGridViewDonNhapKho();
                                    cB_MaHoaDon.Items.Clear();
                                    LoadDataToComboBoxMaHoaDon();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã hoá đơn " + cB_MaHoaDon.Text + " da ton tai");
                        return;
                    }
                }
            }
        }

        private void btn_UpdateDonNhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblDonNhapKho";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_DonNhapKho = new DataTable("tblDonNhapKho"))
                            {
                                adapter.Fill(dt_DonNhapKho);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_DonNhapKho);

                                    dt_DonNhapKho.PrimaryKey = new DataColumn[] { dt_DonNhapKho.Columns["iSoNK"] };
                                    DataRow row = dt_DonNhapKho.Rows.Find(cB_MaHoaDon.Text);
                                    row["iMaNV"] = tB_MaNV.Text;               
                                    row["dNgayNhapHang"] = dateTimePicker_NgayNhap.Value.ToString("yyyy/MM/d");
                                    row["fTongSoLuong"] = tB_TongSoLuong.Text;




                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Update_tblDonNhapKho";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maNV", tB_MaNV.Text);
                                    command.Parameters.AddWithValue("@ngayNhap", dateTimePicker_NgayNhap.Value.ToString("yyyy/MM/d"));
                                    command.Parameters.AddWithValue("@tongSoLuong", tB_TongSoLuong.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblDonNhapKho");
                                    MessageBox.Show("Cập nhật đơn hàng thành công!");
                                    LoadDataToGridViewDonNhapKho();
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

        private void btn_XoaDonNhap_Click(object sender, EventArgs e)
        {
            int index = dtGV_DonNhapKho.CurrentRow.Index;
            string maHD = dataview_gridviewHoaDon[index]["iSoNK"].ToString();
            try
            {
                DialogResult dialog_delete =
                    MessageBox.Show("Co muon xoa Ma Hoá Đơn " + maHD + " that khong", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog_delete == DialogResult.Yes)
                {
                    CheckRangBuocDonNhapKho(maHD);

                    //khai bao connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblDonNhapKho";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_DonNhapKho = new DataTable("tblDonNhapKho"))
                                {
                                    adapter.Fill(dt_DonNhapKho);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_DonNhapKho);
                                        dt_DonNhapKho.PrimaryKey = new DataColumn[]
                                        {
                                            dt_DonNhapKho.Columns["iSoNK"]
                                        };
                                        DataRow row = dt_DonNhapKho.Rows.Find(maHD);
                                        row.Delete();

                                        command.CommandText = "Delete_tblDonNhapKho";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maNK", maHD);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblDonNhapKho");
                                        MessageBox.Show("xoa thanh cong!");
                                        LoadDataToGridViewDonNhapKho();
                                        cB_MaHoaDon.Items.Clear();
                                        LoadDataToComboBoxMaHoaDon();
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

        private void CheckRangBuocDonNhapKho(string maHD)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocDonNhapKho";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maNK", maHD);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();
                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã hoá đơn " + maHD + " có phát sinh nhập hàng không xoá được!");
                    }
                }
            }
        }

        private void btn_ThemChiTietDonNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_PrimaryKey_tblChiTietNhapKho";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();

                    if (id == null)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblChiTietNhapKho_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_ChiTietNhapKho = new DataTable("tblChiTietNhapKho"))
                            {
                                adapter.Fill(dt_ChiTietNhapKho);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_ChiTietNhapKho);
                                    DataRow row = dt_ChiTietNhapKho.NewRow();
                                    row["iSoNK"] = cB_MaHoaDon.Text;
                                    row["sMaHang"] = cB_MaHang.Text;
                                    row["fGiaNhap"] = tB_GiaNhap.Text;
                                    row["fSoLuongNhap"] = tB_SoLuong.Text;

                                    dt_ChiTietNhapKho.Rows.Add(row);

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Insert_tblChiTietNhapKho";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);
                                    command.Parameters.AddWithValue("@giaNhap", tB_GiaNhap.Text);
                                    command.Parameters.AddWithValue("@soLuongNhap", tB_SoLuong.Text);


                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblChiTietNhapKho");
                                    MessageBox.Show("Thêm mới thành công!");
                                    LoadDataToGridViewDonNhapKho();
                                    cB_MaHang.Items.Clear();
                                    LoadDataToComboBoxMaHoaDon();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma hoá đơn " + cB_MaHoaDon.Text +" "+ cB_MaHang.Text + " da ton tai");
                        return;
                    }
                }
            }
        }

        private void btn_UpdateChiTietDonNhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblChiTietNhapKho_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_ChiTietNhapKho = new DataTable("tblChiTietNhapKho"))
                            {
                                adapter.Fill(dt_ChiTietNhapKho);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_ChiTietNhapKho);

                                    dt_ChiTietNhapKho.PrimaryKey = new DataColumn[] { dt_ChiTietNhapKho.Columns["iSoNK"], dt_ChiTietNhapKho.Columns["sMaHang"] };
                                    object[] primaryKeyValues = new object[] { cB_MaHoaDon.Text, cB_MaHang.Text };
                                    DataRow row = dt_ChiTietNhapKho.Rows.Find(primaryKeyValues);

                                    row["fGiaNhap"] = tB_GiaNhap.Text;
                                    row["fSoLuongNhap"] = tB_SoLuong.Text;                                   

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Update_tblChiTietNhapKho";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNK", cB_MaHoaDon.Text);
                                    command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);
                                    command.Parameters.AddWithValue("@giaNhap", tB_GiaNhap.Text);
                                    command.Parameters.AddWithValue("@soLuongNhap", tB_SoLuong.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblChiTietNhapKho");
                                    MessageBox.Show("Cập nhật Chi Tiet thành công!");
                                    LoadDataToGridViewDonNhapKho();
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

        private void btn_XoaChiTietDonNhap_Click(object sender, EventArgs e)
        {
            int index = dtGV_DonNhapKho.CurrentRow.Index;
            try
            {
                DialogResult dialog_delete =
                    MessageBox.Show("Co muon xoa Chi Tiết Hoá Đơn " + cB_MaHoaDon.Text + " " + cB_MaHang.Text + " that khong", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog_delete == DialogResult.Yes)
                {
                    //khai bao connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblChiTietNhapKho_NoPara";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_ChiTietNhapKho = new DataTable("tblChiTietNhapKho"))
                                {
                                    adapter.Fill(dt_ChiTietNhapKho);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_ChiTietNhapKho);
                                        dt_ChiTietNhapKho.PrimaryKey = new DataColumn[]
                                        {
                                            dt_ChiTietNhapKho.Columns["iSoNK"],
                                            dt_ChiTietNhapKho.Columns["sMaHang"]
                                        };

                                        object[] primaryKeyColumns = new object[] { cB_MaHoaDon.Text, cB_MaHang.Text }; ;

                                        DataRow row = dt_ChiTietNhapKho.NewRow();
                                        row = dt_ChiTietNhapKho.Rows.Find(primaryKeyColumns);
                                        row.Delete();

                                        command.CommandText = "Delete_tblChiTietNhapKho";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maNk", cB_MaHoaDon.Text);
                                        command.Parameters.AddWithValue("@maHang", cB_MaHang.Text);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblChiTietNhapKho");
                                        MessageBox.Show("xoa thanh cong!");
                                        LoadDataToGridViewDonNhapKho();
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
            string filter = "iSoNK IS NOT NULL";
            if (!string.IsNullOrEmpty(cB_MaHoaDon.Text))
            {
                filter += string.Format(" AND Convert(iSoNK, System.String) LIKE '%{0}%'", cB_MaHoaDon.Text);
            }
            if (!string.IsNullOrEmpty(tB_MaNV.Text))
            {
                filter += string.Format(" AND Convert(iMaNV, System.String) LIKE '%{0}%'", tB_MaNV.Text);
            }
            if (!string.IsNullOrEmpty(tB_TongSoLuong.Text))
            {
                filter += string.Format(" AND Convert(fTongSoLuong, System.String) LIKE '%{0}%'", tB_TongSoLuong.Text);
            }
            if (!string.IsNullOrEmpty(cB_MaHang.Text))
            {
                filter += string.Format(" AND sMaHang LIKE '%{0}%'", cB_MaHang.Text);
            }
            if (!string.IsNullOrEmpty(tB_GiaNhap.Text))
            {
                filter += string.Format(" AND Convert(fGiaNhap, System.String) LIKE '%{0}%'", tB_GiaNhap.Text);
            }
            if (!string.IsNullOrEmpty(tB_SoLuong.Text))
            {
                filter += string.Format(" AND Convert(fSoLuongNhap, System.String) LIKE '%{0}%'", tB_SoLuong.Text);
            }
            if (!string.IsNullOrEmpty(dateTimePicker_NgayNhap.Text))
            {
                filter += string.Format(" AND  Convert(dNgayNhapHang, System.String) LIKE '%{0}%'", dateTimePicker_NgayNhap.Value.ToString("dd/M/yyyy"));
            }
            LoadDataToGridViewDonNhapKho(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reportFilter = "NOT(ISNULL({Reports_DonNhapKho.iSoNK}))";
            if (!string.IsNullOrEmpty(cB_MaHoaDon.Text))
            {
                reportFilter += string.Format(" AND {0} LIKE '*{1}*'", "ToText(({Reports_DonNhapKho.iSoNK}))", cB_MaHoaDon.Text);
            }

            FReports fReports = new FReports();
            fReports.Show();
            fReports.ShowReport_DonNhapKho(reportFilter);
        }

        private void btn_HienDSHD_Click(object sender, EventArgs e)
        {
            LoadDataToGridViewDSHD();
        }

        private void LoadDataToGridViewDSHD(string filter="")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_DSDonNhapKho";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@fromDate", dateTimePicker_FromDate.Value.ToString("yyyy/MM/d"));
                        command.Parameters.AddWithValue("@toDate", dateTimePicker_ToDate.Value.ToString("yyyy/MM/d"));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_DSHoaDon = new DataTable())
                            {
                                dt_DSHoaDon.Clear();
                                adapter.Fill(dt_DSHoaDon);
                                //dtGV_DSHD.AutoGenerateColumns = false;

                                if (dt_DSHoaDon.Rows.Count > 0)
                                {
                                    dataview_gridviewDSHoaDon = dt_DSHoaDon.DefaultView;
                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridviewDSHoaDon.RowFilter = filter;
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

        private void dtGV_DSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_DSHD.CurrentRow.Index;

            cB_MaHoaDon.Text = dataview_gridviewDSHoaDon[index]["iSoNK"].ToString();
        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(gradient_rectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);//(57, 128, 227)
        }
    }
}
