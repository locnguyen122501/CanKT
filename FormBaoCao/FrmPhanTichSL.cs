using CanKT.FormChucNang;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CanKT.FormBaoCao
{
    public partial class FrmPhanTichSL : Form
    {
        CanDBContext db = new CanDBContext();

        // Dictionary để lưu trữ trạng thái của từng mục trong ComboBox
        Dictionary<string, bool> itemStatus = new Dictionary<string, bool>();

        // Danh sách để lưu trữ các mục đã bị loại bỏ
        List<string> removedItems = new List<string>();
        public FrmPhanTichSL()
        {
            InitializeComponent();

            InitializeItemStatus();
        }

        private void FrmPhanTichSL_Load(object sender, EventArgs e)
        {

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

        //chuyen in hoa
        private void txbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void cbxDK2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDK2.Checked == true)
            {
                cbbDK2.Enabled = true;
            }
            else
            {
                cbbDK2.Enabled = false;
            }      
        }

        private void cbxDK3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDK3.Checked == true)
            {
                cbbDK3.Enabled = true;
            }
            else
            {
                cbbDK3.Enabled = false;
            }
        }

        // Khởi tạo trạng thái ban đầu của các mục trong ComboBox
        private void InitializeItemStatus()
        {
            foreach (var item in cbbDK1.Items)
            {
                itemStatus.Add(item.ToString(), true);
            }
        }

        private void cbbDK1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDK2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDK3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            DateTime ngaydau = dtpNgayDau.Value.Date;
            DateTime ngaysau = dtpNgayCuoi.Value.Date;

            string makh = txbMaKH.ToString();

            string DK1 = "";
            string DK2 = "";
            string DK3 = "";

            //lay lua chon tu cbb
            switch (cbbDK1.SelectedItem.ToString())
            {
                case "Khách hàng":
                    DK1 = "maKH";
                    break;
                case "Số xe":
                    DK1 = "bienSoXe";
                    break;
                case "Sản phẩm":
                    DK1 = "maSP";
                    break;
                case "Kho":
                    DK1 = "maKho";
                    break;
                case "Máy xay":
                    DK1 = "maMayXay";
                    break;
                case "Xe xúc":
                    DK1 = "maMayXuc";
                    break;
                default:
                    break;
            }
            switch (cbbDK2.SelectedItem.ToString())
            {
                case "Khách hàng":
                    DK2 = "maKH";
                    break;
                case "Số xe":
                    DK2 = "bienSoXe";
                    break;
                case "Sản phẩm":
                    DK2 = "maSP";
                    break;
                case "Kho":
                    DK2 = "maKho";
                    break;
                case "Máy xay":
                    DK2 = "maMayXay";
                    break;
                case "Xe xúc":
                    DK2 = "maMayXuc";
                    break;
                default:
                    break;
            }
            switch (cbbDK3.SelectedItem.ToString())
            {
                case "Khách hàng":
                    DK3 = "maKH";
                    break;
                case "Số xe":
                    DK3 = "bienSoXe";
                    break;
                case "Sản phẩm":
                    DK3 = "maSP";
                    break;
                case "Kho":
                    DK3 = "maKho";
                    break;
                case "Máy xay":
                    DK3 = "maMayXay";
                    break;
                case "Xe xúc":
                    DK3 = "maMayXuc";
                    break;
                default:
                    break;
            }

            int khongintien = 0;
            int sotien = 0;

            if (cbxKhongInTien.Checked == true)
            {
                khongintien = 0; //khong in
            }
            else
            {
                khongintien = 1; //in
            }

            if (rdbKhongThue.Checked == true)
            {
                sotien = 0; //thanh tien
            }
            else
            {
                sotien = 1; //rdbCoThue duoc check => tien thanh toan
            }

            FrmDoanhSo frmDoanhSo = new FrmDoanhSo();
            frmDoanhSo.loadData(ngaydau, ngaysau, makh, DK1, DK2, DK3, khongintien, sotien);
            frmDoanhSo.Show();
        }
    }
}
