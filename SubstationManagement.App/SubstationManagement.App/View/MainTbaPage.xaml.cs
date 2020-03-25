
using Plugin.Geolocator;
using SubstationManagement.App.Model;
using SubstationManagement.App.Utils;
using SubstationManagement.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
namespace SubstationManagement.App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainTbaPage : ContentPage
	{
		double frameSearchY, InfoY;
		static bool IsDisplay = true;
		List<QuanLy> listQuanLy;
		List<QuanLy> listQuanLyChange;
		public MainTbaPage()
		{
			InitializeComponent();
			BindingContext = ViewModelLocator.MainViewModel;
			listQuanLy = new List<QuanLy>();
			listQuanLyChange = new List<QuanLy>();
			listQuanLy = ViewModelLocator.MainViewModel.QuanLys.ToList();
		}
		public void InitList()
		{

			
			//listNames = (tbaViewModel.NameTbas).ToList();
			//listTbas = (tbaViewModel.Tbas).ToList();
			//foreach(Tba tba in listTbas)
			//{
			//	double zoomLevel = 0.5;
			//	double dd_First = tba.KinhDo;
			//	double dd_Second = tba.ViDo;
			//	name.Text = "Tên \n" + tba.Ten;
			//	degree.Text = "Nhiệt độ\n" + tba.NhietDo + "";
			//	wattage.Text = "Công suất \n" + tba.CongSuat + "";
			//	type.Text = "Loại\n" + tba.Loai;
			//	Pin pin = new Pin
			//	{
			//		Label = tba.KinhDo + ", " + tba.ViDo,
			//		Address = tba.Ten,
			//		Type = PinType.Place,
			//		Position = new Position(dd_First, dd_Second)
			//	};
			//	pin.MarkerClicked += async (s, args) =>
			//	 {
			//		 args.HideInfoWindow = true;
			//		 string pinName = ((Pin)s).Label;
			//		 await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
			//		 //update in viewModel
			//	 };
			//	map.Pins.Add(pin);
			//}
		}
		private void OnSearchButtonPressed(object sender, EventArgs e)
		{
			string key_word = sb_search.Text;
			key_word = key_word.ToLower();
			listQuanLyChange.Clear();
			foreach(QuanLy quanLy in listQuanLy)
			{
				if (quanLy.tbaNavigation.ten.ToLower().Contains(key_word))
				{
					listQuanLyChange.Add(quanLy);
				}
			}
			ViewModelLocator.MainViewModel.QuanLys = new ObservableCollection<QuanLy>(listQuanLyChange);
		}

		private async void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			string key_word = sb_search.Text;
			key_word = key_word.ToLower();
			foreach (QuanLy quanLy in listQuanLy)
			{
				if (quanLy.tbaNavigation.ten.ToLower().Contains(key_word))
				{
					listQuanLyChange.Add(quanLy);
				}
			}
			ViewModelLocator.MainViewModel.QuanLys = new ObservableCollection<QuanLy>(listQuanLyChange);


		}

		private void OnFocused(object sender, FocusEventArgs e)
		{
			listTBA.IsVisible = true;
			map.IsVisible = false;
		}

		private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			OnSearchItems(e.SelectedItem.ToString());
		}

		private void OnMapCliked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
		{
			if (IsDisplay)
			{
				frameSearch.TranslateTo(0, -200, 1000);
				Info.TranslateTo(0, 200, 1000);
				IsDisplay = false;
			}
			else
			{
				frameSearch.TranslateTo(0, 0 , 1000);
				Info.TranslateTo(0,0, 1000);
				IsDisplay = true;
			}
		}
		private void OnSearchItems(string item)
		{
			sb_search.Text = item;
			foreach (QuanLy quanLy in listQuanLy)
			{
				if (quanLy.tbaNavigation.ten.ToLower().CompareTo(sb_search.Text.ToLower()) == 0)
				{
					listTBA.IsVisible = false;
					map.IsVisible = true;
					double zoomLevel = 0.5;
					double dd_First = quanLy.tbaNavigation.kinhDo;
					double dd_Second = quanLy.tbaNavigation.viDo;
					//name.Text="Tên \n"+tba.Ten;
					//degree.Text= "Nhiệt độ\n" + tba.NhietDo+"";
					//wattage.Text= "Công suất \n" + tba.CongSuat + "";
					//type.Text= "Loại\n" + tba.Loai;
					//Pin pin = new Pin
					//{
					//	Label = tba.KinhDo + ", " + tba.ViDo,
					//	Address = tba.Ten,
					//	Type = PinType.Place,
					//	Position = new Position(dd_First, dd_Second)
					//};
					//map.Pins.Add(pin);
					Position position = new Position(dd_First, dd_Second);
					MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(zoomLevel));
					map.MoveToRegion(mapSpan);
					break;
				}
			}
		}
	}
}