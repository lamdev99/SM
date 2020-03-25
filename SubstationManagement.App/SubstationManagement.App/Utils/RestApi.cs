using Newtonsoft.Json;
using SubstationManagement.App.Model;
using SubstationManagement.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SubstationManagement.App.Utils
{
	class RestApi
	{
		HttpClientHandler clientHandler;
		HttpClient httpClient;
		Tba tba = new Tba();

		public Tba GetTbas()
		{
			Console.WriteLine("AppLog3");
			return tba;
			
		}
		private static string url1 = "https://118.70.182.154:4000/api/NhanViens/0983236058";
		public RestApi()
		{
			clientHandler = new HttpClientHandler();
			clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

			httpClient = new HttpClient(clientHandler);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.Add("access-control-allow-methods", "[GET]");
		}
		
		public async void  GetTaskAsync()
		{
			//Console.WriteLine("AppLog2");
			//string content = await httpClient.GetStringAsync(url1); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
			//tba = JsonConvert.DeserializeObject<Tba>(content); //Deserializes or converts JSON String into a collection of Post

			try
			{
				HttpResponseMessage response =  await httpClient.GetAsync(url1);
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					Console.WriteLine("AppLog2");
					tba = JsonConvert.DeserializeObject<Tba>(await response.Content.ReadAsStringAsync());
					ViewModelLocator.MainViewModel.QuanLys = new ObservableCollection<QuanLy>(tba.quanLy);
				}
			}
			catch (Exception e)
			{
			}

		}
	}
}
