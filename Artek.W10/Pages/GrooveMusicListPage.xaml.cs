//---------------------------------------------------------------------------
//
// <copyright file="GrooveMusicListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/26/2016 1:39:13 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.DynamicStorage;
using Artek.Sections;
using Artek.ViewModels;
using AppStudio.Uwp;

namespace Artek.Pages
{
    public sealed partial class GrooveMusicListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public GrooveMusicListPage()
        {
			ViewModel = ViewModelFactory.NewList(new GrooveMusicSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(this.GetType().FullName);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("acabd0b0-08c8-48a7-a21b-7c2545e46729");
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
