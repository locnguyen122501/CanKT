using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanKT
{
    public partial class FrmThuTu : Form
    {
        public string SortBy { get; private set; }


        public FrmThuTu()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (rdbMaPhieu.Checked)
            {
                SortBy = "Mã Phiếu";
            }
            else if (rdbSoXe.Checked)
            {
                SortBy = "Mã Xe";
            }
            else if (rdbKhachHang.Checked)
            {
                SortBy = "Mã Khách Hàng";
            }
            this.Close();
        }
    }
}
