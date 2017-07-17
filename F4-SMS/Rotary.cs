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

		internal void ResetCurrOption()
		{
			currOption = 0;
		}

		internal void SetCurrOption(string Option)
		{
			int index = Array.IndexOf(options, Option);
			// IndexOf returns -1 if it cant find the string
			if (index != -1)
			{
				currOption = index;
			}
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
