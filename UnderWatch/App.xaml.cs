using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnderWatch
{
	public partial class App : Application
	{
		private battleTags battle;
		private personalData person;

		public App()
		{
			battle = new battleTags();
			person = new personalData();

			InitializeComponent();

			var tabbedPage = new TabbedPage();

			UnderWatchPage content = new UnderWatchPage(person, tabbedPage, battle);
			var searchNavigationPage = new NavigationPage(content);
			searchNavigationPage.Title = "Search";
			searchNavigationPage.BarBackgroundColor = Color.FromHex("485F89");

			Profile profilePage = new Profile(battle);
			var profileNavigationPage = new NavigationPage(profilePage);
			profileNavigationPage.Title = "Profile";
			profileNavigationPage.Icon = "user";
			profileNavigationPage.BarBackgroundColor = Color.FromHex("485F89");

			Achievements achievePage = new Achievements();
			var achieveNavigationPage = new NavigationPage(achievePage);
			achieveNavigationPage.Title = "Achievements";
			achieveNavigationPage.Icon = "achieve";
			achieveNavigationPage.BarBackgroundColor = Color.FromHex("485F89");

			Stats statsPage = new Stats();
			var statsNavigationPage = new NavigationPage(statsPage);
			statsNavigationPage.Title = "Stats";
			statsNavigationPage.Icon = "stats";
			statsNavigationPage.BarBackgroundColor = Color.FromHex("485F89");

			Heros herosPage = new Heros();
			var herosNavigationPage = new NavigationPage(herosPage);
			herosNavigationPage.Title = "Heros";
			herosNavigationPage.Icon = "mask2";
			herosNavigationPage.BarBackgroundColor = Color.FromHex("485F89");

			tabbedPage.Children.Add(profileNavigationPage);
			tabbedPage.Children.Add(statsNavigationPage);
			tabbedPage.Children.Add(achieveNavigationPage);
			tabbedPage.Children.Add(herosNavigationPage);
			tabbedPage.BarBackgroundColor = Color.FromHex("485F89");
			tabbedPage.BarTextColor = Color.Black;

			tabbedPage.CurrentPageChanged += async (sender, e) =>
            {
				tabbedPage.IsEnabled = false;
				if (tabbedPage.CurrentPage == achieveNavigationPage)
				{
					await achievePage.getAchievements(person);
				}
				else if (tabbedPage.CurrentPage == statsNavigationPage)
				{
					await statsPage.getStats(person);
				}
				else if (tabbedPage.CurrentPage == herosNavigationPage)
				{
					await herosPage.getHeros(person);
				}
				tabbedPage.IsEnabled = true;
            };

			MainPage = searchNavigationPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
