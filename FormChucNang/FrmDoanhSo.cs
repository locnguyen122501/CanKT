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

            // Danh sách ReportParameter để chứa các tham số
            List<ReportParameter> parameters = new List<ReportParameter>();

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
                            var _khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == _maKH);
                            if (_khachHang != null)
                            {
                                _maPhieu = _khachHang.tenKH;
                                _dk1 = _maPhieu;

                                // Thêm tên khách hàng vào danh sách parameters
                                parameters.Add(new ReportParameter("pDK1", _dk1));
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

                                parameters.Add(new ReportParameter("pDK1", maMayXuc));
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

                                parameters.Add(new ReportParameter("pDK2", bienSo));
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

                                parameters.Add(new ReportParameter("pDK3", maSP));
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

                        //decimal tien = _sotien == 0 ? (decimal)_tien.thanhTien : (decimal)_tien.tienThanhToan;
                    }

                    _maKH = makh.ToString();
                    #endregion

                    var _phieu = db.PhieuThus.FirstOrDefault(p => p.maDon == _maPhieu);
                    if (_phieu != null)
                    {
                        decimal slm3 = (decimal) _phieu.soLuongM3;
                        string _slm3 = slm3.ToString();

                        decimal tongm3 = 0;
                        tongm3 = tongm3 + slm3;
                        string _tongm3 = tongm3.ToString();

                        decimal sltan = (decimal) _phieu.soLuongTan;
                        string _sltan = sltan.ToString();

                        decimal tongtan = 0;
                        tongtan = tongtan + sltan;
                        string _tongtan = tongtan.ToString();


                        decimal tien = (decimal) _phieu.thanhTien;
                        string _ttien = tien.ToString();

                        decimal tongtien = 0;
                        tongtien = tongtien + tien;
                        string _tongtien = tongtien.ToString();

                        string stt = "1";

                        DateTime ngay = DateTime.Now.Date;
                        string _ngay = ngay.ToString();

                        // Thêm tên khách hàng vào danh sách parameters
                        parameters.Add(new ReportParameter("pSLM3DK1", _slm3));
                        parameters.Add(new ReportParameter("pSLTanDK1", _sltan));
                        parameters.Add(new ReportParameter("pSoTienDK1", _ttien));
                        parameters.Add(new ReportParameter("pTongTan", _tongtan));
                        parameters.Add(new ReportParameter("pTongM3", _tongm3));
                        parameters.Add(new ReportParameter("pTongTien", _tongtien));
                        parameters.Add(new ReportParameter("pSTT", stt));
                        parameters.Add(new ReportParameter("pNgay", _ngay));
                        parameters.Add(new ReportParameter("pSoTrang", stt));
                    }

                    var _phieu2 = db.PhieuThus.Where(p => p.bienSoXe == bienSo);
                    foreach (var phieu2 in phieuthus)
                    {
                        decimal slm3 = (decimal) phieu2.soLuongM3;
                        string _slm3 = slm3.ToString();

                        decimal sltan = (decimal) phieu2.soLuongTan;
                        string _sltan = sltan.ToString();

                        decimal tien = (decimal)phieu2.thanhTien;
                        string _ttien = tien.ToString();

                        parameters.Add(new ReportParameter("pSLM3DK2", _slm3));
                        parameters.Add(new ReportParameter("pSLTanDK2", _sltan));
                        parameters.Add(new ReportParameter("pSoTienDK2", _ttien));
                    }

                    var _phieu3 = db.PhieuThus.Where(p => p.bienSoXe == bienSo);
                    foreach (var phieu3 in phieuthus)
                    {
                        decimal slm3 = (decimal)phieu3.soLuongM3;
                        string _slm3 = slm3.ToString();

                        decimal sltan = (decimal)phieu3.soLuongTan;
                        string _sltan = sltan.ToString();

                        decimal tien = (decimal)phieu3.thanhTien;
                        string _ttien = tien.ToString();

                        parameters.Add(new ReportParameter("pSLM3DK3", _slm3));
                        parameters.Add(new ReportParameter("pSLTanDK3", _sltan));
                        parameters.Add(new ReportParameter("pSoTienDK3", _ttien));
                    }
                }
            }

            // Khởi tạo mảng ReportParameter để truyền dữ liệu
            //ReportParameter[] parameters = new ReportParameter[]
            //{
            //    new ReportParameter("pDK1", _dk1),
            //    new ReportParameter("pDK2", _dk1),
            //    new ReportParameter("pDK3", _dk1),
            //};

            // Thiết lập các tham số cho report
            reportViewer.LocalReport.ReportPath = @"C:\Users\User001\Desktop\Testing\CanKT\Reports\rptDoanhSo.rdlc";
            reportViewer.LocalReport.SetParameters(parameters.ToArray());

            // Refresh report để hiển thị dữ liệu mới
            reportViewer.RefreshReport();
        }

        private void FrmDoanhSo_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
