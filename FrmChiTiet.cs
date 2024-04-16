using CanKT.Models;
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
    public partial class FrmChiTiet : Form
    {

        CanDBContext db = new CanDBContext();
        public FrmChiTiet()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmChiTiet_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvCan.Rows.Clear();

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

                decimal tlxevao = Convert.ToDecimal(item.trongLuongXeVao);
                row.Cells["Column4"].Value = tlxevao.ToString("N0");
                //row.Cells["Column4"].Value = tlxevao.ToString();

                decimal tlxera = Convert.ToDecimal(item.trongLuongXeRa);
                row.Cells["Column5"].Value = tlxera.ToString("N0");

                row.Cells["Column6"].Value = item.maSP;

                //dinh dang tien
                decimal donGia = Convert.ToDecimal(item.donGia); //chuyen kieu du lieu money sang decimal
                row.Cells["Column7"].Value = donGia.ToString("N0");

                decimal tan = Convert.ToDecimal(item.soLuongTan);
                row.Cells["Column8"].Value = tan.ToString("N0");

                decimal m3 = Convert.ToDecimal(item.soLuongM3);
                row.Cells["Column9"].Value = m3.ToString("N0");

                decimal thanhTien = Convert.ToDecimal(item.thanhTien); //chuyen kieu du lieu money sang decimal               
                row.Cells["Column10"].Value = thanhTien.ToString("N0");

                if (item.trangThai == 0)
                {
                    string trangthai = "Đã hủy";
                    row.Cells["Column11"].Value = trangthai.ToString();
                }
            }
        }
    }
}
