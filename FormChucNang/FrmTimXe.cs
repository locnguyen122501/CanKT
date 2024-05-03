using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT.FormChucNang
{
    public partial class FrmTimXe : Form
    {
        public string SoXe { get; private set; }
        public FrmTimXe()
        {
            InitializeComponent();
        }

        private void FrmTimXe_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txbSoXe;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SoXe = txbSoXe.Text;
            this.Close();
        }

        private void txbSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox

                SoXe = txbSoXe.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                this.Close();
            }
        }

        private void txbSoXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
