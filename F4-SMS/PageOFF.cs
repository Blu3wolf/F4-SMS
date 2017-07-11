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
			display.UpdateOSBLabel(9, string.Format("C{0}Z", Environment.NewLine));
			display.UpdateOSBLabel(12, "FCR");
			display.UpdateOSBLabel(13, "WPN");
			display.UpdateOSBLabel(14, "SMS");
			display.UpdateOSBLabel(15, "SWAP");
			display.UpdateDisplayImage((int)Display.displayImage.SMSOFF, true);
			display.UpdateDisplayImage((int)Display.displayImage.SMSW, true);
		}
	}
}
