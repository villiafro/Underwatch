using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnderWatch
{
	public partial class Achievements : ContentPage
	{
		achievements _achieve;
		personalData _person;

		public Achievements()
		{
			InitializeComponent();
			_achieve = new achievements();
			_person = new personalData();

			Title = "Achievements";
			BackgroundColor = Color.FromRgb(40, 52, 75);

			listview.BackgroundColor = Color.FromRgb(40, 52, 75);
			Picker.SelectedIndexChanged += reloadData;
		}

		private void fillPickers()
		{
			List<string> plays = new List<string> { "Finished", "Unfinished" };

			foreach (string item in plays)
			{
				Picker.Items.Add(item);
			}

			Picker.SelectedIndex = 0;
		}

		/**
		 * Check what dropdown option is selected
		 * */
		private void reloadData(object sender, EventArgs e)
		{
			if (Picker.Items[Picker.SelectedIndex] == "Finished")
			{
				listview.ItemsSource = _achieve.getFinishedAchievements();
			}
			else
			{
				listview.ItemsSource = _achieve.getUnfinishedAchievements();
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
		public async Task getAchievements(personalData person)
		{
			if (_achieve.getAchievements().achievements == null && _person.getTag() != person.getTag())
			{
				_person = person;

				Spinner.IsRunning = true;
				Spinner.IsVisible = true;

				string api = "https://api.lootbox.eu/" + person.getPlatform() + "/" + person.getRegion() + "/" + person.getTag() + "/achievements";
				await _achieve.fillAchievements(api);

				listview.ItemsSource = _achieve.getFinishedAchievements();

				Spinner.IsRunning = false;
				Spinner.IsVisible = false;
			}

		}

	}
}
