using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	class LAU129 : Suspension
	{
		public bool TrackAdapter;

		public override bool IsJettisonable()
		{
			return false;
		}
	}
}
