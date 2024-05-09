using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;
using CanKT.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using CanKT.FormChucNang;
using System.Data.Entity.Core.Objects;

namespace CanKT
{
    public partial class FrmCan : Form
    {
        CanDBContext db = new CanDBContext();

        CultureInfo cultureInfo = new CultureInfo("vi-VN");

        int prevMP = 0;

        string quyenuser = "";

        string tlbanthan, tlchophep = "";
        DateTime handangkiem;

        public FrmCan(string tentaikhoan, string quyen)
        {
            InitializeComponent();

            this.KeyPreview = true;

            quyenuser = quyen;

            if (quyenuser == "Admin")
            {
                lblWelcome.Text = "Admin " + tentaikhoan;
            }
            else
            {
                lblWelcome.Text = "Nhân viên " + tentaikhoan;
            }

            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            LoadDataIntoDataGridView();
            SetupAutoCompleteForTextBoxes();            
        }

        private void FrmCan_Load(object sender, EventArgs e)
        {
            // Lấy mã phiếu tiếp theo từ cơ sở dữ liệu và gán vào txb

            //vi khong co txb nen gan vao gia tri prevMP tao ben tren
            int prevMaPhieu = int.Parse(db.GetOldestMaPhieu());
            prevMP = prevMaPhieu;           

            if (dgvCan.Rows.Count > 0)
            {
                // Thiết lập chỉ số hàng đầu tiên được hiển thị là hàng cuối cùng
                dgvCan.FirstDisplayedScrollingRowIndex = dgvCan.Rows.Count - 1;
            }
        }

        public void LoadDataIntoDataGridView()
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
                row.Cells["Column4"].Value = tlxevao.ToString(cultureInfo);

                decimal tlxera = Convert.ToDecimal(item.trongLuongXeRa);
                row.Cells["Column5"].Value = tlxera.ToString(cultureInfo);

                row.Cells["Column6"].Value = item.maSP;

                //dinh dang tien
                decimal donGia = Convert.ToDecimal(item.donGia); //chuyen kieu du lieu money sang decimal
                row.Cells["Column7"].Value = donGia.ToString("N0",cultureInfo);

                decimal tan = Convert.ToDecimal(item.soLuongTan);
                row.Cells["Column8"].Value = tan.ToString(cultureInfo);

                decimal m3 = Convert.ToDecimal(item.soLuongM3);
                row.Cells["Column9"].Value = m3.ToString(cultureInfo);

                decimal thanhTien = Convert.ToDecimal(item.thanhTien); //chuyen kieu du lieu money sang decimal               
                row.Cells["Column10"].Value = thanhTien.ToString("N0", cultureInfo);
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
                //txbDonGia.Text = string.Format("{0:N0}", (selectedRow.Cells["Column7"].Value));
                txbSoLuongTan.Text = selectedRow.Cells["Column8"].Value.ToString();
                txbSoLuongM3.Text = selectedRow.Cells["Column9"].Value.ToString();
                txbTienHang.Text = string.Format("{0:N0}", (selectedRow.Cells["Column10"].Value));

                int trangthai = kiemTraTrangThaiPhieu();

                if (trangthai == 1)
                {
                    btnSua.Enabled = true;
                    btnIn.Enabled = true;

                    if (quyenuser == "Admin")
                    {
                        btnHuy.Enabled = true;
                    }
                }
                else
                {
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                    btnIn.Enabled = false;                   
                }
            }
        }

        private void dgvCan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã click vào dòng nào chưa
            if (e.RowIndex >= 0 && e.RowIndex < dgvCan.Rows.Count)
            {
                // Bỏ chọn tất cả các hàng trước đó
                dgvCan.ClearSelection();

                // Chọn hàng được click
                dgvCan.Rows[e.RowIndex].Selected = true;

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

                int trangthai = kiemTraTrangThaiPhieu();

                if (trangthai == 1)
                {
                    btnSua.Enabled = true;
                    btnIn.Enabled = true;

                    if (quyenuser == "Admin")
                    {
                        btnHuy.Enabled = true;
                    }
                }
                else
                {
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                    btnIn.Enabled = false;                   
                }

                string lenhxuat = txbLenhXuat.Text;                

                if (e.RowIndex >= 0)
                {
                    string maDon = dgvCan.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    string lenhXuat = GetLenhXuatFromPhieuThu(maDon);
                    txbLenhXuat.Text = lenhXuat;
                }
            }
        }
        
        private int kiemTraTrangThaiPhieu()
        {
            int trangthai = 0;

            string maphieu = txbMaPhieu.Text;

            var phieuthu = db.PhieuThus.FirstOrDefault(p => p.maDon == maphieu);

            if (phieuthu != null)
            {
                trangthai = (int) phieuthu.trangThai;
            }

            return trangthai;
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
            string ghiChu = GetThongSoFromMaXe(soXe);

            txbGhiChu.Text = ghiChu.ToString();
            txbMaKH.Text = maKH.ToString();
        }

        private string GetThongSoFromMaXe(string soXe)
        {
            // Thực hiện truy vấn tới cơ sở dữ liệu của bạn để lấy tên khách hàng từ mã khách hàng
            // Sau đó trả về tên khách hàng tương ứng

            string ghichu = "";
            

            using (var db = new CanDBContext())
            {
                var xe = db.Xes.FirstOrDefault(x => x.bienSoXe == soXe);

                if (xe != null)
                {
                    tlbanthan = xe.trongLuongBanThan.ToString();
                    tlchophep = xe.trongLuongChoPhep.ToString();

                    handangkiem = DateTime.Parse(xe.ngayKetDangKiem.ToString());

                    ghichu = tlbanthan + " - " + tlchophep + " - " + handangkiem;
                }
            }
            return ghichu;
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
            ChuyenDoiTanM3();
        }

        private void TinhTienHang()
        {
            decimal tien;

            // Kiểm tra xem giá trị của hai txb có thể được chuyển đổi thành số không
            if (decimal.TryParse(txbDonGia.Text.Replace(",", ""), out decimal value1) && decimal.TryParse(txbSoLuongTan.Text.Replace(",", ""), out decimal value2))
            {
                // Tính tích của hai giá trị và gán kết quả vào txbtienhang
                tien = value1 * value2;

                //txbTienHang.Text = tien.ToString("N0", cultureInfo).TrimEnd('0').TrimEnd(',');
                txbTienHang.Text = tien.ToString("#,0", cultureInfo);
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
            if (decimal.TryParse(txbTienHang.Text.Replace(".", ""), out decimal value1))
            {
                decimal tien = value1 + (value1 * (decimal)0.0999998833852334);
                // Tính tích của hai giá trị và gán kết quả vào txbthanhtoan

                txbThanhToan.Text = tien.ToString("#,0", cultureInfo);
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
                    giaSP = string.Format(cultureInfo,"{0:#,##0}", gia.donGia);
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

            kiemTraPhieuMoiNhat();
            kiemTraPhieuCuNhat(prevMP);
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

        //an Enter de sang txb tiep theo, Escape de ve txb truoc
        #region KeyDown_Code
        private void txbSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox

                txbSoXe_TextChanged(sender, e);

                //neu xe chua dang ky thi se dang ky
                string bienso = txbSoXe.Text;

                var xe = db.Xes.FirstOrDefault(x => x.bienSoXe == bienso);

                if (xe != null)
                {
                    txbMaSP.Focus();
                    serialPort1_Open();
                }
                else
                {
                    FrmDangKyXe frmDangKyXe = new FrmDangKyXe(bienso);
                    frmDangKyXe.ShowDialog();
                }
            }
        }

        private void txbTLXeVao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaSP.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbSoXe.Focus();
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

                string temp = txbLenhXuat.Text;

                var lenhxuat = db.NhapXuats.FirstOrDefault(l => l.maNhapXuat == temp);

                if (lenhxuat != null)
                {
                    MessageBox.Show("Lệnh xuất này đã bị trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbLenhXuat.Clear();
                    txbLenhXuat.Focus();
                }
                else
                {
                    txbMaSP.Focus();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMaKH.Focus();
            }
        }

        private void txbMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaKho.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbLenhXuat.Focus();
            }
        }

        private void txbMaKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaMayXay.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMaSP.Focus();
            }
        }

        private void txbMaMayXay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbMaXeXuc.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMaKho.Focus();
            }
        }

        private void txbMaXeXuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox
                txbSalan.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMaMayXay.Focus();
            }
        }

        private void txbSalan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Enter tạo ký tự mới trong TextBox

                string maphieu = txbMaPhieu.Text;

                //neu chua co ma phieu thi se them, neu co roi thi se cap nhat
                var phieu = db.PhieuThus.FirstOrDefault(u => u.maDon == maphieu);
                if (phieu != null)
                {
                    btnSua.PerformClick();
                }
                else
                {
                    themData();
                }
            }           

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // Ngăn không cho phím Escape tạo ký tự mới trong TextBox
                txbMaXeXuc.Focus();
            }
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

            // kiem tra tai trong
            
            decimal temp1 = (decimal)int.Parse(txbTLXeRa.Text.Replace(",", ""));

            var xe = db.Xes.FirstOrDefault(x => x.bienSoXe == txbSoXe.Text);

            decimal temp2 = Convert.ToDecimal(xe.trongLuongChoPhep.ToString().Replace(".", ""));

            if (xe != null && temp2 < temp1)
            {
                MessageBox.Show("Xe quá tải trọng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        //phim tat cho cac button chuc nang
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (ActiveControl is System.Windows.Forms.TextBox)
            {
                // Đang nhập trong TextBox, không xử lý các phím tắt
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                dgvCan.Focus();
            }

            //kiem tra da nhan Ctrl+P chua de trigger btnTimPhieu
            if (e.KeyCode == Keys.P)
            {
                btnTimPhieu.PerformClick();
            }

            //kiem tra da nhan Ctrl+A chua de tao moi phieu
            if (e.Control && e.KeyCode == Keys.A)
            {
                txbSoXe.Clear();
                txbTLXeVao.Text = "0";
                txbTLXeRa.Text = "0";
                txbLenhXuat.Clear();
                txbMaSP.Clear();
                txbSoLuongM3.Text = "0";
                txbMaKho.Clear();
                txbMaMayXay.Clear();
                txbMaXeXuc.Clear();

                this.ActiveControl = txbSoXe;
            }

            //kiem tra da nhan Ctrl+S chua de luu phieu
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSua.PerformClick();
            }

            //kiem tra da nhan Ctrl+D chua de xoa phieu
            if (e.Control && e.KeyCode == Keys.H)
            {
                btnHuy.PerformClick();
            }

            //kiem tra da nhan Ctrl+Q chua de trigger btnPhieuTruoc
            if (e.KeyCode == Keys.Q)
            {
                btnPhieuTruoc.PerformClick();
            }

            //kiem tra da nhan Ctrl+E chua de trigger btnPhieuSau
            if (e.KeyCode == Keys.E)
            {
                btnPhieuSau.PerformClick();
            }
        }

        //cac phim chuc nang
        #region buttonChucNang
        //them data vao db
        private void themData()
        {
            // string maphieu = txbMaPhieu.Text;

            string maphieu = GenerateTemporaryMaPhieu();

            string soxe = txbSoXe.Text;

            decimal trongluongxevao = Convert.ToDecimal(txbTLXeVao.Text.Replace(",", ""))/1000;

            string makh = txbMaKH.Text;
            string masp = txbMaSP.Text;

            //decimal dongia = decimal.Parse(txbDonGia.Text);
            decimal dongia = (decimal) int.Parse(txbDonGia.Text.Replace(".", ""));

            string makho = txbMaKho.Text;
            string mamayxay = txbMaMayXay.Text;
            string mamayxuc = txbMaXeXuc.Text;

            DateTime giovao = DateTime.Now;

            // Tạo đối tượng mới từ dữ liệu đã nhận được
            PhieuThu phieuThu = new PhieuThu
            {
                maDon = maphieu,
                bienSoXe = soxe,
                trongLuongXeVao = trongluongxevao,
                trongLuongXeRa = 0,
                maKH = makh,
                maSP = masp,
                donGia = dongia,
                soLuongTan = 0,
                soLuongM3 = 0,
                thanhTien = 0,
                tienThanhToan = 0,
                maKho = makho,
                maMayXay = mamayxay,
                maMayXuc = mamayxuc,
                thoiGianVao = giovao,
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

            LoadDataIntoDataGridView();
        }


        int flag = 0; //flag kiem tra cho btnIn

        //update db
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string newMaDon = GenerateOfficialMaPhieu();

            //maIn = newMaDon;

            string maphieu = txbMaPhieu.Text; //de lay phieu vao

            string backUpMaDon = maphieu;

            string soxe = txbSoXe.Text;

            decimal trongluongxevao = Convert.ToDecimal(txbTLXeVao.Text.Replace(",", ""))/1000;
            decimal trongluongxera = Convert.ToDecimal(txbTLXeRa.Text.Replace(",", ""))/1000;

            string lenhxuat = txbLenhXuat.Text;
            string makh = txbMaKH.Text;
            string masp = txbMaSP.Text;
            decimal soluongtan = Convert.ToDecimal(txbSoLuongTan.Text.Replace(",", ""))/1000;
            decimal soluongm3 = Convert.ToDecimal(txbSoLuongM3.Text.Replace(",", ""))/1000;
            decimal dongia = (decimal) int.Parse(txbDonGia.Text.Replace(".", ""));
            decimal thanhtien = (decimal) int.Parse(txbTienHang.Text.Replace(".", ""));
            decimal thanhtoan = (decimal) int.Parse(txbThanhToan.Text.Replace(".", ""));
            
            string makho = txbMaKho.Text;
            string mamayxay = txbMaMayXay.Text;
            string mamayxuc = txbMaXeXuc.Text;

            DateTime giora = DateTime.Now;

            int trangthai = 1;

            // Truy vấn dữ liệu tương ứng từ cơ sở dữ liệu bằng mã sản phẩm
            using (var db = new CanDBContext())
            {
                var newObj = new PhieuThu
                {
                    maDon = newMaDon,
                };

                var phieuthu = db.PhieuThus.FirstOrDefault(p => p.maDon == maphieu);

                if (phieuthu != null)
                {
                    if (quyenuser == "Admin")
                    {
                        flag = 1;

                        // Cập nhật các thuộc tính của đối tượng dữ liệu
                        if (phieuthu.trongLuongXeRa == 0)
                        {
                            phieuthu.thoiGianRa = giora;
                        }
                        phieuthu.bienSoXe = soxe;
                        phieuthu.trongLuongXeVao = trongluongxevao;
                        phieuthu.trongLuongXeRa = trongluongxera;

                        var xe = db.Xes.FirstOrDefault(x => x.bienSoXe == soxe);
                        if (xe != null && xe.trongLuongChoPhep < trongluongxera)
                        {
                            MessageBox.Show("Xe quá tải trọng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (phieuthu.lenhXuat == null)
                        {
                            phieuthu.lenhXuat = lenhxuat;

                            #region Tạo mã nhập xuất
                            // Tạo đối tượng mới từ dữ liệu đã nhận được
                            NhapXuat xuat = new NhapXuat
                            {
                                maNhapXuat = lenhxuat,
                                trangThai = 1,
                            };

                            // Thêm đối tượng vào db
                            using (var dbx = new CanDBContext())
                            {
                                dbx.NhapXuats.Add(xuat);
                                dbx.SaveChanges();
                            }
                            #endregion
                        }

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
                        phieuthu.trangThai = trangthai;

                        // Tạo đối tượng mới
                        var newPhieuThu = new PhieuThu();

                        // Copy các thuộc tính từ đối tượng cũ sang đối tượng mới
                        newPhieuThu.bienSoXe = phieuthu.bienSoXe;
                        newPhieuThu.trongLuongXeVao = phieuthu.trongLuongXeVao;
                        newPhieuThu.trongLuongXeRa = phieuthu.trongLuongXeRa;
                        newPhieuThu.lenhXuat = phieuthu.lenhXuat;
                        newPhieuThu.maKH = phieuthu.maKH;
                        newPhieuThu.maSP = phieuthu.maSP;
                        newPhieuThu.soLuongTan = phieuthu.soLuongTan;
                        newPhieuThu.soLuongM3 = phieuthu.soLuongM3;
                        newPhieuThu.donGia = phieuthu.donGia;
                        newPhieuThu.thanhTien = phieuthu.thanhTien;
                        newPhieuThu.tienThanhToan = phieuthu.tienThanhToan;
                        newPhieuThu.maKho = phieuthu.maKho;
                        newPhieuThu.maMayXay = phieuthu.maMayXay;
                        newPhieuThu.maMayXuc = phieuthu.maMayXuc;
                        newPhieuThu.thoiGianVao = phieuthu.thoiGianVao;
                        newPhieuThu.trangThai = phieuthu.trangThai;

                        // Thêm các thuộc tính mới cho đối tượng mới
                        newPhieuThu.maDon = backUpMaDon;
                        
                        newPhieuThu.thoiGianRa = giora;

                        // Thêm đối tượng mới vào cơ sở dữ liệu
                        db.PhieuThus.Add(newPhieuThu);

                        // Xóa đối tượng cũ
                        db.PhieuThus.Remove(phieuthu);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();

                        // Thông báo thành công
                        MessageBox.Show("Cập nhật phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnIn.PerformClick();
                    }
                    else
                    {
                        if (phieuthu.trongLuongXeRa == 0 && phieuthu.maDon.StartsWith("H"))
                        {
                            flag = 1;

                            phieuthu.trongLuongXeRa = trongluongxera;
                            phieuthu.lenhXuat = lenhxuat;

                            #region Tạo mã nhập xuất
                            // Tạo đối tượng mới từ dữ liệu đã nhận được
                            NhapXuat xuat = new NhapXuat
                            {
                                maNhapXuat = lenhxuat,
                                trangThai = 1,
                            };

                            // Thêm đối tượng vào db
                            using (var dbx = new CanDBContext())
                            {
                                dbx.NhapXuats.Add(xuat);
                                dbx.SaveChanges();
                            }
                            #endregion

                            phieuthu.soLuongTan = soluongtan;
                            phieuthu.soLuongM3 = soluongm3;
                            phieuthu.donGia = dongia;
                            phieuthu.thanhTien = thanhtien;
                            phieuthu.tienThanhToan = thanhtoan;
                            phieuthu.maSP = masp;
                            phieuthu.maKho = makho;
                            phieuthu.maMayXay = mamayxay;
                            phieuthu.maMayXuc = mamayxuc;
                            phieuthu.thoiGianRa = giora;
                            phieuthu.trangThai = trangthai;

                            // Tạo đối tượng mới
                            var newPhieuThu = new PhieuThu();

                            // Copy các thuộc tính từ đối tượng cũ sang đối tượng mới
                            newPhieuThu.bienSoXe = phieuthu.bienSoXe;
                            newPhieuThu.trongLuongXeVao = phieuthu.trongLuongXeVao;
                            newPhieuThu.trongLuongXeRa = phieuthu.trongLuongXeRa;
                            newPhieuThu.lenhXuat = phieuthu.lenhXuat;
                            newPhieuThu.maKH = phieuthu.maKH;
                            newPhieuThu.maSP = phieuthu.maSP;
                            newPhieuThu.soLuongTan = phieuthu.soLuongTan;
                            newPhieuThu.soLuongM3 = phieuthu.soLuongM3;
                            newPhieuThu.donGia = phieuthu.donGia;
                            newPhieuThu.thanhTien = phieuthu.thanhTien;
                            newPhieuThu.tienThanhToan = phieuthu.tienThanhToan;
                            newPhieuThu.maKho = phieuthu.maKho;
                            newPhieuThu.maMayXay = phieuthu.maMayXay;
                            newPhieuThu.maMayXuc = phieuthu.maMayXuc;
                            newPhieuThu.thoiGianVao = phieuthu.thoiGianVao;
                            newPhieuThu.trangThai = phieuthu.trangThai;

                            // Thêm các thuộc tính mới cho đối tượng mới
                            newPhieuThu.maDon = newMaDon;
                            newPhieuThu.thoiGianRa = giora;

                            // Thêm đối tượng mới vào cơ sở dữ liệu
                            db.PhieuThus.Add(newPhieuThu);

                            // Xóa đối tượng cũ
                            db.PhieuThus.Remove(phieuthu);

                            // Lưu thay đổi vào cơ sở dữ liệu
                            db.SaveChanges();
                            XuLyCongNo(txbMaKH.Text, (decimal) newPhieuThu.soLuongTan, (decimal) newPhieuThu.soLuongM3, (decimal) newPhieuThu.tienThanhToan);
                            
                            txbMaPhieu.Text = newMaDon;

                            // Thông báo thành công
                            MessageBox.Show("Cập nhật phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnIn.PerformClick();
                        }
                        else                           
                        {
                            MessageBox.Show("Không có quyền sửa phiếu có sẵn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            // Xóa dữ liệu trong các textbox sau khi update thành công
            //txbMaPhieu.Clear();
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

        private void XuLyCongNo(string makh, decimal sltan, decimal slm3, decimal thanhtien)
        {
            string macn = GetMaCNFromMaKH(makh);

            using (var db = new CanDBContext())
            {
                var congno = db.HanMucCongNoes.FirstOrDefault(c => c.maCongNo == macn);

                if (congno != null)
                {
                    congno.soLuongTanXuat = congno.soLuongTanXuat + sltan;
                    congno.soLuongM3Xuat = congno.soLuongM3Xuat + slm3;
                    congno.thanhTien = congno.thanhTien + thanhtien;
                    congno.tienConLai = congno.tienConLai - congno.thanhTien;

                    if (congno.tienConLai < 0)
                    {
                        MessageBox.Show("Đã quá tổng hạn mức công nợ trong ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                db.SaveChanges();
            }
        }

        private string GetMaCNFromMaKH(string maKH)
        {
            string maCN = "";

            using (var db = new CanDBContext())
            {
                var hmct = db.HanMucCongNoes.FirstOrDefault(h => h.maKH == maKH);

                if (hmct != null)
                {
                    maCN = hmct.maCongNo;
                }
            }
            return maCN;
        }

        //XOA DATA
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
                    MessageBox.Show("Đã hủy phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Lỗi khi hủy phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Đã hủy phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                        MessageBox.Show("Lỗi khi hủy phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //ham xoa cua btnHuy
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
                        if (entity.trangThai == 0)
                        {
                            return false;
                        }

                        entity.trangThai = 0; //khong duoc xoa phieu, chi set trang thai = 0 (huy)
                        db.SaveChanges();

                        #region Lay lenh xuat de huy trang thai cua lenh xuat
                        string lenhXuat = "";

                        using (var dbt = new CanDBContext())
                        {
                            var phieuThu = dbt.PhieuThus.FirstOrDefault(pt => pt.maDon == maphieu);

                            if (phieuThu != null)
                            {
                                lenhXuat = phieuThu.lenhXuat;
                            }
                        }

                        using (var dbx = new CanDBContext())
                        {
                            var phieuxuat = dbx.NhapXuats.FirstOrDefault(px => px.maNhapXuat == lenhXuat);

                            if (phieuxuat != null)
                            {
                                phieuxuat.trangThai = 0;
                            }
                            dbx.SaveChanges();
                        }
                        #endregion

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

        private void btnPhieuTruoc_Click(object sender, EventArgs e)
        {
            if (txbMaPhieu.Text.StartsWith("H"))
            {
                return;
            }
            int temp = int.Parse(txbMaPhieu.Text) - 1;

            string maphieu = temp.ToString();
            using (var db = new CanDBContext())
            {
                var phieuThu = db.PhieuThus.FirstOrDefault(p => p.maDon == maphieu);

                if (phieuThu != null)
                {
                    txbMaPhieu.Text = phieuThu.maDon.ToString();
                    txbSoXe.Text = phieuThu.bienSoXe.ToString();
                    //txbTLXeVao.Text = string.Format("{0:N0}", phieuThu.trongLuongXeVao);
                    decimal tlxevao = (decimal) phieuThu.trongLuongXeVao;
                    txbTLXeVao.Text = tlxevao.ToString(cultureInfo);

                    decimal tlxera = (decimal)phieuThu.trongLuongXeRa;
                    txbTLXeRa.Text = tlxera.ToString(cultureInfo);

                    txbLenhXuat.Text = phieuThu.lenhXuat;
                    txbMaKH.Text = phieuThu.maKH;
                    txbMaSP.Text = phieuThu.maSP;

                    decimal sltan = (decimal)phieuThu.soLuongTan;
                    txbSoLuongTan.Text = sltan.ToString(cultureInfo);

                    decimal slm3 = (decimal)phieuThu.soLuongM3;
                    txbSoLuongM3.Text = slm3.ToString(cultureInfo);

                    txbDonGia.Text = string.Format(cultureInfo,"{0:N0}", phieuThu.donGia);
                    txbTienHang.Text = string.Format(cultureInfo, "{0:N0}", phieuThu.thanhTien);
                    txbThanhToan.Text = string.Format(cultureInfo, "{0:N0}", phieuThu.tienThanhToan);
                    txbMaKho.Text = phieuThu.maKho;
                    txbMaMayXay.Text = phieuThu.maMayXay;
                    txbMaXeXuc.Text = phieuThu.maMayXuc;

                    int trangthai = kiemTraTrangThaiPhieu();

                    if (trangthai == 1)
                    {
                        btnSua.Enabled = true;
                        btnIn.Enabled = true;

                        if (quyenuser == "Admin")
                        {
                            btnHuy.Enabled = true;
                        }
                    }
                    else
                    {
                        btnSua.Enabled = false;
                        btnHuy.Enabled = false;
                        btnIn.Enabled = false;
                    }
                }
            }
        }

        private void btnPhieuSau_Click(object sender, EventArgs e)
        {
            if (txbMaPhieu.Text.StartsWith("H"))
            {
                return;
            }

            int temp = int.Parse(txbMaPhieu.Text) + 1;

            string maphieu = temp.ToString();
            using (var db = new CanDBContext())
            {
                var phieuThu = db.PhieuThus.FirstOrDefault(p => p.maDon == maphieu);

                if (phieuThu != null)
                {
                    txbMaPhieu.Text = phieuThu.maDon.ToString();
                    txbSoXe.Text = phieuThu.bienSoXe.ToString();

                    decimal tlxevao = (decimal)phieuThu.trongLuongXeVao;
                    txbTLXeVao.Text = tlxevao.ToString(cultureInfo);

                    decimal tlxera = (decimal)phieuThu.trongLuongXeRa;
                    txbTLXeRa.Text = tlxera.ToString(cultureInfo);

                    txbLenhXuat.Text = phieuThu.lenhXuat;
                    txbMaKH.Text = phieuThu.maKH;
                    txbMaSP.Text = phieuThu.maSP;

                    decimal sltan = (decimal)phieuThu.soLuongTan;
                    txbSoLuongTan.Text = sltan.ToString(cultureInfo);

                    decimal slm3 = (decimal)phieuThu.soLuongM3;
                    txbSoLuongM3.Text = slm3.ToString(cultureInfo);

                    txbDonGia.Text = string.Format(cultureInfo, "{0:N0}", phieuThu.donGia);
                    txbTienHang.Text = string.Format(cultureInfo, "{0:N0}", phieuThu.thanhTien);
                    txbThanhToan.Text = string.Format(cultureInfo, "{0:N0}", phieuThu.tienThanhToan);
                    txbMaKho.Text = phieuThu.maKho;
                    txbMaMayXay.Text = phieuThu.maMayXay;
                    txbMaXeXuc.Text = phieuThu.maMayXuc;

                    int trangthai = kiemTraTrangThaiPhieu();

                    if (trangthai == 1)
                    {
                        btnSua.Enabled = true;
                        btnIn.Enabled = true;

                        if (quyenuser == "Admin")
                        {
                            btnHuy.Enabled = true;
                        }
                    }
                    else
                    {
                        btnSua.Enabled = false;
                        btnHuy.Enabled = false;
                        btnIn.Enabled = false;
                    }
                }
            }
        }

        /*dung 2 vong lap de kiem tra ma phieu 
        - vong lap 1:
        neu ma phieu khong ton tai trong db -> khong xem duoc phieu sau (btnPhieuSau khong sang len de click)
        - vong lap 2: ma phieu ton tai
        kiem tra phieu do co phai phieu moi nhat hay khong
        neu la phieu moi nhat -> khong xem duoc phieu sau (btnPhieuSau khong sang len de click)
        con lai -> xem phieu sau (btnPhieuSau sang len de click)
        */

        //bo ham nay vao trong txbMaPhieu_TextChanged
        //de kiem tra xem phieu nay co phai la phieu moi nhat/khong ton tai khong 
        private void kiemTraPhieuMoiNhat()
        {
            // Truy vấn mã phiếu mới nhất từ cơ sở dữ liệu
            //var latestPhieu = PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault();

            string maDon = txbMaPhieu.Text;
            int nextMaPhieu = int.Parse(db.GetNextMaPhieu()) - 1;

            using (var db = new CanDBContext())
            {
                var phieuThu = db.PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault(kh => kh.maDon == maDon);

                if (phieuThu.maDon.StartsWith("H"))
                {

                }
                else
                {
                    if (phieuThu == null)
                    {
                        btnPhieuSau.Enabled = false;                        
                    }
                    else
                    {
                        int temp = int.Parse(phieuThu.maDon.ToString());
                        if (temp < nextMaPhieu)
                        {
                            btnPhieuSau.Enabled = true;
                        }
                        else
                        {
                            btnPhieuSau.Enabled = false;
                        }
                    }
                }
            }
        }

        //tuong tu => kiem tra phieu cu nhat
        //cung bo ham nay vao trong txbMaPhieu_TextChanged
        private void kiemTraPhieuCuNhat(int prevMaPhieu)
        {
            // Truy vấn mã phiếu mới nhất từ cơ sở dữ liệu
            //var latestPhieu = PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault();

            string maDon = txbMaPhieu.Text;
            //int nextMaPhieu = int.Parse(db.GetNextMaPhieu()) - 1;

            using (var db = new CanDBContext())
            {
                var phieuThu = db.PhieuThus.OrderBy(p => p.maDon).FirstOrDefault(kh => kh.maDon == maDon);

                if (phieuThu.maDon.StartsWith("H"))
                {

                }
                else
                {
                    if (phieuThu == null)
                    {
                        btnPhieuTruoc.Enabled = false;
                    }
                    else
                    {
                        int temp = int.Parse(phieuThu.maDon.ToString());
                        if (temp > prevMaPhieu)
                        {
                            btnPhieuTruoc.Enabled = true;
                        }
                        else
                        {
                            btnPhieuTruoc.Enabled = false;
                        }
                    }

                }
            }
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            using (var dialog = new FrmTimPhieu())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string maPhieu = dialog.MaPhieu;
                    // Truy xuất thông tin phiếu từ cơ sở dữ liệu
                    var phieu = db.PhieuThus.FirstOrDefault(p => p.maDon == maPhieu);
                    if (phieu != null)
                    {
                        // Hiển thị thông tin tương ứng lên các textbox
                        txbMaPhieu.Text = phieu.maDon;
                        txbSoXe.Text = phieu.bienSoXe;

                        decimal tlxevao = (decimal)phieu.trongLuongXeVao;
                        txbTLXeVao.Text = tlxevao.ToString(cultureInfo);

                        decimal tlxera = (decimal)phieu.trongLuongXeRa;
                        txbTLXeRa.Text = tlxera.ToString(cultureInfo);

                        txbLenhXuat.Text = phieu.lenhXuat;
                        txbMaSP.Text = phieu.maSP;
                        txbMaKho.Text = phieu.maKho;
                        txbMaMayXay.Text = phieu.maMayXay;
                        txbMaXeXuc.Text = phieu.maMayXuc;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin cho mã phiếu " + maPhieu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnTimXe_Click(object sender, EventArgs e)
        {
            using (var dialog = new FrmTimXe())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string soXe = dialog.SoXe;
                    DateTime ngayHienTai = DateTime.Today;
                    // Truy xuất thông tin phiếu từ cơ sở dữ liệu
                    var phieu = db.PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault(p => p.bienSoXe == soXe && DbFunctions.TruncateTime(p.thoiGianVao) == ngayHienTai);
                    if (phieu != null)
                    {
                        // Hiển thị thông tin tương ứng lên các textbox
                        txbMaPhieu.Text = phieu.maDon;
                        txbSoXe.Text = phieu.bienSoXe;

                        decimal tlxevao = (decimal)phieu.trongLuongXeVao;
                        txbTLXeVao.Text = tlxevao.ToString(cultureInfo);

                        decimal tlxera = (decimal)phieu.trongLuongXeRa;
                        txbTLXeRa.Text = tlxera.ToString(cultureInfo);

                        txbLenhXuat.Text = phieu.lenhXuat;
                        txbMaSP.Text = phieu.maSP;
                        txbMaKho.Text = phieu.maKho;
                        txbMaMayXay.Text = phieu.maMayXay;
                        txbMaXeXuc.Text = phieu.maMayXuc;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin cho số xe " + soXe, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        //Sap xep phieu theo ma phieu, so xe hoac ma khach
        private void btnThuTu_Click(object sender, EventArgs e)
        {
            FrmThuTu frmThuTu = new FrmThuTu();
            frmThuTu.ShowDialog();

            string sortBy = frmThuTu.SortBy;
            SortData(sortBy);
        }

        private void SortData(string sortBy)
        {
            switch (sortBy)
            {
                case "Mã Phiếu":
                    dgvCan.Sort(dgvCan.Columns["Column1"], ListSortDirection.Ascending);
                    break;
                case "Mã Xe":
                    dgvCan.Sort(dgvCan.Columns["Column2"], ListSortDirection.Ascending);
                    break;
                case "Mã Khách Hàng":
                    dgvCan.Sort(dgvCan.Columns["Column3"], ListSortDirection.Ascending);
                    break;
                default:
                    // Mặc định sắp xếp theo mã phiếu
                    dgvCan.Sort(dgvCan.Columns["Column1"], ListSortDirection.Ascending);
                    break;
            }
        }

        private void btnXeVao_Click(object sender, EventArgs e)
        {
            //disable cac function cua btnXeRa
            txbTLXeRa.Enabled = false;
            txbLenhXuat.Enabled = false;
            txbSoLuongTan.Enabled = false;
            txbSoLuongM3.Enabled = false;
            txbDonGia.Enabled = false;
            txbTienHang.Enabled = false;
            txbThanhToan.Enabled = false;

            btnSua.Enabled = false;

            txbSoXe.Enabled = true;
            txbTLXeVao.Enabled = true;
            txbMaKH.Enabled = true;
            txbMaSP.Enabled = true;
            txbMaKho.Enabled = true;
            txbMaMayXay.Enabled = true;
            txbMaXeXuc.Enabled = true;
            txbSalan.Enabled = true;

            this.ActiveControl = txbSoXe;

            serialPort1_Open();
        }

        private void btnXeRa_Click(object sender, EventArgs e)
        {
            //disable cac function cua btnXeVao
            txbSoXe.Enabled = false;
            txbTLXeVao.Enabled = false;
            txbMaKH.Enabled = false;

            txbTLXeRa.Enabled = true;
            txbLenhXuat.Enabled = true; 
            txbMaSP.Enabled = true;
            if (quyenuser == "Admin")
            {
                txbSoLuongTan.Enabled = true;
                txbSoLuongM3.Enabled = true;
                txbDonGia.Enabled = true;
                txbTienHang.Enabled = true;
                txbThanhToan.Enabled = true;
            }               
            txbMaKho.Enabled = true;
            txbMaMayXay.Enabled = true;
            txbMaXeXuc.Enabled = true;
            txbSalan.Enabled = true;

            btnSua.Enabled = true;

            if (txbSoXe.Text == "" || txbTLXeVao.Text == "" || txbTLXeVao.Text == "0")
            {
                MessageBox.Show("Chưa có giá trị đầu vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.ActiveControl = txbLenhXuat;

            serialPort1_Open();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string maPhieu = txbMaPhieu.Text;

            if (flag == 1) // = 1 : phieu vua duoc luu => in phieu
            {
                flag = 0; //reset lai flag

                // Gọi phương thức LoadData của form chứa reportViewer và truyền dữ liệu
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.LoadData(txbMaKH.Text, txbSoXe.Text, txbMaKho.Text, txbMaMayXay.Text, txbMaXeXuc.Text, txbTLXeVao.Text,
                    txbTLXeRa.Text, txbSoLuongM3.Text, txbMaSP.Text, txbDonGia.Text, txbTienHang.Text, txbThanhToan.Text,
                    maPhieu, txbLenhXuat.Text);
                frmPrint.Show();
            }
            else // = 0 : phieu cu => kiem tra trang thai
            {
                var Phieu = db.PhieuThus.FirstOrDefault(p => p.maDon == maPhieu);
                if (Phieu != null)
                {
                    int trangthai = (int)Phieu.trangThai;

                    if (trangthai == 1)
                    {
                        // Gọi phương thức LoadData của form chứa reportViewer và truyền dữ liệu
                        FrmPrint frmPrint = new FrmPrint();
                        frmPrint.LoadData(txbMaKH.Text, txbSoXe.Text, txbMaKho.Text, txbMaMayXay.Text, txbMaXeXuc.Text, txbTLXeVao.Text,
                            txbTLXeRa.Text, txbSoLuongM3.Text, txbMaSP.Text, txbDonGia.Text, txbTienHang.Text, txbThanhToan.Text,
                            maPhieu, txbLenhXuat.Text);
                        frmPrint.Show();
                    }
                    else
                    {
                        MessageBox.Show("Phiếu này đã hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //goi y khi nhap trong cac txb
        private void SetupAutoCompleteForTextBoxes()
        {
            // truy van data tu db
            var datasoxe = db.Xes.Select(item => item.bienSoXe).Distinct().ToList();

            // Tạo một AutoCompleteStringCollection và thêm các giá trị từ kết quả truy vấn vào collection cho txbSoXe
            AutoCompleteStringCollection autoCompleteCollection1 = new AutoCompleteStringCollection();
            foreach (var item in datasoxe)
            {
                autoCompleteCollection1.Add(item);
            }

            // Thiết lập AutoCompleteMode và AutoCompleteSource cho txbSoXe
            txbSoXe.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbSoXe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbSoXe.AutoCompleteCustomSource = autoCompleteCollection1;

            //sanpham
            var datasp = db.SanPhams.Select(item => item.maThanhPham).Distinct().ToList();

            AutoCompleteStringCollection autoCompleteCollection2 = new AutoCompleteStringCollection();
            foreach (var item in datasp)
            {
                autoCompleteCollection2.Add(item);
            }

            txbMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbMaSP.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbMaSP.AutoCompleteCustomSource = autoCompleteCollection2;

            //kho
            var datakho = db.Khoes.Select(item => item.maKho).Distinct().ToList();

            AutoCompleteStringCollection autoCompleteCollection3 = new AutoCompleteStringCollection();
            foreach (var item in datakho)
            {
                autoCompleteCollection3.Add(item);
            }

            txbMaKho.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbMaKho.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbMaKho.AutoCompleteCustomSource = autoCompleteCollection3;

            //may xay
            var datamx = db.MayXays.Select(item => item.maMayXay).Distinct().ToList();

            AutoCompleteStringCollection autoCompleteCollection4 = new AutoCompleteStringCollection();
            foreach (var item in datamx)
            {
                autoCompleteCollection4.Add(item);
            }

            txbMaMayXay.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbMaMayXay.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbMaMayXay.AutoCompleteCustomSource = autoCompleteCollection4;

            //xe xuc
            var dataxx = db.XeXucs.Select(item => item.maXeXuc).Distinct().ToList();

            AutoCompleteStringCollection autoCompleteCollection5 = new AutoCompleteStringCollection();
            foreach (var item in dataxx)
            {
                autoCompleteCollection5.Add(item);
            }

            txbMaXeXuc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbMaXeXuc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbMaXeXuc.AutoCompleteCustomSource = autoCompleteCollection5;
        }

        //mo va load cong COM
        public SerialPort Port { get; private set; } = null;
        private string dataReceived = string.Empty;

        private void serialPort1_Open()
        {
            int comLength, RefreshCount = 0;
            string[] arrayCom;
            string comName;
            try
            {
                comLength = SerialPort.GetPortNames().Length;
                arrayCom = new string[comLength];
                arrayCom = SerialPort.GetPortNames();
                comLength = SerialPort.GetPortNames().Length;
                comName = arrayCom[RefreshCount].ToString();

                //create new instance
                this.Port = new SerialPort();

                //set properties
                Port.BaudRate = 9600;
                Port.DataBits = 8;
                Port.Parity = Parity.None; //use 'None' when DataBits = 8; if DataBits = 7, use 'Even' or 'Odd'
                Port.DtrEnable = true; //enable Data Terminal Ready
                Port.Handshake = Handshake.None;
                Port.PortName = comName;
                Port.ReadTimeout = 200; //used when using ReadLine
                Port.RtsEnable = true; //enable Request to send
                Port.StopBits = StopBits.One;
                Port.WriteTimeout = 50;

                //MessageBox.Show("Success!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Port.DataReceived += serialPort1_DataReceived;

                Port.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open COM Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string weightDataVao = "";
        private string weightDataRa = "";

        //lay du lieu tu can
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            dataReceived = Port.ReadExisting();

            // Tìm và lọc số từ chuỗi
            string[] parts = dataReceived.Split(new char[] { ' ', ')', '(' }, StringSplitOptions.RemoveEmptyEntries);

            // Chuyển đổi chuỗi thành số nguyên
            string firstTwelveDigits = "";
            string mostFrequentValue = "0";
            string secondMostFrequentValue = "0";
            int maxFrequency = 0;
            int secondMaxFrequency = 0;
            int t = 0;

            if (txbTLXeVao.Enabled == true)
            {
                for (int i = 2000; t < i; t++)
                {
                    Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

                    foreach (string part in parts)
                    {
                        if (int.TryParse(part, out int num))
                        {
                            // Lọc các giá trị có độ dài từ 4-5                       

                            if (num.ToString().Length > 3 && num.ToString().Length < 6)
                            {
                                string formattedNumber = num.ToString("N0").Substring(0);

                                // Thêm số vào Dictionary và tăng tần suất nếu nó đã tồn tại
                                if (frequencyMap.ContainsKey(formattedNumber))
                                {
                                    frequencyMap[formattedNumber]++; //tăng tần suất
                                }
                                else
                                {
                                    frequencyMap.Add(formattedNumber, 1); //thêm vào 
                                }
                            }

                            // Tìm giá trị có tần suất xuất hiện cao nhất và tần suất xuất hiện thứ hai
                            foreach (var entry in frequencyMap)
                            {
                                if (entry.Value > maxFrequency)
                                {
                                    secondMostFrequentValue = mostFrequentValue;
                                    secondMaxFrequency = maxFrequency;
                                    mostFrequentValue = entry.Key;
                                    maxFrequency = entry.Value;
                                }
                                else if (entry.Value > secondMaxFrequency)
                                {
                                    secondMostFrequentValue = entry.Key;
                                    secondMaxFrequency = entry.Value;
                                }
                            }

                            int mostFrequentValueInt, secondMostFrequentValueInt;

                            // Kiểm tra xem tần suất xuất hiện của số gần nhất và số xa hơn
                            if (maxFrequency == secondMaxFrequency)
                            {
                                // So sánh độ dài của hai giá trị
                                if (mostFrequentValue.Length > secondMostFrequentValue.Length)
                                {
                                    firstTwelveDigits = mostFrequentValue;
                                }
                                else
                                {
                                    firstTwelveDigits = secondMostFrequentValue;
                                }
                            }
                            else
                            {
                                if (int.TryParse(mostFrequentValue, out mostFrequentValueInt))
                                {
                                    // Kiểm tra và chuyển đổi secondMostFrequentValue thành số nguyên
                                    if (int.TryParse(secondMostFrequentValue, out secondMostFrequentValueInt))
                                    {
                                        //truong hop 12852 va 1285
                                        if (mostFrequentValueInt / 10 == secondMostFrequentValueInt)
                                        {
                                            firstTwelveDigits = mostFrequentValue;
                                        }
                                    }
                                }
                            }

                            if (txbTLXeVao.Enabled == true)
                            {
                                if (txbTLXeVao.InvokeRequired)
                                {
                                    weightDataVao = firstTwelveDigits.ToString();

                                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.Clear(); }));
                                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.AppendText(weightDataVao + Environment.NewLine); }));
                                }
                            }
                            else
                            {
                                if (txbTLXeRa.InvokeRequired)
                                {
                                    weightDataRa = firstTwelveDigits.ToString();

                                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.Clear(); }));
                                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.AppendText(weightDataRa + Environment.NewLine); }));
                                }
                            }
                        }
                    }
                }

                string dv = weightDataVao.Replace(",", "");

                //khi ra tram can thi sua lai dieu kien ben duoi
                //hien tai de dauvao > tlbanthan de tu test
                if (int.Parse(dv) > int.Parse(tlbanthan))
                {
                    MessageBox.Show(dv + " < " + tlbanthan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.Clear(); }));
                }
                else
                {
                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.Clear(); }));
                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.AppendText(weightDataVao + Environment.NewLine); }));
                }
            }
            else
            {
                for (int i = 300; t < i; t++)
                {
                    Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

                    foreach (string part in parts)
                    {
                        if (int.TryParse(part, out int num))
                        {
                            // Lọc các giá trị có độ dài từ 4-5                       

                            if (num.ToString().Length > 3 && num.ToString().Length < 6)
                            {
                                string formattedNumber = num.ToString("N0").Substring(0);

                                // Thêm số vào Dictionary và tăng tần suất nếu nó đã tồn tại
                                if (frequencyMap.ContainsKey(formattedNumber))
                                {
                                    frequencyMap[formattedNumber]++; //tăng tần suất
                                }
                                else
                                {
                                    frequencyMap.Add(formattedNumber, 1); //thêm vào 
                                }

                                //firstTwelveDigits = num.ToString("N0").Substring(0);
                            }

                            // Tìm giá trị có tần suất xuất hiện cao nhất và tần suất xuất hiện thứ hai
                            foreach (var entry in frequencyMap)
                            {
                                if (entry.Value > maxFrequency)
                                {
                                    secondMostFrequentValue = mostFrequentValue;
                                    secondMaxFrequency = maxFrequency;
                                    mostFrequentValue = entry.Key;
                                    maxFrequency = entry.Value;
                                }
                                else if (entry.Value > secondMaxFrequency)
                                {
                                    secondMostFrequentValue = entry.Key;
                                    secondMaxFrequency = entry.Value;
                                }
                            }

                            int mostFrequentValueInt, secondMostFrequentValueInt;

                            // Kiểm tra xem tần suất xuất hiện của số gần nhất và số xa hơn
                            if (maxFrequency == secondMaxFrequency)
                            {
                                // So sánh độ dài của hai giá trị
                                if (mostFrequentValue.Length > secondMostFrequentValue.Length)
                                {
                                    firstTwelveDigits = mostFrequentValue;
                                }
                                else
                                {
                                    firstTwelveDigits = secondMostFrequentValue;
                                }
                            }
                            else
                            {
                                if (int.TryParse(mostFrequentValue, out mostFrequentValueInt))
                                {
                                    // Kiểm tra và chuyển đổi secondMostFrequentValue thành số nguyên
                                    if (int.TryParse(secondMostFrequentValue, out secondMostFrequentValueInt))
                                    {
                                        //truong hop 12852 va 1285
                                        if (mostFrequentValueInt / 10 == secondMostFrequentValueInt)
                                        {
                                            firstTwelveDigits = mostFrequentValue;
                                        }
                                    }
                                }
                            }

                            if (txbTLXeVao.Enabled == true)
                            {
                                if (txbTLXeVao.InvokeRequired)
                                {
                                    weightDataVao = firstTwelveDigits.ToString();

                                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.Clear(); }));
                                    txbTLXeVao.Invoke(new MethodInvoker(delegate { txbTLXeVao.AppendText(weightDataVao + Environment.NewLine); }));
                                }
                            }
                            else
                            {
                                if (txbTLXeRa.InvokeRequired)
                                {
                                    weightDataRa = firstTwelveDigits.ToString();

                                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.Clear(); }));
                                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.AppendText(weightDataRa + Environment.NewLine); }));
                                }
                            }
                        }
                    }
                }

                string dr = weightDataRa.Replace(",", "");

                if (int.Parse(tlchophep) < int.Parse(dr))
                {
                    MessageBox.Show(tlchophep + " < " + dr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.Clear(); }));
                }
                else
                {
                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.Clear(); }));
                    txbTLXeRa.Invoke(new MethodInvoker(delegate { txbTLXeRa.AppendText(weightDataRa + Environment.NewLine); }));
                }
            }

            Port.Close();
        }

        public string GenerateTemporaryMaPhieu()
        {
            // Lấy mã phiếu tạm thời cuối cùng từ cơ sở dữ liệu
            var lastTemporaryMaPhieu = db.PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault(p => p.maDon.StartsWith("H"));

            if (lastTemporaryMaPhieu != null)
            {
                // Lấy số cuối cùng từ mã phiếu tạm thời
                int lastNumber;
                if (int.TryParse(lastTemporaryMaPhieu.maDon.Substring(1), out lastNumber))
                {
                    // Tăng số tiếp theo lên một
                    int nextNumber = lastNumber + 1;

                    // Tạo mã phiếu tạm thời mới
                    string nextTemporaryMaPhieu = "H" + nextNumber.ToString();

                    // Kiểm tra xem mã phiếu tạm thời mới đã tồn tại chưa
                    while (db.PhieuThus.Any(p => p.maDon == nextTemporaryMaPhieu))
                    {
                        nextNumber++;
                        nextTemporaryMaPhieu = "H" + nextNumber.ToString();
                    }

                    return nextTemporaryMaPhieu;
                }
            }

            // Nếu không có mã phiếu tạm thời nào trong cơ sở dữ liệu, bạn có thể bắt đầu từ "H1"
            return "H1";
        }

        public string GenerateOfficialMaPhieu()
        {
            // Lấy mã phiếu chính thức cuối cùng từ cơ sở dữ liệu
            var lastOfficialMaPhieu = db.PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault(p => !p.maDon.StartsWith("H"));

            if (lastOfficialMaPhieu != null)
            {
                // Lấy số cuối cùng từ mã phiếu chính thức
                int lastNumber;
                if (int.TryParse(lastOfficialMaPhieu.maDon, out lastNumber))
                {
                    // Tăng số tiếp theo lên một
                    int nextNumber = lastNumber + 1;

                    // Tạo mã phiếu chính thức mới
                    string nextOfficialMaPhieu = nextNumber.ToString();

                    // Kiểm tra xem mã phiếu chính thức mới đã tồn tại chưa
                    while (db.PhieuThus.Any(p => p.maDon == nextOfficialMaPhieu))
                    {
                        nextNumber++;
                        nextOfficialMaPhieu = nextNumber.ToString();
                    }

                    return nextOfficialMaPhieu;
                }
            }

            // Nếu không có mã phiếu chính thức nào trong cơ sở dữ liệu, bạn có thể bắt đầu từ "1"
            return "1";
        }
    }
}
