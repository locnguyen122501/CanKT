using CanKT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT.FormBaoCao
{
    public partial class FrmSoDuKH : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmSoDuKH()
        {
            InitializeComponent();
        }

        private void txbMaKH_TextChanged(object sender, EventArgs e)
        {
            string maKH = txbMaKH.Text;
            string tenKH = GetTenKHFromMaKH(maKH);

            txbTenKH.Text = tenKH.ToString();
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
            DateTime ngay = dtpNgay.Value;
            decimal tiennop = (decimal)int.Parse(txbTienNop.Text.Replace(".", ""));
        }
    }
}
