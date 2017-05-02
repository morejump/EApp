﻿using Prism.Unity;
using EApp.Views;
using Xamarin.Forms;

namespace EApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{Pages.home}");
            //NavigationService.NavigateAsync($"{Pages.NavBar}/{Pages.}");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<TestLayoutPage>();
            Container.RegisterTypeForNavigation<ListSentencePage>();
            Container.RegisterTypeForNavigation<ListDownloadedAudioPage>();
            Container.RegisterTypeForNavigation<Home>();
        }
    }
    public static class Pages
    {
        public static string NavBar = nameof(NavigationPage);
        public static string TestLayout = nameof(TestLayoutPage);
        public static string ListSentence = nameof(ListSentencePage);
        public static string ListAudioDownload = nameof(ListDownloadedAudioPage);
        public static string home = nameof(Home);

    }
}