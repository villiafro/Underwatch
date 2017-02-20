using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnderWatch
{
	public partial class Stats : ContentPage
	{
		stats _stats;
		personalData _person;

		public Stats()
		{
			InitializeComponent();
			_stats = new stats();
			_person = new personalData();
			fillPickers();

			Title = "Statistics";
			BackgroundColor = Color.FromRgb(40, 52, 75);

			listview.BackgroundColor = Color.FromRgb(40, 52, 75);

			Picker.SelectedIndexChanged += reloadData;

		}

		private void fillPickers()
		{
			List<string> plays = new List<string> { "Quickplay", "Competitive" };

			foreach (string item in plays)
			{
				Picker.Items.Add(item);
			}

			Picker.SelectedIndex = 0;
		}

		/**
		 * Check what dropdown option is selected
		 * */
		private async void reloadData(object sender, EventArgs e)
		{
			if (Picker.Items[Picker.SelectedIndex] == "Quickplay")
			{
				listview.ItemsSource = await _stats.getListOfStats(_stats.getStatQuick());
			}
			else
			{
				listview.ItemsSource = await _stats.getListOfStats(_stats.getStatComp());
			}
		}

		/**
		 * Deactivate the selected item in the listview
		 * */
		private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return;
			((ListView)sender).SelectedItem = null;
		}

		/**
		 * Fill the content of the page if not already done for selected game tag
		 * */
		public async Task getStats(personalData person)
		{
			if (_stats.getStatQuick().MeleeFinalBlows == null && _person.getTag() != person.getTag())
			{
				_person = person;

				Spinner.IsRunning = true;
				Spinner.IsVisible = true;

				string api = "https://api.lootbox.eu/" + person.getPlatform() + "/" + person.getRegion() + "/" + person.getTag() + "/quickplay/allHeroes/";
				await _stats.fillQuick(api);
				api = "https://api.lootbox.eu/" + person.getPlatform() + "/" + person.getRegion() + "/" + person.getTag() + "/competitive/allHeroes/";
				await _stats.fillComp(api);

				listview.ItemsSource = await _stats.getListOfStats(_stats.getStatQuick());

				Spinner.IsRunning = false;
				Spinner.IsVisible = false;
			}
		}
	}
}
