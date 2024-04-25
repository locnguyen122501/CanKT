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
    public partial class FrmXeXuc : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmXeXuc()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmXeXuc_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvXeXuc.Rows.Clear();

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.XeXucs.ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvXeXuc.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvXeXuc.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maXeXuc;
                row.Cells["Column2"].Value = item.tenXeXuc;
                row.Cells["Column3"].Value = item.tenTaiXe;
                row.Cells["Column4"].Value = item.ghiChu;

                if (item.trangThai == 0)
                {
                    string trangthai = "Không còn sử dụng";
                    row.Cells["Column5"].Value = trangthai.ToString();
                }
            }
        }
    }
}
