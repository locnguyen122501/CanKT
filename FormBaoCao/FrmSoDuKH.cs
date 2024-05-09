using CanKT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT.FormBaoCao
{
    public partial class FrmSoDuKH : Form
    {
        CanDBContext db = new CanDBContext();

        CultureInfo cultureInfo = new CultureInfo("vi-VN");
        public FrmSoDuKH()
        {
            InitializeComponent();
        }

        //load data dua theo ma KH va ngay duoc chon tu dtp
        private void txbMaKH_TextChanged(object sender, EventArgs e)
        {
            string maKH = txbMaKH.Text;
            string tenKH = GetTenKHFromMaKH(maKH);

            txbTenKH.Text = tenKH.ToString();

            using (var db = new CanDBContext())
            {
                var hmcn = db.HanMucCongNoes.FirstOrDefault(h => h.maCongNo == maKH);

                if (hmcn != null)
                {
                    if (hmcn.ngay != dtpNgay.Value.Date)
                    {
                        txbTienNop.Text = "0";
                        txbSLTan.Text = "0";
                        txbSLM3.Text = "0";
                        txbThanhTien.Text = "0";
                        txbTienConLai.Text = "0";
                    }
                    else
                    {
                        decimal tiennop = (decimal)hmcn.soTienNop;
                        txbTienNop.Text = tiennop.ToString("N0",cultureInfo);

                        decimal sltan = (decimal) hmcn.soLuongTanXuat;
                        txbSLTan.Text = sltan.ToString(cultureInfo);

                        decimal slm3 = (decimal)hmcn.soLuongM3Xuat;
                        txbSLM3.Text = slm3.ToString(cultureInfo);

                        decimal thanhtien = (decimal)hmcn.thanhTien;
                        txbThanhTien.Text = thanhtien.ToString("N0", cultureInfo);

                        decimal tienconlai = (decimal)hmcn.tienConLai;
                        txbTienConLai.Text = tienconlai.ToString("N0", cultureInfo);
                    }
                }
                else
                {
                    txbTienNop.Text = "0";
                    txbSLTan.Text = "0";
                    txbSLM3.Text = "0";
                    txbThanhTien.Text = "0";
                    txbTienConLai.Text = "0";
                }
            }
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            string maKH = txbMaKH.Text;
            string tenKH = GetTenKHFromMaKH(maKH);

            txbTenKH.Text = tenKH.ToString();

            using (var db = new CanDBContext())
            {
                var hmcn = db.HanMucCongNoes.FirstOrDefault(h => h.maCongNo == maKH);

                if (hmcn != null)
                {
                    if (hmcn.ngay != dtpNgay.Value.Date)
                    {
                        txbTienNop.Text = "0";
                        txbSLTan.Text = "0";
                        txbSLM3.Text = "0";
                        txbThanhTien.Text = "0";
                        txbTienConLai.Text = "0";
                    }
                    else
                    {
                        decimal tiennop = (decimal)hmcn.soTienNop;
                        txbTienNop.Text = tiennop.ToString("N0", cultureInfo);

                        decimal sltan = (decimal)hmcn.soLuongTanXuat;
                        txbSLTan.Text = sltan.ToString(cultureInfo);

                        decimal slm3 = (decimal)hmcn.soLuongM3Xuat;
                        txbSLM3.Text = slm3.ToString(cultureInfo);

                        decimal thanhtien = (decimal)hmcn.thanhTien;
                        txbThanhTien.Text = thanhtien.ToString("N0", cultureInfo);

                        decimal tienconlai = (decimal)hmcn.tienConLai;
                        txbTienConLai.Text = tienconlai.ToString("N0", cultureInfo);
                    }
                }
                else
                {
                    txbTienNop.Text = "0";
                    txbSLTan.Text = "0";
                    txbSLM3.Text = "0";
                    txbThanhTien.Text = "0";
                    txbTienConLai.Text = "0";
                }
            }
        }

        private string GetTenKHFromMaKH(string maKH)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy tên khách hàng từ mã khách hàng
            // Sau đó trả về tên khách hàng tương ứng

            string tenKH = "";

            using (var db = new CanDBContext())
            {
                var khachhang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == maKH);

                if (khachhang != null)
                {
                    tenKH = khachhang.tenKH;
                }
            }
            return tenKH;
        }

        //chuyen in hoa
        private void txbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            string makh = txbMaKH.Text;
            DateTime ngay = dtpNgay.Value.Date;
            decimal tiennop = (decimal)int.Parse(txbTienNop.Text.Replace(".", ""));
            decimal tienconlai = (decimal)int.Parse(txbTienConLai.Text.Replace(".", ""));

            using (var db = new CanDBContext())
            {
                var hmcn = db.HanMucCongNoes.FirstOrDefault(h => h.maCongNo == makh);

                if (hmcn != null)
                {
                    if (hmcn.ngay != DateTime.Now.Date)
                    {
                        hmcn.ngay = ngay;
                        hmcn.soTienNop = 0;
                        hmcn.soLuongTanXuat = 0;
                        hmcn.soLuongM3Xuat = 0;
                        hmcn.thanhTien = 0;
                    }
   
                    hmcn.soTienNop = hmcn.soTienNop + tiennop;
                    hmcn.tienConLai = tiennop + hmcn.tienConLai;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    load_data();
                }
            }
        }

        private void load_data()
        {
            string maKH = txbMaKH.Text;
            string tenKH = GetTenKHFromMaKH(maKH);

            txbTenKH.Text = tenKH.ToString();

            using (var db = new CanDBContext())
            {
                var hmcn = db.HanMucCongNoes.FirstOrDefault(h => h.maCongNo == maKH);

                if (hmcn != null)
                {
                    if (hmcn.ngay != dtpNgay.Value.Date)
                    {
                        txbTienNop.Text = "0";
                        txbSLTan.Text = "0";
                        txbSLM3.Text = "0";
                        txbThanhTien.Text = "0";
                        txbTienConLai.Text = "0";
                    }
                    else
                    {
                        decimal tiennop = (decimal)hmcn.soTienNop;
                        txbTienNop.Text = tiennop.ToString("N0", cultureInfo);

                        decimal sltan = (decimal)hmcn.soLuongTanXuat;
                        txbSLTan.Text = sltan.ToString(cultureInfo);

                        decimal slm3 = (decimal)hmcn.soLuongM3Xuat;
                        txbSLM3.Text = slm3.ToString(cultureInfo);

                        decimal thanhtien = (decimal)hmcn.thanhTien;
                        txbThanhTien.Text = thanhtien.ToString("N0", cultureInfo);

                        decimal tienconlai = (decimal)hmcn.tienConLai;
                        txbTienConLai.Text = tienconlai.ToString("N0", cultureInfo);
                    }
                }
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
