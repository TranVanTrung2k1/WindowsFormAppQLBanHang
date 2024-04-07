using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLyCuaHangMayTinh
{
    public partial class FTrangChu : Form
    {
        public FTrangChu()
        {
            InitializeComponent();
        }

        private void btn_OpenFormQuanLyLoai_MatHang_Click(object sender, EventArgs e)
        {
            FLoai_MatHang fLoai_MatHang = new FLoai_MatHang();
            fLoai_MatHang.Show();
        }

        private void btn_OpenFDonDatHang_Click(object sender, EventArgs e)
        {
            FDonDatHang fdonDatHang = new FDonDatHang();
            fdonDatHang.Show();
        }

        private void btn_OpenFDonNhapHang_Click(object sender, EventArgs e)
        {
            FDonNhapKho fdonNhapKho = new FDonNhapKho();
            fdonNhapKho.Show();
        }

        private void btn_OpenFNhanVien_Click(object sender, EventArgs e)
        {
            FNhanVien fnhanVien = new FNhanVien();
            fnhanVien.Show();
        }

        private void btn_OpenFKhachHang_Click(object sender, EventArgs e)
        {
            FKhachHang fkhachHang = new FKhachHang();
            fkhachHang.Show();
        }

        private void btn_OpenFNhaCungCap_Click(object sender, EventArgs e)
        {
            FNhaCungCap fNhaCungCap = new FNhaCungCap();
            fNhaCungCap.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
