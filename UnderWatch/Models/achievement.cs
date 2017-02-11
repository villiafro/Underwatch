using System;
using System.Collections.Generic;

namespace UnderWatch
{
	public class achievement
	{
		public class Achievement
		{
			public string name { get; set; }
			public bool finished { get; set; }
			public string image { get; set; }
			public string description { get; set; }
			public object category { get; set; }
		}

		public class RootObject
		{
			public int totalNumberOfAchievements { get; set; }
			public int numberOfAchievementsCompleted { get; set; }
			public string finishedAchievements { get; set; }
			public List<Achievement> achievements { get; set; }
		}
	}
}
