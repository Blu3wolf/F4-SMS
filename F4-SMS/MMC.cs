using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* Responsible for controlling the MMC state
	 * decides what mastermode to be in, based on input to DisplayForm
	 * stores current master mode, power status, status of A/C */

	class MMC
	{
		public MMC(DisplayForm WinForm)
		{
			// does anything need to be done to instantiate the object?
			winform = WinForm;
		}

		private DisplayForm winform;

		private bool mMCPower;

		private bool mFDSPower;

		private bool sMSPower;

		private bool gunArmed;

		private bool wOW;

		private int currentMasterMode;

		private int overriddenMasterMode;

		public int CurrentMasterMode
		{
			get => currentMasterMode;
			set
			{
				switch (value)
				{
					case (int)MasterModes.DGFT | (int)MasterModes.MSL:
						if (currentMasterMode == (int)MasterModes.DGFT | currentMasterMode == (int)MasterModes.MSL)
						{
							currentMasterMode = value;
						}
						else
						{
							overriddenMasterMode = currentMasterMode;
							currentMasterMode = value;
						}
						break;
					default:
						if (currentMasterMode != (int)MasterModes.DGFT & currentMasterMode != (int)MasterModes.MSL)
						{
							if (currentMasterMode == value)
							{
								currentMasterMode = (int)MasterModes.NAV;
							}
							else
							{
								currentMasterMode = value;
							}
						}
						else
						{
							// the current mastermode is DGFT or MSL, and we just tried to switch to a non override mode
						}
						break;
				}
				winform.UpdateMMLabel();
			}
		}

		public void CancelOverride()
		{
			currentMasterMode = overriddenMasterMode;
			winform.UpdateMMLabel();
		}

		public bool MMCPower { get => mMCPower; set => mMCPower = value; }

		public bool MFDSPower { get => mFDSPower; set => mFDSPower = value; }

		public bool SMSPower { get => sMSPower; set => sMSPower = value; }

		public bool GunArmed { get => gunArmed; set => gunArmed = value; }

		public bool WOW { get => wOW; set => wOW = value; }

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
					winform.UpdateMMLabel();
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
				}
			}
			else
			{
				// MFDS has no power, so blank the MFD

			}

			if (!MMCPower)
			{
				// MMC has no power
				winform.HideMMLabel();

				if (Option == (int)SystemStartupOptions.MMCPower)
				{
					// the MMC just powered off. If the DTC was being loaded, 
					// or the INV was being changed, SMS might lockup

				}
			}
		}



	}
}
