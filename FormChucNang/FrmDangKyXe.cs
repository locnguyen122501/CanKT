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

namespace CanKT
{
    public partial class FrmDangKyXe : Form
    { 

        private string biensoxe;
        int selectedValue = 1;


        public FrmDangKyXe(string bienso)
        {
            InitializeComponent();
            this.biensoxe = bienso;
        }

        private void FrmDangKyXe_Load(object sender, EventArgs e)
        {
            txbSoXe.Text = biensoxe.ToString();
            this.ActiveControl = cbbLoaiXe;
            cbbLoaiXe.SelectedIndex = 0;
        }

        #region KeyDown_Code
        private void txbSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbbLoaiXe.Focus();
            }
        }


        //khi focus vao cbb thi droplist se tu duoc do xuong de chon
        private void cbbLoaiXe_Enter(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                comboBox.DroppedDown = true;
            }
        }

        private void cbbLoaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Sử dụng hàm MapComboBoxItemToValue để gán giá trị cho biến từ một item được chọn trong cbb
                string selectedItem = cbbLoaiXe.SelectedItem.ToString();
                selectedValue = MapComboBoxItemToValue(selectedItem);

                txbTLBanThan.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txbSoXe.Focus();
            }
        }

        private void txbTLBanThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txbTLChoPhep.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                cbbLoaiXe.Focus();
            }
        }

        private void txbTLChoPhep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dtpKetDangKiem.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txbTLBanThan.Focus();
            }
        }

        private void dtpKetDangKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTimePicker dtp = sender as DateTimePicker;
                if (dtp != null)
                {
                    // Lấy giá trị ngày tháng năm từ TextBox
                    string[] formats = { "dd/MM/yyyy", "dd-MM-yyyy", "dd.MM.yyyy" }; // Các định dạng ngày tháng năm mà bạn muốn chấp nhận
                    DateTime selectedDate;
                    if (DateTime.TryParseExact(dtp.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                    {
                        dtp.Value = selectedDate; // Cập nhật giá trị của DateTimePicker từ giá trị người dùng nhập vào

                        e.SuppressKeyPress = true;
                        txbMaKH.Focus();
                    }
                    else
                    {
                        // Xử lý khi người dùng nhập vào một ngày không hợp lệ
                        MessageBox.Show("Ngày không hợp lệ. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txbTLChoPhep.Focus();
            }
        }

        private void txbMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txbTenKH.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                dtpKetDangKiem.Focus();
            }
        }

        private void txbTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnXacNhan.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txbMaKH.Focus();
            }
        }
        #endregion

        #region KeyLeaveThemdauphay
        private void txbTLBanThan_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbTLBanThan.Text, out int tlbt))
            {
                txbTLBanThan.Text = tlbt.ToString("N0");
            }
        }

        private void txbTLChoPhep_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbTLChoPhep.Text, out int tlcp))
            {
                txbTLChoPhep.Text = tlcp.ToString("N0");
            }
        }
        #endregion

        #region KeyPressChuyenInHoa
        private void txbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txbTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                // Chuyển đổi ký tự nhập vào thành chữ hoa
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
        #endregion

        private int MapComboBoxItemToValue(string selectedItem)
        {
            //ánh xạ từng item tới giá trị tương ứng
            switch (selectedItem)
            {
                case "Xe tải":
                    return 1;
                case "Rơ móc":
                    return 2;
                case "Đầu kéo":
                    return 3;
                default:
                    //trong trường hợp không tìm thấy item nào khớp, trả về một giá trị mặc định hoặc xử lý ngoại lệ
                    throw new ArgumentException("Invalid item selected");
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int tlbanthan = int.Parse(txbTLBanThan.Text.Replace(",", ""));
            int tlchophep = int.Parse(txbTLChoPhep.Text.Replace(",", ""));
            DateTime ngayketdangkiem = dtpKetDangKiem.Value.Date; 
            int loaixe = selectedValue;

            string makh = txbMaKH.Text; 
            string tenkh = txbTenKH.Text;

            #region Tạo và thêm khách hàng vào db
            KhachHang kh = new KhachHang
            {
                maKH = makh,
                tenKH = tenkh,
                loai = 1,
                trangThai = 1,
            };

            using (var db = new CanDBContext())
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }
            #endregion

            #region Tạo và thêm mã công nợ cho khách hàng vào db
            HanMucCongNo hmcn = new HanMucCongNo
            {
                maCongNo = makh,
                maKH = makh,
                soTienNop = 0,
                soLuongTanXuat = 0,
                soLuongM3Xuat = 0,
                thanhTien = 0,
                tienConLai = 0,
            };

            using (var db = new CanDBContext())
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }
            #endregion

            #region Tạo và thêm xe vào db
            Xe x = new Xe
            {
                bienSoXe = biensoxe,
                trongLuongBanThan = tlbanthan,
                trongLuongChoPhep = tlchophep,
                loaiXe = loaixe,
                ngayKetDangKiem = ngayketdangkiem,
                maKH = makh,
                trangThai = 1,
            };

            // Thêm đối tượng vào cơ sở dữ liệu bằng Entity Framework
            using (var db = new CanDBContext())
            {
                db.Xes.Add(x);
                db.SaveChanges();
            }
            #endregion

            this.Close();
        }
    }
}
