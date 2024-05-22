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
            var thongKeData = GetThongKeData(makh, dk1, dk2, dk3);

            
        }

        private List<PhieuThu> GetThongKeData(string makh, string dk1, string dk2,
            string dk3)
        {
            using (var context = new CanDBContext())
            {
                var query = context.PhieuThus.AsQueryable();

                // Không có bộ lọc, chỉ lấy tất cả các bản ghi
                var result = query.Select(tk => new PhieuThu
                {
                    maKH = dk1 != null ? EF.Property<string>(tk, dk1) : tk.maKH,
                    maMayXay = dk1 != null ? EF.Property<string>(tk, dk2) : tk.maMayXay,
                    maSP = dk1 != null ? EF.Property<string>(tk, dk3) : tk.maSP,

                    //KhoiLuongTanXuat = selectedColumnMayXay != null ? EF.Property<double>(tk, selectedColumnMayXay) : tk.KhoiLuongTanXuat,
                    //KhoiLuongM3Xuat = selectedColumnSanPham != null ? EF.Property<double>(tk, selectedColumnSanPham) : tk.KhoiLuongM3Xuat,
                    tienThanhToan = tk.tienThanhToan
                }).ToList();

                return result;
            }
        }

        private void FrmDoanhSo_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
