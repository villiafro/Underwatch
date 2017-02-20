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
using System.Text.RegularExpressions;

namespace UnderWatch
{
	public partial class UnderWatchPage : ContentPage
	{
		private battleTags _battle;
		private TabbedPage _tab;
		private personalData _person;

		private Image _underwatchImage = new Image()
		{
			Source = "overwatchNew.png"		
		};

		private Label _underwatchGreet = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.FromHex("f0edf2"),
			Text = "Underwatch",
			FontSize = 40,
			FontAttributes = FontAttributes.Bold
		};

		private Label _underwatchInstruction = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.FromHex("f0edf2"),
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
			IsRunning = false,
			Color = Color.White
		};

		private Label _underwatchResult = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = string.Empty,
			TextColor = Color.Red,
		};

		private Button _pathNotes = new Button()
		{
			Text = "Path Notes",
			BackgroundColor = Color.White,
			TextColor = Color.Gray
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

		public UnderWatchPage(personalData person, TabbedPage tab, battleTags battle)
		{
			InitializeComponent();

			Title = "Search";

			_battle = battle;
			_tab = tab;
			_person = person;

			BackgroundColor = BackgroundColor = Color.FromRgb(40, 52, 75);

			fillPickers();

			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
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
					_pathNotes,
					_progressBar,
					_underwatchResult

				}
			};

			var scrollView = new ScrollView { Content = layout };
			Content = scrollView;

			_pathNotes.Clicked += displayPatchNotes;
			_searchButton.Clicked += displayProfile;
			_underwatchEntry.Completed += displayProfile;
		}

		/**
		 * Load content for Patch Notes page and navigate
		 * */
		private async void displayPatchNotes(object sender, EventArgs e)
		{
			_progressBar.IsRunning = true;
			_pathNotes.IsEnabled = false;

			patchNotes patch = new patchNotes();
			await patch.fillNotes();
			foreach (var note in patch.getNotes().patchNotes)
			{
				string output = Regex.Replace(note.detail, "<[^>]*>", string.Empty);
				output = Regex.Replace(output, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

				note.detail = output;
			}
			await this.Navigation.PushAsync(new Patch(patch));

			_pathNotes.IsEnabled = true;
			_progressBar.IsRunning = false;
		}

		/**
		 * Load content for Profile page and navigate
		 * */
		private async void displayProfile(object s, EventArgs e)
		{
			_progressBar.IsRunning = true;
			_searchButton.IsEnabled = false;
			_underwatchResult.Text = string.Empty;

			if (_underwatchEntry.Text != "")
			{
				_person.setPersonalData(_underwatchEntry.Text, _platformPicker.Items[_platformPicker.SelectedIndex], _regionPicker.Items[_regionPicker.SelectedIndex]);

				var _apiString = "https://api.lootbox.eu/" + _person.getPlatform() + "/" + _person.getRegion() + "/" + _person.getTag() + "/profile";

				await _battle.fillProfile(_apiString);

				if (_battle.getBattleData() != null)
				{
					await this.Navigation.PushAsync(_tab);
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
			_underwatchEntry.Text = "";
		}

	}
}
