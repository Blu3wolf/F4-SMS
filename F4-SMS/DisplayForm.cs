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

	public enum DisplayImage
	{
		SMSOFF, SMSW
	}

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

			INVLabels = new Label[]
			{
				labelOSB20,
				labelOSB16,
				labelOSB17,
				labelINVSt3,
				labelINVSt4,
				labelINVSt5,
				labelINVSt6,
				labelINVSt7,
				labelOSB9,
				labelOSB10
			};

			// Generate the array of all picture elements
			displayImages = new PictureBox[]
			{
				pictureBoxSMSOFF,
				pictureBoxSMSW
			};

			// set initial values for form start

			MMC = new MMC(this)
			{
				WOW = checkBoxWOW.Checked,
				SMSPower = checkBoxSMSPower.Checked,
				MFDSPower = checkBoxMFDSPower.Checked,
				MMCPower = checkBoxMMCPower.Checked
			};
			display = new Display(this);
		}

		internal Display display;

		// this is the MMC object for this instance of the DisplayForm window
		private MMC mMC;

		private Label[] OSBLabels;

		private Label[] INVLabels;

		private PictureBox[] displayImages;

		internal MMC MMC { get => mMC; set => mMC = value; }

		public void BlankDisplay()
		{
			// Make all display screen elements non visible
			foreach (Label label in OSBLabels)
			{
				label.Visible = false;
			}

			foreach (Label label in INVLabels)
			{
				label.Visible = false;
			}
			
			foreach (PictureBox displayPicture in displayImages)
			{
				displayPicture.Visible = false;
			}

			// Do the same for the labelMid8 (HUNG STORES)
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

		public void UpdateINVStLabel(int station, string text)
		{
			Label label = INVLabels[station];
			ValidateInput(label, text);
		}

		public void UpdateDisplayImage(int Image, bool visible)
		{
			displayImages[Image].Visible = visible;
		}
            
        private void CheckBoxSMSPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC.SMSPower = checkBoxSMSPower.Checked;
        }

        private void CheckBoxMMCPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC.MMCPower = checkBoxMMCPower.Checked;
        }

        private void CheckBoxMFDSPower_CheckedChanged(object sender, EventArgs e)
        {
			MMC.MFDSPower = checkBoxMFDSPower.Checked;
        }

		private void CheckBoxWOW_CheckedChanged(object sender, EventArgs e)
		{
			MMC.WOW = checkBoxWOW.Checked;
		}

		private void ButtonAAMastermode_Click(object sender, EventArgs e)
		{
			MMC.CurrentMasterMode = (int)MasterModes.AA;
		}

		private void ButtonAGMastermode_Click(object sender, EventArgs e)
		{
			MMC.CurrentMasterMode = (int)MasterModes.AG;
		}

		private void RadioButtonMRM_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonMRM.Checked)
			{
				MMC.CurrentMasterMode = (int)MasterModes.MSL;
			}
		}

		private void RadioButtonCancelOverride_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonCancelOverride.Checked)
			{
				MMC.CancelOverride();
			}
		}

		private void RadioButtonDGFT_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonDGFT.Checked)
			{
				MMC.CurrentMasterMode = (int)MasterModes.DGFT;
			}
		}

		public void UpdateMMLabel()
		{
			CurrMMLabel.Visible = true;
			int mode = MMC.CurrentMasterMode;
			string modename = ((MasterModes) mode).ToString();
			CurrMMLabel.Text = modename;
		}

		public void HideMMLabel()
		{
			CurrMMLabel.Visible = false;
		}

		private void ButtonOSB1_Click(object sender, EventArgs e)
		{
			display.ButtonPress(1);
		}

		private void ButtonOSB2_Click(object sender, EventArgs e)
		{
			display.ButtonPress(2);
		}

		private void ButtonOSB3_Click(object sender, EventArgs e)
		{
			display.ButtonPress(3);
		}

		private void ButtonOSB4_Click(object sender, EventArgs e)
		{
			display.ButtonPress(4);
		}

		private void ButtonOSB5_Click(object sender, EventArgs e)
		{
			display.ButtonPress(5);
		}

		private void ButtonOSB6_Click(object sender, EventArgs e)
		{
			display.ButtonPress(6);
		}

		private void ButtonOSB7_Click(object sender, EventArgs e)
		{
			display.ButtonPress(7);
		}

		private void ButtonOSB8_Click(object sender, EventArgs e)
		{
			display.ButtonPress(8);
		}

		private void ButtonOSB9_Click(object sender, EventArgs e)
		{
			display.ButtonPress(9);
		}

		private void ButtonOSB10_Click(object sender, EventArgs e)
		{
			display.ButtonPress(10);
		}

		private void ButtonOSB11_Click(object sender, EventArgs e)
		{
			display.ButtonPress(11);
		}

		private void ButtonOSB12_Click(object sender, EventArgs e)
		{
			display.ButtonPress(12);
		}

		private void ButtonOSB13_Click(object sender, EventArgs e)
		{
			display.ButtonPress(13);
		}

		private void ButtonOSB14_Click(object sender, EventArgs e)
		{
			display.ButtonPress(14);
		}

		private void ButtonOSB15_Click(object sender, EventArgs e)
		{
			display.ButtonPress(15);
		}

		private void ButtonOSB16_Click(object sender, EventArgs e)
		{
			display.ButtonPress(16);
		}

		private void ButtonOSB17_Click(object sender, EventArgs e)
		{
			display.ButtonPress(17);
		}

		private void ButtonOSB18_Click(object sender, EventArgs e)
		{
			display.ButtonPress(18);
		}

		private void ButtonOSB19_Click(object sender, EventArgs e)
		{
			display.ButtonPress(19);
		}

		private void ButtonOSB20_Click(object sender, EventArgs e)
		{
			display.ButtonPress(20);
		}
	}
}
