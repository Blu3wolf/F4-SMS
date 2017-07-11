using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* Responsible for displaying the MFD on the DisplayForm
	 * knows what is drawn on the MFD 
	 * acts a bit like the SMS computer, decides what page to display, etc*/

	class Display
	{
		public Display(DisplayForm WinForm)
		{
			winform = WinForm;
			PageOFF OFFPage = new PageOFF(this);
			PageSTBY STBYPage = new PageSTBY(this);
			
			Pages = new Object[]
			{
				OFFPage,
				STBYPage
			};

		}

		private DisplayForm winform;

		private Object[] Pages;

		private SMSPage currPage;

		public SMSPage CurrPage { get => currPage; set => currPage = value; }

		public void UpdateOSBLabel(int OSB, string text)
		{
			winform.UpdateOSBLabel(OSB, text);
		}
	}
}