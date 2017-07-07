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

		public bool WOW;

		private int currentMasterMode;

		public int CurrentMasterMode { get => currentMasterMode; set => currentMasterMode = value; }

		public enum MasterModes
		{
			NAV, AA, AG, DGFT, MSL
		}

		// displayPage is the int of the current page if read from the enum Pages
		private int displayPage;

		// Pages is a enum of all possible display pages
		public enum Pages
		{
			OFF, STBY, INV, SJ, EJ, AAM, MSL, DGFT, GUN, AG, BIT
		}

		public enum SystemStartupOptions
		{
			MMCPower, MFDSPower, SMSPower, WOW, DTCLoad, InvLoad, GunArmed
		}

		public void SystemStartupOptionsChanged(int Option)
		{
			if (MFDSPower)
			{
				if (!(SMSPower & MMCPower))
				{
					// MFDS has power, but either ST STA or FCC is not powered, so display the OFF page

				}
				else
				{
					// MFDS, SMS and MMC all have power
					switch (Option)
					{
						case (int)SystemStartupOptions.MMCPower:
							// MMC just powered up
							if (WOW)
							{
								// MMC just powered up on the ground
								// Mastermode will now be NAV
								// SMS will now be STBY mode, INV page

							}
							else
							{
								// MMC just powered up in the air
								// Mastermode will be whatever it was last

							}
							break;
						case (int)SystemStartupOptions.SMSPower:
							// SMS just powered up, in STBY mode
							// we should probably display the INV page

							break;
						default:
							break;
					}
					{ 
						// MFDS, MMC and SMS have power, and WOW=true, so display the STBY page
						Display.SetSMSPage((int)Pages.STBY);
						// If the 
						masterMode = (int)Mastermodes.NAV;
					}
				}
			}
			else
			{
				// MFDS has no power, so blank the MFD

			}
		}

	}
}
