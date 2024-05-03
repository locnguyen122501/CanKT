using CanKT.Models;
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
    public partial class FrmDoiMatKhau : Form
    {
        CanDBContext db = new CanDBContext();

        string tentk = "";
        
        public FrmDoiMatKhau(string tentaikhoan)
        {
            InitializeComponent();

            tentk = tentaikhoan;
        }

        #region KeyDown_TextBox
        private void txbMatKhauCu_KeyDown(object sender, KeyEventArgs e)
        {
            string password = txbXacNhan.Text;

            if (e.KeyCode == Keys.Enter)
            {
                if (txbMatKhauCu.Text.Trim().Length.Equals(0)) //kiem tra da nhap vao textbox hay chua
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMatKhauCu.Focus();
                }
                else
                {
                    using (var db = new CanDBContext())
                    {
                        var user = db.NhanViens.FirstOrDefault(u => u.tenTaiKhoan == tentk);
                        if (user != null)
                        {
                            if (user.matKhau != txbMatKhauCu.Text)
                            {
                                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                e.SuppressKeyPress = true;
                                txbMatKhauCu.Focus();
                            }
                            else
                            {
                                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                                txbMatKhauMoi.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void txbMatKhauMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbMatKhauMoi.Text.Trim().Length.Equals(0)) //kiem tra da nhap vao textbox hay chua
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMatKhauMoi.Focus();
                }
                else
                {
                    e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                    txbXacNhan.Focus();
                }
                
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMatKhauCu.Focus();
            }
        }

        private void txbXacNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbXacNhan.Text.Trim().Length.Equals(0) || txbXacNhan.Text != txbMatKhauMoi.Text)
                {
                    MessageBox.Show("Vui lòng xác nhận lại mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbXacNhan.Focus();
                }
                else
                {
                    e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                    btnXacNhan.Enabled = true;
                    btnXacNhan.PerformClick();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMatKhauMoi.Focus();
            }
        }
        #endregion

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string password = txbXacNhan.Text;
            using (var db = new CanDBContext())
            {
                var user = db.NhanViens.FirstOrDefault(u => u.tenTaiKhoan == tentk);
                if (user != null)
                {
                    if (user.matKhau == txbMatKhauCu.Text)
                    {
                        user.matKhau = password;
                    }
                }
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
