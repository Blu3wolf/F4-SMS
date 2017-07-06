using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* Responsible for controlling the MMC state
	 * decides what mastermode to be in
	 * stores current master mode, power status, status of A/C */

	class MMC
	{
		public MMC()
		{

		}

		public bool MMCPower;

		public bool MFDSPower;

		public bool SMSPower;

		public bool GunArmed;

		private int currentMasterMode;

		public int CurrentMasterMode { get => currentMasterMode; set => currentMasterMode = value; }

		private enum MasterModes
		{
			NAV, AA, AG, DGFT, MSL
		}

		public int SetMasterMode()
		{

		}

		// displayPage is the int of the current page if read from the enum Pages
		private int displayPage;

		// Pages is a enum of all possible display pages
		private enum Pages
		{
			OFF, STBY, INV, SJ, EJ, AAM, MSL, DGFT, GUN, AG, BIT
		}

	}
}
