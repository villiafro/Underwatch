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
		private databattle.RootObject _battleData;

		public battleTags()
		{
			_battleData = new databattle.RootObject();

			/*_battleData.games = new battleTag.Games();
			_battleData.games.quick = new battleTag.Quick();
			_battleData.games.competitive = new battleTag.Competitive();
			_battleData.playtime = new battleTag.Playtime();
			_battleData.competitive = new battleTag.Competitive2();*/
		}

		public databattle.Data getBattleData()
		{
			return _battleData.data;
		}

		public async Task fillProfile(string _apiString)
		{
			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_apiString);

			if (apiRequest != null)
			{
				var json = JsonConvert.DeserializeObject<databattle.RootObject>(apiRequest);
				//foreach (var obj in jsonObj.data.games.competitive.wins)
				//{
				//	Debug.WriteLine(jsonObj.data.games.competitive.wins);
				//}
				_battleData = json;
				/*var response = JObject.Parse(apiRequest);

				_battleData.username = response["data"]["username"].ToString();
				_battleData.level = response["data"]["level"].ToString();
				_battleData.avatar = response["data"]["avatar"].ToString();
				_battleData.levelFrame = response["data"]["levelFrame"].ToString();
				_battleData.star = response["data"]["star"].ToString();

				_battleData.games.quick.wins = response["data"]["games"]["quick"]["wins"].ToString();
				_battleData.games.competitive.wins = response["data"]["games"]["competitive"]["wins"].ToString();
				_battleData.games.competitive.lost = response["data"]["games"]["competitive"]["lost"].ToString();
				_battleData.games.competitive.played = response["data"]["games"]["competitive"]["played"].ToString();

				_battleData.playtime.quick = response["data"]["playtime"]["quick"].ToString();
				_battleData.playtime.competitive = response["data"]["playtime"]["competitive"].ToString();

				_battleData.competitive.rank = response["data"]["competitive"]["rank"].ToString();
				_battleData.competitive.rank_img = response["data"]["competitive"]["rank_img"].ToString();*/
			}
			else
			{
				_battleData = null;
			}


		}
	}
}
