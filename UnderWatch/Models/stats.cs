using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnderWatch
{
	public class stats
	{
		//https://api.lootbox.eu/pc/eu/DYN4MIC-21500/quickplay/allHeroes/

		private stat.RootObject _statQuick;
		private stat.RootObject _statComp;

		public stats()
		{
			_statQuick = new stat.RootObject();
			_statComp = new stat.RootObject();
		}

		public stat.RootObject getStatQuick()
		{
			return _statQuick;
		}

		public stat.RootObject getStatComp()
		{
			return _statComp;
		}

		public async Task fillQuick(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_statQuick = JsonConvert.DeserializeObject<stat.RootObject>(apiRequest);
			}
			else
			{
				_statQuick = null;
			}

		}

		public async Task fillComp(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_statComp = JsonConvert.DeserializeObject<stat.RootObject>(apiRequest);
			}
			else
			{
				_statComp = null;
			}

		}
	}
}
