using System;
using System.Collections.Generic;

namespace UnderWatch
{
	public class achievement
	{
		public string totalNumberOfAchievements { get; set; }
		public string numberOfAchievementsCompleted { get; set; }
		public string finishedAchievements { get; set; }
		public List<Achievement> achievements { get; set; }

		public achievement()
		{
		}

		public class Achievement
		{
			public string name { get; set; }
			public string finished { get; set; }
			public string image { get; set; }
			public string description { get; set; }
			public string category { get; set; }
		}
	}
}
