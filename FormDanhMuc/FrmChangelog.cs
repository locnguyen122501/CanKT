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

namespace CanKT.FormDanhMuc
{
    public partial class FrmChangelog : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmChangelog()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
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

                string chuoi = item.ghiChu;

                if (chuoi != null)
                {
                    string[] logs = chuoi.Split(new string[] { "\n" }, StringSplitOptions.None);

                    // Kiểm tra và lấy giá trị
                    string log1 = logs.Length > 0 ? logs[0] : "";
                    string log2 = logs.Length > 1 ? logs[1] : "";
                    string log3 = logs.Length > 2 ? logs[2] : "";
                    string log4 = logs.Length > 3 ? logs[3] : "";
                    string log5 = logs.Length > 4 ? logs[4] : "";

                    chuoi = log1 + "\n" + log2 + "\n" + log3 + "\n" + log4 + "\n" + log5;
                }

                row.Cells["Column2"].Value = chuoi;
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
