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
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace CanKT.FormChucNang
{
    public partial class FrmDoanhSo : Form
    {
        CanDBContext db = new CanDBContext();

        DateTime ngayDau;
        DateTime ngaySau;
        string maKH;
        string DK1, DK2, DK3 = "";
        int khongInTien, soTien = 0;

        public FrmDoanhSo(DateTime ngaydau, DateTime ngaysau, string makh, string dk1, string dk2,
            string dk3, int khongintien, int sotien)
        {
            InitializeComponent();

            ngayDau = ngaydau;
            ngaySau = ngaysau;
            maKH = makh;
            DK1 = dk1;
            DK2 = dk2;
            DK3 = dk3;
            khongInTien = khongintien;
            soTien = sotien;
        }

        private List<PhieuThu> GetThongKeData(string makh, string dk1, string dk2,
            string dk3)
        {
            using (var context = new CanDBContext())
            {
                var query = context.PhieuThus.AsQueryable();

                if (!string.IsNullOrEmpty(dk1))
                {
                    query = query.Where(BuildPredicate<PhieuThu>(dk1));
                }

                if (!string.IsNullOrEmpty(dk2))
                {
                    //query = query.Where(BuildPredicate<PhieuThu>(dk2));
                    dk1 = dk1 + "\n\t" + dk2;
                }

                if (!string.IsNullOrEmpty(dk3))
                {
                    //query = query.Where(BuildPredicate<PhieuThu>(dk3));
                    dk1 = dk1 + "\n\t" + dk3;
                }
                return query.ToList();
            }
        }

        private Expression<Func<T, bool>> BuildPredicate<T>(string propertyName)
        {
            var param = Expression.Parameter(typeof(T), "t");
            var property = Expression.Property(param, propertyName);
            var notNull = Expression.NotEqual(property, Expression.Constant(null));
            return Expression.Lambda<Func<T, bool>>(notNull, param);
        }

        private void FrmDoanhSo_Load(object sender, EventArgs e)
        {
            var thongKeData = GetThongKeData(maKH, DK1, DK2, DK3);

            var reportDataSource = new ReportDataSource("CanDBDataset", thongKeData);
            this.reportViewer.LocalReport.DataSources.Clear();
            ReportParameter pNgayParameter = new ReportParameter("pNgay", DateTime.Today.ToString("dd-MM-yyyy"));
            this.reportViewer.LocalReport.SetParameters(new ReportParameter[] { pNgayParameter });
            ReportParameter pSTTParameter = new ReportParameter("pSTT", "1");
            this.reportViewer.LocalReport.SetParameters(new ReportParameter[] { pSTTParameter });
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.LocalReport.Refresh();
            this.reportViewer.RefreshReport();
        }
    }
}
