namespace CanKT.FormChucNang
{
    partial class FrmKhoaSo
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
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMoSo = new System.Windows.Forms.Button();
            this.btnKhoaSo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dddddd, dd/MM/yyyy";
            this.dtpNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(133, 12);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(208, 26);
            this.dtpNgay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn ngày";
            // 
            // btnMoSo
            // 
            this.btnMoSo.Location = new System.Drawing.Point(133, 44);
            this.btnMoSo.Name = "btnMoSo";
            this.btnMoSo.Size = new System.Drawing.Size(75, 23);
            this.btnMoSo.TabIndex = 3;
            this.btnMoSo.Text = "Mở sổ";
            this.btnMoSo.UseVisualStyleBackColor = true;
            this.btnMoSo.Click += new System.EventHandler(this.btnMoSo_Click);
            // 
            // btnKhoaSo
            // 
            this.btnKhoaSo.Location = new System.Drawing.Point(214, 44);
            this.btnKhoaSo.Name = "btnKhoaSo";
            this.btnKhoaSo.Size = new System.Drawing.Size(75, 23);
            this.btnKhoaSo.TabIndex = 4;
            this.btnKhoaSo.Text = "Khóa sổ";
            this.btnKhoaSo.UseVisualStyleBackColor = true;
            this.btnKhoaSo.Click += new System.EventHandler(this.btnKhoaSo_Click);
            // 
            // FrmKhoaSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(353, 79);
            this.Controls.Add(this.btnKhoaSo);
            this.Controls.Add(this.btnMoSo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKhoaSo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khóa sổ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMoSo;
        private System.Windows.Forms.Button btnKhoaSo;
    }
}