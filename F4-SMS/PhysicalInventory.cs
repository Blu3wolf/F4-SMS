using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* Responsible for providing information on actual load. Stores information about load.
	 * Knows which RIUs are xmitting on the 1553 Mux, 
	 * which racks are loaded, what stations they are at, what stores are on them */

	public enum Ammunition
	{
		M56, PGU28
	}

	public enum Rack
	{
		L129, S210, S301, WWP, NJETT, S951, TER, LAU88, LAU117, LAU118, SUU20
	}



	class PhysicalInventory
	{
		public PhysicalInventory()
		{

		}

		int ammo;

		public int Ammo { get => ammo; }

		
	}
}
