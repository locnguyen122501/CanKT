using CanKT.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT
{
    public partial class FrmPrint : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmPrint()
        {
            InitializeComponent();
        }

        // Tạo một phương thức public để nhận dữ liệu từ form chính
        public void LoadData(string khachHang, string soXe, string maKho, string maMayXay, string maXeXuc, string tlXeVao, string tlXeRa, string slM3, string maSP,
            string donGia, string tienHang, string tienThanhToan, string maPhieu, string lenhXuat)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");

            DateTime date = DateTime.Today;
            string ngayhomnay = date.ToString("dd/MM/yyyy");

            //doi tan sang kg
            decimal tlVaoKg = (decimal.Parse(tlXeVao) * 1000) / 1000;
            string _tlXeVao = tlVaoKg.ToString("N0", cultureInfo);

            decimal tlRaKg = (decimal.Parse(tlXeRa) * 1000) / 1000;
            string _tlXeRa = tlRaKg.ToString("N0", cultureInfo);

            string _tienHang = tienHang.Replace(".", ""); //tienHang dang o dang string nhung la 1.850.000 nen can remove "." ra

            decimal temp = Math.Round(decimal.Parse(_tienHang) * (decimal) 0.1);
            string thueGTGT = temp.ToString("N0", cultureInfo);

            decimal hanghoa = (decimal.Parse(tlXeRa) - decimal.Parse(tlXeVao))/1000;
            string tlHangHoa = hanghoa.ToString("N3", cultureInfo);

            #region Xu ly lay ten hien thi
            var _khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == khachHang);
            if (_khachHang != null)
            {
                khachHang = _khachHang.tenKH;
            }

            var _maKho = db.Khoes.FirstOrDefault(k => k.maKho == maKho);
            if (_maKho != null)
            {
                maKho = _maKho.tenKho;
            }

            var _maMayXay = db.MayXays.FirstOrDefault(mx => mx.maMayXay == maMayXay);
            if (_maMayXay != null)
            {
                maMayXay = _maMayXay.tenMayXay;
            }

            var _maXeXuc = db.XeXucs.FirstOrDefault(x => x.maXeXuc == maXeXuc);
            if (_maXeXuc != null)
            {
                maXeXuc = _maXeXuc.tenXeXuc;
            }

            var _maSP = db.SanPhams.FirstOrDefault(sp => sp.maThanhPham == maSP);
            if (_maSP != null)
            {
                maSP = _maSP.tenThanhPham;
            }
            #endregion

            // Khởi tạo mảng ReportParameter để truyền dữ liệu
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("pNgay", ngayhomnay),
                new ReportParameter("pMaPhieu", maPhieu),
                new ReportParameter("pLenhXuat", lenhXuat),
                new ReportParameter("pKhachHang", khachHang),
                new ReportParameter("pSoXe", soXe),
                new ReportParameter("pKho", maKho),
                new ReportParameter("pMayXay", maMayXay),
                new ReportParameter("pXeXuc", maXeXuc),
                new ReportParameter("pTLXeVao", _tlXeVao),
                new ReportParameter("pTLXeRa", _tlXeRa),
                new ReportParameter("pTLHangHoa", tlHangHoa),
                new ReportParameter("pM3", slM3),
                new ReportParameter("pSanPham", maSP),
                new ReportParameter("pDonGia", donGia),
                new ReportParameter("pTienHang", tienHang),
                new ReportParameter("pThueGTGT", thueGTGT),
                new ReportParameter("pTienThanhToan", tienThanhToan)
            };

            // Thiết lập các tham số cho report
            reportViewer.LocalReport.ReportPath = @"C:\Users\User001\Desktop\Testing\CanKT\FormChucNang\rptReport.rdlc";
            reportViewer.LocalReport.SetParameters(parameters);

            // Refresh report để hiển thị dữ liệu mới
            reportViewer.RefreshReport();
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
