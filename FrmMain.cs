﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT
{
    public partial class FrmMain : Form
    {
        private string tentk, quyen;
        public FrmMain(string tentaikhoan, string quyen)
        {
            InitializeComponent();
            this.tentk = tentaikhoan;
            this.quyen = quyen;
        }



        private Form currentFormChild;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //if (quyen == "Admin")
            //{
            //    phiếuNhậpxuấtToolStripMenuItem.Visible = true;
            //}
            //else
            //{
            //    phiếuNhậpxuấtToolStripMenuItem.Visible = false;
            //}

            //set quyen nhu tren
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void cânXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCan(tentk, quyen));
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có thực sự muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                this.Hide();
                frmDangNhap.ShowDialog();
            }
        }

        #region Exit_Function
        private bool isExiting = false;

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isExiting = true;
            var result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ExitApplication();
            }
        }

        private void ExitApplication()
        {
            Application.Exit();
        }

        private void phiếuNhậpxuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmChiTiet());
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSanPham());
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhachHang());
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKho());
        }

        private void máyXayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmMayXay());
        }

        private void xeXúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmXeXuc());
        }

        private void xeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmXe());
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExiting)
            {
                isExiting = true;
                var result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    isExiting = false;
                    e.Cancel = true;
                }
                else
                {
                    ExitApplication();
                }
            }
        }
        #endregion

        //next
    }
}
