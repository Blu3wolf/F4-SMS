using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F4SMS
{

	/* Class is responsible for the whole of the Form - the UI and the MFDS display */

    public partial class DisplayForm : Form
    {
		// DisplayForm() gets called when the form is initialised, which happens when someone pressed load on the main menu
        public DisplayForm()
        {
			// Ini Com required for winforms designer support
            InitializeComponent();

			// instantiate MMC
			MMC MMC1 = new MMC();

			// set initial values for form start
			displayPage = (int)Pages.OFF;
			masterMode = (int)Mastermodes.NAV;
			overrideState = false;

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
			allPictures.Add(pictureBoxSMSW);

			// Blank the MFD completely
			BlankSMSPage();
		}

		private List<Label> allLabels = new List<Label>();

		private List<PictureBox> allPictures = new List<PictureBox>();

		// overrideState is the bool of whether the DGFT switch is not centered
		private bool overrideState;

		// overridden is the int of the system mastermode that was overridden by the override
		private int overridden;

		// If Startup options change, this function figures out what changes to make to the display
		private void SystemStartupOptionsChanged()
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
						masterMode = (int)Mastermodes.NAV;
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

		private void BlankSMSPage()
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

		private void SetSMSPage(int page)
		{
			// Wipe the slate clean
			BlankSMSPage();

			// Figure out which page we are switching to, and display that page
			switch (page)
			{
				case (int)Pages.OFF:
					displayOFF();
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

		private void displayOFF()
		{
			pictureBoxSMSOFF.Visible = true;
			pictureBoxSMSW.Visible = true;
			labelOSB9.Visible = true;
			labelOSB12.Visible = true;
			labelOSB13.Visible = true;
			labelOSB14.Visible = true;
			labelOSB15.Visible = true;
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
			// WOW changing doesnt actually change the SMS state itself, so dont do anything in particular
		}

		private void buttonAAMastermode_Click(object sender, EventArgs e)
		{
			if (!overrideState)
			{
				if (masterMode == (int)Mastermodes.AA)
				{
					masterMode = (int)Mastermodes.NAV;
				}
				else
				{
					masterMode = (int)Mastermodes.AA;
				}
			}
		}

		private void buttonAGMastermode_Click(object sender, EventArgs e)
		{
			if (!overrideState)
			{
				if (masterMode == (int)Mastermodes.AG)
				{
					masterMode = (int)Mastermodes.NAV;
				}
				else
				{
					masterMode = (int)Mastermodes.AG;
				}
			}
		}

		private void radioButtonMRM_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonMRM.Checked)
			{
				overrideState = true;
				overridden = masterMode;
				masterMode = (int)Mastermodes.MSL;
			}
		}

		private void radioButtonCancelOverride_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonCancelOverride.Checked)
			{
				overrideState = false;
				masterMode = overridden;
			}
		}

		private void radioButtonDGFT_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonDGFT.Checked)
			{
				overrideState = true;
				overridden = masterMode;
				masterMode = (int)Mastermodes.DGFT;
			}
		}
	}
}
