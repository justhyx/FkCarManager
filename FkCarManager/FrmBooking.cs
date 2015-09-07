using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FkCarManager
{
    public partial class FrmBooking : Form
    {
        public FrmBooking()
        {
            InitializeComponent();
        }

        private static FrmBooking singerton;
        public static bool GetForm(Form parent)
        {
            if (singerton == null)
            {
                singerton = new FrmBooking();
                singerton.MdiParent = parent;
                singerton.WindowState = FormWindowState.Maximized;

            }
            singerton.Show();
            singerton.Activate();
            return true;
        }
        private void FrmBooking_Load(object sender, EventArgs e)
        {

        }
    }
}
