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

		}

		private Display display;

		public abstract void DrawMe();

		public void UpdateOSB(int OSB, string text)
		{

		}

	}
}
