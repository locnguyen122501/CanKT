namespace CanKT
{
    partial class FrmThuTu
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
            this.rdbMaPhieu = new System.Windows.Forms.RadioButton();
            this.lblSapXep = new System.Windows.Forms.Label();
            this.rdbSoXe = new System.Windows.Forms.RadioButton();
            this.rdbKhachHang = new System.Windows.Forms.RadioButton();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbMaPhieu
            // 
            this.rdbMaPhieu.AutoSize = true;
            this.rdbMaPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaPhieu.Location = new System.Drawing.Point(157, 9);
            this.rdbMaPhieu.Name = "rdbMaPhieu";
            this.rdbMaPhieu.Size = new System.Drawing.Size(119, 29);
            this.rdbMaPhieu.TabIndex = 0;
            this.rdbMaPhieu.TabStop = true;
            this.rdbMaPhieu.Text = "Mã phiếu";
            this.rdbMaPhieu.UseVisualStyleBackColor = true;
            // 
            // lblSapXep
            // 
            this.lblSapXep.AutoSize = true;
            this.lblSapXep.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSapXep.Location = new System.Drawing.Point(12, 9);
            this.lblSapXep.Name = "lblSapXep";
            this.lblSapXep.Size = new System.Drawing.Size(139, 25);
            this.lblSapXep.TabIndex = 1;
            this.lblSapXep.Text = "Sắp xếp theo";
            // 
            // rdbSoXe
            // 
            this.rdbSoXe.AutoSize = true;
            this.rdbSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSoXe.Location = new System.Drawing.Point(157, 44);
            this.rdbSoXe.Name = "rdbSoXe";
            this.rdbSoXe.Size = new System.Drawing.Size(85, 29);
            this.rdbSoXe.TabIndex = 2;
            this.rdbSoXe.TabStop = true;
            this.rdbSoXe.Text = "Số xe";
            this.rdbSoXe.UseVisualStyleBackColor = true;
            // 
            // rdbKhachHang
            // 
            this.rdbKhachHang.AutoSize = true;
            this.rdbKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKhachHang.Location = new System.Drawing.Point(157, 79);
            this.rdbKhachHang.Name = "rdbKhachHang";
            this.rdbKhachHang.Size = new System.Drawing.Size(145, 29);
            this.rdbKhachHang.TabIndex = 3;
            this.rdbKhachHang.TabStop = true;
            this.rdbKhachHang.Text = "Khách hàng";
            this.rdbKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(87, 114);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(131, 44);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // FrmThuTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(312, 172);
            this.ControlBox = false;
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.rdbKhachHang);
            this.Controls.Add(this.rdbSoXe);
            this.Controls.Add(this.lblSapXep);
            this.Controls.Add(this.rdbMaPhieu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThuTu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sắp xếp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbMaPhieu;
        private System.Windows.Forms.Label lblSapXep;
        private System.Windows.Forms.RadioButton rdbSoXe;
        private System.Windows.Forms.RadioButton rdbKhachHang;
        private System.Windows.Forms.Button btnXacNhan;
    }
}