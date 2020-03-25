using SubstationManagement.App.Model;
using SubstationManagement.App.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SubstationManagement.App.ViewModel
{
	class TbaViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<string> nameTbas; //list to list of search
		private ObservableCollection<Tba> tbas;
		private ObservableCollection<QuanLy> quanlys;
		private ObservableCollection<string> nameQuanlys;
		private Tba tba; //info in InfoFrame
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<QuanLy> QuanLys
		{
			get => quanlys;
			set
			{
				quanlys = value;
				RaisePropertyChanged("QuanLys");
			}
		}
		public ObservableCollection<string> NameQuanlys
		{
			get => nameQuanlys;
			set
			{
				nameQuanlys = value;
				RaisePropertyChanged("NameQuanlys");
			}
		}
		public Tba TBA
		{
			get => tba;
			set
			{
				tba = value;
				RaisePropertyChanged("TBA");
			}
		}
		public ObservableCollection<string> NameTbas
		{
			get => nameTbas;
			set
			{
				nameTbas = value;
				RaisePropertyChanged("NameTbas");
			}
		}
		public ObservableCollection<Tba> Tbas
		{
			get => tbas;
			set
			{
				tbas = value;
				foreach(Tba tba in tbas)
				{

				}
				RaisePropertyChanged("Tbas");
			}
		}
		public TbaViewModel()
		{
			NameQuanlys = new ObservableCollection<string>();
			QuanLys = new ObservableCollection<QuanLy>();
			Tbas = new ObservableCollection<Tba>();
			//RestApi restApi = new RestApi();
			//restApi.GetTaskAsync(list =>
			//{
			//	foreach (Tba tba in list)
			//	{
			//		Tbas.Add(tba);
			//	}
			//	foreach (Tba tba1 in Tbas)
			//	{
			//		NameTbas.Add(tba1.Ten);
			//	}
			//});
			NameTbas = new ObservableCollection<string>();

		}
		public TbaViewModel(string key)
		{

		}
		void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
