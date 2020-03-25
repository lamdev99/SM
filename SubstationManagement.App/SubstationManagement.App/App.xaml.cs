using SubstationManagement.App.Utils;
using SubstationManagement.App.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SubstationManagement.App
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainMasterDetailPage();
		}

		protected override void OnStart()
		{
			RestApi restApi = new RestApi();
			restApi.GetTaskAsync();
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
		
	}
}
