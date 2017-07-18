using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* Responsible for logic about how STBY page reacts to user input. 
	 * knows how STBY page reacts to input
	 * tells display how to draw STBY page */

	class PageSTBY : SMSPage
	{
		public PageSTBY(Display Displayer)
		{
			display = Displayer;
			string[] BBSOptions = new string[] { "BARO", "RALT", "PR" };
			BBS = new Rotary(BBSOptions);
			display.MMC.MMCPowerUp += OnMMCPowerUp;
		}

		private void OnMMCPowerUp(object sender, EventArgs e)
		{
			BBS.ResetCurrOption();
		}

		private Rotary BBS;

		public override void DrawMe()
		{
			UpdateOSB(1, "STBY");
			UpdateOSB(4, "INV");
			UpdateOSB(6, BBS.GetCurrOption());
			UpdateOSB(8, string.Format("CLR{0}RACK", Environment.NewLine));
			UpdateOSB(11, "S-J");
			UpdateOSB(12, "WPN");
			UpdateOSB(14, "SMS");
			UpdateOSB(15, "SWAP");
			UpdateOSB(18, string.Format("CLR{0}WPN", Environment.NewLine));
			// UpdateMid(8, "HUNG STORE"); // do this only if a hung store is present
			display.UpdateDisplayImage((int)DisplayImage.SMSW, true);
		}

		public override void ButtonPress(int OSB)
		{
			switch (OSB)
			{
				case 4:
					display.SwitchTo((int)PageTypes.INVPage);
					break;
				case 6:
					BBS.IncOption();
					UpdateOSB(6, BBS.GetCurrOption());
					break;
				default:
					break;
			}
		}
	}
}
