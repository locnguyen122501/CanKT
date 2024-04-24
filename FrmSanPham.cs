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
    public partial class FrmSanPham : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmSanPham()
        {
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            dgvCan.Rows.Clear();

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = (from sp in db.SanPhams
                        join d in db.Gias on sp.maThanhPham equals d.maThanhPham into gj
                        from subd in gj.DefaultIfEmpty()
                        //join t3 in db.MaTienTes on subd != null ? subd.maNgoaiTe : null equals t3.maTienTe1 into tj
                        //from subt3 in tj.DefaultIfEmpty()
                        select new
                        {
                            sp.maThanhPham,
                            sp.tenThanhPham,
                            sp.maDonViTinh,
                            sp.heSoQuyDoi,
                            sp.trangThai,
                            donGia = subd != null ? subd.donGia : null,
                            maNgoaiTe = subd != null ? subd.maNgoaiTe : null,
                            //tenTienTe = subt3 != null ? subt3.tenTienTe : null
                        }).ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvCan.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvCan.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maThanhPham;
                row.Cells["Column2"].Value = item.tenThanhPham;
                
                // Lấy thông tin về đơn vị tính từ bảng DVT
                var dvt = db.DonViTinhs.FirstOrDefault(d => d.maDonViTinh == item.maDonViTinh);
                if (dvt != null)
                {
                    row.Cells["Column3"].Value = dvt.tenDonViTinh;
                }

                double tlxevao = Convert.ToDouble(item.heSoQuyDoi);
                row.Cells["Column4"].Value = tlxevao.ToString();

                // Lấy thông tin về đơn vị tính từ bảng DVT
                var gia = db.Gias.FirstOrDefault(g => g.maThanhPham == item.maThanhPham);
                if (gia != null)
                {
                    decimal giasp = Convert.ToDecimal(gia.donGia);
                    row.Cells["Column5"].Value = giasp.ToString("N0");
                }

                row.Cells["Column6"].Value = item.maNgoaiTe;

                if (item.trangThai == 0)
                {
                    string trangthai = "Đã hủy";
                    row.Cells["Column7"].Value = trangthai.ToString();
                }
            }
        }
    }
}
