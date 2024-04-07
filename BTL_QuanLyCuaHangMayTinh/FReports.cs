using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FReports : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyKinhDoanhMayTinh"].ConnectionString;

        public FReports()
        {
            InitializeComponent();
        }

        public void ShowReport_DonDatHang(string reportFilter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Reports_DonDatHang";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);
                                ReportDocument reportDocument = new ReportDocument();
                                //string path = string.Format("D:\\Visual Code\\BTL_QuanLyCuaHangMayTinh\\BTL_QuanLyCuaHangMayTinh\\BaoCao\\DonDatHang.rpt");
                                string path = string.Format("{0}\\BaoCao\\DonDatHang.rpt", Application.StartupPath);
                                //MessageBox.Show(Application.StartupPath); //D:\Visual Code\BTL_QuanLyCuaHangMayTinh\BTL_QuanLyCuaHangMayTinh\FReports.cs
                                reportDocument.Load(path);

                                reportDocument.Database.Tables["Reports_DonDatHang"].SetDataSource(dataTable);
                                //reportDocument.SetParameterValue("NguoiLapPhieu", "{0}" ,"{Reports_DonDatHang.sTenNV}");
                                //reportDocument.RecordSelectionFormula = "{Reports_DonDatHang.iSoHD} LIKE '*1*'";
                                if (reportFilter != null)
                                {
                                    reportDocument.RecordSelectionFormula = reportFilter;
                                }
                                crystalReportViewer1.ReportSource = reportDocument;
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

        public void ShowReport_DonNhapKho(string reportFilter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Reports_DonNhapKho";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);
                                ReportDocument reportDocument = new ReportDocument();
                                string path = string.Format("{0}\\BaoCao\\DonNhapKho1.rpt", Application.StartupPath);
                                //MessageBox.Show(Application.StartupPath); 
                                reportDocument.Load(path);

                                reportDocument.Database.Tables["Reports_DonNhapKho"].SetDataSource(dataTable);
                                if (reportFilter != null)
                                {
                                    reportDocument.RecordSelectionFormula = reportFilter;
                                }
                                crystalReportViewer1.ReportSource = reportDocument;
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

        public void ShowReport_KhachHang(string reportFilter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Select_tblKhachHang";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);
                                ReportDocument reportDocument = new ReportDocument();
                                //string path = string.Format("{0}\\BaoCao\\KhachHang.rpt", Application.StartupPath);
                                //D:\Visual Code\BTL_QuanLyCuaHangMayTinh\BTL_QuanLyCuaHangMayTinh\BaoCao\KhachHang.rpt
                                string path = string.Format("D:\\Visual Code\\BTL_QuanLyCuaHangMayTinh\\BTL_QuanLyCuaHangMayTinh\\BaoCao\\KhachHang.rpt");
                                //MessageBox.Show(Application.StartupPath); 
                                reportDocument.Load(path);

                                reportDocument.Database.Tables["Select_tblKhachHang"].SetDataSource(dataTable);
                                if (reportFilter != null)
                                {
                                    reportDocument.RecordSelectionFormula = reportFilter;
                                }
                                crystalReportViewer1.ReportSource = reportDocument;
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

        public void ShowReport_NhanVien(string reportFilter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        //FNhanVien fNhanVien = new FNhanVien();
                        command.CommandText = "Select_tblNhanVien";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        //command.Parameters.AddWithValue("@tuoi", fNhanVien.TuoiNV());
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);
                                ReportDocument reportDocument = new ReportDocument();
                                //string path = string.Format("{0}\\BaoCao\\KhachHang.rpt", Application.StartupPath);
                                //D:\Visual Code\BTL_QuanLyCuaHangMayTinh\BTL_QuanLyCuaHangMayTinh\BaoCao\KhachHang.rpt
                                string path = string.Format("D:\\Visual Code\\BTL_QuanLyCuaHangMayTinh\\BTL_QuanLyCuaHangMayTinh\\BaoCao\\BaiThi.rpt");
                                //MessageBox.Show(Application.StartupPath); 
                                reportDocument.Load(path);

                                reportDocument.Database.Tables["Select_tblNhanVien"].SetDataSource(dataTable);
                                if (reportFilter != null)
                                {
                                    reportDocument.RecordSelectionFormula = reportFilter;
                                }
                                crystalReportViewer1.ReportSource = reportDocument;
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
        //public void ShowReport_NhanVienLuongCB(string reportFilter)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand command = connection.CreateCommand())
        //            {
                        
        //                command.CommandText = "Select_tblNhanVien";
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.Clear();
                        
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //                {
        //                    using (DataTable dataTable = new DataTable())
        //                    {
        //                        adapter.Fill(dataTable);
        //                        ReportDocument reportDocument = new ReportDocument();
        //                        //string path = string.Format("{0}\\BaoCao\\KhachHang.rpt", Application.StartupPath);
        //                        //D:\Visual Code\BTL_QuanLyCuaHangMayTinh\BTL_QuanLyCuaHangMayTinh\BaoCao\KhachHang.rpt
        //                        string path = string.Format("D:\\Visual Code\\BTL_QuanLyCuaHangMayTinh\\BTL_QuanLyCuaHangMayTinh\\BaoCao\\BaiThi.rpt");
        //                        //MessageBox.Show(Application.StartupPath); 
        //                        reportDocument.Load(path);

        //                        reportDocument.Database.Tables["Select_tblNhanVien"].SetDataSource(dataTable);
        //                        if (reportFilter != null)
        //                        {
        //                            reportDocument.RecordSelectionFormula = reportFilter;
        //                        }
        //                        crystalReportViewer1.ReportSource = reportDocument;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
