using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace spinner
{
    public class MainPage : ContentPage
    {
        Button customPickerButton;

        public MainPage()
        {
            for (int i = 0; i < 5; i++){ CustomPickerViewModel.CustomPickerItems.Add(new CustomPickerItems("Helelo", Color.Black));}
            StackLayout cellWrapper = new StackLayout { Orientation = StackOrientation.Vertical };
            cellWrapper.Padding = 70;

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
            customPickerButton.FontSize = 15;
            customPickerButton.Clicked += OnOpenListViewPage;

            Label label=new Label();
            label.SetBinding(Label.TextProperty, "Selected");
            label.FontSize = 15;
            label.BackgroundColor = Color.Pink;
            label.HorizontalOptions=LayoutOptions.EndAndExpand;
            label.VerticalOptions=LayoutOptions.Center;

            StackLayout stackLayout = new StackLayout
            {
                BackgroundColor = Color.Bisque,
                Orientation = StackOrientation.Horizontal,
                Children = { customPickerButton, label }
            };

            cellWrapper.Children.Add(xamarinPicker);
            cellWrapper.Children.Add(stackLayout);

            Content = cellWrapper;
            this.BindingContext = new MainPageItems();
        }
        private async void OnOpenListViewPage(object sender, EventArgs e)
        {
            var page = new CustomPicker();
            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}
