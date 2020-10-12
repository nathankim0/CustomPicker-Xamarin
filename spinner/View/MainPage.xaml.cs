using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace spinner
{
    public class MainPage : ContentPage
    {
        Button customPickerButton;

        public MainPage()
        {
            for (int i = 0; i < 5; i++){ CustomPickerViewModel.CustomPickerItems.Add(new CustomPickerItems("Helelo", Color.Black));}
            StackLayout cellWrapper = new StackLayout { Orientation = StackOrientation.Vertical };
            cellWrapper.Padding = 50;

            Picker xamarinPicker = new Picker
            {
                Title = "Xamarin Picker",
                ItemsSource = new[]
                {
                    "General",
                    "Health",
                    "Career",
                    "Relationship",
                    "Learning",
                    "Enjoyment",
                    "Wealth",
                    "Travel"
                }
            };

            customPickerButton = new Button { Text = "Custom Picker" };
            customPickerButton.Clicked += OnOpenListViewPage;
            customPickerButton.SetBinding(Button.TextProperty, "Selected");

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { customPickerButton }
            };

            cellWrapper.Children.Add(xamarinPicker);
            cellWrapper.Children.Add(stackLayout);

            Content = cellWrapper;
            this.BindingContext = new MainPageItems();
        }
        private async void OnOpenListViewPage(object sender, EventArgs e)
        {
            var page = new CustomPicker();
            page.BindingContext = this.BindingContext;

            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}
