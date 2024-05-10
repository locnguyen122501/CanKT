namespace CanKT
{
    partial class FrmDangKyXe
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
            this.txbSoXe = new System.Windows.Forms.TextBox();
            this.lblSoXe = new System.Windows.Forms.Label();
            this.lblTLBanThan = new System.Windows.Forms.Label();
            this.txbTLBanThan = new System.Windows.Forms.TextBox();
            this.txbTLChoPhep = new System.Windows.Forms.TextBox();
            this.lblTLChoPhep = new System.Windows.Forms.Label();
            this.dtpKetDangKiem = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.lblNgayKetDangKiem = new System.Windows.Forms.Label();
            this.cbbLoaiXe = new System.Windows.Forms.ComboBox();
            this.grbThongTinKH = new System.Windows.Forms.GroupBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.txbMaKH = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txbTenKH = new System.Windows.Forms.TextBox();
            this.grbThongTinXe = new System.Windows.Forms.GroupBox();
            this.grbThongTinKH.SuspendLayout();
            this.grbThongTinXe.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbSoXe
            // 
            this.txbSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoXe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txbSoXe.Location = new System.Drawing.Point(187, 21);
            this.txbSoXe.Name = "txbSoXe";
            this.txbSoXe.Size = new System.Drawing.Size(170, 31);
            this.txbSoXe.TabIndex = 3;
            this.txbSoXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSoXe_KeyDown);
            // 
            // lblSoXe
            // 
            this.lblSoXe.AutoSize = true;
            this.lblSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoXe.Location = new System.Drawing.Point(18, 34);
            this.lblSoXe.Name = "lblSoXe";
            this.lblSoXe.Size = new System.Drawing.Size(49, 20);
            this.lblSoXe.TabIndex = 2;
            this.lblSoXe.Text = "Số xe";
            // 
            // lblTLBanThan
            // 
            this.lblTLBanThan.AutoSize = true;
            this.lblTLBanThan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTLBanThan.Location = new System.Drawing.Point(18, 69);
            this.lblTLBanThan.Name = "lblTLBanThan";
            this.lblTLBanThan.Size = new System.Drawing.Size(160, 20);
            this.lblTLBanThan.TabIndex = 4;
            this.lblTLBanThan.Text = "Trọng lượng bản thân";
            // 
            // txbTLBanThan
            // 
            this.txbTLBanThan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTLBanThan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txbTLBanThan.Location = new System.Drawing.Point(187, 58);
            this.txbTLBanThan.Name = "txbTLBanThan";
            this.txbTLBanThan.Size = new System.Drawing.Size(170, 31);
            this.txbTLBanThan.TabIndex = 5;
            this.txbTLBanThan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTLBanThan_KeyDown);
            this.txbTLBanThan.Leave += new System.EventHandler(this.txbTLBanThan_Leave);
            // 
            // txbTLChoPhep
            // 
            this.txbTLChoPhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTLChoPhep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txbTLChoPhep.Location = new System.Drawing.Point(187, 95);
            this.txbTLChoPhep.Name = "txbTLChoPhep";
            this.txbTLChoPhep.Size = new System.Drawing.Size(170, 31);
            this.txbTLChoPhep.TabIndex = 7;
            this.txbTLChoPhep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTLChoPhep_KeyDown);
            this.txbTLChoPhep.Leave += new System.EventHandler(this.txbTLChoPhep_Leave);
            // 
            // lblTLChoPhep
            // 
            this.lblTLChoPhep.AutoSize = true;
            this.lblTLChoPhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTLChoPhep.Location = new System.Drawing.Point(18, 106);
            this.lblTLChoPhep.Name = "lblTLChoPhep";
            this.lblTLChoPhep.Size = new System.Drawing.Size(163, 20);
            this.lblTLChoPhep.TabIndex = 6;
            this.lblTLChoPhep.Text = "Trọng lượng cho phép";
            // 
            // dtpKetDangKiem
            // 
            this.dtpKetDangKiem.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKetDangKiem.CustomFormat = "dd/MM/yyyy";
            this.dtpKetDangKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKetDangKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetDangKiem.Location = new System.Drawing.Point(187, 132);
            this.dtpKetDangKiem.Name = "dtpKetDangKiem";
            this.dtpKetDangKiem.Size = new System.Drawing.Size(170, 31);
            this.dtpKetDangKiem.TabIndex = 8;
            this.dtpKetDangKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpKetDangKiem_KeyDown);
            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiXe.Location = new System.Drawing.Point(374, 34);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(59, 20);
            this.lblLoaiXe.TabIndex = 9;
            this.lblLoaiXe.Text = "Loại xe";
            // 
            // lblNgayKetDangKiem
            // 
            this.lblNgayKetDangKiem.AutoSize = true;
            this.lblNgayKetDangKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetDangKiem.Location = new System.Drawing.Point(18, 143);
            this.lblNgayKetDangKiem.Name = "lblNgayKetDangKiem";
            this.lblNgayKetDangKiem.Size = new System.Drawing.Size(148, 20);
            this.lblNgayKetDangKiem.TabIndex = 10;
            this.lblNgayKetDangKiem.Text = "Ngày kết đăng kiểm";
            // 
            // cbbLoaiXe
            // 
            this.cbbLoaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaiXe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbbLoaiXe.FormattingEnabled = true;
            this.cbbLoaiXe.Items.AddRange(new object[] {
            "Xe tải",
            "Rơ móc",
            "Đầu kéo"});
            this.cbbLoaiXe.Location = new System.Drawing.Point(439, 19);
            this.cbbLoaiXe.Name = "cbbLoaiXe";
            this.cbbLoaiXe.Size = new System.Drawing.Size(129, 33);
            this.cbbLoaiXe.TabIndex = 11;
            this.cbbLoaiXe.Enter += new System.EventHandler(this.cbbLoaiXe_Enter);
            this.cbbLoaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbLoaiXe_KeyDown);
            // 
            // grbThongTinKH
            // 
            this.grbThongTinKH.Controls.Add(this.btnXacNhan);
            this.grbThongTinKH.Controls.Add(this.txbMaKH);
            this.grbThongTinKH.Controls.Add(this.lblMaKH);
            this.grbThongTinKH.Controls.Add(this.lblTenKH);
            this.grbThongTinKH.Controls.Add(this.txbTenKH);
            this.grbThongTinKH.Location = new System.Drawing.Point(12, 197);
            this.grbThongTinKH.Name = "grbThongTinKH";
            this.grbThongTinKH.Size = new System.Drawing.Size(580, 105);
            this.grbThongTinKH.TabIndex = 12;
            this.grbThongTinKH.TabStop = false;
            this.grbThongTinKH.Text = "Thông tin khách hàng";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnXacNhan.Location = new System.Drawing.Point(439, 63);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhan.TabIndex = 10;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txbMaKH
            // 
            this.txbMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txbMaKH.Location = new System.Drawing.Point(187, 19);
            this.txbMaKH.Name = "txbMaKH";
            this.txbMaKH.Size = new System.Drawing.Size(170, 31);
            this.txbMaKH.TabIndex = 7;
            this.txbMaKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMaKH_KeyDown);
            this.txbMaKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMaKH_KeyPress);
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(18, 32);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(118, 20);
            this.lblMaKH.TabIndex = 6;
            this.lblMaKH.Text = "Mã khách hàng";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(18, 67);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(123, 20);
            this.lblTenKH.TabIndex = 8;
            this.lblTenKH.Text = "Tên khách hàng";
            // 
            // txbTenKH
            // 
            this.txbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txbTenKH.Location = new System.Drawing.Point(187, 56);
            this.txbTenKH.Name = "txbTenKH";
            this.txbTenKH.Size = new System.Drawing.Size(170, 31);
            this.txbTenKH.TabIndex = 9;
            this.txbTenKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTenKH_KeyDown);
            this.txbTenKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTenKH_KeyPress);
            // 
            // grbThongTinXe
            // 
            this.grbThongTinXe.Controls.Add(this.txbSoXe);
            this.grbThongTinXe.Controls.Add(this.lblSoXe);
            this.grbThongTinXe.Controls.Add(this.cbbLoaiXe);
            this.grbThongTinXe.Controls.Add(this.lblTLBanThan);
            this.grbThongTinXe.Controls.Add(this.lblNgayKetDangKiem);
            this.grbThongTinXe.Controls.Add(this.txbTLBanThan);
            this.grbThongTinXe.Controls.Add(this.lblLoaiXe);
            this.grbThongTinXe.Controls.Add(this.lblTLChoPhep);
            this.grbThongTinXe.Controls.Add(this.dtpKetDangKiem);
            this.grbThongTinXe.Controls.Add(this.txbTLChoPhep);
            this.grbThongTinXe.Location = new System.Drawing.Point(12, 12);
            this.grbThongTinXe.Name = "grbThongTinXe";
            this.grbThongTinXe.Size = new System.Drawing.Size(580, 179);
            this.grbThongTinXe.TabIndex = 13;
            this.grbThongTinXe.TabStop = false;
            this.grbThongTinXe.Text = "Thông tin xe";
            // 
            // FrmDangKyXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(605, 312);
            this.ControlBox = false;
            this.Controls.Add(this.grbThongTinXe);
            this.Controls.Add(this.grbThongTinKH);
            this.Name = "FrmDangKyXe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký xe";
            this.Load += new System.EventHandler(this.FrmDangKyXe_Load);
            this.grbThongTinKH.ResumeLayout(false);
            this.grbThongTinKH.PerformLayout();
            this.grbThongTinXe.ResumeLayout(false);
            this.grbThongTinXe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbSoXe;
        private System.Windows.Forms.Label lblSoXe;
        private System.Windows.Forms.Label lblTLBanThan;
        private System.Windows.Forms.TextBox txbTLBanThan;
        private System.Windows.Forms.TextBox txbTLChoPhep;
        private System.Windows.Forms.Label lblTLChoPhep;
        private System.Windows.Forms.DateTimePicker dtpKetDangKiem;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.Label lblNgayKetDangKiem;
        private System.Windows.Forms.ComboBox cbbLoaiXe;
        private System.Windows.Forms.GroupBox grbThongTinKH;
        private System.Windows.Forms.GroupBox grbThongTinXe;
        private System.Windows.Forms.TextBox txbMaKH;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txbTenKH;
        private System.Windows.Forms.Button btnXacNhan;
    }
}