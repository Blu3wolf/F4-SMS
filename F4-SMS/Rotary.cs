using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4SMS
{
	class Rotary
	{
		public Rotary(string[] Options)
		{
			options = Options;
			currOption = 0;
		}

		private string[] options;

		private int currOption;

		internal void SetCurrOption(string Option)
		{
			currOption = Array.IndexOf(options, Option);
		}

		public string GetCurrOption()
		{
			return options[currOption];
		}

		public string IncOption()
		{
			if (currOption == options.Length - 1) // then it is the last element in the array
			{
				currOption = 0;
			}
			else
			{
				currOption = currOption + 1;
			}
			return GetCurrOption();
		}
	}
}
