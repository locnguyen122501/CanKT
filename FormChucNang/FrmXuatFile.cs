using CanKT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Runtime.InteropServices.ComTypes;

namespace CanKT.FormChucNang
{
    public partial class FrmXuatFile : Form
    {
        CanDBContext db = new CanDBContext();

        CultureInfo cultureInfo = new CultureInfo("vi-VN");
        public FrmXuatFile()
        {
            InitializeComponent(); 
        }

        private void LoadDataIntoDataGridView()
        {
            dgvCan.Rows.Clear();

            // Lấy giá trị ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime ngaydau = dtpNgayDau.Value.Date;
            DateTime ngaycuoi = dtpNgayCuoi.Value.Date.AddDays(1).AddTicks(-1); // Lấy hết ngày kết thúc

            // Truy vấn dữ liệu từ DbSet trong DbContext
            var data = db.PhieuThus.Where(p => p.trangThai == 3 && p.thoiGianRa >= ngaydau && p.thoiGianRa <= ngaycuoi);

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

                row.Cells["Column6"].Value = item.lenhXuat;
                row.Cells["Column7"].Value = item.maSP;

                //dinh dang tien
                decimal donGia = Convert.ToDecimal(item.donGia); //chuyen kieu du lieu money sang decimal
                row.Cells["Column8"].Value = donGia.ToString("N0", cultureInfo);

                decimal tan = Convert.ToDecimal(item.soLuongTan);
                row.Cells["Column9"].Value = tan.ToString(cultureInfo);

                decimal m3 = Convert.ToDecimal(item.soLuongM3);
                row.Cells["Column10"].Value = m3.ToString(cultureInfo);

                decimal thanhTien = Convert.ToDecimal(item.thanhTien); //chuyen kieu du lieu money sang decimal               
                row.Cells["Column11"].Value = thanhTien.ToString("N0", cultureInfo);

                decimal thanhtoan = Convert.ToDecimal(item.tienThanhToan); //chuyen kieu du lieu money sang decimal               
                row.Cells["Column12"].Value = thanhtoan.ToString("N0", cultureInfo);

                row.Cells["Column13"].Value = item.maKho;
                row.Cells["Column14"].Value = item.maMayXay;
                row.Cells["Column15"].Value = item.maMayXuc;
                row.Cells["Column16"].Value = item.thoiGianVao;
                row.Cells["Column17"].Value = item.thoiGianRa;
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
            }
        }

        #region buttonChucNang
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void btnXuatOnline_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Hiển thị SaveFileDialog để người dùng chọn nơi lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Chọn vị trí lưu file";
                saveFileDialog.FileName = "CanData.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveDataGridViewToExcel(dgvCan, filePath);
                    MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveDataGridViewToExcel(DataGridView dgv, string filePath)
        {
            // Kiểm tra nếu file đã tồn tại
            bool fileExists = File.Exists(filePath);
            using (var workbook = fileExists ? new XLWorkbook(filePath) : new XLWorkbook())
            {
                IXLWorksheet worksheet;

                // Kiểm tra nếu workbook đã có worksheet
                if (fileExists && workbook.Worksheets.Count > 0)
                {
                    worksheet = workbook.Worksheet(1); // Lấy worksheet đầu tiên
                }
                else
                {
                    worksheet = workbook.Worksheets.Add("Sheet1"); // Tạo worksheet mới nếu chưa có
                }

                // Xóa tất cả các hàng trừ hàng đầu tiên
                if (worksheet.RowsUsed().Count() > 1)
                {
                    worksheet.Rows(2, worksheet.RowsUsed().Count()).Delete();
                }

                // Xác định hàng bắt đầu để thêm dữ liệu
                int startRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1;

                // Thêm tiêu đề cột (chỉ thêm nếu chưa có dữ liệu)
                if (startRow == 1)
                {
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dgv.Columns[col].HeaderText;
                    }
                    startRow++;
                }

                // Thêm nội dung của DataGridView vào worksheet
                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        worksheet.Cell(row + 2, col + 1).Value = dgv.Rows[row].Cells[col].Value;
                    }
                }

                // Lưu workbook vào file
                workbook.SaveAs(filePath);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
