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
using static System.Net.Mime.MediaTypeNames;

namespace CanKT.FormChucNang
{
    public partial class FrmKhoaSo : Form
    {
        CanDBContext db = new CanDBContext();

        string tentaikhoan = "";

        string quyentk = "";

        public FrmKhoaSo(string tentk, string quyen)
        {
            InitializeComponent();

            tentaikhoan = tentk;
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

                    #region Update Changelog
                    string chuoi = phieu.ghiChu;

                    if (chuoi != null)
                    {
                        string[] logs = chuoi.Split(new string[] { "\n" }, StringSplitOptions.None);

                        // Kiểm tra và lấy giá trị
                        string log1 = logs.Length > 0 ? logs[0] : "";
                        string log2 = logs.Length > 1 ? logs[1] : "";
                        string log3 = logs.Length > 2 ? logs[2] : "";
                        string log4 = logs.Length > 3 ? logs[3] : "";
                        string log5 = logs.Length > 4 ? logs[4] : "";

                        log5 = log4;
                        log4 = log3;
                        log3 = log2;
                        log2 = log1;
                        log1 = (DateTime.Now + " - Da khoa so " + " | " + tentaikhoan + "\n");
                        phieu.ghiChu = log1 + log2 + "\n" + log3 + "\n" + log4 + "\n" + log5;
                    }
                    else
                    {
                        phieu.ghiChu = (DateTime.Now + " - Da khoa so " + " | " + tentaikhoan + "\n");
                    }
                    #endregion
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

                        #region Update Changelog
                        string chuoi = phieu.ghiChu;

                        if (chuoi != null)
                        {
                            string[] logs = chuoi.Split(new string[] { "\n" }, StringSplitOptions.None);

                            // Kiểm tra và lấy giá trị
                            string log1 = logs.Length > 0 ? logs[0] : "";
                            string log2 = logs.Length > 1 ? logs[1] : "";
                            string log3 = logs.Length > 2 ? logs[2] : "";
                            string log4 = logs.Length > 3 ? logs[3] : "";
                            string log5 = logs.Length > 4 ? logs[4] : "";

                            log5 = log4;
                            log4 = log3;
                            log3 = log2;
                            log2 = log1;
                            log1 = (DateTime.Now + " - Da mo so " + " | " + tentaikhoan + "\n");
                            phieu.ghiChu = log1 + log2 + "\n" + log3 + "\n" + log4 + "\n" + log5;
                        }
                        else
                        {
                            phieu.ghiChu = (DateTime.Now + " - Da mo so " + " | " + tentaikhoan + "\n");
                        }
                        #endregion
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

                            #region Update Changelog
                            string chuoi = phieu.ghiChu;

                            if (chuoi != null)
                            {
                                string[] logs = chuoi.Split(new string[] { "\n" }, StringSplitOptions.None);

                                // Kiểm tra và lấy giá trị
                                string log1 = logs.Length > 0 ? logs[0] : "";
                                string log2 = logs.Length > 1 ? logs[1] : "";
                                string log3 = logs.Length > 2 ? logs[2] : "";
                                string log4 = logs.Length > 3 ? logs[3] : "";
                                string log5 = logs.Length > 4 ? logs[4] : "";

                                log5 = log4;
                                log4 = log3;
                                log3 = log2;
                                log2 = log1;
                                log1 = (DateTime.Now + " - Da mo so " + " | " + tentaikhoan + "\n");
                                phieu.ghiChu = log1 + log2 + "\n" + log3 + "\n" + log4 + "\n" + log5;
                            }
                            else
                            {
                                phieu.ghiChu = (DateTime.Now + " - Da mo so " + " | " + tentaikhoan + "\n");
                            }
                            #endregion
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
