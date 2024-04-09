namespace CanKT
{
    partial class frmDangNhap
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
            this.checkboxHienthi = new System.Windows.Forms.CheckBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.txbMatkhau = new System.Windows.Forms.TextBox();
            this.lbMatkhau = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkboxHienthi
            // 
            this.checkboxHienthi.AutoSize = true;
            this.checkboxHienthi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkboxHienthi.Location = new System.Drawing.Point(130, 194);
            this.checkboxHienthi.Name = "checkboxHienthi";
            this.checkboxHienthi.Size = new System.Drawing.Size(109, 17);
            this.checkboxHienthi.TabIndex = 20;
            this.checkboxHienthi.Text = "Hiển thị mật khẩu";
            this.checkboxHienthi.UseVisualStyleBackColor = true;
            this.checkboxHienthi.CheckedChanged += new System.EventHandler(this.checkboxHienthi_CheckedChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnThoat.Location = new System.Drawing.Point(211, 217);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 19;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDangnhap.Location = new System.Drawing.Point(130, 217);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangnhap.TabIndex = 18;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // txbMatkhau
            // 
            this.txbMatkhau.Location = new System.Drawing.Point(130, 168);
            this.txbMatkhau.Name = "txbMatkhau";
            this.txbMatkhau.PasswordChar = '*';
            this.txbMatkhau.Size = new System.Drawing.Size(156, 20);
            this.txbMatkhau.TabIndex = 17;
            // 
            // lbMatkhau
            // 
            this.lbMatkhau.AutoSize = true;
            this.lbMatkhau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMatkhau.Location = new System.Drawing.Point(43, 175);
            this.lbMatkhau.Name = "lbMatkhau";
            this.lbMatkhau.Size = new System.Drawing.Size(52, 13);
            this.lbMatkhau.TabIndex = 16;
            this.lbMatkhau.Text = "Mật khẩu";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTen.Location = new System.Drawing.Point(43, 142);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(26, 13);
            this.lbTen.TabIndex = 15;
            this.lbTen.Text = "Tên";
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(130, 135);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(156, 20);
            this.txbTen.TabIndex = 14;
            this.txbTen.Enter += new System.EventHandler(this.txbTen_Enter);
            this.txbTen.Leave += new System.EventHandler(this.txbTen_Leave);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(359, 360);
            this.Controls.Add(this.checkboxHienthi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.txbMatkhau);
            this.Controls.Add(this.lbMatkhau);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.txbTen);
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxHienthi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.TextBox txbMatkhau;
        private System.Windows.Forms.Label lbMatkhau;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.TextBox txbTen;
    }
}

