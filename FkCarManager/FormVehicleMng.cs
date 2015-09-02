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
    public partial class FormVehicleMng : Form
    {
        private static FormVehicleMng singerton;

        protected FormVehicleMng(Form parent)
        {
            InitializeComponent();

        }

        public static bool GetForm(Form parent)
        {
            if (singerton == null)
            {
                singerton = new FormVehicleMng(parent);
                singerton.MdiParent = parent;
                singerton.WindowState = FormWindowState.Maximized;

            }
            singerton.Show();
            singerton.Activate();
            return true;
        }

        private void FormVehicleMng_Load(object sender, EventArgs e)
        {

        }

        private void FormVehicleMng_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }


    }
}
