using Microsoft.Reporting.WinForms;
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
    public partial class FrmPrint : Form
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        // Tạo một phương thức public để nhận dữ liệu từ form chính
        public void LoadData(string khachHang, string soXe, string maKho, string maMayXay, string maXeXuc, string tlXeVao, string tlXeRa, string slM3, string maSP, string donGia, string tienHang, string tienThanhToan)
        {
            decimal temp = decimal.Parse(tienHang) * (decimal) 0.1;
            string thueGTGT = temp.ToString("N0");


            // Khởi tạo mảng ReportParameter để truyền dữ liệu
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("pKhachHang", khachHang),
                new ReportParameter("pSoXe", soXe),
                new ReportParameter("pKho", maKho),
                new ReportParameter("pMayXay", maMayXay),
                new ReportParameter("pXeXuc", maXeXuc),
                new ReportParameter("pTLXeVao", tlXeVao),
                new ReportParameter("pTLXeRa", tlXeRa),
                new ReportParameter("pM3", slM3),
                new ReportParameter("pSanPham", maSP),
                new ReportParameter("pDonGia", donGia),
                new ReportParameter("pTienHang", tienHang),
                new ReportParameter("pThueGTGT", thueGTGT),
                new ReportParameter("pTienThanhToan", tienThanhToan)
            };

            // Thiết lập các tham số cho report
            reportViewer.LocalReport.ReportPath = @"C:\Users\User001\Desktop\Testing\CanKT\rptReport.rdlc"; // Thay đổi đường dẫn đến report RDLC của bạn
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
