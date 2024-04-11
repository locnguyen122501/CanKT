using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;
using CanKT.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CanKT
{
    public partial class FrmCan : Form
    {
        CanDBContext db = new CanDBContext();

        //private string tentaikhoan;
        public FrmCan(string tentaikhoan)
        {
            InitializeComponent();

            lblWelcome.Text = "Xin chào " + tentaikhoan;

            //this.tentaikhoan = tentaikhoan;
            LoadDataIntoDataGridView();
        }


        private void FrmCan_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txbSoXe;
        }

        private void LoadDataIntoDataGridView()
        {
            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.PhieuThus.ToList();

            foreach (var item in data)
            {
                int rowIndex = dgvCan.Rows.Add(); //thêm một hàng mới vào dgv
                DataGridViewRow row = dgvCan.Rows[rowIndex]; //lấy hàng vừa thêm từ database

                //gán dữ liệu vào từng cell tương ứng trong hàng
                row.Cells["Column1"].Value = item.maDon; 
                row.Cells["Column2"].Value = item.bienSoXe;
                row.Cells["Column3"].Value = item.maKH;

                decimal tlxevao = Convert.ToDecimal(item.trongLuongXeVao);
                row.Cells["Column4"].Value = tlxevao.ToString("N0");

                decimal tlxera = Convert.ToDecimal(item.trongLuongXeRa);
                row.Cells["Column5"].Value = tlxera.ToString("N0");

                row.Cells["Column6"].Value = item.maSP;

                //dinh dang tien
                decimal donGia = Convert.ToDecimal(item.donGia); //chuyen kieu du lieu money sang decimal
                row.Cells["Column7"].Value = donGia.ToString("N0");

                decimal tan = Convert.ToDecimal(item.soLuongTan);
                row.Cells["Column8"].Value = tan.ToString("N0");

                decimal m3 = Convert.ToDecimal(item.soLuongM3);
                row.Cells["Column9"].Value = m3.ToString("N0");

                decimal thanhTien = Convert.ToDecimal(item.thanhTien); //chuyen kieu du lieu money sang decimal               
                row.Cells["Column10"].Value = thanhTien.ToString("N0");
            }
        }
       

        private void dgvCan_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (dgvCan.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvCan.SelectedRows[0];

                // Lấy dữ liệu từ các cột của dòng được chọn và đổ vào các txb
                txbMaPhieu.Text = selectedRow.Cells["Column1"].Value.ToString();
                txbSoXe.Text = selectedRow.Cells["Column2"].Value.ToString();
                txbMaKH.Text = selectedRow.Cells["Column3"].Value.ToString();
                txbTLXeRa.Text = selectedRow.Cells["Column4"].Value.ToString();
                txbTLXeVao.Text = selectedRow.Cells["Column5"].Value.ToString();
                txbMaSP.Text = selectedRow.Cells["Column6"].Value.ToString();
                txbDonGia.Text = selectedRow.Cells["Column7"].Value.ToString();
                txbSoLuongTan.Text = selectedRow.Cells["Column8"].Value.ToString();
                txbSoLuongM3.Text = selectedRow.Cells["Column9"].Value.ToString();
                txbTienHang.Text = selectedRow.Cells["Column10"].Value.ToString();

            }
        }

        private void dgvCan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã click vào dòng nào chưa
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được click
                DataGridViewRow selectedRow = dgvCan.Rows[e.RowIndex];

                // Đổ dữ liệu từ các cột của dòng được click vào các TextBox tương ứng
                txbMaPhieu.Text = selectedRow.Cells["Column1"].Value.ToString();
                txbSoXe.Text = selectedRow.Cells["Column2"].Value.ToString();
                txbMaKH.Text = selectedRow.Cells["Column3"].Value.ToString();
                txbTLXeRa.Text = selectedRow.Cells["Column4"].Value.ToString();
                txbTLXeVao.Text = selectedRow.Cells["Column5"].Value.ToString();
                txbMaSP.Text = selectedRow.Cells["Column6"].Value.ToString();
                txbDonGia.Text = selectedRow.Cells["Column7"].Value.ToString();
                txbSoLuongTan.Text = selectedRow.Cells["Column8"].Value.ToString();
                //txbSoLuongM3.Text = selectedRow.Cells["Column9"].Value.ToString();
                txbTienHang.Text = selectedRow.Cells["Column10"].Value.ToString();

                string lenhxuat = txbLenhXuat.Text;

                if (e.RowIndex >= 0)
                {
                    string maDon = dgvCan.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    string lenhXuat = GetLenhXuatFromPhieuThu(maDon);
                    txbLenhXuat.Text = lenhXuat;
                }

                if (e.RowIndex >= 0)
                {
                    // Lấy mã khách hàng từ cột "maKH" của dòng được chọn
                    string maKH = dgvCan.Rows[e.RowIndex].Cells["Column3"].Value.ToString();

                    // Truy vấn dữ liệu từ bảng khác để lấy tên khách hàng tương ứng
                    string tenKH = GetTenKHFromMaKH(maKH); // Thay thế hàm này bằng cách truy vấn thực tế từ cơ sở dữ liệu của bạn

                    // Đổ dữ liệu tên khách hàng vào TextBox tương ứng
                    txbTenKH.Text = tenKH;
                }
            }
        }

        private string GetLenhXuatFromPhieuThu(string maDon)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy tên khách hàng từ mã khách hàng
            // Ví dụ:
            // SELECT tenKH FROM TenBangKhachHang WHERE maKH = 'maKH';
            // Sau đó trả về tên khách hàng tương ứng

            string lenhXuat = "";

            using (var db = new CanDBContext())
            {
                var phieuThu = db.PhieuThus.FirstOrDefault(kh => kh.maDon == maDon);

                if (phieuThu != null)
                {
                    lenhXuat = phieuThu.lenhXuat;
                }
            }
            return lenhXuat;
        }

        private string GetTenKHFromMaKH(string maKH)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy tên khách hàng từ mã khách hàng
            // Ví dụ:
            // SELECT tenKH FROM TenBangKhachHang WHERE maKH = 'maKH';
            // Sau đó trả về tên khách hàng tương ứng

            string tenKH = "";

            using (var db = new CanDBContext()) 
            {
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == maKH);

                if (khachHang != null)
                {
                    tenKH = khachHang.tenKH;
                }
            }
            return tenKH;
        }

        private void txbDonGia_TextChanged(object sender, EventArgs e)
        {
            TinhTienHang();
        }

        private void txbSoLuongTan_TextChanged(object sender, EventArgs e)
        {
            TinhTienHang();
            ChuyenDoiTanM3();
        }

        private void TinhTienHang()
        {
            // Kiểm tra xem giá trị của hai TextBox có thể được chuyển đổi thành số không
            if (double.TryParse(txbDonGia.Text, out double value1) && double.TryParse(txbSoLuongTan.Text, out double value2))
            //if(double.TryParse(txbDonGia.Text, out double value1))
            {
                double tien = value1 * value2;

                //txbTienHang.Text = tien.ToString("N0");
                //double tien = value1 * 100;
                // Tính tích của hai giá trị và gán kết quả vào TextBox thứ ba

                txbTienHang.Text = tien.ToString("N0", CultureInfo.InvariantCulture);
            }
            else
            {
                // Nếu một trong hai TextBox không thể chuyển đổi thành số, gán giá trị rỗng cho TextBox thứ ba
                txbTienHang.Text = "";
            }
        }

        private void txbTienHang_TextChanged(object sender, EventArgs e)
        {
            TinhTienThanhToan();
        }

        private void TinhTienThanhToan()
        {
            // Kiểm tra xem giá trị của hai TextBox có thể được chuyển đổi thành số không
            if (double.TryParse(txbTienHang.Text, out double value1))
            {
                double tien = value1 + (value1*0.0999998833852334);
                // Tính tích của hai giá trị và gán kết quả vào TextBox thứ ba

                txbThanhToan.Text = tien.ToString("N0");
            }
            else
            {
                // Nếu một trong hai TextBox không thể chuyển đổi thành số, gán giá trị rỗng cho TextBox thứ ba
                txbThanhToan.Text = "";
            }
        }

        private void ChuyenDoiTanM3()
        {
            string maSP = txbMaSP.Text;

                // Truy vấn dữ liệu từ bảng khác để lấy tên khách hàng tương ứng
            string heSo = GetHeSoFromMaSP(maSP);
            double temp = double.Parse(heSo);

                
            // Kiểm tra xem giá trị của hai TextBox có thể được chuyển đổi thành số không
            if (double.TryParse(txbSoLuongTan.Text, out double value1))
            {
                double m3 = (value1)/(temp);
                // Tính tích của hai giá trị và gán kết quả vào TextBox thứ ba

                txbSoLuongM3.Text = m3.ToString("N0");
            }
            else
            {
                // Nếu một trong hai TextBox không thể chuyển đổi thành số, gán giá trị rỗng cho TextBox thứ ba
                txbSoLuongM3.Text = "";
            }
        }

        private string GetHeSoFromMaSP(string maSP)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy tên khách hàng từ mã khách hàng
            // Ví dụ:
            // SELECT tenKH FROM TenBangKhachHang WHERE maKH = 'maKH';
            // Sau đó trả về tên khách hàng tương ứng
            string ma = maSP;

            double heSo = 0;

            using (var db = new CanDBContext())
            {
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.maThanhPham == ma);

                if (sanPham != null)
                {
                    heSo = (double)sanPham.heSoQuyDoi;
                }
            }

            String temp = heSo.ToString();

            return temp;
        }

        private void txbMaSP_TextChanged(object sender, EventArgs e)
        {
            string maSP = txbMaSP.Text;
            string tenSP = GetTenSPFromMaSP(maSP);

            txbTenSP.Text = tenSP.ToString();
        }

        private string GetTenSPFromMaSP(string maSP)
        {
            string tenSP = "";

            using (var db = new CanDBContext())
            {
                var sanpham = db.SanPhams.FirstOrDefault(sp => sp.maThanhPham == maSP);

                if (sanpham != null)
                {
                    tenSP = sanpham.tenThanhPham;
                }
            }
            return tenSP;
        }

        private void txbMaPhieu_TextChanged(object sender, EventArgs e)
        {
            string maPhieu = txbMaPhieu.Text;
            string maKho = GetMaKhoFromMaPhieu(maPhieu);
            string maMayXay = GetMaMayXayFromMaPhieu(maPhieu);
            string maMayXuc = GetMaMayXucFromMaPhieu(maPhieu);

            txbMaKho.Text = maKho.ToString();
            txbMaMayXay.Text = maMayXay.ToString();
            txbMaXeXuc.Text = maMayXuc.ToString();
        }

        private string GetMaKhoFromMaPhieu(string maPhieu)
        {
            string maKho = "";

            using (var db = new CanDBContext())
            {
                var phieuthu = db.PhieuThus.FirstOrDefault(p => p.maDon == maPhieu);

                if (phieuthu != null)
                {
                    maKho = phieuthu.maKho;
                }
            }
            return maKho;
        }

        private string GetMaMayXayFromMaPhieu(string maPhieu)
        {
            string maMXay = "";

            using (var db = new CanDBContext())
            {
                var phieuthu = db.PhieuThus.FirstOrDefault(p => p.maDon == maPhieu);

                if (phieuthu != null)
                {
                    maMXay = phieuthu.maMayXay;
                }
            }
            return maMXay;
        }

        private string GetMaMayXucFromMaPhieu(string maPhieu)
        {
            string maMXuc = "";

            using (var db = new CanDBContext())
            {
                var phieuthu = db.PhieuThus.FirstOrDefault(p => p.maDon == maPhieu);

                if (phieuthu != null)
                {
                    maMXuc = phieuthu.maMayXuc;
                }
            }
            return maMXuc;
        }


        //lay ten kho tu ma kho
        private void txbMaKho_TextChanged(object sender, EventArgs e)
        {
            string maKho = txbMaKho.Text;
            string tenKho = GetTenKhoFromMaKho(maKho);

            txbTenKho.Text = tenKho.ToString();
        }

        private string GetTenKhoFromMaKho(string maKho)
        {
            string tenKho = "";

            using (var db = new CanDBContext())
            {
                var kho = db.Khoes.FirstOrDefault(p => p.maKho == maKho);

                if (kho != null)
                {
                    tenKho = kho.tenKho;
                }
            }
            return tenKho;
        }

        //lay ten may xay tu ma may xay
        private void txbMaMayXay_TextChanged(object sender, EventArgs e)
        {
            string maMXay = txbMaMayXay.Text;
            string tenMXay = GetTenMayXayFromMaMayXay(maMXay);

            txbTenMayXay.Text = tenMXay.ToString();
        }

        private string GetTenMayXayFromMaMayXay(string maMXay)
        {
            string tenMXay = "";

            using (var db = new CanDBContext())
            {
                var mayxay = db.MayXays.FirstOrDefault(mx => mx.maMayXay == maMXay);

                if (mayxay != null)
                {
                    tenMXay = mayxay.tenMayXay;
                }
            }
            return tenMXay;
        }

        //lay ten may xuc tu ma may xuc
        private void txbMaXeXuc_TextChanged(object sender, EventArgs e)
        {
            string maMXuc = txbMaXeXuc.Text;
            string tenMXuc = GetTenXeXucFromMaXeXuc(maMXuc);

            txbTenXeXuc.Text = tenMXuc.ToString();
        }

        private string GetTenXeXucFromMaXeXuc(string maMXuc)
        {
            string tenMXuc = "";

            using (var db = new CanDBContext())
            {
                var mayxuc = db.XeXucs.FirstOrDefault(xx => xx.maXeXuc == maMXuc);

                if (mayxuc != null)
                {
                    tenMXuc = mayxuc.tenXeXuc;
                }
            }
            return tenMXuc;
        }

        #region KeyDown_Code
        private void txbSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbTLXeVao.Focus();
            }
        }

        private void txbTLXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbTLXeRa.Focus();
            }
        }

        private void txbTLXeRa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaKH.Focus();
            }
        }

        private void txbMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbLenhXuat.Focus();
            }
        }

        private void txbLenhXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaSP.Focus();
            }
        }

        private void txbMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaKho.Focus();
            }
        }

        private void txbMaKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaMayXay.Focus();
            }
        }

        private void txbMaMayXay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaXeXuc.Focus();
            }
        }
        #endregion

        //next

        private void btnXong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
