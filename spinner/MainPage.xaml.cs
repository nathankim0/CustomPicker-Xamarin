using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace spinner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnOpenListViewPage(object sender, EventArgs e)
        {
            var page = new CustomPicker();

            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}
