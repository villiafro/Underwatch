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
			TextColor = Color.White,
			FontSize = 20,
			FontAttributes = FontAttributes.Bold
		};

		private Label _profileLevel = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.White,
			FontSize = 20,
			Margin = new Thickness(0, -95, 0, 90 )
		};

		private Image _profileLevelFrame = new Image()
		{
			Margin = -20
		};

		private Image _profileStar = new Image()
		{
			Margin = new Thickness(0,-35,0,0)
		};

		private Label _profileRank = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Rank: ",
			TextColor = Color.White,
			FontSize = 20
		};

		private Image _profileRankImg = new Image() 
		{ 
			Margin = -20
		};

		private Label _profilePlayQuick = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Playtime quick: ",
			TextColor = Color.White,
			FontSize = 10
		};

		private Label _profileQuickWin = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Quick wins: ",
			TextColor = Color.White,
			FontSize = 10
		};

		private Label _profilePlayComp = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Playtime competitive: ",
			TextColor = Color.White,
			FontSize = 10
		};

		private Label _profileCompWin = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Competitive wins: ",
			TextColor = Color.White,
			FontSize = 10
		};

		private Label _profileCompLost = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Competitive lost: ",
			TextColor = Color.White,
			FontSize = 10
		};

		private Label _profileCompPlay = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = "Competitive played: ",
			TextColor = Color.White,
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
					_profileUsername,
					levelrank(),
					content()
				}
			};

			var scrollView = new ScrollView { Content = layout };

			Content = scrollView;
		}

		/**
		 * Put Level and Rank images up into grid
		 * */
		private Grid levelrank()
		{
			Grid levelRank = new Grid()
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
						{
							new RowDefinition { Height = GridLength.Auto },
							new RowDefinition { Height = GridLength.Auto },
							new RowDefinition { Height = GridLength.Auto }
						},
				ColumnDefinitions =
						{
							new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star)},
							new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star)}
						}

			};

			levelRank.Children.Add(_profileLevelFrame, 0, 0);
			levelRank.Children.Add(_profileStar, 0, 1);
			levelRank.Children.Add(_profileLevel, 0, 2);

			levelRank.Children.Add(_profileRankImg, 1, 0);
			levelRank.Children.Add(_profileRank, 1, 1);

			return levelRank;
		}

		/**
		 * Put Content up into frames and into grid
		 * */
		private Grid content()
		{

			Frame playQuick = new Frame()
			{
				Content = _profilePlayQuick,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.FromHex("485F89"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = true
			};

			Frame quickWin = new Frame()
			{
				Content = _profileQuickWin,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.FromHex("485F89"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = true
			};

			Frame playComp = new Frame()
			{
				Content = _profilePlayComp,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.FromHex("485F89"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = true
			};

			Frame compWin = new Frame()
			{
				Content = _profileCompWin,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.FromHex("485F89"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = true
			};

			Frame compLost = new Frame()
			{
				Content = _profileCompLost,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.FromHex("485F89"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = true
			};

			Frame compPlay = new Frame()
			{
				Content = _profileCompPlay,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.FromHex("485F89"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = true
			};

			Grid plays = new Grid()
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
						{
							new RowDefinition { Height = GridLength.Auto },
							new RowDefinition { Height = GridLength.Auto },
							new RowDefinition { Height = GridLength.Auto }
						},
				ColumnDefinitions =
						{
							new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star)},
							new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star)}
						}

			};

			plays.Children.Add(playQuick, 0, 0);
			plays.Children.Add(quickWin, 1, 0);
			plays.Children.Add(playComp, 0, 1);
			plays.Children.Add(compWin, 1, 1);
			plays.Children.Add(compLost, 0, 2);
			plays.Children.Add(compPlay, 1, 2);

			return plays;
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
			_profileUsername.Text = data.username;
			_profileLevel.Text = data.level.ToString();
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
