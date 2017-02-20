using System;
using UIKit;
using UnderWatch.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CostumTabRenderer))]
namespace UnderWatch.iOS
{
	public class CostumTabRenderer : TabbedRenderer
	{
		public override void ViewWillAppear(bool animated)
		{
			var tabs = Element as TabbedPage;
			if (tabs != null)
			{
				for (int i = 0; i < TabBar.Items.Length; i++)
				{
					UpdateItem(TabBar.Items[i], tabs.Children[i].Icon);
				}
			}

			base.ViewWillAppear(animated);
		}

		private void UpdateItem(UITabBarItem item, string icon)
		{
			if (item == null)
			{
				return;
			}
			item.SelectedImage = UIImage.FromBundle(icon);
			item.SelectedImage.AccessibilityIdentifier = icon;
		}
	}
}

