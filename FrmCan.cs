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

        public FrmCan(string tentaikhoan)
        {
            InitializeComponent();

            lblWelcome.Text = "Xin chào " + tentaikhoan;

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
                //row.Cells["Column4"].Value = tlxevao.ToString();

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
                txbTLXeVao.Text = selectedRow.Cells["Column4"].Value.ToString();
                txbTLXeRa.Text = selectedRow.Cells["Column5"].Value.ToString();
                txbMaSP.Text = selectedRow.Cells["Column6"].Value.ToString();
                txbDonGia.Text = selectedRow.Cells["Column7"].Value.ToString();
                txbSoLuongTan.Text = selectedRow.Cells["Column8"].Value.ToString();
                txbSoLuongM3.Text = selectedRow.Cells["Column9"].Value.ToString();
                //txbTienHang.Text = selectedRow.Cells["Column10"].Value.ToString();
                txbTienHang.Text = string.Format("{0:N0}", (selectedRow.Cells["Column10"].Value));
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
                txbTLXeVao.Text = selectedRow.Cells["Column4"].Value.ToString();
                txbTLXeRa.Text = selectedRow.Cells["Column5"].Value.ToString();
                txbMaSP.Text = selectedRow.Cells["Column6"].Value.ToString();
                txbDonGia.Text = selectedRow.Cells["Column7"].Value.ToString();
                txbSoLuongTan.Text = selectedRow.Cells["Column8"].Value.ToString();
                txbSoLuongM3.Text = selectedRow.Cells["Column9"].Value.ToString();
                //txbTienHang.Text = selectedRow.Cells["Column10"].Value.ToString("N0");
                txbTienHang.Text = string.Format("{0:N0}", (selectedRow.Cells["Column10"].Value));

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
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy lệnh xuất từ mã phiếu thu
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
            decimal tien;
            string temp = "";

            // Kiểm tra xem giá trị của hai txb có thể được chuyển đổi thành số không
            if (decimal.TryParse(txbDonGia.Text.Replace(",", ""), out decimal value1) && decimal.TryParse(txbSoLuongTan.Text.Replace(",", ""), out decimal value2))
            {
                // Tính tích của hai giá trị và gán kết quả vào txbtienhang
                tien = value1 * value2;               

                //txbTienHang.Text = tien.ToString("N0", CultureInfo.InvariantCulture);
                txbTienHang.Text = tien.ToString("N0");
                temp = txbTienHang.ToString();
                temp = temp.TrimEnd('0').TrimEnd(',');
            }
            else
            {
                // Nếu một trong hai TextBox không thể chuyển đổi thành số, gán giá trị rỗng
                txbTienHang.Text = "";
            }
        }

        private void txbTienHang_TextChanged(object sender, EventArgs e)
        {
            TinhTienThanhToan();
        }

        private void TinhTienThanhToan()
        {
            // Kiểm tra xem giá trị của hai txb có thể được chuyển đổi thành số không
            if (decimal.TryParse(txbTienHang.Text.Replace(",", ""), out decimal value1))
            {
                decimal tien = value1 + (value1 * (decimal)0.0999998833852334);
                // Tính tích của hai giá trị và gán kết quả vào txbthanhtoan

                txbThanhToan.Text = tien.ToString("N0");               
            }
            else
            {
                // Nếu không thể chuyển đổi thành số, gán giá trị rỗng cho txb
                txbThanhToan.Text = "0";
            }
        }

        private void ChuyenDoiTanM3()
        {
            string maSP = txbMaSP.Text;

            // Truy vấn dữ liệu từ bảng khác để lấy hệ số tương ứng
            string heSo = GetHeSoFromMaSP(maSP);
            double temp = double.Parse(heSo);

                
            // Kiểm tra xem giá trị của hai txb có thể được chuyển đổi thành số không
            if (double.TryParse(txbSoLuongTan.Text.Replace(",", ""), out double value1))
            {
                double m3 = (value1)/(temp);
                // Tính tích của hai giá trị và gán kết quả vào txbsoluongm3

                txbSoLuongM3.Text = m3.ToString("N0");
            }
            else
            {
                // Nếu không thể chuyển đổi thành số, gán giá trị rỗng cho txb
                txbSoLuongM3.Text = "";
            }
        }

        private string GetHeSoFromMaSP(string maSP)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy hệ số từ mã sản phẩm
            // Sau đó trả về hệ số tương ứng
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
            string giaSP = GetGiaFromMaSP(maSP);

            txbTenSP.Text = tenSP.ToString();
            txbDonGia.Text = giaSP.ToString();
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

        private string GetGiaFromMaSP(string maSP)
        {
            string giaSP = "";

            using (var db = new CanDBContext())
            {
                var gia = db.Gias.FirstOrDefault(g => g.maThanhPham == maSP);

                if (gia != null)
                {
                    giaSP = string.Format("{0:#,##0}", gia.donGia);
                }
            }
            return giaSP;
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

        private void txbTLXeRa_TextChanged(object sender, EventArgs e)
        {
            int soluongtan;

            // Loại bỏ dấu phân tách hàng nghìn và chuyển đổi về kiểu số nguyên
            
            

            int trongluongxevao;
            //if (int.TryParse(txbTLXeVao.Text, out trongluongxevao))
            //{
            //    int tlxevao = int.Parse(trongluongxevao.Replace(",", ""));
            //}

            if (int.TryParse(txbTLXeVao.Text.Replace(",", ""), out trongluongxevao))
            {

            }

            int trongluongxera;
            if (int.TryParse(txbTLXeRa.Text.Replace(",", ""), out trongluongxera))
            {

            }

            soluongtan = trongluongxera - trongluongxevao;
            txbSoLuongTan.Text = soluongtan.ToString("N0");
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

        private void txbMaXeXuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbSalan.Focus();
            }
        }

        private void txbSalan_KeyDown(object sender, KeyEventArgs e)
        {
            themData();
        }
        #endregion

        //next

        private void btnXong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themData()
        {
            string maphieu = txbMaPhieu.Text;
            string soxe = txbSoXe.Text;

            int trongluongxevao = int.Parse(txbTLXeVao.Text.Replace(",", ""));
            int trongluongxera = int.Parse(txbTLXeRa.Text.Replace(",", ""));

            string lenhxuat = txbLenhXuat.Text;
            string makh = txbMaKH.Text;
            string masp = txbMaSP.Text;
            int soluongtan = int.Parse(txbSoLuongTan.Text.Replace(",", ""));
            int soluongm3 = int.Parse(txbSoLuongM3.Text.Replace(",", ""));
            decimal dongia = decimal.Parse(txbDonGia.Text);
            dongia = Math.Round(dongia / 1000) * 1000;
            decimal thanhtien = decimal.Parse(txbTienHang.Text);
            thanhtien = Math.Round(thanhtien / 1000) * 1000;
            decimal thanhtoan = decimal.Parse(txbThanhToan.Text);
            thanhtoan = Math.Round(thanhtoan / 1000) * 1000;
            string makho = txbMaKho.Text;
            string mamayxay = txbMaMayXay.Text;
            string mamayxuc = txbMaXeXuc.Text;

            // Tạo đối tượng mới từ dữ liệu đã nhận được
            PhieuThu phieuThu = new PhieuThu
            {
                maDon = maphieu,
                bienSoXe = soxe,
                trongLuongXeVao = trongluongxevao,
                trongLuongXeRa = trongluongxera,
                lenhXuat = lenhxuat,
                maKH = makh,
                maSP = masp,
                soLuongTan = soluongtan,
                soLuongM3 = soluongm3,
                donGia = dongia,
                thanhTien = thanhtien,
                tienThanhToan = thanhtoan,
                maKho = makho,
                maMayXay = mamayxay,
                maMayXuc = mamayxuc,

            };

            // Thêm đối tượng vào cơ sở dữ liệu bằng Entity Framework
            using (var db = new CanDBContext())
            {
                db.PhieuThus.Add(phieuThu);
                db.SaveChanges();
            }

            // Thông báo thành công
            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa dữ liệu trong các textbox sau khi thêm thành công (tuỳ chọn)
            txbSoXe.Clear();
            LoadDataIntoDataGridView();

        }

        #region KeyPressChuyenInHoa
        private void txbSoXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txbMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txbMaKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txbMaMayXay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txbMaXeXuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
        #endregion

        #region KeyLeaveThemdauphay
        private void txbTLXeVao_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbTLXeVao.Text, out int tlvao))
            {
                txbTLXeVao.Text = tlvao.ToString("N0");
            }
        }

        private void txbTLXeRa_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbTLXeRa.Text, out int tlra))
            {
                txbTLXeRa.Text = tlra.ToString("N0");
            }
        }
        #endregion
    }
}
