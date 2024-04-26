using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT
{
    public partial class FrmTimPhieu : Form
    {
        public string MaPhieu { get; private set; }

        public FrmTimPhieu()
        {
            InitializeComponent();
        }
       

        private void FrmTimPhieu_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txbMaPhieu;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MaPhieu = txbMaPhieu.Text;
            this.Close();
        }

        private void txbMaPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox

                MaPhieu = txbMaPhieu.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                this.Close();
            }
        }
    }
}
