using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace UnderWatch
{
	public class battleTags
	{
		//https://api.lootbox.eu/pc/eu/DYN4MIC-21500/profile

		private battleTag.RootObject _battleData;

		public battleTags()
		{
			_battleData = new battleTag.RootObject();
		}

		public battleTag.Data getBattleData()
		{
			return _battleData.data;
		}

		public async Task fillProfile(string _apiString)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_apiString);

			if (apiRequest != null)
			{
				_battleData = JsonConvert.DeserializeObject<battleTag.RootObject>(apiRequest);
			}
			else
			{
				_battleData = null;
			}
		}
	}
}
