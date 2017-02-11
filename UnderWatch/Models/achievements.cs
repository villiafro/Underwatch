using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace UnderWatch
{
	public class achievements
	{
		private achievement _achieve;

		public achievements()
		{
			_achieve = new achievement();
		}

		public achievement getAchievements()
		{
			return _achieve;
		}

		public async Task fillAchievements(string _api)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_api);

			if (apiRequest != null)
			{

				_achieve = JsonConvert.DeserializeObject<achievement>(apiRequest);
				foreach (var row in _achieve.achievements)
				{
					Debug.WriteLine(row);
				}

			}
			else
			{
				_achieve = null;
			}
			
		}
	}
}
