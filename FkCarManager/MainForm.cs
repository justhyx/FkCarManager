using System;
using System.Windows.Forms;
using FkCar.BLL;
using Pro.CommonUntil;

namespace FkCarManager
{
    public partial class MainForm : Form
    {
        UserBLL userbll;
        public MainForm()
        {
            InitializeComponent();
            userbll = UserBLL.GetBLLObject();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime d = userbll.GetDateCheck();
            if (d != null && !d.Equals(DateTime.MinValue))
            {
                MessageBox.Show("Pass");
            }
        }

        private void toolStripBooking_Click(object sender, EventArgs e)
        {

        }

        private void TSMBookingMng_Click(object sender, EventArgs e)
        {

        }

        private void TSMCarMng_Click(object sender, EventArgs e)
        {
            FormVehicleMng.GetForm(this);
        }

        private void TSMBooking_Click(object sender, EventArgs e)
        {
            FrmBooking.GetForm(this);
        }
    }
}
