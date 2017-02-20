using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnderWatch
{
	public class stats
	{
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

		/**
		 * Requesting json from API: https://api.lootbox.eu/pc/eu/DYN4MIC-21500/quickplay/allHeroes/
		 * */
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

		/**
		 * Requesting json from API: https://api.lootbox.eu/pc/eu/DYN4MIC-21500/competitive/allHeroes/
		 * */
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

		/**
		 * Sorter the response and assigning string names to them
		 * */
		public Task<List<string>> getListOfStats(stat.RootObject data)
		{
			List<string> listOfStats = new List<string>();

			listOfStats.Add("Games Played: " + data.GamesPlayed);
			listOfStats.Add("Games Won: " + data.GamesWon);
			listOfStats.Add("Games Lost: " + data.GamesLost);
			listOfStats.Add("Games Tied: " + data.GamesTied);

			listOfStats.Add("Cards: " + data.Cards);

			listOfStats.Add("Medals: " + data.Medals);
			listOfStats.Add("Medals - Gold: " + data.Medals_Gold);
			listOfStats.Add("Medals - Silver: " + data.Medals_Silver);
			listOfStats.Add("Medals - Bronze: " + data.Medals_Bronze);

			listOfStats.Add("Deaths: " + data.Deaths);

			listOfStats.Add("Environmental Kills: " + data.EnvironmentalKills);
			listOfStats.Add("Environmental Deaths: " + data.EnvironmentalDeaths);

			listOfStats.Add("Eliminations: " + data.Eliminations);
			listOfStats.Add("Eliminationd - Most In Game: " + data.Eliminations_MostinGame);
			listOfStats.Add("Eliminationd - Average: " + data.Eliminations_Average);

			listOfStats.Add("Solo Kills: " + data.SoloKills);
			listOfStats.Add("Solo Kills - Most In Game: " + data.SoloKills_MostinGame);
			listOfStats.Add("Solo Kills - Average: " + data.SoloKills_Average);

			listOfStats.Add("Objective Kills: " + data.ObjectiveKills);
			listOfStats.Add("Objective Kills - Most In Game: " + data.ObjectiveKills_MostinGame);
			listOfStats.Add("Objective Kills - Average: " + data.ObjectiveKills_Average);

			listOfStats.Add("Melee Final Blows: " + data.MeleeFinalBlows);
			listOfStats.Add("Melee Final Blows - Most In Game: " + data.MeleeFinalBlow_MostinGame);
			listOfStats.Add("Melee Final Blows - Average: " + data.MeleeFinalBlows_Average);

			listOfStats.Add("Final Blows: " + data.FinalBlows);
			listOfStats.Add("Final Blows - Most In Game: " + data.FinalBlows_MostinGame);
			listOfStats.Add("Final Blows - Average: " + data.FinalBlows_Average);

			listOfStats.Add("Multikills: " + data.Multikills);
			listOfStats.Add("Multikills Best: " + data.Multikill_Best);

			listOfStats.Add("Damage Done: " + data.DamageDone);
			listOfStats.Add("Damage Done - Most In Game: " + data.DamageDone_MostinGame);
			listOfStats.Add("Damage Done - Average: " + data.DamageDone_Average);

			listOfStats.Add("Healing Done: " + data.HealingDone);
			listOfStats.Add("Healing Done - Most In Game: " + data.HealingDone_MostinGame);
			listOfStats.Add("Healing Done - Average: " + data.HealingDone_Average);

			listOfStats.Add("Defensive Assists: " + data.DefensiveAssists);
			listOfStats.Add("Defensive Assists - Most In Game: " + data.DefensiveAssists_MostinGame);
			listOfStats.Add("Defensive Assists - Average: " + data.DefensiveAssists_Average);

			listOfStats.Add("Offensive Assists: " + data.OffensiveAssists);
			listOfStats.Add("Offensive Assists - Most In Game: " + data.OffensiveAssists_MostinGame);
			listOfStats.Add("Offensive Assists - Average: " + data.OffensiveAssists_Average);

			listOfStats.Add("Objective Time: " + data.ObjectiveTime);
			listOfStats.Add("Objective Time - Most In Game: " + data.ObjectiveTime_MostinGame);
			listOfStats.Add("Objective Time - Average: " + data.ObjectiveTime_Average);

			listOfStats.Add("Time Spent On Fire: " + data.TimeSpentonFire);
			listOfStats.Add("Time Spent On Fire - Most In Game: " + data.TimeSpentonFire_MostinGame);
			listOfStats.Add("Time Spent On Fire - Average: " + data.TimeSpentonFire_Average);

			return Task.Run(() => listOfStats);
		}

	}
}
