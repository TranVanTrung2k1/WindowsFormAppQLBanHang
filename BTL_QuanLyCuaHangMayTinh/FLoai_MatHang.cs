using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_QuanLyCuaHangMayTinh
{
    public partial class FLoai_MatHang : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;
        private DataTable dt_combobox = new DataTable();
        private DataTable dt_comboboxNCC = new DataTable();
        private DataView dataview_gridViewLoaiHang = new DataView();
        private DataView dataview_gridViewMatHang = new DataView();


        public FLoai_MatHang()
        {
            InitializeComponent();
        }

        private void btn_ThemLoaiHang_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    if (!Check_MaLoaiHang())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblLoaiHang";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_LoaiHang = new DataTable("tblLoaiHang"))
                            {
                                adapter.Fill(dt_LoaiHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_LoaiHang);
                                    DataRow row = dt_LoaiHang.NewRow();
                                    row["sMaLoaiHang"] = cB_MaLoaiHang.Text;
                                    row["sTenLoaiHang"] = tB_TenLoaiHang.Text;

                                    dt_LoaiHang.Rows.Add(row);

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Insert_tblLoaiHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maLoaiHang", cB_MaLoaiHang.Text);
                                    command.Parameters.AddWithValue("@tenLoaiHang", tB_TenLoaiHang.Text);

                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblLoaiHang");
                                    MessageBox.Show("Thêm mới loại hàng thành công!");
                                    LoadDataToGridView_LoaiHang();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma loai hang " + cB_MaLoaiHang.Text + " da ton tai");
                        return;
                    }
                }
            }
        }

        private bool Check_MaLoaiHang()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string procCheckMaLoaiHang = "Check_MaLoaiHang";
                    command.CommandText = procCheckMaLoaiHang;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maloaihang", cB_MaLoaiHang.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();
                    if(id == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private bool Check_MaNCC()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string procCheckMaNCC = "Check_MaNCC";
                    command.CommandText = procCheckMaNCC;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maNCC", cB_MaNCC.Text);
                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();
                    if (id == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void btn_ThemMatHang_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string procCheckMaLoaiHang = "Check_MaHang";
                    command.CommandText = procCheckMaLoaiHang;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mahang", tB_MaHang.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();

                    if (id == null)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblMatHang";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dt_MatHang = new DataTable("tblMatHang"))
                            {
                                adapter.Fill(dt_MatHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_MatHang);
                                    DataRow row = dt_MatHang.NewRow();
                                    row["sMaHang"] = tB_MaHang.Text;
                                    row["sTenHang"] = tB_TenHang.Text;
                                    row["sMaLoaiHang"] = cB_MaLoaiHang.Text;
                                    row["iMaNCC"] = cB_MaNCC.Text;
                                    row["fGiaHang"] = tB_GiaHang.Text;
                                    row["fSoLuong"] = tB_SoLuong.Text;

                                    dt_MatHang.Rows.Add(row);

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Insert_tblMatHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maHang", tB_MaHang.Text);
                                    command.Parameters.AddWithValue("@tenHang", tB_TenHang.Text);
                                    command.Parameters.AddWithValue("@maNCC", cB_MaNCC.Text);
                                    command.Parameters.AddWithValue("@maLoaiHang", cB_MaLoaiHang.Text);
                                    command.Parameters.AddWithValue("@giaHang", tB_GiaHang.Text);
                                    command.Parameters.AddWithValue("@soLuong", tB_SoLuong.Text);

                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblMatHang");
                                    MessageBox.Show("Thêm mới mặt hàng thành công!");
                                    LoadDataToGridView_MatHang();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma hang " + tB_MaHang.Text + " da ton tai");
                        return;
                    }
                }
            }
        }

        private void btn_CapNhatLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblLoaiHang";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using (DataTable dtLoaiHang = new DataTable("tblLoaiHang"))
                            {
                                adapter.Fill(dtLoaiHang);
                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dtLoaiHang);

                                    dtLoaiHang.PrimaryKey = new DataColumn[] { dtLoaiHang.Columns["sMaLoaiHang"] };
                                    DataRow row = dtLoaiHang.Rows.Find(cB_MaLoaiHang.Text);
                                    row["sTenLoaiHang"] = tB_TenLoaiHang.Text;

                                   

                                    //Thêm  bản ghi vào csdl
                                    command.CommandText = "Update_tblLoaiHang";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maLoaiHang", cB_MaLoaiHang.Text);
                                    command.Parameters.AddWithValue("@tenLoaiHang", tB_TenLoaiHang.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblLoaiHang");
                                    MessageBox.Show("Cập nhật loại hàng thành công!");
                                    LoadDataToGridView_LoaiHang();
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

        private void btn_CapNhatMatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_MaLoaiHang() && Check_MaNCC())
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                command.CommandText = "Select_tblMatHang";
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Clear();

                                using (DataTable dtMatHang = new DataTable("tblMatHang"))
                                {
                                    adapter.Fill(dtMatHang);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dtMatHang);

                                        dtMatHang.PrimaryKey = new DataColumn[] { dtMatHang.Columns["sMaHang"] };
                                        DataRow row = dtMatHang.Rows.Find(tB_MaHang.Text);
                                        row["sTenHang"] = tB_TenHang.Text;
                                        row["sMaLoaiHang"] = cB_MaLoaiHang.Text;
                                        row["iMaNCC"] = cB_MaNCC.Text;
                                        row["fGiaHang"] = tB_GiaHang.Text;
                                        row["fSoLuong"] = tB_SoLuong.Text;

                                       

                                        //Thêm  bản ghi vào csdl
                                        command.CommandText = "Update_tblMatHang";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maHang", tB_MaHang.Text);
                                        command.Parameters.AddWithValue("@tenHang", tB_TenHang.Text);
                                        command.Parameters.AddWithValue("@maNCC", cB_MaNCC.Text);
                                        command.Parameters.AddWithValue("@maLoaiHang", cB_MaLoaiHang.Text);
                                        command.Parameters.AddWithValue("@giaHang", tB_GiaHang.Text);
                                        command.Parameters.AddWithValue("@soLuong", tB_SoLuong.Text);

                                        adapter.UpdateCommand = command;
                                        adapter.Update(dataSet, "tblMatHang");
                                        MessageBox.Show("Cập nhật mặt hàng thành công!");
                                        LoadDataToGridView_MatHang();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("mã loại hàng hoặc NCC không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("da co loi xay ra!" + ex);
            }
        }

        private void LoadData_ComboBox_MaLoaiHang()
        {
            string procSelectMaLoaiHang = "Select_tblLoaiHang";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = procSelectMaLoaiHang;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.Text;
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = sqlCommand;

                            adapter.Fill(dt_combobox);
                            //Hiển thị dư liệu từ datatable len Combobox
                            if (dt_combobox.Rows.Count > 0)
                            {
                                //cách 1: ràng buộc data
                                //cB_MaLoaiHang.DataSource = dataTable;
                                //cB_MaLoaiHang.ValueMember = "sMaLoaiHang";
                                //cB_MaLoaiHang.DisplayMember = "sMaLoaiHang";

                                //cách 2: ko ràng buộc data
                                foreach (DataRow row in dt_combobox.Rows)
                                {
                                    cB_MaLoaiHang.Items.Add(row["sMaLoaiHang"]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Khong ton tai ban ghi nao!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dã có lỗi xảy ra!" + ex.Message);
            }
            finally
            {

            }
        }

        private void LoadData_ComboBox_MaNCC()
        {
            string procSelectMaNCC = "Select_tblNhaCungCap";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = procSelectMaNCC;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.Text;
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = sqlCommand;

                            adapter.Fill(dt_comboboxNCC);
                            //Hiển thị dư liệu từ datatable len Combobox
                            if (dt_comboboxNCC.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt_comboboxNCC.Rows)
                                {
                                    cB_MaNCC.Items.Add(row["iMaNCC"]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Khong ton tai ban ghi nao!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dã có lỗi xảy ra!" + ex.Message);
            }
            finally
            {

            }
        }

        private void FLoai_MatHang_Load(object sender, EventArgs e)
        {
            tB_MaHang.Focus();

            LoadData_ComboBox_MaLoaiHang();
            LoadData_ComboBox_MaNCC();
            LoadDataToGridView_LoaiHang();
            LoadDataToGridView_MatHang();
        }

        private void cB_MaLoaiHang_Validating(object sender, CancelEventArgs e)
        {
            string maloaihang = cB_MaLoaiHang.Text.ToUpper();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "Check_MaLoaiHang ";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maloaihang", maloaihang);

                    connection.Open();
                    var a = sqlCommand.ExecuteScalar();
                    connection.Close();

                    if (a != null)
                    {
                        e.Cancel = false;
                        errorProvider.SetError(cB_MaLoaiHang, null);
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(cB_MaLoaiHang, "ma loai hang khong dung dinh dang!");
                    }
                }
            }
        }
        //private void cB_MaLoaiHang_Validated(object sender, EventArgs e)
        //{
        //    errorProvider.SetError(cB_MaLoaiHang, "Mã loại hàng sai định dạng");
        //}

        private void cB_MaNCC_Validating(object sender, CancelEventArgs e)
        {
            string maNCC = cB_MaNCC.Text.ToUpper();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "Check_MaNCC";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maNCC", maNCC);

                    connection.Open();
                    var a = sqlCommand.ExecuteScalar();
                    connection.Close();

                    if (a != null)
                    {
                        e.Cancel = false;
                        errorProvider.SetError(cB_MaNCC, null);
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(cB_MaNCC, "ma loai hang khong dung dinh dang!");
                    }
                }
            }
        }

        private void cB_MaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cB_MaLoaiHang.SelectedIndex;
            string maloaihang = dt_combobox.Rows[index]["sMaLoaiHang"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string procTenLoaiHang = "Select_sTenLoaiHang";
                    command.CommandText = procTenLoaiHang;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maloaihang", maloaihang);

                    connection.Open();
                    var a = command.ExecuteScalar();
                    connection.Close();

                    tB_TenLoaiHang.Text = a.ToString();
                }
            }
        }

        private void LoadDataToGridView_LoaiHang(string filter = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblLoaiHang";
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_gridView = new DataTable())
                            {
                                dt_gridView.Clear();
                                adapter.Fill(dt_gridView);
                                if (dt_gridView.Rows.Count > 0)
                                {
                                    dataview_gridViewLoaiHang = dt_gridView.DefaultView;
                                    //dataGridView_DSSV.AutoGenerateColumns = false;
                                    //dataGridView_DSSV.DataSource = dt_gridView;

                                    //Lọc data từ dataView
                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridViewLoaiHang.RowFilter = filter;
                                    }

                                    dtGV_LoaiHang.DataSource = dataview_gridViewLoaiHang;
                                }
                                else
                                {
                                    MessageBox.Show("Khong ton tai du lieu!");
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

        private void LoadDataToGridView_MatHang(string filter = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblMatHang";
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_gridView = new DataTable())
                            {
                                dt_gridView.Clear();
                                adapter.Fill(dt_gridView);
                                if (dt_gridView.Rows.Count > 0)
                                {
                                    dataview_gridViewMatHang = dt_gridView.DefaultView;
                                    //dataGridView_DSSV.AutoGenerateColumns = false;
                                    //dataGridView_DSSV.DataSource = dt_gridView;

                                    //Lọc data từ dataView
                                    if (!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridViewMatHang.RowFilter = filter;
                                    }

                                    dtGV_MatHang.DataSource = dataview_gridViewMatHang;
                                }
                                else
                                {
                                    MessageBox.Show("Khong ton tai du lieu!");
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

        private void dtGV_LoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_LoaiHang.CurrentRow.Index;
            cB_MaLoaiHang.Text = dataview_gridViewLoaiHang[index]["sMaLoaiHang"].ToString();
            cB_MaLoaiHang.Enabled = false;
            tB_TenLoaiHang.Text = dataview_gridViewLoaiHang[index]["sTenLoaiHang"].ToString();
        }

        private void dtGV_MatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_MatHang.CurrentRow.Index;
            tB_MaHang.Text = dataview_gridViewMatHang[index]["sMaHang"].ToString();           
            tB_TenHang.Text = dataview_gridViewMatHang[index]["sTenHang"].ToString();
            tB_GiaHang.Text = dataview_gridViewMatHang[index]["fGiaHang"].ToString();
            tB_SoLuong.Text = dataview_gridViewMatHang[index]["fSoLuong"].ToString();
            cB_MaNCC.Text = dataview_gridViewMatHang[index]["iMaNCC"].ToString();
            cB_MaLoaiHang.Text = dataview_gridViewMatHang[index]["sMaLoaiHang"].ToString();
            cB_MaLoaiHang.Enabled = false;
            cB_MaNCC.Enabled = false;
            tB_MaHang.ReadOnly = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cB_MaLoaiHang.Text = tB_TenLoaiHang.Text = cB_MaNCC.Text = tB_MaHang.Text = tB_TenHang.Text = tB_GiaHang.Text = tB_SoLuong.Text = string.Empty;
            cB_MaLoaiHang.Enabled = true;
            cB_MaNCC.Enabled = true;
            tB_MaHang.ReadOnly = false;
            cB_MaLoaiHang.Focus();
        }

        private void btn_XoaLoaiHang_Click(object sender, EventArgs e)
        {
            int index = dtGV_LoaiHang.CurrentRow.Index;
            string maloaihang = dataview_gridViewLoaiHang[index]["sMaLoaiHang"].ToString();
            try
            {
                DialogResult dialog_delete =
                    MessageBox.Show("Co muon xoa Ma Loai Hang " + maloaihang + " that khong", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog_delete == DialogResult.Yes)
                {
                    KiemTraRangBuocLoaiHang(maloaihang);

                    //khai bao connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblLoaiHang";
                            command.CommandType = CommandType.StoredProcedure;
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_DeleteLoaiHang = new DataTable("tblLoaiHang"))
                                {
                                    adapter.Fill(dt_DeleteLoaiHang);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_DeleteLoaiHang);
                                        dt_DeleteLoaiHang.PrimaryKey = new DataColumn[]
                                        {
                                            dt_DeleteLoaiHang.Columns["sMaLoaiHang"]
                                        };
                                        DataRow row = dt_DeleteLoaiHang.Rows.Find(maloaihang);
                                        row.Delete();

                                        command.CommandText = "Delete_tblLoaiHang";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maloaihang", maloaihang);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblLoaiHang");
                                        MessageBox.Show("xoa thanh cong!");
                                        LoadDataToGridView_LoaiHang();
                                    }
                                }
                            }
                        }
                    }
                    //kkhai bao command va cac thong so command de select bang sv
                    //khai bao adapter 
                    //khai bao datatable, adapte.Fill(datatable) va dataset va add từng datatable vao dataset
                    //tim khoa chinh can xoa
                    //DataTable dt = new DataTable();
                    //dt.PrimaryKey = new DataColumn[] { dt.Columns["sMaSV"] };
                    //DataRow row = dt.Rows.Find(msv);
                    //or DataRow row = dt.Rows.Find(tB_Msv);
                    //row.Delete();
                    //thuc hien DeleteCommand va adapter.update(dataset)
                    //LoadDataToGridView();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                string errorStr = ex.Message;
                if (errorStr.Contains("FK_tblMatHa"))
                {
                    MessageBox.Show("ràng buộc không xoá được!");
                }
                else
                {
                    MessageBox.Show("da co loi xay ra! " + ex);
                }
            }
        }

        private void KiemTraRangBuocLoaiHang(string maloaihang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocLoaiHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@maloaihang", maloaihang);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();
                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã loại hàng " + maloaihang + " có phát sinh mặt hàng không xoá được!");
                    }
                }
            }
        }

        private void KiemTraRangBuocMatHang_Nhap(string mahang)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocMatHang_Nhap";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mahang", mahang);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();
                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã hàng " + mahang + " có phát sinh nhập hàng không xoá được!");
                    }
                }
            }
        }

        private void KiemTraRangBuocMatHang_Xuat(string mahang)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocMatHang_Xuat";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mahang", mahang);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();
                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã hàng " + mahang + " có phát sinh xuất hàng không xoá được!");
                    }
                }
            }
        }

        private void btn_XoaMatHang_Click(object sender, EventArgs e)
        {
            int index = dtGV_MatHang.CurrentRow.Index;
            string mahang = dataview_gridViewMatHang[index]["sMaHang"].ToString();
            try
            {
                DialogResult dialog_delete =
                    MessageBox.Show("Co muon xoa Ma Loai Hang " + mahang + " that khong", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog_delete == DialogResult.Yes)
                {
                    KiemTraRangBuocMatHang_Nhap(mahang);
                    KiemTraRangBuocMatHang_Xuat(mahang);

                    //khai bao connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblMatHang";
                            command.CommandType = CommandType.StoredProcedure;
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dt_DeleteMatHang = new DataTable("tblMatHang"))
                                {
                                    adapter.Fill(dt_DeleteMatHang);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_DeleteMatHang);
                                        dt_DeleteMatHang.PrimaryKey = new DataColumn[]
                                        {
                                            dt_DeleteMatHang.Columns["sMaHang"]
                                        };
                                        DataRow row = dt_DeleteMatHang.Rows.Find(mahang);
                                        row.Delete();

                                        command.CommandText = "Delete_tblMatHang";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@mahang", mahang);

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblMatHang");
                                        MessageBox.Show("xoa thanh cong!");
                                        LoadDataToGridView_MatHang();
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
            string filter = "sMaLoaiHang IS NOT NULL";
            if (!string.IsNullOrEmpty(cB_MaLoaiHang.Text))
            {
                filter += string.Format(" AND sMaLoaiHang LIKE '%{0}%'", cB_MaLoaiHang.Text);
            }
            if (!string.IsNullOrEmpty(tB_TenLoaiHang.Text))
            {
                filter += string.Format(" AND sTenLoaiHang LIKE '%{0}%'", tB_TenLoaiHang.Text);
            }
            LoadDataToGridView_LoaiHang(filter);

            string filter2 = "sMaHang IS NOT NULL";
            if (!string.IsNullOrEmpty(tB_MaHang.Text))
            {
                filter2 += string.Format(" AND sMaHang LIKE '%{0}%'", tB_MaHang.Text);
            }
            if (!string.IsNullOrEmpty(cB_MaLoaiHang.Text))
            {
                filter2 += string.Format(" AND sMaLoaiHang LIKE '%{0}%'", cB_MaLoaiHang.Text);
            }

            LoadDataToGridView_MatHang(filter2);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
