using SubstationManagement.App.Model;
using SubstationManagement.App.Utils;
using SubstationManagement.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SubstationManagement.App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMasterDetailPage : MasterDetailPage
	{
		public MainMasterDetailPage()
		{
			InitializeComponent();
			BindingContext = ViewModelLocator.MainViewModel;
		}

	}
}