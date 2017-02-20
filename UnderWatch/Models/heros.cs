using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnderWatch
{
	public class heros
	{
		private List<hero.RootObject> _herosQuick;
		private List<hero.RootObject> _herosComp;

		public heros()
		{
			_herosQuick = new List<hero.RootObject>();
			_herosComp = new List<hero.RootObject>();
		}

		public List<hero.RootObject> getQuick()
		{
			return _herosQuick;
		}

		public List<hero.RootObject> getComp()
		{
			return _herosComp;
		}

		/**
		 * Requesting json from API: https://api.lootbox.eu/pc/eu/DYN4MIC-21500/quickplay/heroes
		 * */
		public async Task fillQuick(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_herosQuick = JsonConvert.DeserializeObject<List<hero.RootObject>>(apiRequest);
			}
			else
			{
				_herosQuick = null;
			}
		}

		/**
		 * Requesting json from API: https://api.lootbox.eu/pc/eu/DYN4MIC-21500/competitive/heroes
		 * */
		public async Task fillComp(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_herosComp = JsonConvert.DeserializeObject<List<hero.RootObject>>(apiRequest);
			}
			else
			{
				_herosComp = null;
			}

		}
	}
}
