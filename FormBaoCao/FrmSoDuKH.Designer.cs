namespace CanKT.FormBaoCao
{
    partial class FrmSoDuKH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.txbTienNop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTenKH = new System.Windows.Forms.TextBox();
            this.txbMaKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbSLTan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbThanhTien = new System.Windows.Forms.TextBox();
            this.txbSLM3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTienConLai = new System.Windows.Forms.TextBox();
            this.btnTinh = new System.Windows.Forms.Button();
            this.btnTroLai = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpNgay);
            this.groupBox1.Controls.Add(this.txbTienNop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbTenKH);
            this.groupBox1.Controls.Add(this.txbMaKH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nộp tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số tiền";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Location = new System.Drawing.Point(81, 45);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(176, 20);
            this.dtpNgay.TabIndex = 5;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // txbTienNop
            // 
            this.txbTienNop.Location = new System.Drawing.Point(81, 71);
            this.txbTienNop.Name = "txbTienNop";
            this.txbTienNop.Size = new System.Drawing.Size(176, 20);
            this.txbTienNop.TabIndex = 4;
            this.txbTienNop.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày";
            // 
            // txbTenKH
            // 
            this.txbTenKH.Location = new System.Drawing.Point(142, 19);
            this.txbTenKH.Name = "txbTenKH";
            this.txbTenKH.ReadOnly = true;
            this.txbTenKH.Size = new System.Drawing.Size(217, 20);
            this.txbTenKH.TabIndex = 2;
            // 
            // txbMaKH
            // 
            this.txbMaKH.Location = new System.Drawing.Point(81, 19);
            this.txbMaKH.Name = "txbMaKH";
            this.txbMaKH.Size = new System.Drawing.Size(55, 20);
            this.txbMaKH.TabIndex = 1;
            this.txbMaKH.TextChanged += new System.EventHandler(this.txbMaKH_TextChanged);
            this.txbMaKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMaKH_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã KH";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txbSLTan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbThanhTien);
            this.groupBox2.Controls.Add(this.txbSLM3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xuất kho";
            // 
            // txbSLTan
            // 
            this.txbSLTan.Location = new System.Drawing.Point(81, 19);
            this.txbSLTan.Name = "txbSLTan";
            this.txbSLTan.ReadOnly = true;
            this.txbSLTan.Size = new System.Drawing.Size(108, 20);
            this.txbSLTan.TabIndex = 7;
            this.txbSLTan.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thành tiền";
            // 
            // txbThanhTien
            // 
            this.txbThanhTien.Location = new System.Drawing.Point(81, 45);
            this.txbThanhTien.Name = "txbThanhTien";
            this.txbThanhTien.ReadOnly = true;
            this.txbThanhTien.Size = new System.Drawing.Size(176, 20);
            this.txbThanhTien.TabIndex = 4;
            this.txbThanhTien.Text = "0";
            // 
            // txbSLM3
            // 
            this.txbSLM3.Location = new System.Drawing.Point(226, 19);
            this.txbSLM3.Name = "txbSLM3";
            this.txbSLM3.ReadOnly = true;
            this.txbSLM3.Size = new System.Drawing.Size(108, 20);
            this.txbSLM3.TabIndex = 2;
            this.txbSLM3.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số lượng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txbTienConLai);
            this.groupBox3.Location = new System.Drawing.Point(13, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Còn lại";
            // 
            // txbTienConLai
            // 
            this.txbTienConLai.Location = new System.Drawing.Point(81, 19);
            this.txbTienConLai.Name = "txbTienConLai";
            this.txbTienConLai.ReadOnly = true;
            this.txbTienConLai.Size = new System.Drawing.Size(176, 20);
            this.txbTienConLai.TabIndex = 4;
            this.txbTienConLai.Text = "0";
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(94, 262);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(85, 23);
            this.btnTinh.TabIndex = 3;
            this.btnTinh.Text = "Tính";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // btnTroLai
            // 
            this.btnTroLai.Location = new System.Drawing.Point(185, 262);
            this.btnTroLai.Name = "btnTroLai";
            this.btnTroLai.Size = new System.Drawing.Size(85, 23);
            this.btnTroLai.TabIndex = 4;
            this.btnTroLai.Text = "Trở lại";
            this.btnTroLai.UseVisualStyleBackColor = true;
            this.btnTroLai.Click += new System.EventHandler(this.btnTroLai_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Tấn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "M³";
            // 
            // FrmSoDuKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(395, 295);
            this.Controls.Add(this.btnTroLai);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSoDuKH";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số dư khách hàng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbMaKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.TextBox txbTienNop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbThanhTien;
        private System.Windows.Forms.TextBox txbSLM3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbSLTan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTienConLai;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Button btnTroLai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}