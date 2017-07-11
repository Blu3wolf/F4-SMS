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
		public PageSTBY(Display Displayer) : base(Displayer) { }

		public override void DrawMe()
		{
			UpdateOSB(1, "STBY");
			UpdateOSB(4, "INV");
			UpdateOSB(6, "BARO");
			UpdateOSB(8, string.Format("CLR{0}RACK", Environment.NewLine));
			UpdateOSB(11, "S-J");
			UpdateOSB(12, "WPN");
			UpdateOSB(14, "SMS");
			UpdateOSB(15, "SWAP");
			UpdateOSB(18, string.Format("CLR{0}WPN", Environment.NewLine));
			UpdateMid(8, "HUNG STORE");
			display.UpdateDisplayImage((int)Display.DisplayImage.SMSW, true);
		}
	}
}
