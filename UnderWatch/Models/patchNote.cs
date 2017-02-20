using System;
using System.Collections.Generic;

namespace UnderWatch
{
	public class patchNote
	{
		public class PatchNote
		{
			public string program { get; set; }
			public string locale { get; set; }
			public string type { get; set; }
			public string patchVersion { get; set; }
			public string status { get; set; }
			public string detail { get; set; }
			public int buildNumber { get; set; }
			public object publish { get; set; }
			public object created { get; set; }
			public object updated { get; set; }
			public bool develop { get; set; }
			public string slug { get; set; }
			public string version { get; set; }
		}

		public class Pagination
		{
			public int totalEntries { get; set; }
			public int totalPages { get; set; }
			public int pageSize { get; set; }
			public int page { get; set; }
		}

		public class RootObject
		{
			public List<PatchNote> patchNotes { get; set; }
			public Pagination pagination { get; set; }
		}
	}
}
