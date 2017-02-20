using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UnderWatch
{
	public partial class Profile : ContentPage
	{
		private battleTags _battle;

		private Image _profileImage = new Image(){ };

		private Label _profileUsername = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Username: ",
			FontSize = 20,
			FontAttributes = FontAttributes.Bold
		};

		private Label _profileLevel = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Level: ",
			FontSize = 10
		};

		private Image _profileLevelFrame = new Image() { };
		private Image _profileStar = new Image() { };

		private Label _profileRank = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Rank: ",
			FontSize = 10
		};

		private Image _profileRankImg = new Image() { };

		private Label _profilePlayQuick = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Playtime quick: ",
			FontSize = 10
		};

		private Label _profileQuickWin = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Quick wins: ",
			FontSize = 10
		};

		private Label _profilePlayComp = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Playtime competitive: ",
			FontSize = 10
		};

		private Label _profileCompWin = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Competitive wins: ",
			FontSize = 10
		};

		private Label _profileCompLost = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Competitive lost: ",
			FontSize = 10
		};

		private Label _profileCompPlay = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Competitive played: ",
			FontSize = 10
		};

		public Profile(battleTags battle)
		{
			InitializeComponent();

			_battle = battle;

			BackgroundColor = Color.FromRgb(40, 52, 75);

			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Margin = 30,
				Children =
				{
					_profileImage,
					new StackLayout()
					{
						Children =
						{
							_profileUsername,
							_profileLevel,
							_profileLevelFrame,
							_profileStar,
							_profileRank,
							_profileRankImg
						}
					},
					new StackLayout()
					{
						Children =
						{
							_profilePlayQuick,
							_profileQuickWin,
							_profilePlayComp,
							_profileCompWin,
							_profileCompLost,
							_profileCompPlay
						}
					}
				}
			};

			var scrollView = new ScrollView { Content = layout };

			Content = scrollView;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			fillProfile();
		}

		/**
		 * Fill page with data collected
		 * */
		public void fillProfile()
		{
			var data = _battle.getBattleData();

			_profileImage.Source = data.avatar;
			_profileUsername.Text = "Username: " + data.username;
			_profileLevel.Text = "Level: " + data.level;
			_profileLevelFrame.Source = data.levelFrame;
			_profileStar.Source = data.star;
			_profileRank.Text = "Rank: " + data.competitive.rank;
			_profileRankImg.Source = data.competitive.rank_img;
			_profilePlayQuick.Text = "Playtime quick: " + data.playtime.quick;
			_profileQuickWin.Text = "Quick wins: " + data.games.quick.wins;
			_profilePlayComp.Text = "Playtime competitive: " + data.playtime.competitive;
			_profileCompWin.Text = "Competitive wins: " + data.games.competitive.wins;
			_profileCompLost.Text = "Competitive lost: " + data.games.competitive.lost;
			_profileCompPlay.Text = "Competitive played: " + data.games.competitive.played;
		}
	}
}
