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
			displayPage = (int)Pages.OFF;
        }

		public enum Pages
		{
			DEAD, OFF, STBY, INV, SJ, EJ, AAM, MSL, DGFT, GUN, AG, BIT
		}

		public int displayPage;

        // This will eventually allow complex interactions between states - for now, all boxes simply need to be checked
        public void SystemStartupOptionsChanged()
        {
            if (checkBoxMFDSPower.Checked)
            {
				if (!(checkBoxSMSPower.Checked & checkBoxMMCPower.Checked))
				{
					SetSMSPage((int)Pages.OFF);
                }
				else
				{
					SetSMSPage((int)Pages.STBY);
				}
            }
			else
			{
				SetSMSPage((int)Pages.DEAD);
			}
        }

		public void BlankSMSPage()
		{

		}

		public void SetSMSPage(int page)
		{
			// Wipe the slate clean
			BlankSMSPage();

			// Figure out which page we are switching to, and display that page
			switch (page)
			{
				case (int)Pages.DEAD:
					pictureBoxSMSOFF.Visible = false;
					break;
				case (int)Pages.OFF:
					pictureBoxSMSOFF.Visible = true;
					break;
				case (int)Pages.STBY:
					break;
				case (int)Pages.INV:
					break;
				case (int)Pages.SJ:
					break;
				case (int)Pages.EJ:
					break;
				case (int)Pages.AAM:
					break;
				case (int)Pages.MSL:
					break;
				case (int)Pages.DGFT:
					break;
				case (int)Pages.GUN:
					break;
				case (int)Pages.AG:
					break;
				case (int)Pages.BIT:
					break;
				default:
					break;
			}

			if (page == (int)Pages.OFF)
			{
				pictureBoxSMSOFF.Visible = true;
			}
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

	public class Controls
	{

	}
}
