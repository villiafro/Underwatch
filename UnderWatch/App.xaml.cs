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

			tabbedPage.Children.Add(profileNavigationPage);
			tabbedPage.Children.Add(achieveNavigationPage);

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
