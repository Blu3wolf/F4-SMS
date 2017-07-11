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

			// Generate the array of all picture elements
			displayImages = new PictureBox[]
			{
				pictureBoxSMSOFF,
				pictureBoxSMSW
			};

			// set initial values for form start
			display = new Display(this);

			MMC MMCObject = new MMC(this);
			MMC1 = MMCObject;
			MMC1.WOW = checkBoxWOW.Checked;
			MMC1.SMSPower = checkBoxSMSPower.Checked;
			MMC1.MFDSPower = checkBoxMFDSPower.Checked;
			MMC1.MMCPower = checkBoxMMCPower.Checked;

		}

		internal Display display;

		// this is the MMC object for this instance of the DisplayForm window
		private MMC MMC1;

		private Label[] OSBLabels;

		private PictureBox[] displayImages;

		public void BlankDisplay()
		{
			// Make all display screen elements non visible
			// Do this by iterating over the collection OSBLabels and marking each object .Visible = false;
			foreach (Label label in OSBLabels)
			{
				label.Visible = false;
			}

			// Do the same for displayImages and mark each one as .Visible = false;
			foreach (PictureBox displayPicture in displayImages)
			{
				displayPicture.Visible = false;
			}

			// Do the same for the labelMid8
			labelMid8.Visible = false;
		}

		private void ValidateInput(Label label, string text)
		{
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

		public void UpdateOSBLabel(int OSB, string text)
		{
			Label label = OSBLabels[(OSB - 1)];
			ValidateInput(label, text);
		}

		public void UpdateMidLabel(int line, string text)
		{
			Label label = labelMid8;
			ValidateInput(label, text);
		}

		public void UpdateDisplayImage(int Image, bool visible)
		{
			displayImages[Image].Visible = visible;
		}
            
        private void CheckBoxSMSPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC1.SMSPower = checkBoxSMSPower.Checked;
        }

        private void CheckBoxMMCPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC1.MMCPower = checkBoxMMCPower.Checked;
        }

        private void CheckBoxMFDSPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC1.MFDSPower = checkBoxMFDSPower.Checked;
        }

		private void CheckBoxWOW_CheckedChanged(object sender, EventArgs e)
		{
			MMC1.WOW = checkBoxWOW.Checked;
		}

		private void ButtonAAMastermode_Click(object sender, EventArgs e)
		{
			MMC1.CurrentMasterMode = (int)MMC.MasterModes.AA;
		}

		private void ButtonAGMastermode_Click(object sender, EventArgs e)
		{
			MMC1.CurrentMasterMode = (int)MMC.MasterModes.AG;
		}

		private void RadioButtonMRM_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonMRM.Checked)
			{
				MMC1.CurrentMasterMode = (int)MMC.MasterModes.MSL;
			}
		}

		private void RadioButtonCancelOverride_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonCancelOverride.Checked)
			{
				MMC1.CancelOverride();
			}
		}

		private void RadioButtonDGFT_CheckedChanged(object sender, EventArgs e)
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
