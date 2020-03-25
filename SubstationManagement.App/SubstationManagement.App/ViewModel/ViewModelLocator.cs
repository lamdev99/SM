using System;
using System.Collections.Generic;
using System.Text;

namespace SubstationManagement.App.ViewModel
{
	class ViewModelLocator
	{
		private static TbaViewModel tbaViewModel = new TbaViewModel();
		public static TbaViewModel MainViewModel
		{
			get => tbaViewModel;
		}
	}
}
