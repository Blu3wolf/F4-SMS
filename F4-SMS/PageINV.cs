using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* responsible for telling Display how to draw INV page.
	 * knows the logic for how the INV page reacts to user input. */

	class PageINV : SMSPage
	{
		public PageINV(Display Displayer)
		{
			display = Displayer;
		}

		public override void DrawMe()
		{
			int ModeNo = display.MMC.CurrentMasterMode;
			string ModeName;
			switch (ModeNo)
			{
				case (int)MasterModes.NAV:
					ModeName = "STBY";
					break;
				case (int)MasterModes.AA:
					ModeName = "A-A";
					break;
				case (int)MasterModes.AG:
					ModeName = "A-G";
					break;
				case (int)MasterModes.DGFT:
					ModeName = "DGFT";
					break;
				case (int)MasterModes.MSL:
					ModeName = "MSL";
					break;
				default:
					ModeName = "STBY";
					break;
			}
			 // string ModeName = Enum.GetName(typeof(MasterModes), ModeNo);
			UpdateOSB(1, ModeName);
			UpdateOSB(3, string.Format("{0} 1  MAU{0} 1  TK300{0}- - - - - - -", Environment.NewLine));
			UpdateOSB(4, "INV");
			UpdateOSB(5, "CLR");
			UpdateOSB(9, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateOSB(10, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateOSB(11, "S-J");
			UpdateOSB(12, "WPN");
			UpdateOSB(14, "SMS");
			UpdateOSB(15, "SWAP");
			UpdateOSB(16, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateOSB(17, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateOSB(20, string.Format("51GUN{0}M56", Environment.NewLine));
			display.UpdateDisplayImage((int)DisplayImage.SMSW, true);
		}

		public override void ButtonPress(int OSB)
		{
			switch (OSB)
			{
				case 4:
					// switch to the correct SMS mode page: STBY, A-G, A-A, DGFT, or MSL as appropriate
					display.SwitchTo((int)PageTypes.STBYPage);
					break;
				default:
					break;
			}
		}
	}
}
