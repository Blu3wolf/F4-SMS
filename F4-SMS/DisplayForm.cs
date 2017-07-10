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

			DigitalInventory DigInvObject = new DigitalInventory();
			DigInv1 = DigInvObject;

			PhysicalInventory PhyInvObject = new PhysicalInventory();
			PhyInv1 = PhyInvObject;

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

		// this is the MMC object for this instance of the DisplayForm window
		private MMC MMC1;

		// this is the Digital Inventory object for this instance of the DF window
		private DigitalInventory DigInv1;

		// this is the Physical Inventory object for this instance of the DF window
		private PhysicalInventory PhyInv1;

		private List<Label> allLabels = new List<Label>();

		private List<PictureBox> allPictures = new List<PictureBox>();

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
