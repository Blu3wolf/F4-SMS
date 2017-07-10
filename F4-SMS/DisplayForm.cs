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

			// set initial values for form start
			MMC MMCObject = new MMC(this);
			MMC1 = MMCObject;
			MMC1.WOW = checkBoxWOW.Checked;
			MMC1.SMSPower = checkBoxSMSPower.Checked;
			MMC1.MFDSPower = checkBoxMFDSPower.Checked;
			MMC1.MMCPower = checkBoxMMCPower.Checked;

			DigitalInventory DigInvObject = new DigitalInventory();
			DigInv1 = DigInvObject;

			PhysicalInventory PhyInvObject = new PhysicalInventory();
			PhyInv1 = PhyInvObject;

			// Generate the array of OSB labels for this display
			OSBLabels = new Label[]
			{
				labelOSB1,
				labelOSB2,
				labelOSB3,
				labelOSB4,
				labelOSB5,
				labelOSB6,
				labelOSB7,
				labelOSB8,
				labelOSB9,
				labelOSB10,
				labelOSB11,
				labelOSB12,
				labelOSB13,
				labelOSB14,
				labelOSB15,
				labelOSB16,
				labelOSB17,
				labelOSB18,
				labelOSB19,
				labelOSB20
			};

			// Generate the list of all picture elements
			allPictures.Add(pictureBoxSMSOFF);
			allPictures.Add(pictureBoxSMSW);

			// Blank the MFD completely
			BlankSMSPage();
		}

		// this is the MMC object for this instance of the DisplayForm window
		private MMC MMC1;

		// this is the Digital Inventory object for this instance of the DF window
		private DigitalInventory DigInv1;

		// this is the Physical Inventory object for this instance of the DF window
		private PhysicalInventory PhyInv1;

		private Label[] OSBLabels;

		private List<PictureBox> allPictures = new List<PictureBox>();

		public void BlankSMSPage()
		{
			// Make all display screen elements non visible
			// Do this by iterating over the collection OSBLabels and marking each object .Visible = false;
			foreach (Label label in OSBLabels)
			{
				label.Visible = false;
			}

			// Do the same for allPictures and mark each one as .Visible = false;
			foreach (PictureBox displayPicture in allPictures)
			{
				displayPicture.Visible = false;
			}
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

		public void UpdateOSBLabel(int OSB, string text)
		{
			Label label = OSBLabels[(OSB - 1)];
			if (text.Length == 0)
			{
				label.Visible = false;
			}
			else
			{
				label.Text = text;
				label.Visible = true;
			}
		}
            
        private void checkBoxSMSPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC1.SMSPower = checkBoxSMSPower.Checked;
            MMC1.SystemStartupOptionsChanged((int)MMC.SystemStartupOptions.SMSPower);
        }

        private void checkBoxMMCPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC1.MMCPower = checkBoxMMCPower.Checked;
			MMC1.SystemStartupOptionsChanged((int)MMC.SystemStartupOptions.MMCPower);
        }

        private void checkBoxMFDSPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC1.MFDSPower = checkBoxMFDSPower.Checked;
            MMC1.SystemStartupOptionsChanged((int)MMC.SystemStartupOptions.MFDSPower);
        }

		private void checkBoxWOW_CheckedChanged(object sender, EventArgs e)
		{
			MMC1.WOW = checkBoxWOW.Checked;
			MMC1.SystemStartupOptionsChanged((int)MMC.SystemStartupOptions.WOW);
		}

		private void buttonAAMastermode_Click(object sender, EventArgs e)
		{
			MMC1.CurrentMasterMode = (int)MMC.MasterModes.AA;
		}

		private void buttonAGMastermode_Click(object sender, EventArgs e)
		{
			MMC1.CurrentMasterMode = (int)MMC.MasterModes.AG;
		}

		private void radioButtonMRM_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonMRM.Checked)
			{
				MMC1.CurrentMasterMode = (int)MMC.MasterModes.MSL;
			}
		}

		private void radioButtonCancelOverride_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonCancelOverride.Checked)
			{
				MMC1.CancelOverride();
			}
		}

		private void radioButtonDGFT_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonDGFT.Checked)
			{
				MMC1.CurrentMasterMode = (int)MMC.MasterModes.DGFT;
			}
		}

		public void UpdateMMLabel()
		{
			CurrMMLabel.Visible = true;
			int mode = MMC1.CurrentMasterMode;
			string modename = ((MMC.MasterModes) mode).ToString();
			CurrMMLabel.Text = modename;
		}

		public void HideMMLabel()
		{
			CurrMMLabel.Visible = false;
		}
	}
}
