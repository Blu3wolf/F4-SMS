﻿using System;
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
			mMC = winform.MMC
			PageOFF OFFPage = new PageOFF(this);
			PageSTBY STBYPage = new PageSTBY(this);
			currPage = OFFPage;
			
			Pages = new SMSPage[]
			{
				OFFPage,
				STBYPage
			};

			// Blank the MFD completely
			BlankDisplay();

		}

		public enum PageTypes
		{
			OFFPage, STBYPage
		}

		public enum DisplayImage
		{
			SMSOFF, SMSW
		}

		private DisplayForm winform;

		private MMC mMC;

		private SMSPage[] Pages;

		private SMSPage currPage;

		public SMSPage CurrPage { get => currPage; set => currPage = value; }

		internal MMC MMC { get => mMC; set => mMC = value; }

		

		private void SystemStartUp(object sender, SystemStartupEventArgs e)
		{
			if (e.MFDSPower)
			{
				if (e.SMSPower & e.MMCPower)
				{
					// MFDS has power, MMC and ST STA have power
					SwitchTo((int)PageTypes.STBYPage);
				}
				else
				{
					// MFDS has power, but either ST STA or MMC is not powered, so display the OFF page
					SwitchTo((int)PageTypes.OFFPage);
				}
			}
		}

		public void BlankDisplay()
		{
			winform.BlankDisplay();
		}

		public void UpdateOSBLabel(int OSB, string text)
		{
			winform.UpdateOSBLabel(OSB, text);
		}

		public void UpdateMidLabel(int line, string text)
		{
			winform.UpdateMidLabel(line, text);
		}

		public void UpdateDisplayImage(int Image, bool visible)
		{
			winform.UpdateDisplayImage(Image, visible);
		}

		public void SwitchTo(int pagetype)
		{
			BlankDisplay();
			Pages[pagetype].SwitchTo();
		}

		public void ButtonPress(int OSB)
		{
			CurrPage.ButtonPress(OSB);
		}
	}
}