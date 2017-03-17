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
			// Ini Com required for winforms designer support
            InitializeComponent();

			// set initial page value for form start, and blank the page completely (MFD starts off, off)
			displayPage = (int)Pages.OFF;
			BlankSMSPage();

			// Generate the list of all labels
			allLabels.Add(labelOSB1);
			allLabels.Add(labelOSB2);
			allLabels.Add(labelOSB3);
			allLabels.Add(labelOSB4);
			allLabels.Add(labelOSB5);
			allLabels.Add(labelOSB6);
			allLabels.Add(labelOSB7);
			allLabels.Add(labelOSB8);
			allLabels.Add(labelOSB9);
			allLabels.Add(labelOSB10);
			allLabels.Add(labelOSB11);
			allLabels.Add(labelOSB12);
			allLabels.Add(labelOSB13);
			allLabels.Add(labelOSB14);
			allLabels.Add(labelOSB15);
			allLabels.Add(labelOSB16);
			allLabels.Add(labelOSB17);
			allLabels.Add(labelOSB18);
			allLabels.Add(labelOSB19);
			allLabels.Add(labelOSB20);
			allLabels.Add(labelHungStores);

			// Generate the list of all picture elements
			allPictures.Add(pictureBoxSMSOFF);
		}

		private List<Label> allLabels = new List<Label>();

		private List<PictureBox> allPictures = new List<PictureBox>();

		// Pages is a enum of all possible display pages
		public enum Pages
		{
			OFF, STBY, INV, SJ, EJ, AAM, MSL, DGFT, GUN, AG, BIT, WPN, FCR
		}

		// displayPage is the int of the current page if read from the enum Pages
		public int displayPage;

		// Mastermodes is an enum of all possible system mastermodes
		public enum Mastermodes
		{
			NAV, AA, AG, DGFT, MSL
		}

		// masterMode is the int of the system mastermode if read from the enum Mastermodes
		public int Mastermode;

        // If Startup options change, this function figures out what changes to make to the display
        public void SystemStartupOptionsChanged()
        {
            if (checkBoxMFDSPower.Checked)
            {
				if (!(checkBoxSMSPower.Checked & checkBoxMMCPower.Checked))
				{
					// MFDS has power, but either ST STA or FCC is not powered, so display the OFF page
					SetSMSPage((int)Pages.OFF);
                }
				else 
				{
					if (checkBoxWOW.Checked)
					{
						// MFDS, MMC and SMS have power, and WOW=true, so display the STBY page
						SetSMSPage((int)Pages.STBY);
					}
					else
					{
						// MFDS, MMC and SMS have power, and WOW=false, so display the last selected master mode
						// ... somehow
					}
				}
            }
			else
			{
				// MFDS has no power, so blank the MFD
				BlankSMSPage();
			}
        }

		public void BlankSMSPage()
		{
			// Make all display screen elements non visible
			// Do this by iterating over the collection allLabels and marking each object .Visible = false;
			foreach (Label displayLabel in allLabels)
			{
				displayLabel.Visible = false;
			}

			// Do the same for allPictures and mark each one as .Visible = false;
			foreach (PictureBox displayPicture in allPictures)
			{
				displayPicture.Visible = false;
			}
		}

		public void SetSMSPage(int page)
		{
			// Wipe the slate clean
			BlankSMSPage();

			// Figure out which page we are switching to, and display that page
			switch (page)
			{
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
				case (int)Pages.WPN:
					break;
				case (int)Pages.FCR:
					break;
				default:
					// We got a weird result; Display the OFF page anyway. 
					pictureBoxSMSOFF.Visible = true;
					break;
			}

			// Update the value of displayPage

			displayPage = page;
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

		private void checkBoxWOW_CheckedChanged(object sender, EventArgs e)
		{
			SystemStartupOptionsChanged();
		}
	}

	public class Controls
	{

	}

	public class OFF
	{
		public OFF()
		{

		}

		private List<Label> offLabels = new List<Label>();
	}

	public class STBY
	{

	}
}
