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
    public partial class FrmXe : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmXe()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmXe_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvXe.Rows.Clear();

            // Truy vấn dữ liệu từ DbSet trong DbContext
            //var data = db.Khoes.ToList();

            var data = (from x in db.Xes
                        join k in db.KhachHangs on x.maKH equals k.maKH into gj
                        from subk in gj.DefaultIfEmpty()
                        select new
                        {
                            x.bienSoXe,
                            x.tenXe,
                            x.loaiXe,
                            x.tenTaiXe,
                            x.trongLuongBanThan,
                            x.trongLuongChoPhep,
                            x.ngayKetDangKiem,
                            x.trangThai,
                            tenKH = subk != null ? subk.tenKH : null,
                        }).ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvXe.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvXe.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.bienSoXe;
                row.Cells["Column2"].Value = item.tenXe;
                row.Cells["Column3"].Value = item.tenKH;

                if (item.loaiXe == 1)
                {
                    string loai = "Xe tải";
                    row.Cells["Column4"].Value = loai.ToString();
                }
                else
                {
                    if (item.loaiXe == 2)
                    {
                        string loai = "Rơ móc";
                        row.Cells["Column4"].Value = loai.ToString();
                    }
                    else
                    {
                        string loai = "Đầu kéo";
                        row.Cells["Column4"].Value = loai.ToString();
                    }
                }
                
                row.Cells["Column5"].Value = item.tenTaiXe;

                decimal tlbanthan = Convert.ToDecimal(item.trongLuongBanThan);
                row.Cells["Column6"].Value = tlbanthan.ToString("N0");

                decimal tlchophep = Convert.ToDecimal(item.trongLuongChoPhep);
                row.Cells["Column7"].Value = tlchophep.ToString("N0");

                DateTime ngayketdangkiem = Convert.ToDateTime(item.ngayKetDangKiem);
                row.Cells["Column8"].Value = ngayketdangkiem.ToString("dd/MM/yyyy");

                if (item.trangThai == 0)
                {
                    string trangthai = "Không còn sử dụng";
                    row.Cells["Column9"].Value = trangthai.ToString();
                }
            }
        }
    }
}
