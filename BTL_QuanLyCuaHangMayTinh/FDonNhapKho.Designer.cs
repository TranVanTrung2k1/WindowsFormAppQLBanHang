namespace BTL_QuanLyCuaHangMayTinh
{
    partial class FDonNhapKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtGV_DonNhapKho = new System.Windows.Forms.DataGridView();
            this.iSoNk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMahang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNgayNhapKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cB_MaHang = new System.Windows.Forms.ComboBox();
            this.btn_XoaChiTietDonNhap = new System.Windows.Forms.Button();
            this.btn_UpdateChiTietDonNhap = new System.Windows.Forms.Button();
            this.btn_ThemChiTietDonNhap = new System.Windows.Forms.Button();
            this.tB_SoLuong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tB_GiaNhap = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_ThemDonNhap = new System.Windows.Forms.Button();
            this.btn_XoaDonNhap = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_UpdateDonNhap = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_ToDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FromDate = new System.Windows.Forms.DateTimePicker();
            this.dtGV_DSHD = new System.Windows.Forms.DataGridView();
            this.btn_HienDSHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cB_MaHoaDon = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.tB_TongSoLuong = new System.Windows.Forms.TextBox();
            this.tB_MaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_InDSHD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_DonNhapKho)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_DSHD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGV_DonNhapKho
            // 
            this.dtGV_DonNhapKho.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtGV_DonNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_DonNhapKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iSoNk,
            this.iMaNV,
            this.sMahang,
            this.fGiaNhap,
            this.fSoLuong,
            this.dNgayNhapKho});
            this.dtGV_DonNhapKho.Location = new System.Drawing.Point(9, 66);
            this.dtGV_DonNhapKho.Name = "dtGV_DonNhapKho";
            this.dtGV_DonNhapKho.RowHeadersWidth = 51;
            this.dtGV_DonNhapKho.RowTemplate.Height = 24;
            this.dtGV_DonNhapKho.Size = new System.Drawing.Size(856, 230);
            this.dtGV_DonNhapKho.TabIndex = 50;
            this.dtGV_DonNhapKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGV_DonNhapKho_CellClick);
            // 
            // iSoNk
            // 
            this.iSoNk.DataPropertyName = "iSoNK";
            this.iSoNk.HeaderText = "Số NK";
            this.iSoNk.MinimumWidth = 6;
            this.iSoNk.Name = "iSoNk";
            this.iSoNk.Width = 125;
            // 
            // iMaNV
            // 
            this.iMaNV.DataPropertyName = "iMaNV";
            this.iMaNV.HeaderText = "Mã NV";
            this.iMaNV.MinimumWidth = 6;
            this.iMaNV.Name = "iMaNV";
            this.iMaNV.Width = 125;
            // 
            // sMahang
            // 
            this.sMahang.DataPropertyName = "sMaHang";
            this.sMahang.HeaderText = "Mã Hàng";
            this.sMahang.MinimumWidth = 6;
            this.sMahang.Name = "sMahang";
            this.sMahang.Width = 125;
            // 
            // fGiaNhap
            // 
            this.fGiaNhap.DataPropertyName = "fGiaNhap";
            this.fGiaNhap.HeaderText = "Đơn Giá";
            this.fGiaNhap.MinimumWidth = 6;
            this.fGiaNhap.Name = "fGiaNhap";
            this.fGiaNhap.Width = 125;
            // 
            // fSoLuong
            // 
            this.fSoLuong.DataPropertyName = "fSoLuongNhap";
            this.fSoLuong.HeaderText = "Số lượng ";
            this.fSoLuong.MinimumWidth = 6;
            this.fSoLuong.Name = "fSoLuong";
            this.fSoLuong.Width = 125;
            // 
            // dNgayNhapKho
            // 
            this.dNgayNhapKho.DataPropertyName = "dNgayNhapHang";
            this.dNgayNhapKho.HeaderText = "Ngày Nhập";
            this.dNgayNhapKho.MinimumWidth = 6;
            this.dNgayNhapKho.Name = "dNgayNhapKho";
            this.dNgayNhapKho.Width = 125;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cB_MaHang);
            this.groupBox3.Controls.Add(this.dtGV_DonNhapKho);
            this.groupBox3.Controls.Add(this.btn_XoaChiTietDonNhap);
            this.groupBox3.Controls.Add(this.btn_UpdateChiTietDonNhap);
            this.groupBox3.Controls.Add(this.btn_ThemChiTietDonNhap);
            this.groupBox3.Controls.Add(this.tB_SoLuong);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tB_GiaNhap);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(403, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 302);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông Tin Chi Tiết Đơn Hàng";
            // 
            // cB_MaHang
            // 
            this.cB_MaHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB_MaHang.FormattingEnabled = true;
            this.cB_MaHang.Location = new System.Drawing.Point(105, 35);
            this.cB_MaHang.Name = "cB_MaHang";
            this.cB_MaHang.Size = new System.Drawing.Size(199, 24);
            this.cB_MaHang.TabIndex = 51;
            this.cB_MaHang.TextChanged += new System.EventHandler(this.cB_MaHang_TextChanged);
            // 
            // btn_XoaChiTietDonNhap
            // 
            this.btn_XoaChiTietDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaChiTietDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_XoaChiTietDonNhap.Location = new System.Drawing.Point(889, 197);
            this.btn_XoaChiTietDonNhap.Name = "btn_XoaChiTietDonNhap";
            this.btn_XoaChiTietDonNhap.Size = new System.Drawing.Size(109, 23);
            this.btn_XoaChiTietDonNhap.TabIndex = 49;
            this.btn_XoaChiTietDonNhap.Text = "Xoá";
            this.btn_XoaChiTietDonNhap.UseVisualStyleBackColor = true;
            this.btn_XoaChiTietDonNhap.Click += new System.EventHandler(this.btn_XoaChiTietDonNhap_Click);
            // 
            // btn_UpdateChiTietDonNhap
            // 
            this.btn_UpdateChiTietDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateChiTietDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_UpdateChiTietDonNhap.Location = new System.Drawing.Point(889, 149);
            this.btn_UpdateChiTietDonNhap.Name = "btn_UpdateChiTietDonNhap";
            this.btn_UpdateChiTietDonNhap.Size = new System.Drawing.Size(109, 23);
            this.btn_UpdateChiTietDonNhap.TabIndex = 48;
            this.btn_UpdateChiTietDonNhap.Text = "Cập Nhật";
            this.btn_UpdateChiTietDonNhap.UseVisualStyleBackColor = true;
            this.btn_UpdateChiTietDonNhap.Click += new System.EventHandler(this.btn_UpdateChiTietDonNhap_Click);
            // 
            // btn_ThemChiTietDonNhap
            // 
            this.btn_ThemChiTietDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemChiTietDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_ThemChiTietDonNhap.Location = new System.Drawing.Point(889, 101);
            this.btn_ThemChiTietDonNhap.Name = "btn_ThemChiTietDonNhap";
            this.btn_ThemChiTietDonNhap.Size = new System.Drawing.Size(109, 23);
            this.btn_ThemChiTietDonNhap.TabIndex = 47;
            this.btn_ThemChiTietDonNhap.Text = "Thêm";
            this.btn_ThemChiTietDonNhap.UseVisualStyleBackColor = true;
            this.btn_ThemChiTietDonNhap.Click += new System.EventHandler(this.btn_ThemChiTietDonNhap_Click);
            // 
            // tB_SoLuong
            // 
            this.tB_SoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_SoLuong.Location = new System.Drawing.Point(717, 35);
            this.tB_SoLuong.Name = "tB_SoLuong";
            this.tB_SoLuong.Size = new System.Drawing.Size(148, 22);
            this.tB_SoLuong.TabIndex = 42;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label13.Location = new System.Drawing.Point(645, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 41;
            this.label13.Text = "Số lượng :";
            // 
            // tB_GiaNhap
            // 
            this.tB_GiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_GiaNhap.Location = new System.Drawing.Point(428, 35);
            this.tB_GiaNhap.Name = "tB_GiaNhap";
            this.tB_GiaNhap.Size = new System.Drawing.Size(160, 22);
            this.tB_GiaNhap.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label10.Location = new System.Drawing.Point(338, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "Giá nhập :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label11.Location = new System.Drawing.Point(8, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mã hàng hoá :";
            // 
            // btn_ThemDonNhap
            // 
            this.btn_ThemDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_ThemDonNhap.Location = new System.Drawing.Point(889, 29);
            this.btn_ThemDonNhap.Name = "btn_ThemDonNhap";
            this.btn_ThemDonNhap.Size = new System.Drawing.Size(109, 23);
            this.btn_ThemDonNhap.TabIndex = 44;
            this.btn_ThemDonNhap.Text = "Thêm";
            this.btn_ThemDonNhap.UseVisualStyleBackColor = true;
            this.btn_ThemDonNhap.Click += new System.EventHandler(this.btn_ThemDonNhap_Click);
            // 
            // btn_XoaDonNhap
            // 
            this.btn_XoaDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_XoaDonNhap.Location = new System.Drawing.Point(889, 125);
            this.btn_XoaDonNhap.Name = "btn_XoaDonNhap";
            this.btn_XoaDonNhap.Size = new System.Drawing.Size(109, 23);
            this.btn_XoaDonNhap.TabIndex = 46;
            this.btn_XoaDonNhap.Text = "Xoá";
            this.btn_XoaDonNhap.UseVisualStyleBackColor = true;
            this.btn_XoaDonNhap.Click += new System.EventHandler(this.btn_XoaDonNhap_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(1292, 548);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(109, 23);
            this.btn_Exit.TabIndex = 75;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_UpdateDonNhap
            // 
            this.btn_UpdateDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_UpdateDonNhap.Location = new System.Drawing.Point(889, 77);
            this.btn_UpdateDonNhap.Name = "btn_UpdateDonNhap";
            this.btn_UpdateDonNhap.Size = new System.Drawing.Size(109, 23);
            this.btn_UpdateDonNhap.TabIndex = 45;
            this.btn_UpdateDonNhap.Text = "Cập Nhật";
            this.btn_UpdateDonNhap.UseVisualStyleBackColor = true;
            this.btn_UpdateDonNhap.Click += new System.EventHandler(this.btn_UpdateDonNhap_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(1028, 548);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(109, 23);
            this.btn_Search.TabIndex = 73;
            this.btn_Search.Text = "Tìm Kiếm";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dateTimePicker_ToDate);
            this.groupBox2.Controls.Add(this.dateTimePicker_FromDate);
            this.groupBox2.Controls.Add(this.dtGV_DSHD);
            this.groupBox2.Controls.Add(this.btn_HienDSHD);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(7, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 473);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Đơn Hàng";
            // 
            // dateTimePicker_ToDate
            // 
            this.dateTimePicker_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_ToDate.Location = new System.Drawing.Point(99, 75);
            this.dateTimePicker_ToDate.Name = "dateTimePicker_ToDate";
            this.dateTimePicker_ToDate.Size = new System.Drawing.Size(284, 22);
            this.dateTimePicker_ToDate.TabIndex = 33;
            // 
            // dateTimePicker_FromDate
            // 
            this.dateTimePicker_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_FromDate.Location = new System.Drawing.Point(99, 36);
            this.dateTimePicker_FromDate.Name = "dateTimePicker_FromDate";
            this.dateTimePicker_FromDate.Size = new System.Drawing.Size(284, 22);
            this.dateTimePicker_FromDate.TabIndex = 32;
            // 
            // dtGV_DSHD
            // 
            this.dtGV_DSHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGV_DSHD.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtGV_DSHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_DSHD.Location = new System.Drawing.Point(6, 158);
            this.dtGV_DSHD.Name = "dtGV_DSHD";
            this.dtGV_DSHD.RowHeadersWidth = 51;
            this.dtGV_DSHD.RowTemplate.Height = 24;
            this.dtGV_DSHD.Size = new System.Drawing.Size(377, 309);
            this.dtGV_DSHD.TabIndex = 31;
            this.dtGV_DSHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGV_DSHD_CellClick);
            // 
            // btn_HienDSHD
            // 
            this.btn_HienDSHD.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_HienDSHD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_HienDSHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HienDSHD.ForeColor = System.Drawing.Color.Black;
            this.btn_HienDSHD.Location = new System.Drawing.Point(10, 114);
            this.btn_HienDSHD.Name = "btn_HienDSHD";
            this.btn_HienDSHD.Size = new System.Drawing.Size(373, 38);
            this.btn_HienDSHD.TabIndex = 28;
            this.btn_HienDSHD.Text = "Lấy Danh Sách Đơn Hàng";
            this.btn_HienDSHD.UseVisualStyleBackColor = false;
            this.btn_HienDSHD.Click += new System.EventHandler(this.btn_HienDSHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "From Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "To Date : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(622, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 38);
            this.label6.TabIndex = 69;
            this.label6.Text = "Đơn Nhập Kho";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cB_MaHoaDon);
            this.groupBox1.Controls.Add(this.btn_XoaDonNhap);
            this.groupBox1.Controls.Add(this.btn_UpdateDonNhap);
            this.groupBox1.Controls.Add(this.btn_ThemDonNhap);
            this.groupBox1.Controls.Add(this.dateTimePicker_NgayNhap);
            this.groupBox1.Controls.Add(this.tB_TongSoLuong);
            this.groupBox1.Controls.Add(this.tB_MaNV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox1.Location = new System.Drawing.Point(403, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 165);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn Nhập Hàng";
            // 
            // cB_MaHoaDon
            // 
            this.cB_MaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB_MaHoaDon.FormattingEnabled = true;
            this.cB_MaHoaDon.Location = new System.Drawing.Point(117, 47);
            this.cB_MaHoaDon.Name = "cB_MaHoaDon";
            this.cB_MaHoaDon.Size = new System.Drawing.Size(244, 24);
            this.cB_MaHoaDon.TabIndex = 47;
            this.cB_MaHoaDon.SelectedIndexChanged += new System.EventHandler(this.cB_MaHoaDon_SelectedIndexChanged);
            this.cB_MaHoaDon.TextChanged += new System.EventHandler(this.cB_MaHoaDon_TextChanged);
            // 
            // dateTimePicker_NgayNhap
            // 
            this.dateTimePicker_NgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_NgayNhap.Location = new System.Drawing.Point(615, 111);
            this.dateTimePicker_NgayNhap.Name = "dateTimePicker_NgayNhap";
            this.dateTimePicker_NgayNhap.Size = new System.Drawing.Size(253, 22);
            this.dateTimePicker_NgayNhap.TabIndex = 41;
            // 
            // tB_TongSoLuong
            // 
            this.tB_TongSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_TongSoLuong.Location = new System.Drawing.Point(615, 52);
            this.tB_TongSoLuong.Name = "tB_TongSoLuong";
            this.tB_TongSoLuong.Size = new System.Drawing.Size(148, 22);
            this.tB_TongSoLuong.TabIndex = 39;
            // 
            // tB_MaNV
            // 
            this.tB_MaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_MaNV.Location = new System.Drawing.Point(117, 108);
            this.tB_MaNV.Name = "tB_MaNV";
            this.tB_MaNV.Size = new System.Drawing.Size(244, 22);
            this.tB_MaNV.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hoá đơn :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(7, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã nhân viên :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(471, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tổng Số  Lượng :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(476, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ngày nhập hàng :";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(1162, 548);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(109, 23);
            this.btn_Cancel.TabIndex = 74;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_InDSHD
            // 
            this.btn_InDSHD.Location = new System.Drawing.Point(901, 548);
            this.btn_InDSHD.Name = "btn_InDSHD";
            this.btn_InDSHD.Size = new System.Drawing.Size(101, 23);
            this.btn_InDSHD.TabIndex = 76;
            this.btn_InDSHD.Text = "InDSHD";
            this.btn_InDSHD.UseVisualStyleBackColor = true;
            this.btn_InDSHD.Click += new System.EventHandler(this.button1_Click);
            // 
            // FDonNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1436, 588);
            this.Controls.Add(this.btn_InDSHD);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Name = "FDonNhapKho";
            this.Text = "FDonNhapKho";
            this.Load += new System.EventHandler(this.FDonNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_DonNhapKho)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_DSHD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGV_DonNhapKho;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_XoaChiTietDonNhap;
        private System.Windows.Forms.Button btn_UpdateChiTietDonNhap;
        private System.Windows.Forms.Button btn_ThemChiTietDonNhap;
        private System.Windows.Forms.TextBox tB_SoLuong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tB_GiaNhap;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_ThemDonNhap;
        private System.Windows.Forms.Button btn_XoaDonNhap;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_UpdateDonNhap;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ToDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FromDate;
        private System.Windows.Forms.DataGridView dtGV_DSHD;
        private System.Windows.Forms.Button btn_HienDSHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayNhap;
        private System.Windows.Forms.TextBox tB_TongSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox cB_MaHang;
        private System.Windows.Forms.ComboBox cB_MaHoaDon;
        private System.Windows.Forms.TextBox tB_MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSoNk;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMahang;
        private System.Windows.Forms.DataGridViewTextBoxColumn fGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn fSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNgayNhapKho;
        private System.Windows.Forms.Button btn_InDSHD;
    }
}