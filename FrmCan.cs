using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;
using CanKT.Models;

namespace CanKT
{
    public partial class FrmCan : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmCan()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }


        private void FrmCan_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txbSoXe;
        }

        private void LoadDataIntoDataGridView()
        {
            

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.PhieuThus.ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvCan.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvCan.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maDon; 
                row.Cells["Column2"].Value = item.bienSoXe;
                row.Cells["Column3"].Value = item.maKH;
                row.Cells["Column4"].Value = item.trongLuongXeVao;
                row.Cells["Column5"].Value = item.trongLuongXeRa;
                row.Cells["Column6"].Value = item.maSP;

                //dinh dang tien
                decimal donGia = Convert.ToDecimal(item.donGia); //chuyen kieu du lieu money sang decimal
                row.Cells["Column7"].Value = donGia.ToString("#,0.###", CultureInfo.InvariantCulture);

                row.Cells["Column8"].Value = item.soLuongTan;
                row.Cells["Column9"].Value = item.soLuongM3;

                decimal thanhTien = Convert.ToDecimal(item.thanhTien); //chuyen kieu du lieu money sang decimal
                row.Cells["Column10"].Value = thanhTien.ToString("#,0.###", CultureInfo.InvariantCulture);
            }
        }

        private void txbSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbTLXeVao.Focus();
            }
        }

        private void txbTLXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbTLXeRa.Focus();
            }
        }

        private void txbTLXeRa_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
