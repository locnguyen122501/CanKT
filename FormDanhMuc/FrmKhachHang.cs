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
    public partial class FrmKhachHang : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmKhachHang()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvKH.Rows.Clear();

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.KhachHangs.ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvKH.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvKH.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maKH;
                row.Cells["Column2"].Value = item.tenKH;

                if (item.loai == 1)
                {
                    string loai = "Khách hàng";
                    row.Cells["Column3"].Value = loai.ToString();
                }
                else
                {
                    string loai = "Nhà cung cấp";
                    row.Cells["Column3"].Value = loai.ToString();
                }

                row.Cells["Column4"].Value = item.maSoThue;
                row.Cells["Column5"].Value = item.diaChi;
                row.Cells["Column6"].Value = item.sdt;
                row.Cells["Column7"].Value = item.email;
                row.Cells["Column8"].Value = item.ghiChu;

                if (item.trangThai == 0)
                {
                    string trangthai = "Không còn sử dụng";
                    row.Cells["Column9"].Value = trangthai.ToString();
                }
            }
        }
    }
}
