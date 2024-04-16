using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanKT.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CanKT
{
    public partial class FrmDangNhap : Form
    {
        CanDBContext db = new CanDBContext();

        public FrmDangNhap()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txbTen; //focus vao txb Ten dang nhap
        }

        private void txbTen_Enter(object sender, EventArgs e)
        {
            if (txbTen.Text == "Nhập tên tài khoản")
            {
                txbTen.Text = "";
                txbTen.ForeColor = Color.Black;
            }
        }

        private void txbTen_Leave(object sender, EventArgs e)
        {
            if (txbTen.Text == "")
            {
                txbTen.Text = "Nhập tên tài khoản";
                txbTen.ForeColor = Color.DarkGray;
            }
        }

        private void checkboxHienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxHienthi.Checked)
            {
                txbMatkhau.PasswordChar = '\0'; //hien thi mat khau
            }
            else
            {
                txbMatkhau.PasswordChar = '*'; //an mat khau
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txbTen.Text.Trim().Length.Equals(0)) //kiem tra da nhap vao textbox hay chua
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTen.Focus();
            }
            else
            {
                if (txbMatkhau.Text.Trim().Length.Equals(0))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMatkhau.Focus();
                }
                else
                {
                    string username = txbTen.Text;
                    string password = txbMatkhau.Text;

                    var user = db.NhanViens.FirstOrDefault(u => u.tenTaiKhoan == username);

                    if (user != null) //ton tai tai khoan
                    {
                        if (user.matKhau == password)
                        {
                            //check quyen user
                            string quyen = "";

                            if (user.quyen == "Admin")
                            {
                                quyen = user.quyen;
                            }
                            else
                            {
                                quyen = user.quyen;
                            }
                            
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string tentaikhoan = user.tenTaiKhoan;

                            FrmMain frmMain = new FrmMain(tentaikhoan, quyen);
                            this.Hide();
                            frmMain.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else //tai khoan khong ton tai
                    {
                        MessageBox.Show("Tai khoan không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //kiem tra da nhan phim escape chua va co dang focus vao 2 textbox Ten, MK khong
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnThoat.PerformClick();
            }
        }

        private void txbTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMatkhau.Focus();
            }         
        }

        private void txbMatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnDangnhap.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txbTen.Focus();
            }
        }
    }
}
