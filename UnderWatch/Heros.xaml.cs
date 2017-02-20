using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnderWatch
{
	public partial class Heros : ContentPage
	{
		heros _heros;
		personalData _person;

		public Heros()
		{
			InitializeComponent();
			_heros = new heros();
			_person = new personalData();
			fillPickers();

			Title = "Heroes";
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
		private void reloadData(object sender, EventArgs e)
		{
			if (Picker.Items[Picker.SelectedIndex] == "Quickplay")
			{
				listview.ItemsSource = _heros.getQuick();
			}
			else
			{
				listview.ItemsSource = _heros.getComp();
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
		public async Task getHeros(personalData person)
		{
			if (_heros.getQuick().Count == 0 && _person.getTag() != person.getTag())
			{
				_person = person;

				Spinner.IsRunning = true;
				Spinner.IsVisible = true;

				string api = "https://api.lootbox.eu/" + person.getPlatform() + "/" + person.getRegion() + "/" + person.getTag() + "/quickplay/heroes";
				await _heros.fillQuick(api);
				api = "https://api.lootbox.eu/" + person.getPlatform() + "/" + person.getRegion() + "/" + person.getTag() + "/competitive/heroes";
				await _heros.fillComp(api);

				listview.ItemsSource = _heros.getQuick();

				Spinner.IsRunning = false;
				Spinner.IsVisible = false;
			}

		}
	}
}
