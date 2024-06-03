using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanKT
{
    public class TransparentPanel : Panel
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Don't paint background to keep it transparent
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            MessageBox.Show("TransparentPanel MouseClick triggered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
