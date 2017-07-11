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
			display = winform.display;
			CurrentMasterMode = (int)MasterModes.NAV;
			overridden = false;
			DigInv1 = new DigitalInventory();
			PhyInv1 = new PhysicalInventory();
		}

		// this is the Digital Inventory object for this instance of the DF window
		private DigitalInventory DigInv1;

		// this is the Physical Inventory object for this instance of the DF window
		private PhysicalInventory PhyInv1;

		private DisplayForm winform;

		private Display display;

		private bool mMCPower;

		private bool mFDSPower;

		private bool sMSPower;

		private bool gunArmed;

		private bool wOW;

		private int currentMasterMode;

		private int overriddenMasterMode; // this should be the mode to reenter after cancelling an override mode

		private bool overridden; // whether or not the current mastermode is an override mode

		public int CurrentMasterMode
		{
			get => currentMasterMode;
			set
			{
				if (MMCPower)
				{
					if (value == (int)MasterModes.DGFT | value == (int)MasterModes.MSL)
					{
						// we are switching to an override mode
						if (overridden)
						// we are switching from an override mode, to an override mode
						{
							currentMasterMode = value;
						}
						else
						// we are switching from a non-override mode to an override mode
						{
							overriddenMasterMode = currentMasterMode;
							currentMasterMode = value;
							overridden = true;
						}
					}
					else // we are switching to a non-override mode
					{
						if (overridden)
						{
							// the current mastermode is DGFT or MSL, and 
							// we just tried to switch to a non override mode
						}
						else
						{
							// then are are switching from a non-override mode
							if (currentMasterMode == value)
							// we are trying to switch to the current mode? select NAV then
							{
								currentMasterMode = (int)MasterModes.NAV;
							}
							else
							// we are switching to a non-override mode,
							// and we arent trying to select the current mode
							{
								currentMasterMode = value;
							}
						}
					}
					winform.UpdateMMLabel();
				}
			}
		}

		public void CancelOverride()
		{
			currentMasterMode = overriddenMasterMode;
			overridden = false;
			winform.UpdateMMLabel();
		}

		public bool MMCPower
		{
			get => mMCPower;
			set
			{
				if (value != mMCPower)
				{
					if (value) // then MMC is being turned on
					{
						if (WOW)
						{
							// MMC just powered up on the ground
							// Mastermode will now be NAV
							if (!overridden)
							{
								currentMasterMode = (int)MasterModes.NAV;
								// SMS mode is now STBY
							}
						}
						else
						{
							// MMC just powered up in the air
							// Mastermode will be whatever it was last
							// SMS mode will be whatever it was
						}
						mMCPower = value;
						winform.UpdateMMLabel();
					}
					else
					{
						winform.HideMMLabel();
						// the MMC just powered off. If the DTC was being loaded, 
						// or the INV was being changed, SMS might lockup
						// switch SMS page to OFF
						mMCPower = value;
					}
					SystemStartupOptionsChanged();
				}
			}
		}

		public bool MFDSPower
		{
			get => mFDSPower;
			set
			{
				if (value != mFDSPower)
				{
					if (value) // then MFDS is being turned on
					{
						//SMSDisplay.Enable();
					}
					else // then MFDS is being turned off
					{
						winform.BlankDisplay();
					}
					mFDSPower = value;
					SystemStartupOptionsChanged();
				}
			}
		}

		public bool SMSPower
		{
			get => sMSPower;
			set
			{
				if (value != sMSPower)
				{
					if (value) // then RIU power just got turned on
					{
						
					}
					else // ST STA power just got cut
					{

					}
					sMSPower = value;
					SystemStartupOptionsChanged();
				}
			}
		}

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

		private void SystemStartupOptionsChanged()
		{
			if (MFDSPower)
			{
				if (SMSPower & MMCPower)
				{
					// MFDS has power, MMC and ST STA have power
					display.SwitchTo((int)Pages.STBY);
				}
				else
				{
					// MFDS has power, but either ST STA or MMC is not powered, so display the OFF page
					display.SwitchTo((int)Pages.OFF);
				}
			}
		}
	}
}
