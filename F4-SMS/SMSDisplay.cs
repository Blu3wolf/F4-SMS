using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F4_SMS
{
    public partial class SMSDisplay : Form
    {
        public SMSDisplay()
        {
            InitializeComponent();
        }

        // This will eventually allow complex interactions between states - for now, all boxes simply need to be checked
        public void SystemStartupOptionsChanged()
        {
            if (checkBoxMFDSPower.Checked)
            {
				if (!(checkBoxSMSPower.Checked & checkBoxMMCPower.Checked))
				{
					SetSMSPage(OFF);
                }
				else
				{
					SetSMSPage(STBY);
				}
            }
        }

		public void SetSMSPage()
		{

		}
            
        private void checkBoxSMSPower_CheckedChanged(object sender, EventArgs e)
        {
            SystemStartupOptionsChanged();
        }

        private void checkBoxMMCPower_CheckedChanged(object sender, EventArgs e)
        {
            SystemStartupOptionsChanged();
        }

        private void checkBoxMFDSPower_CheckedChanged(object sender, EventArgs e)
        {
            SystemStartupOptionsChanged();
        }
    }
}
