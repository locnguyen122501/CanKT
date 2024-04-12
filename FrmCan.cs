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

            // Lấy mã phiếu tiếp theo từ cơ sở dữ liệu
            string nextMaPhieu = db.GetNextMaPhieu();

            // Gán mã phiếu vào textbox
            txbMaPhieu.Text = nextMaPhieu;
        }

        private void LoadDataIntoDataGridView()
        {
            dgvCan.Rows.Clear();

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
       
        //đổ dữ liệu lên các txb khi click vào dòng hoặc ô của phiếu tương ứng
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
                txbTienHang.Text = string.Format("{0:N0}", (selectedRow.Cells["Column10"].Value));

                string lenhxuat = txbLenhXuat.Text;                

                if (e.RowIndex >= 0)
                {
                    string maDon = dgvCan.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    string lenhXuat = GetLenhXuatFromPhieuThu(maDon);
                    txbLenhXuat.Text = lenhXuat;
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

        //xu ly khi nhap vao ma se load thong tin tuong ung
        //bao gom xu ly tinh tien hang, thanh toan
        #region xulytextchanged

        private void txbSoXe_TextChanged(object sender, EventArgs e)
        {
            string soXe = txbSoXe.Text;
            string maKH = GetMaKHFromMaXe(soXe);

            txbMaKH.Text = maKH.ToString();
        }

        private string GetMaKHFromMaXe(string soXe)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy tên khách hàng từ mã khách hàng
            // Sau đó trả về tên khách hàng tương ứng

            string maKH = "";

            using (var db = new CanDBContext())
            {
                var xe = db.Xes.FirstOrDefault(x => x.bienSoXe == soXe);

                if (xe != null)
                {
                    maKH = xe.maKH;
                }               
            }
            return maKH;
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

        private void txbDonGia_TextChanged(object sender, EventArgs e)
        {
            TinhTienHang();
        }

        private void txbSoLuongTan_TextChanged(object sender, EventArgs e)
        {
            TinhTienHang();            
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
                txbTienHang.Text = "0";
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

            ChuyenDoiTanM3();
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
            string giaSP = "0";

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

        private void ChuyenDoiTanM3()
        {
            string maSP = txbMaSP.Text;

            // Truy vấn dữ liệu từ bảng khác để lấy hệ số tương ứng
            string heSo = GetHeSoFromMaSP(maSP);
            double temp = double.Parse(heSo);


            // Kiểm tra xem giá trị của hai txb có thể được chuyển đổi thành số không
            if (double.TryParse(txbSoLuongTan.Text.Replace(",", ""), out double value1))
            {
                double m3 = (value1) / (temp);
                // Tính tích của hai giá trị và gán kết quả vào txbsoluongm3

                txbSoLuongM3.Text = m3.ToString("N0");
            }
            else
            {
                // Nếu không thể chuyển đổi thành số, gán giá trị rỗng cho txb
                txbSoLuongM3.Text = "0";
            }
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
        #endregion


        //an Enter de sang txb tiep theo
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

        //next
        private void btnXong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region buttonChucNang
        //them data vao db
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
            MessageBox.Show("Thêm phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa dữ liệu trong các textbox sau khi thêm thành công
            txbSoXe.Clear();
            txbTLXeVao.Text = "0";
            txbTLXeRa.Text = "0";
            txbLenhXuat.Clear();
            txbMaSP.Clear();
            txbSoLuongM3.Text = "0";
            txbMaKho.Clear();
            txbMaMayXay.Clear();
            txbMaXeXuc.Clear();

            // Lấy mã phiếu tiếp theo từ cơ sở dữ liệu
            string nextMaPhieu = db.GetNextMaPhieu();

            // Gán mã phiếu vào textbox
            txbMaPhieu.Text = nextMaPhieu;

            LoadDataIntoDataGridView();

        }


        //update db
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string maDon = txbMaPhieu.Text;

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

            // Truy vấn dữ liệu tương ứng từ cơ sở dữ liệu bằng mã sản phẩm
            using (var db = new CanDBContext())
            {
                var phieuthu = db.PhieuThus.FirstOrDefault(p => p.maDon == maDon); // Thay thế "Products" bằng tên bảng của bạn
                if (phieuthu != null)
                {
                    // Cập nhật các thuộc tính của đối tượng dữ liệu
                    phieuthu.bienSoXe = soxe;
                    phieuthu.trongLuongXeVao = trongluongxevao;
                    phieuthu.trongLuongXeRa = trongluongxera;
                    phieuthu.lenhXuat = lenhxuat;
                    phieuthu.maKH = makh;
                    phieuthu.maSP = masp;
                    phieuthu.soLuongTan = soluongtan;
                    phieuthu.soLuongM3 = soluongm3;
                    phieuthu.donGia = dongia;
                    phieuthu.thanhTien = thanhtien;
                    phieuthu.tienThanhToan = thanhtoan;
                    phieuthu.maKho = makho;
                    phieuthu.maMayXay = mamayxay;
                    phieuthu.maMayXuc = mamayxuc;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                }
            }

            // Thông báo thành công
            MessageBox.Show("Cập nhật phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lấy mã phiếu tiếp theo từ cơ sở dữ liệu
            string nextMaPhieu = db.GetNextMaPhieu();

            // Gán mã phiếu vào textbox
            txbMaPhieu.Text = nextMaPhieu;

            LoadDataIntoDataGridView();

            // Xóa dữ liệu trong các textbox sau khi update thành công
            txbSoXe.Clear();
            txbTLXeVao.Text = "0";
            txbTLXeRa.Text = "0";
            txbLenhXuat.Clear();
            txbMaSP.Clear();
            txbSoLuongM3.Text = "0";
            txbMaKho.Clear();
            txbMaMayXay.Clear();
            txbMaXeXuc.Clear();


            //khong update lai dgv
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //xoa du lieu theo dong duoc chon
            if (dgvCan.SelectedRows.Count > 0)
            {
                // Lấy ID hoặc thông tin cần thiết từ hàng được chọn
                string maphieu = dgvCan.SelectedRows[0].Cells["Column1"].Value.ToString();

                // Thực hiện xóa dữ liệu từ cơ sở dữ liệu
                if (XoaDuLieu(maphieu))
                {
                    // Nếu xóa thành công, cập nhật lại hiển thị trên DataGridView
                    MessageBox.Show("Xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDataIntoDataGridView();
                }
                else
                {
                    // Nếu xóa không thành công, hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi khi xóa dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //xoa du lieu theo o duoc chon
                if (dgvCan.SelectedCells.Count > 0)
                {

                    // Lấy chỉ số của ô đang được chọn
                    int selectedRowIndex = dgvCan.SelectedCells[0].RowIndex;

                    // Lấy giá trị của ô ID tương ứng trong hàng đó
                    string maphieu = dgvCan.Rows[selectedRowIndex].Cells["Column1"].Value.ToString();

                    // Thực hiện xóa dữ liệu từ cơ sở dữ liệu
                    if (XoaDuLieu(maphieu))
                    {
                        // Nếu xóa thành công, cập nhật lại hiển thị trên DataGridView
                        MessageBox.Show("Xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Lấy mã phiếu tiếp theo từ cơ sở dữ liệu
                        string nextMaPhieu = db.GetNextMaPhieu();

                        // Gán mã phiếu vào textbox
                        txbMaPhieu.Text = nextMaPhieu;

                        // Xóa dữ liệu trong các textbox sau khi update thành công
                        txbSoXe.Clear();
                        txbTLXeVao.Text = "0";
                        txbTLXeRa.Text = "0";
                        txbLenhXuat.Clear();
                        txbMaSP.Clear();
                        txbSoLuongM3.Text = "0";
                        txbMaKho.Clear();
                        txbMaMayXay.Clear();
                        txbMaXeXuc.Clear();

                        LoadDataIntoDataGridView();
                    }
                    else
                    {
                        // Nếu xóa không thành công, hiển thị thông báo lỗi
                        MessageBox.Show("Lỗi khi xóa dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool XoaDuLieu(string maphieu)
        {
            try
            {
                // Thực hiện xóa dữ liệu từ cơ sở dữ liệu bằng Entity Framework Core
                using (var db = new CanDBContext())
                {
                    var entity = db.PhieuThus.Find(maphieu);
                    if (entity != null)
                    {
                        db.PhieuThus.Remove(entity);
                        db.SaveChanges();

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
    }
}
