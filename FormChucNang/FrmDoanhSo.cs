using CanKT.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT.FormChucNang
{
    public partial class FrmDoanhSo : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmDoanhSo()
        {
            InitializeComponent();
        }

        public void loadData(DateTime ngaydau, DateTime ngaysau, string makh, string dk1, string dk2,
            string dk3, int khongintien, int sotien)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");

            DateTime _ngaydau = ngaydau.Date;
            string ngayDau = _ngaydau.ToString("dd/MM/yyyy");

            DateTime _ngaysau = ngaysau.Date;
            string ngaySau = _ngaysau.ToString("dd/MM/yyyy");

            string _maPhieu = "";
            string _maKH = "";
            string _dk1 = dk1.ToString();
            string _dk2 = dk2.ToString();
            string _dk3 = dk3.ToString();
            string bienSo = "";
            string maSP = "";
            string maKho = "";
            string maMayXay = "";
            string maMayXuc = "";
            int _khongintien = khongintien;
            int _sotien = sotien;

            // Truy vấn tất cả các phiếu trong cơ sở dữ liệu có ngày nhỏ hơn hoặc bằng ngày được chọn
            using (var db = new CanDBContext())
            {
                var phieuthus = db.PhieuThus.Where(p => p.trangThai == 1);

                foreach (var phieu in phieuthus)
                {
                    _maPhieu = phieu.maDon;
                    _maKH = phieu.maKH;
                    bienSo = phieu.bienSoXe;
                    maSP = phieu.maSP;
                    maKho = phieu.maKho;
                    maMayXay = phieu.maMayXay;
                    maMayXuc = phieu.maMayXuc;

                    #region Xu ly lay ten hien thi
                    switch (_dk1)
                    {
                        case "maKH":
                            var _khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == _maPhieu);
                            if (_khachHang != null)
                            {
                                _maPhieu = _khachHang.tenKH;
                            }
                            break;
                        case "bienSoXe":
                            var _soXe = db.Xes.FirstOrDefault(x => x.bienSoXe == bienSo);
                            if (_soXe != null)
                            {
                                bienSo = _soXe.bienSoXe;
                            }
                            break;
                        case "maSP":
                            var _sanPham = db.SanPhams.FirstOrDefault(sp => sp.maThanhPham == maSP);
                            if (_sanPham != null)
                            {
                                maSP = _sanPham.tenThanhPham;
                            }
                            break;
                        case "maKho":
                            var _maKho = db.Khoes.FirstOrDefault(k => k.maKho == maKho);
                            if (_maKho != null)
                            {
                                maKho = _maKho.tenKho;
                            }
                            break;
                        case "maMayXay":
                            var _maMayXay = db.MayXays.FirstOrDefault(mx => mx.maMayXay == maMayXay);
                            if (_maMayXay != null)
                            {
                                maMayXay = _maMayXay.tenMayXay;
                            }
                            break;
                        case "maMayXuc":
                            var _maMayXuc = db.XeXucs.FirstOrDefault(xx => xx.maXeXuc == maMayXuc);
                            if (_maMayXuc != null)
                            {
                                maMayXuc = _maMayXuc.tenXeXuc;
                            }
                            break;
                        default:
                            break;
                    }
                    switch (_dk2)
                    {
                        case "maKH":
                            var _khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == _maPhieu);
                            if (_khachHang != null)
                            {
                                _maPhieu = _khachHang.tenKH;
                            }
                            break;
                        case "bienSoXe":
                            var _soXe = db.Xes.FirstOrDefault(x => x.bienSoXe == bienSo);
                            if (_soXe != null)
                            {
                                bienSo = _soXe.bienSoXe;
                            }
                            break;
                        case "maSP":
                            var _sanPham = db.SanPhams.FirstOrDefault(sp => sp.maThanhPham == maSP);
                            if (_sanPham != null)
                            {
                                maSP = _sanPham.tenThanhPham;
                            }
                            break;
                        case "maKho":
                            var _maKho = db.Khoes.FirstOrDefault(k => k.maKho == maKho);
                            if (_maKho != null)
                            {
                                maKho = _maKho.tenKho;
                            }
                            break;
                        case "maMayXay":
                            var _maMayXay = db.MayXays.FirstOrDefault(mx => mx.maMayXay == maMayXay);
                            if (_maMayXay != null)
                            {
                                maMayXay = _maMayXay.tenMayXay;
                            }
                            break;
                        case "maMayXuc":
                            var _maMayXuc = db.XeXucs.FirstOrDefault(xx => xx.maXeXuc == maMayXuc);
                            if (_maMayXuc != null)
                            {
                                maMayXuc = _maMayXuc.tenXeXuc;
                            }
                            break;
                        default:
                            break;
                    }
                    switch (_dk3)
                    {
                        case "maKH":
                            var _khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == _maPhieu);
                            if (_khachHang != null)
                            {
                                _maPhieu = _khachHang.tenKH;
                            }
                            break;
                        case "bienSoXe":
                            var _soXe = db.Xes.FirstOrDefault(x => x.bienSoXe == bienSo);
                            if (_soXe != null)
                            {
                                bienSo = _soXe.bienSoXe;
                            }
                            break;
                        case "maSP":
                            var _sanPham = db.SanPhams.FirstOrDefault(sp => sp.maThanhPham == maSP);
                            if (_sanPham != null)
                            {
                                maSP = _sanPham.tenThanhPham;
                            }
                            break;
                        case "maKho":
                            var _maKho = db.Khoes.FirstOrDefault(k => k.maKho == maKho);
                            if (_maKho != null)
                            {
                                maKho = _maKho.tenKho;
                            }
                            break;
                        case "maMayXay":
                            var _maMayXay = db.MayXays.FirstOrDefault(mx => mx.maMayXay == maMayXay);
                            if (_maMayXay != null)
                            {
                                maMayXay = _maMayXay.tenMayXay;
                            }
                            break;
                        case "maMayXuc":
                            var _maMayXuc = db.XeXucs.FirstOrDefault(xx => xx.maXeXuc == maMayXuc);
                            if (_maMayXuc != null)
                            {
                                maMayXuc = _maMayXuc.tenXeXuc;
                            }
                            break;
                        default:
                            break;
                    }

                    var _tien = db.PhieuThus.FirstOrDefault(p => p.maDon == _maPhieu);
                    if (_tien != null)
                    {
                        if (_sotien == 0)
                        {
                            decimal tien = (decimal)_tien.thanhTien;
                        }
                        else
                        {
                            decimal tien = (decimal)_tien.tienThanhToan;
                        }
                    }

                    _maKH = makh.ToString();
                    #endregion
                }
            }

            // Khởi tạo mảng ReportParameter để truyền dữ liệu
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("pDK1", _dk1),
                new ReportParameter("pDK2", _dk2),
                new ReportParameter("pDK3", _dk3),
            };

            // Thiết lập các tham số cho report
            reportViewer.LocalReport.ReportPath = @"C:\Users\User001\Desktop\Testing\CanKT\Reports\rptDoanhSo.rdlc";
            reportViewer.LocalReport.SetParameters(parameters);

            // Refresh report để hiển thị dữ liệu mới
            reportViewer.RefreshReport();
        }

        private void FrmDoanhSo_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
