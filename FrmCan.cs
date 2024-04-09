using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanKT.Models;

namespace CanKT
{
    public partial class FrmCan : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmCan()
        {
            InitializeComponent();
        }


        private void FrmCan_Load(object sender, EventArgs e)
        {
            var data = db.PhieuThus.ToList();
            var dataTable = ConvertToDataTable(data);

            // Gán dữ liệu vào DataGridView
            dgvCan.DataSource = dataTable;
            foreach (DataGridViewColumn column in dgvCan.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            int numberOfColumnsToRemove = 7; // Số lượng cột tên bảng bạn muốn loại bỏ từ cuối

            // Loại bỏ các cột tên bảng từ cuối của DataGridView
            for (int i = 0; i < numberOfColumnsToRemove; i++)
            {
                int columnIndex = dgvCan.Columns.Count - 1; // Lấy index của cột cuối cùng
                dgvCan.Columns.RemoveAt(columnIndex); // Loại bỏ cột cuối cùng
            }
        }

        // Phương thức để chuyển đổi danh sách thành DataTable
        private DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                    
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
