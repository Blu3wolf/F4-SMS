using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	/* Responsible for logic about how STBY page reacts to user input. 
	 * knows how STBY page reacts to input
	 * tells display how to draw STBY page */

	class PageSTBY : SMSPage
	{
		public PageSTBY(Display Displayer) : base(Displayer) { }

		public override void DrawMe()
		{

		}
	}
}
