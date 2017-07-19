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

	public enum Racks
	{
		MAU, TER, LAU, SUU20, SUU25, AL119, AL131, AGTS, TOWPD, TK370, TK600, MRLW, LNCH
	}

	class PhysicalInventory
	{
	}
}
