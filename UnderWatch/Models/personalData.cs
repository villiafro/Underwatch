using System;
namespace UnderWatch
{
	public class personalData
	{
		private string gametag;
		private string platform;
		private string region;

		public personalData()
		{
			gametag = "";
			platform = "";
			region = "";
		}

		public void setPersonalData(string tag, string plat, string reg)
		{
			gametag = tag;
			platform = plat;
			region = reg;
		}

		public string getTag()
		{
			return gametag;
		}

		public string getPlatform()
		{
			return platform;
		}

		public string getRegion()
		{
			return region;
		}
	}
}
