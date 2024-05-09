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
    public partial class FrmMayXay : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmMayXay()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmMayXay_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvMayXay.Rows.Clear();

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.MayXays.ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvMayXay.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvMayXay.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maMayXay;
                row.Cells["Column2"].Value = item.tenMayXay;
                row.Cells["Column3"].Value = item.ghiChu;

                if (item.trangThai == 0)
                {
                    string trangthai = "Không còn sử dụng";
                    row.Cells["Column4"].Value = trangthai.ToString();
                }
            }
        }

        private void dgvMayXay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã click vào dòng nào chưa
            if (e.RowIndex >= 0 && e.RowIndex < dgvMayXay.Rows.Count)
            {
                // Bỏ chọn tất cả các hàng trước đó
                dgvMayXay.ClearSelection();

                // Chọn hàng được click
                dgvMayXay.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
