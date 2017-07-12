using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	abstract class SMSPage
	{
		public SMSPage(Display Displayer)
		{
			display = Displayer;
		}

		public SMSPage()
		{
		}

		public void SwitchTo()
		{
			DrawMe();
			display.CurrPage = this;
		}

		internal Display display;

		public abstract void DrawMe();

		public abstract void ButtonPress(int OSB);

		internal void UpdateOSB(int OSB, string text)
		{
			display.UpdateOSBLabel(OSB, text);
		}

		internal void UpdateMid(int line, string text)
		{
			display.UpdateMidLabel(line, text);
		}

	}
}
