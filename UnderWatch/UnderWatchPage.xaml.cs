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
	public partial class UnderWatchPage : ContentPage
	{
		private battleTags _battle;
		private TabbedPage _tab;

		private Image _underwatchImage = new Image()
		{
			Source = "overwatch.png"		
		};

		private Label _underwatchGreet = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Underwatch",
			FontSize = 40,
			FontAttributes = FontAttributes.Bold
		};

		private Label _underwatchInstruction = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Enter Overwatch battle tag",
			FontSize = 20
		};

		private Entry _underwatchEntry = new Entry
		{
			HorizontalOptions = LayoutOptions.Fill,
			Placeholder = "Battle-tag",
			Text = ""
		};

		private Button _searchButton = new Button()
		{
			Text = "Search",
			BackgroundColor = Color.White,
			TextColor = Color.Gray,
			HorizontalOptions = LayoutOptions.Fill
		};

		private Picker _platformPicker = new Picker()
		{
			Title = "Platform",
			VerticalOptions = LayoutOptions.CenterAndExpand,
		};

		private Picker _regionPicker = new Picker()
		{
			Title = "Region",
			VerticalOptions = LayoutOptions.CenterAndExpand
		};

		private ActivityIndicator _progressBar = new ActivityIndicator
		{
			IsRunning = false
		};

		private Label _underwatchResult = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = string.Empty,
			TextColor = Color.Red,
		};

		private void fillPickers()
		{
			List<string> platform = new List<string> { "pc", "xbl", "psn" };
			List<string> region = new List<string> { "eu", "us", "kr", "cn", "global" };

			foreach (string item in platform)
			{
				_platformPicker.Items.Add(item);
			}

			foreach (string item in region)
			{
				_regionPicker.Items.Add(item);
			}

			_platformPicker.SelectedIndex = 0;
			_regionPicker.SelectedIndex = 0;
		}

		public UnderWatchPage(battleTags battle, TabbedPage tab)
		{
			InitializeComponent();

			_battle = battle;
			_tab = tab;

			BackgroundColor = Color.White;
			Title = "UnderWatch";

			fillPickers();

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Spacing = 10,
				Margin = 30,
				Children =
				{
					_underwatchImage,
					new StackLayout()
					{
						Children =
						{
							_underwatchGreet,
							_underwatchInstruction,
							_underwatchEntry,
							_platformPicker,
							_regionPicker

						}
					},
					_searchButton,
					_progressBar,
					_underwatchResult
				}
			};

			_searchButton.Clicked += displayProfile;
			_underwatchEntry.Completed += displayProfile;
		}

		private async void displayProfile(object sender, EventArgs e)
		{
			_progressBar.IsRunning = true;
			_searchButton.IsEnabled = false;
			_underwatchResult.Text = string.Empty;

			if (_underwatchEntry.Text != "")
			{
				var _apiString = "https://api.lootbox.eu/" + _platformPicker.Items[_platformPicker.SelectedIndex] + "/" + _regionPicker.Items[_regionPicker.SelectedIndex] + "/" + _underwatchEntry.Text + "/profile";

				await _battle.fillProfile(_apiString);

				if (_battle.getBattleData() != null)
				{
					App.Current.MainPage = _tab;
				}
				else
				{
					_underwatchResult.Text = "No results for given battle tag";
				}
			}
			else
			{
				_underwatchResult.Text = "Please enter a battle tag";
			}

			_progressBar.IsRunning = false;
			_searchButton.IsEnabled = true;
		}


	}
}
