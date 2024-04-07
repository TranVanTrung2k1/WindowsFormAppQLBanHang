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
    public partial class FNhaCungCap : Form
    {
        
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;
        private DataView dataview_gridViewNCC = new DataView();

        public FNhaCungCap()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ThemNCC_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_MaNCC_tblNhaCungCap";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNCC", tB_MaNCC.Text);

                    connection.Open();
                    var id = command.ExecuteScalar();
                    connection.Close();

                    if(id == null)
                    {
                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = "Select_tblNhaCungCap";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using(DataTable dt_NCC = new DataTable("tblNhaCungCap"))
                            {
                                adapter.Fill(dt_NCC);
                                using(DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dt_NCC);
                                    DataRow row = dt_NCC.NewRow();
                                    row["iMaNCC"] = tB_MaNCC.Text;
                                    row["sTenNhaCC"] = tB_TenNCC.Text;
                                    row["sTenGiaoDich"] = tB_GiaoDich.Text;
                                    row["sDiaChi"] = tB_DiaChi.Text;
                                    row["sDienThoai"] = tB_Sdt.Text;

                                    dt_NCC.Rows.Add(row);

                                    command.CommandText = "Insert_tblNhaCungCap";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNCC", tB_MaNCC.Text);
                                    command.Parameters.AddWithValue("@tenNCC", tB_TenNCC.Text);
                                    command.Parameters.AddWithValue("@tenGiaoDich", tB_GiaoDich.Text);
                                    command.Parameters.AddWithValue("@diaChi", tB_DiaChi.Text);
                                    command.Parameters.AddWithValue("@sdt", tB_Sdt.Text);

                                    adapter.InsertCommand = command;
                                    adapter.Update(dataSet, "tblNhaCungCap");
                                    MessageBox.Show("Thêm mới NCC thành công!");
                                    LoadDataToGridViewNCC(); 
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà cung cấp " + tB_MaNCC + " đã tồn tại!");
                        return;
                    }
                }
            }
        }

        private void btn_UpdateNCC_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblNhaCungCap";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using(DataTable dtNCC = new DataTable("tblNhaCungCap"))
                            {
                                adapter.Fill(dtNCC);

                                using(DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(dtNCC);
                                    dtNCC.PrimaryKey = new DataColumn[] { dtNCC.Columns["iMaNCC"] };
                                    DataRow row = dtNCC.Rows.Find(tB_MaNCC.Text);
                                    row["sTenNhaCC"] = tB_TenNCC.Text;
                                    row["sTenGiaoDich"] = tB_GiaoDich.Text;
                                    row["sDiaChi"] = tB_DiaChi.Text;
                                    row["sDienThoai"] = tB_Sdt.Text;

                                    command.CommandText = "Update_tblNhaCungCap";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maNCC", tB_MaNCC.Text);
                                    command.Parameters.AddWithValue("@tenNCC", tB_TenNCC.Text);
                                    command.Parameters.AddWithValue("@tenGiaoDich", tB_GiaoDich.Text);
                                    command.Parameters.AddWithValue("@diaChi", tB_DiaChi.Text);
                                    command.Parameters.AddWithValue("@sdt", tB_Sdt.Text);

                                    adapter.UpdateCommand = command;
                                    adapter.Update(dataSet, "tblNhaCungCap");
                                    MessageBox.Show("Cập Nhật Thành Công!");
                                    LoadDataToGridViewNCC();
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            tB_MaNCC.Text = tB_TenNCC.Text = tB_GiaoDich.Text = tB_DiaChi.Text = tB_Sdt.Text = String.Empty;
            tB_MaNCC.ReadOnly = false;
            tB_MaNCC.Focus();   
        }

        private void btn_XoaNCC_Click(object sender, EventArgs e)
        {
            int index = dtGV_NCC.CurrentRow.Index;
            string maNCC = dataview_gridViewNCC[index]["iMaNCC"].ToString();
            try
            {
                DialogResult dialogDelete = MessageBox.Show("Bạn có muốn xoá NCC: " + maNCC + " thật không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);  
                if(dialogDelete == DialogResult.Yes)
                {
                    KiemTraRangBuocNCC(maNCC);

                   using(SqlConnection connection = new SqlConnection(connectionString))
                   {
                        using(SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select_tblNhaCungCap";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();

                            using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using(DataTable dt_NCC = new DataTable("tblNhaCungCap"))
                                {
                                    adapter.Fill(dt_NCC);
                                    using(DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dt_NCC);
                                        dt_NCC.PrimaryKey = new DataColumn[]
                                        {
                                            dt_NCC.Columns["iMaNCC"]
                                        };
                                        DataRow row = dt_NCC.Rows.Find(maNCC);
                                        row.Delete();

                                        command.CommandText = "Delete_tblNhaCungCap";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@maNCC", Convert.ToInt32(maNCC));

                                        adapter.DeleteCommand = command;
                                        adapter.Update(dataSet, "tblNhaCungCap");
                                        MessageBox.Show("Đã xoá thành công!");
                                        LoadDataToGridViewNCC();
                                    }
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

        private void KiemTraRangBuocNCC(string maNCC)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CheckRangBuocNCC";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maNCC", maNCC);
                    connection.Open();
                    bool exist = (command.ExecuteScalar() != null);
                    connection.Close();

                    if (exist)
                    {
                        throw new Exception("Ràng buộc mã nhà cung cấp " + maNCC + " có phát sinh mặt hàng không xoá được!");
                    }
                }
            }
        }

        private void LoadDataToGridViewNCC(string filter = "")
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblNhaCungCap";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dt_GridView = new DataTable())
                            {
                                dt_GridView.Clear();
                                adapter.Fill(dt_GridView);
                                if(dt_GridView.Rows.Count > 0)
                                {
                                    dataview_gridViewNCC = dt_GridView.DefaultView;
                                    if(!string.IsNullOrEmpty(filter))
                                    {
                                        dataview_gridViewNCC.RowFilter = filter;
                                    }
                                    dtGV_NCC.DataSource = dataview_gridViewNCC;
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
                MessageBox.Show("Đã có lỗi xảy ra! " + ex.Message);
            }
        }

        private void dtGV_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtGV_NCC.CurrentRow.Index;

            tB_MaNCC.Text = dataview_gridViewNCC[index]["iMaNCC"].ToString();
            tB_MaNCC.ReadOnly = true;
            tB_TenNCC.Text = dataview_gridViewNCC[index]["sTenNhaCC"].ToString();
            tB_GiaoDich.Text = dataview_gridViewNCC[index]["sTenGiaoDich"].ToString();
            tB_DiaChi.Text = dataview_gridViewNCC[index]["sDiaChi"].ToString();
            tB_Sdt.Text = dataview_gridViewNCC[index]["sDienThoai"].ToString();
        }

        private void FNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDataToGridViewNCC();
        }
    }
}
