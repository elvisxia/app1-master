using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App1
{
    public sealed partial class MainPage : Page
    {
        public ProductCollection _productcollection;

        public MainPage()
        {
            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Enabled;

            _productcollection = new App1.ProductCollection();
            

            cvsProductsLetter.Source = _productcollection.GroupByLetter;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }

            base.OnNavigatedTo(e);
        }

        private void btnProdAdd1_Click(object sender, RoutedEventArgs e)
        {
            var p = new Product() { Name = "DEPARTMENT" };

            try
            {
                _productcollection.Add(p);
            }
            catch (Exception ex)
            {
                var res = new MessageDialog(ex.Message).ShowAsync();
            }
        }

        private void btnProdAdd2_Click(object sender, RoutedEventArgs e)
        {
            var p = new Product() { Name = "COFFEE" };

            try
            {
                 _productcollection.Add(p);
            }
            catch (Exception ex)
            {
                var res = new MessageDialog(ex.Message).ShowAsync();
            }
        }

        private void btnProdAdd3_Click(object sender, RoutedEventArgs e)
        {

            var p = new Product() { Name = "TEA" };

            try
            {
                 _productcollection.Add(p);
            }
            catch (Exception ex)
            {
                var res = new MessageDialog(ex.Message).ShowAsync();
            }
        }

        private void btnProdAdd4_Click(object sender, RoutedEventArgs e)
        {

            var p = new Product() { Name = "CAPPUCCINO" };

            try
            {
                 _productcollection.Add(p);
            }
            catch (Exception ex)
            {
                var res = new MessageDialog(ex.Message).ShowAsync();
            }
        }
        private void btnProdNavigate_Click(object sender, RoutedEventArgs e)
        {
            ProductCollection newColl = new ProductCollection();
            newColl.CreateNewGroupByLetter(_productcollection.GroupByLetter);
            this.Frame.Navigate(typeof(SecondPage), newColl);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoForward)
            {
                this.Frame.GoForward();
            }
        }
    }
}
