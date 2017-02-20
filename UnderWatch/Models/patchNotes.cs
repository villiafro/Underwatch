using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnderWatch
{
	public class patchNotes
	{
		private patchNote.RootObject _notes;

		public patchNotes()
		{
			_notes = new patchNote.RootObject();
		}

		public patchNote.RootObject getNotes()
		{
			return _notes;
		}

		/**
		 * Requesting json from API: https://api.lootbox.eu/patch_notes
		 * */
		public async Task fillNotes()
		{
			string _apiString = "https://api.lootbox.eu/patch_notes";

			HttpClient client = new HttpClient();
			var apiRequest = await client.GetStringAsync(_apiString);

			if (apiRequest != null)
			{
				_notes = JsonConvert.DeserializeObject<patchNote.RootObject>(apiRequest);
			}
			else
			{
				_notes = null;
			}
		}
	}
}
