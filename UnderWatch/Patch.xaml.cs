using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UnderWatch
{
	public partial class Patch : ContentPage
	{
		private patchNotes _patch;

		public Patch(patchNotes patch)
		{
			InitializeComponent();
			_patch = patch;
			Title = "Patch Notes";
			BackgroundColor = Color.FromRgb(40, 52, 75);

			listview.ItemsSource = _patch.getNotes().patchNotes;
			listview.BackgroundColor = Color.FromRgb(40, 52, 75);
		}

		private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return;
			((ListView)sender).SelectedItem = null;
		}
	}
}
