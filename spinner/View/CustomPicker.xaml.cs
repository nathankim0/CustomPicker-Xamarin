using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace spinner
{
    public partial class CustomPicker : PopupPage
    {
        public CustomPicker()
        {
            StackLayout outerStackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(50, 150, 50, 150)
            };
            
            StackLayout listStackLayout = new StackLayout
            {
                BackgroundColor = Color.White,
                Children=
                {
                    new ListView
                    {
                        ItemTemplate = new DataTemplate(typeof(CustomViewCell)),
                        ItemsSource = CustomPickerViewModel.CustomPickerItems
                    }
                }
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                TextColor = Color.FromHex("#8B00FF"),
                Padding = new Thickness(0, 0, 20, 10)

            };
            Button confirmButton = new Button
            {
                Text = "Confirm",
                TextColor = Color.FromHex("#8B00FF"),
                Padding = new Thickness(0, 0, 20, 10),
            };

            cancelButton.Clicked += OnCancel;
            confirmButton.Clicked += OnConfirm;
                
            StackLayout buttonStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.White,
                Children ={cancelButton, confirmButton}
            };
            outerStackLayout.Children.Add(listStackLayout);
            outerStackLayout.Children.Add(buttonStackLayout);

            Content = outerStackLayout;
        }
        
        private async void OnCancel(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnConfirm(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
    
    public class CustomViewCell: ViewCell
    {
        public CustomViewCell()
        {
            StackLayout layout = new StackLayout (){ Padding = new Thickness(2, 15)};
            layout.Orientation = StackOrientation.Horizontal;
            /*
            layout.Children.Add (new Image ()
            {
                HorizontalOptions = LayoutOptions.Start, 
                Source = ".png"
            });
            */
            Label nameLabel = new Label (){ HorizontalOptions = LayoutOptions.CenterAndExpand };
            nameLabel.SetBinding (Label.TextProperty, "name");
            nameLabel.SetBinding (Label.TextColorProperty, "color");
            layout.Children.Add (nameLabel);
            
            View = layout;
        }
    }
    
}