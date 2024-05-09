using CanKT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT
{
    public partial class FrmChiTiet : Form
    {

        CanDBContext db = new CanDBContext();
        CultureInfo cultureInfo = new CultureInfo("vi-VN");
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
                row.Cells["Column4"].Value = tlxevao.ToString(cultureInfo);

                decimal tlxera = Convert.ToDecimal(item.trongLuongXeRa);
                row.Cells["Column5"].Value = tlxera.ToString(cultureInfo);

                row.Cells["Column6"].Value = item.lenhXuat;

                row.Cells["Column7"].Value = item.maSP;

                //dinh dang tien
                decimal donGia = Convert.ToDecimal(item.donGia); //chuyen kieu du lieu money sang decimal
                row.Cells["Column8"].Value = donGia.ToString("N0", cultureInfo);

                decimal tan = Convert.ToDecimal(item.soLuongTan);
                row.Cells["Column9"].Value = tan.ToString(cultureInfo);

                decimal m3 = Convert.ToDecimal(item.soLuongM3);
                row.Cells["Column10"].Value = m3.ToString(cultureInfo);

                decimal thanhTien = Convert.ToDecimal(item.thanhTien); //chuyen kieu du lieu money sang decimal               
                row.Cells["Column11"].Value = thanhTien.ToString("N0", cultureInfo);

                if (item.trangThai == 0)
                {
                    string trangthai = "Đã hủy";
                    row.Cells["Column12"].Value = trangthai.ToString();
                }
            }
        }

        private void dgvCan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã click vào dòng nào chưa
            if (e.RowIndex >= 0 && e.RowIndex < dgvCan.Rows.Count)
            {
                // Bỏ chọn tất cả các hàng trước đó
                dgvCan.ClearSelection();

                // Chọn hàng được click
                dgvCan.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
