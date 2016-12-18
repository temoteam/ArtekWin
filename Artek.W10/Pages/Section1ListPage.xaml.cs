//---------------------------------------------------------------------------
//
// <copyright file="Section1ListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/26/2016 1:39:13 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.RestApi;
using Artek.Sections;
using Artek.ViewModels;
using AppStudio.Uwp;

namespace Artek.Pages
{
    public sealed partial class Section1ListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public Section1ListPage()
        {
			ViewModel = ViewModelFactory.NewList(new Section1Section());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(this.GetType().FullName);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("86093d11-9cf2-4b39-885a-fb647acd0d06");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
