using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace UnderWatch
{
	//https://api.lootbox.eu/pc/eu/DYN4MIC-21500/achievements

	public class achievements
	{
		private achievement.RootObject _achieve;

		public achievements()
		{
			_achieve = new achievement.RootObject();
		}

		public achievement.RootObject getAchievements()
		{
			return _achieve;
		}

		public async Task fillAchievements(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{
				_achieve = JsonConvert.DeserializeObject<achievement.RootObject>(apiRequest);
			}
			else
			{
				_achieve = null;
			}
			
		}
	}
}
