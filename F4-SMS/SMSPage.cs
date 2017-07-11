using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	abstract class SMSPage
	{


		public void SwitchTo()
		{
			DrawMe();

		}

		public abstract void DrawMe();

	}
}
