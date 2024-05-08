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
    public partial class FrmPhanTichSL : Form
    {
        CanDBContext db = new CanDBContext();
        public FrmPhanTichSL()
        {
            InitializeComponent();
        }

        private void FrmPhanTichSL_Load(object sender, EventArgs e)
        {

        }
    }
}
