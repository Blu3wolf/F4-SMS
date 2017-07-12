using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* responsible for telling display how to draw the OFF page, 
	 * contains information about how OFF page reacts to user input */

	class PageOFF : SMSPage
	{
		public PageOFF(Display Displayer) : base(Displayer) { }

		public override void DrawMe()
		{
			UpdateOSB(9, string.Format("C{0}Z", Environment.NewLine));
			UpdateOSB(12, "FCR");
			UpdateOSB(13, "WPN");
			UpdateOSB(14, "SMS");
			UpdateOSB(15, "SWAP");
			display.UpdateDisplayImage((int)Display.DisplayImage.SMSOFF, true);
			display.UpdateDisplayImage((int)Display.DisplayImage.SMSW, true);
		}

		public override void ButtonPress(int OSB)
		{
			
		}
	}
}
