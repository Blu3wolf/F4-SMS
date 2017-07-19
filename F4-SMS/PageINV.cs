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
			UpdateOSB(4, "INV");
			UpdateOSB(5, "CLR");
			UpdateOSB(11, "S-J");
			UpdateOSB(12, "WPN");
			UpdateOSB(14, "SMS");
			UpdateOSB(15, "SWAP");
			display.UpdateDisplayImage((int)DisplayImage.SMSW, true);

			string[] Inv = new string[]
			{
				Mline("51GUN", "M56"),
				Mline(InvLine(1, "MRLW"), InvLine(1, "A120A")),
				Mline(InvLine(1, "MRLW"), InvLine(1, "A120A")),
				Mline(InvLine(1, "MAU"), InvLine(1, "TER"), InvLine(3, "M82BS")),
				Mline(InvLine(1, "TK370"), BlankLine(), BlankLine()),
				Mline(InvLine(1, "MAU"), InvLine(1, "TK300"), BlankLine()),
				Mline(InvLine(1, "TK370"), BlankLine(), BlankLine()),
				Mline(InvLine(1, "MAU"), InvLine(1, "TER"), InvLine(3, "M82BS")),
				Mline(InvLine(1, "LNCH"), InvLine(1, "A-9X")),
				Mline(InvLine(1, "MRLW"), InvLine(1, "A120A")),
			};


			UpdateINV(Inv);
			/*
			UpdateINVSt(0, string.Format("51GUN{0}M56", Environment.NewLine));
			UpdateINVSt(1, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateINVSt(2, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateINVSt(3, string.Format(" 1  MAU{0} 1  TER{0} 3  M82BS", Environment.NewLine));
			UpdateINVSt(4, string.Format(" 1  TK370{0}-   -   -   -   -   -   -{0}-   -   -   -   -   -   -", Environment.NewLine));
			UpdateINVSt(5, string.Format(" 1  MAU{0} 1  TK300{0}- - - - - - -", Environment.NewLine));
			UpdateINVSt(6, string.Format(" 1  TK370{0}-   -   -   -   -   -   -{0}-   -   -   -   -   -   -", Environment.NewLine));
			UpdateINVSt(7, string.Format(" 1  MAU{0} 1  TER{0} 3  M82BS", Environment.NewLine));
			UpdateINVSt(8, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			UpdateINVSt(9, string.Format(" 1  MRLW{0} 1  A120A", Environment.NewLine));
			*/
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

		public string Mline(string line1, string line2)
		{
			return String.Format("{0}{2}{1}", line1, line2, Environment.NewLine);
		}

		public string Mline(string line1, string line2, string line3)
		{
			return String.Format("{0}{3}{1}{3}{2}", line1, line2, line3, Environment.NewLine);
		}

		public string InvLine(int qty, string type)
		{
			return String.Format(" {0}  {1}", qty, type);
		}

		public string BlankLine()
		{
			return "-  -  -  -  -  -  -";
		}

		public void UpdateINV(string[] INV)
		{
			if (INV.Length != 10)
			{
				throw new Exception();
			}
			int count = -1; // this means first iteration is count #0
			foreach (string ILabel in INV)
			{
				count += 1;
				UpdateINVSt(count, ILabel);
			}
		}
	}
}
