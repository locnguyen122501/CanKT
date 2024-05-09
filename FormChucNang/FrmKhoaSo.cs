using CanKT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT.FormChucNang
{
    public partial class FrmKhoaSo : Form
    {
        CanDBContext db = new CanDBContext();

        string quyentk = "";

        public FrmKhoaSo(string quyen)
        {
            InitializeComponent();

            quyentk = quyen;
        }       

        private void btnKhoaSo_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime selectedDate = dtpNgay.Value.Date;

            // Truy vấn tất cả các phiếu trong cơ sở dữ liệu có ngày nhỏ hơn hoặc bằng ngày được chọn
            using (var db = new CanDBContext())
            {
                var phieuthus = db.PhieuThus.Where(p => DbFunctions.TruncateTime(p.thoiGianRa) == selectedDate.Date && p.trangThai == 1);

                // Đổi trạng thái của các phiếu tìm thấy thành 3
                foreach (var phieu in phieuthus)
                {
                    phieu.trangThai = 3;
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                MessageBox.Show("Đã khóa sổ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMoSo_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime selectedDate = dtpNgay.Value.Date;

            // Truy vấn tất cả các phiếu trong cơ sở dữ liệu có ngày nhỏ hơn hoặc bằng ngày được chọn
            using (var db = new CanDBContext())
            {
                if (quyentk == "Admin")
                {
                    var phieuthus = db.PhieuThus.Where(p => DbFunctions.TruncateTime(p.thoiGianRa) == selectedDate.Date && p.trangThai == 3);

                    // Đổi trạng thái của các phiếu tìm thấy thành 3
                    foreach (var phieu in phieuthus)
                    {
                        phieu.trangThai = 1;
                    }

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    MessageBox.Show("Đã mở ngày chốt sổ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (selectedDate.Date == DateTime.Today.Date) // chỉ được mở trong ngày
                    {
                        var phieuthus = db.PhieuThus.Where(p => DbFunctions.TruncateTime(p.thoiGianRa) == selectedDate.Date && p.trangThai == 3);

                        // Đổi trạng thái của các phiếu tìm thấy thành 3
                        foreach (var phieu in phieuthus)
                        {
                            phieu.trangThai = 1;
                        }

                        // Lưu các thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();

                        MessageBox.Show("Đã mở ngày chốt sổ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không được mở ngày chốt sổ nhỏ hơn ngày đã chốt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }        
            }
        }
    }
}
