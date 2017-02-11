using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnderWatch
{
	public class heros
	{
		//https://api.lootbox.eu/pc/eu/DYN4MIC-21500/competitive/heroes

		private hero.RootObject _herosQuick;
		private hero.RootObject _herosComp;

		public heros()
		{
			_herosQuick = new hero.RootObject();
			_herosComp = new hero.RootObject();
		}

		public hero.RootObject getQuick()
		{
			return _herosQuick;
		}

		public hero.RootObject getComp()
		{
			return _herosComp;
		}

		public async Task fillQuick(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_herosQuick = JsonConvert.DeserializeObject<hero.RootObject>(apiRequest);
			}
			else
			{
				_herosQuick = null;
			}

		}

		public async Task fillComp(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_herosComp = JsonConvert.DeserializeObject<hero.RootObject>(apiRequest);
			}
			else
			{
				_herosComp = null;
			}

		}
	}
}
