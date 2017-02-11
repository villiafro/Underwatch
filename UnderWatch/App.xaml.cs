using Xamarin.Forms;

namespace UnderWatch
{
	public partial class App : Application
	{
		private battleTags battle;

		public App()
		{
			InitializeComponent();

			battle = new battleTags();

			var tabbedPage = new TabbedPage();

			UnderWatchPage content = new UnderWatchPage(battle, tabbedPage);

			Profile profilePage = new Profile(battle);
			var profileNavigationPage = new NavigationPage(profilePage);
			profileNavigationPage.Title = "Profile";

			Achievements achievePage = new Achievements();
			var achieveNavigationPage = new NavigationPage(achievePage);
			achieveNavigationPage.Title = "Achievements";

			Stats statsPage = new Stats();
			var statsNavigationPage = new NavigationPage(statsPage);
			statsNavigationPage.Title = "Stats";

			Heros herosPage = new Heros();
			var herosNavigationPage = new NavigationPage(herosPage);
			herosNavigationPage.Title = "Heros";


			tabbedPage.Children.Add(profileNavigationPage);
			tabbedPage.Children.Add(achieveNavigationPage);
			tabbedPage.Children.Add(statsNavigationPage);
			tabbedPage.Children.Add(herosNavigationPage);

			MainPage = content;
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
