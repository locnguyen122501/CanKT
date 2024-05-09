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
    public partial class FrmKho : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmKho()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmKho_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvKho.Rows.Clear();

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.Khoes.ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvKho.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvKho.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maKho;
                row.Cells["Column2"].Value = item.tenKho;
                row.Cells["Column3"].Value = item.ghiChu;

                if (item.trangThai == 0)
                {
                    string trangthai = "Không còn sử dụng";
                    row.Cells["Column4"].Value = trangthai.ToString();
                }
            }
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã click vào dòng nào chưa
            if (e.RowIndex >= 0 && e.RowIndex < dgvKho.Rows.Count)
            {
                // Bỏ chọn tất cả các hàng trước đó
                dgvKho.ClearSelection();

                // Chọn hàng được click
                dgvKho.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
