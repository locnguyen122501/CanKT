﻿namespace CanKT
{
    partial class FrmCan
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
            this.dgvCan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbTenXeXuc = new System.Windows.Forms.TextBox();
            this.lblXeXuc = new System.Windows.Forms.Label();
            this.txbMaXeXuc = new System.Windows.Forms.TextBox();
            this.txbTenMayXay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaMayXay = new System.Windows.Forms.TextBox();
            this.txbTenKho = new System.Windows.Forms.TextBox();
            this.lblKho = new System.Windows.Forms.Label();
            this.txbMaKho = new System.Windows.Forms.TextBox();
            this.lblSalan = new System.Windows.Forms.Label();
            this.txbSalan = new System.Windows.Forms.TextBox();
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.txbThanhToan = new System.Windows.Forms.TextBox();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.txbTienHang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoLuongM3 = new System.Windows.Forms.Label();
            this.txbSoLuongM3 = new System.Windows.Forms.TextBox();
            this.txbSoLuongTan = new System.Windows.Forms.TextBox();
            this.lblSoLuongTan = new System.Windows.Forms.Label();
            this.txbDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txbTenSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txbMaSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txbLenhXuat = new System.Windows.Forms.TextBox();
            this.txbTenKH = new System.Windows.Forms.TextBox();
            this.txbMaKH = new System.Windows.Forms.TextBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txbTLXeVao = new System.Windows.Forms.TextBox();
            this.lblTLXeRa = new System.Windows.Forms.Label();
            this.txbTLXeRa = new System.Windows.Forms.TextBox();
            this.lblTLXeVao = new System.Windows.Forms.Label();
            this.txbSoXe = new System.Windows.Forms.TextBox();
            this.lblSoXe = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCan
            // 
            this.dgvCan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvCan.Location = new System.Drawing.Point(0, 408);
            this.dgvCan.Name = "dgvCan";
            this.dgvCan.Size = new System.Drawing.Size(1232, 177);
            this.dgvCan.TabIndex = 0;
            this.dgvCan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCan_CellClick);
            this.dgvCan.SelectionChanged += new System.EventHandler(this.dgvCan_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Mã đơn";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Số xe";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Mã KH";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "SL vào";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "SL ra";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Mã SP";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Đơn giá";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "SL (Tấn)";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "SL (M³)";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "Thanh toán";
            this.Column10.Name = "Column10";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.txbTenXeXuc);
            this.groupBox1.Controls.Add(this.lblXeXuc);
            this.groupBox1.Controls.Add(this.txbMaXeXuc);
            this.groupBox1.Controls.Add(this.txbTenMayXay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbMaMayXay);
            this.groupBox1.Controls.Add(this.txbTenKho);
            this.groupBox1.Controls.Add(this.lblKho);
            this.groupBox1.Controls.Add(this.txbMaKho);
            this.groupBox1.Controls.Add(this.lblSalan);
            this.groupBox1.Controls.Add(this.txbSalan);
            this.groupBox1.Controls.Add(this.lblThanhToan);
            this.groupBox1.Controls.Add(this.txbThanhToan);
            this.groupBox1.Controls.Add(this.lblTienHang);
            this.groupBox1.Controls.Add(this.txbTienHang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSoLuongM3);
            this.groupBox1.Controls.Add(this.txbSoLuongM3);
            this.groupBox1.Controls.Add(this.txbSoLuongTan);
            this.groupBox1.Controls.Add(this.lblSoLuongTan);
            this.groupBox1.Controls.Add(this.txbDonGia);
            this.groupBox1.Controls.Add(this.lblDonGia);
            this.groupBox1.Controls.Add(this.txbTenSP);
            this.groupBox1.Controls.Add(this.lblTenSP);
            this.groupBox1.Controls.Add(this.txbMaSP);
            this.groupBox1.Controls.Add(this.lblMaSP);
            this.groupBox1.Controls.Add(this.txbLenhXuat);
            this.groupBox1.Controls.Add(this.txbTenKH);
            this.groupBox1.Controls.Add(this.txbMaKH);
            this.groupBox1.Controls.Add(this.lblKhachHang);
            this.groupBox1.Controls.Add(this.txbTLXeVao);
            this.groupBox1.Controls.Add(this.lblTLXeRa);
            this.groupBox1.Controls.Add(this.txbTLXeRa);
            this.groupBox1.Controls.Add(this.lblTLXeVao);
            this.groupBox1.Controls.Add(this.txbSoXe);
            this.groupBox1.Controls.Add(this.lblSoXe);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(903, 339);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txbTenXeXuc
            // 
            this.txbTenXeXuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenXeXuc.Location = new System.Drawing.Point(579, 298);
            this.txbTenXeXuc.Name = "txbTenXeXuc";
            this.txbTenXeXuc.Size = new System.Drawing.Size(151, 31);
            this.txbTenXeXuc.TabIndex = 38;
            // 
            // lblXeXuc
            // 
            this.lblXeXuc.AutoSize = true;
            this.lblXeXuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXeXuc.Location = new System.Drawing.Point(496, 275);
            this.lblXeXuc.Name = "lblXeXuc";
            this.lblXeXuc.Size = new System.Drawing.Size(57, 20);
            this.lblXeXuc.TabIndex = 37;
            this.lblXeXuc.Text = "Xe xúc";
            // 
            // txbMaXeXuc
            // 
            this.txbMaXeXuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaXeXuc.Location = new System.Drawing.Point(500, 298);
            this.txbMaXeXuc.Name = "txbMaXeXuc";
            this.txbMaXeXuc.Size = new System.Drawing.Size(73, 31);
            this.txbMaXeXuc.TabIndex = 36;
            // 
            // txbTenMayXay
            // 
            this.txbTenMayXay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenMayXay.Location = new System.Drawing.Point(343, 298);
            this.txbTenMayXay.Name = "txbTenMayXay";
            this.txbTenMayXay.Size = new System.Drawing.Size(151, 31);
            this.txbTenMayXay.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Máy xay";
            // 
            // txbMaMayXay
            // 
            this.txbMaMayXay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaMayXay.Location = new System.Drawing.Point(264, 298);
            this.txbMaMayXay.Name = "txbMaMayXay";
            this.txbMaMayXay.Size = new System.Drawing.Size(73, 31);
            this.txbMaMayXay.TabIndex = 33;
            // 
            // txbTenKho
            // 
            this.txbTenKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenKho.Location = new System.Drawing.Point(92, 298);
            this.txbTenKho.Name = "txbTenKho";
            this.txbTenKho.Size = new System.Drawing.Size(166, 31);
            this.txbTenKho.TabIndex = 32;
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKho.Location = new System.Drawing.Point(9, 275);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(37, 20);
            this.lblKho.TabIndex = 31;
            this.lblKho.Text = "Kho";
            // 
            // txbMaKho
            // 
            this.txbMaKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaKho.Location = new System.Drawing.Point(13, 298);
            this.txbMaKho.Name = "txbMaKho";
            this.txbMaKho.Size = new System.Drawing.Size(73, 31);
            this.txbMaKho.TabIndex = 30;
            // 
            // lblSalan
            // 
            this.lblSalan.AutoSize = true;
            this.lblSalan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalan.Location = new System.Drawing.Point(734, 275);
            this.lblSalan.Name = "lblSalan";
            this.lblSalan.Size = new System.Drawing.Size(50, 20);
            this.lblSalan.TabIndex = 29;
            this.lblSalan.Text = "Salan";
            // 
            // txbSalan
            // 
            this.txbSalan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSalan.Location = new System.Drawing.Point(738, 298);
            this.txbSalan.Name = "txbSalan";
            this.txbSalan.Size = new System.Drawing.Size(153, 31);
            this.txbSalan.TabIndex = 28;
            // 
            // lblThanhToan
            // 
            this.lblThanhToan.AutoSize = true;
            this.lblThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhToan.Location = new System.Drawing.Point(609, 252);
            this.lblThanhToan.Name = "lblThanhToan";
            this.lblThanhToan.Size = new System.Drawing.Size(90, 20);
            this.lblThanhToan.TabIndex = 27;
            this.lblThanhToan.Text = "Thanh toán";
            // 
            // txbThanhToan
            // 
            this.txbThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbThanhToan.Location = new System.Drawing.Point(738, 241);
            this.txbThanhToan.Name = "txbThanhToan";
            this.txbThanhToan.Size = new System.Drawing.Size(153, 31);
            this.txbThanhToan.TabIndex = 26;
            // 
            // lblTienHang
            // 
            this.lblTienHang.AutoSize = true;
            this.lblTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienHang.Location = new System.Drawing.Point(734, 181);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(79, 20);
            this.lblTienHang.TabIndex = 25;
            this.lblTienHang.Text = "Tiền hàng";
            // 
            // txbTienHang
            // 
            this.txbTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTienHang.Location = new System.Drawing.Point(738, 204);
            this.txbTienHang.Name = "txbTienHang";
            this.txbTienHang.Size = new System.Drawing.Size(153, 31);
            this.txbTienHang.TabIndex = 24;
            this.txbTienHang.TextChanged += new System.EventHandler(this.txbTienHang_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Lệnh xuất";
            // 
            // lblSoLuongM3
            // 
            this.lblSoLuongM3.AutoSize = true;
            this.lblSoLuongM3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongM3.Location = new System.Drawing.Point(580, 158);
            this.lblSoLuongM3.Name = "lblSoLuongM3";
            this.lblSoLuongM3.Size = new System.Drawing.Size(27, 20);
            this.lblSoLuongM3.TabIndex = 20;
            this.lblSoLuongM3.Text = "M³";
            // 
            // txbSoLuongM3
            // 
            this.txbSoLuongM3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoLuongM3.Location = new System.Drawing.Point(613, 147);
            this.txbSoLuongM3.Name = "txbSoLuongM3";
            this.txbSoLuongM3.Size = new System.Drawing.Size(119, 31);
            this.txbSoLuongM3.TabIndex = 19;
            this.txbSoLuongM3.TextChanged += new System.EventHandler(this.txbSoLuongM3_TextChanged);
            // 
            // txbSoLuongTan
            // 
            this.txbSoLuongTan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoLuongTan.Location = new System.Drawing.Point(613, 204);
            this.txbSoLuongTan.Name = "txbSoLuongTan";
            this.txbSoLuongTan.Size = new System.Drawing.Size(119, 31);
            this.txbSoLuongTan.TabIndex = 18;
            this.txbSoLuongTan.TextChanged += new System.EventHandler(this.txbSoLuongTan_TextChanged);
            // 
            // lblSoLuongTan
            // 
            this.lblSoLuongTan.AutoSize = true;
            this.lblSoLuongTan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongTan.Location = new System.Drawing.Point(609, 181);
            this.lblSoLuongTan.Name = "lblSoLuongTan";
            this.lblSoLuongTan.Size = new System.Drawing.Size(113, 20);
            this.lblSoLuongTan.TabIndex = 17;
            this.lblSoLuongTan.Text = "Số lượng (Tấn)";
            // 
            // txbDonGia
            // 
            this.txbDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDonGia.Location = new System.Drawing.Point(488, 204);
            this.txbDonGia.Name = "txbDonGia";
            this.txbDonGia.Size = new System.Drawing.Size(119, 31);
            this.txbDonGia.TabIndex = 16;
            this.txbDonGia.TextChanged += new System.EventHandler(this.txbDonGia_TextChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(484, 181);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(64, 20);
            this.lblDonGia.TabIndex = 15;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // txbTenSP
            // 
            this.txbTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenSP.Location = new System.Drawing.Point(266, 204);
            this.txbTenSP.Name = "txbTenSP";
            this.txbTenSP.Size = new System.Drawing.Size(216, 31);
            this.txbTenSP.TabIndex = 14;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(262, 181);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(61, 20);
            this.lblTenSP.TabIndex = 13;
            this.lblTenSP.Text = "Tên SP";
            // 
            // txbMaSP
            // 
            this.txbMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaSP.Location = new System.Drawing.Point(109, 204);
            this.txbMaSP.Name = "txbMaSP";
            this.txbMaSP.Size = new System.Drawing.Size(151, 31);
            this.txbMaSP.TabIndex = 12;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSP.Location = new System.Drawing.Point(105, 181);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(56, 20);
            this.lblMaSP.TabIndex = 11;
            this.lblMaSP.Text = "Mã SP";
            // 
            // txbLenhXuat
            // 
            this.txbLenhXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLenhXuat.Location = new System.Drawing.Point(13, 204);
            this.txbLenhXuat.Name = "txbLenhXuat";
            this.txbLenhXuat.Size = new System.Drawing.Size(90, 31);
            this.txbLenhXuat.TabIndex = 10;
            // 
            // txbTenKH
            // 
            this.txbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenKH.Location = new System.Drawing.Point(266, 147);
            this.txbTenKH.Name = "txbTenKH";
            this.txbTenKH.Size = new System.Drawing.Size(285, 31);
            this.txbTenKH.TabIndex = 8;
            // 
            // txbMaKH
            // 
            this.txbMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaKH.Location = new System.Drawing.Point(157, 147);
            this.txbMaKH.Name = "txbMaKH";
            this.txbMaKH.Size = new System.Drawing.Size(103, 31);
            this.txbMaKH.TabIndex = 7;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachHang.Location = new System.Drawing.Point(9, 158);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(94, 20);
            this.lblKhachHang.TabIndex = 6;
            this.lblKhachHang.Text = "Khách hàng";
            // 
            // txbTLXeVao
            // 
            this.txbTLXeVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTLXeVao.Location = new System.Drawing.Point(157, 110);
            this.txbTLXeVao.Name = "txbTLXeVao";
            this.txbTLXeVao.Size = new System.Drawing.Size(180, 31);
            this.txbTLXeVao.TabIndex = 5;
            this.txbTLXeVao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTLXeRa_KeyDown);
            // 
            // lblTLXeRa
            // 
            this.lblTLXeRa.AutoSize = true;
            this.lblTLXeRa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTLXeRa.Location = new System.Drawing.Point(476, 121);
            this.lblTLXeRa.Name = "lblTLXeRa";
            this.lblTLXeRa.Size = new System.Drawing.Size(131, 20);
            this.lblTLXeRa.TabIndex = 4;
            this.lblTLXeRa.Text = "Trọng lượng xe ra";
            // 
            // txbTLXeRa
            // 
            this.txbTLXeRa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTLXeRa.Location = new System.Drawing.Point(613, 110);
            this.txbTLXeRa.Name = "txbTLXeRa";
            this.txbTLXeRa.Size = new System.Drawing.Size(180, 31);
            this.txbTLXeRa.TabIndex = 3;
            this.txbTLXeRa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTLXeVao_KeyDown);
            // 
            // lblTLXeVao
            // 
            this.lblTLXeVao.AutoSize = true;
            this.lblTLXeVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTLXeVao.Location = new System.Drawing.Point(9, 121);
            this.lblTLXeVao.Name = "lblTLXeVao";
            this.lblTLXeVao.Size = new System.Drawing.Size(142, 20);
            this.lblTLXeVao.TabIndex = 2;
            this.lblTLXeVao.Text = "Trọng lượng xe vào";
            // 
            // txbSoXe
            // 
            this.txbSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoXe.Location = new System.Drawing.Point(157, 73);
            this.txbSoXe.Name = "txbSoXe";
            this.txbSoXe.Size = new System.Drawing.Size(241, 31);
            this.txbSoXe.TabIndex = 1;
            this.txbSoXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSoXe_KeyDown);
            // 
            // lblSoXe
            // 
            this.lblSoXe.AutoSize = true;
            this.lblSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoXe.Location = new System.Drawing.Point(9, 84);
            this.lblSoXe.Name = "lblSoXe";
            this.lblSoXe.Size = new System.Drawing.Size(49, 20);
            this.lblSoXe.TabIndex = 0;
            this.lblSoXe.Text = "Số xe";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(903, 41);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::CanKT.Properties.Resources.camera_pic;
            this.pictureBox1.Location = new System.Drawing.Point(922, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FrmCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1232, 585);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCan";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbSoXe;
        private System.Windows.Forms.Label lblSoXe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTLXeVao;
        private System.Windows.Forms.TextBox txbTLXeRa;
        private System.Windows.Forms.TextBox txbTLXeVao;
        private System.Windows.Forms.Label lblTLXeRa;
        private System.Windows.Forms.TextBox txbMaSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txbLenhXuat;
        private System.Windows.Forms.TextBox txbTenKH;
        private System.Windows.Forms.TextBox txbMaKH;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.TextBox txbTenSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txbDonGia;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblSoLuongM3;
        private System.Windows.Forms.TextBox txbSoLuongM3;
        private System.Windows.Forms.TextBox txbSoLuongTan;
        private System.Windows.Forms.Label lblSoLuongTan;
        private System.Windows.Forms.Label lblThanhToan;
        private System.Windows.Forms.TextBox txbThanhToan;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.TextBox txbTienHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTenXeXuc;
        private System.Windows.Forms.Label lblXeXuc;
        private System.Windows.Forms.TextBox txbMaXeXuc;
        private System.Windows.Forms.TextBox txbTenMayXay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMaMayXay;
        private System.Windows.Forms.TextBox txbTenKho;
        private System.Windows.Forms.Label lblKho;
        private System.Windows.Forms.TextBox txbMaKho;
        private System.Windows.Forms.Label lblSalan;
        private System.Windows.Forms.TextBox txbSalan;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}