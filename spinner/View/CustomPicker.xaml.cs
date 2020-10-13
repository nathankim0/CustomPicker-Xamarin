using System;
using System.ComponentModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace spinner
{
    public class CustomPicker : PopupPage
    {
        public CustomPicker()
        {
            Button cancelButton = button("Cancel", Color.FromHex("#8B00FF"));
            cancelButton.Clicked += OnCancel;

            /*
            Button confirmButton =  button("Confirm", Color.FromHex("#8B00FF"));
            confirmButton.Clicked += OnConfirm;
            */
            
            StackLayout outerStackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            double width = Application.Current.MainPage.Width;
            double height = Application.Current.MainPage.Height;

            outerStackLayout.Padding=new Thickness(width/10, 5, width / 10, 5);

            StackLayout buttonStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.White,
                Children ={cancelButton/*, confirmButton*/}
            };

            StackLayout listStackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White
            };

            ListView listView = new ListView
            {
                Footer = "",
                RowHeight =50,
                //HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(CustomViewCell)),
                ItemsSource = CustomPickerViewModel.CustomPickerItems
            };
            listView.HeightRequest = (CustomPickerViewModel.CustomPickerItems.Count) * 50;

            listView.ItemSelected += OnListViewItemSelected;
            
            listStackLayout.Children.Add(listView);
            listStackLayout.Children.Add(buttonStackLayout);

            outerStackLayout.Children.Add(listStackLayout);

            Content = outerStackLayout;
        }
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            ((ListView)sender).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                ChangeTextToSelectedItem(((CustomPickerItems)args.SelectedItem).name);
            }
        }
        
        private async void ChangeTextToSelectedItem(string text)
        {
            if(BindingContext is MainPageItems)
            { 
              ((MainPageItems)BindingContext).Selected = text;
                Console.WriteLine("@@@@@@" + text);
            }
            await PopupNavigation.Instance.PopAsync();
        }
        
        private async void OnCancel(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
/*
        private async void OnConfirm(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
        */
        private Button button(String text, Color color)
        {
            return new Button
            {
                Text = text,
                TextColor = color,
                Padding = new Thickness(0, 0, 20, 10)
            };
        }
    }
    public class CustomViewCell: ViewCell
    {
        public CustomViewCell()
        {
            StackLayout layout = new StackLayout (){ Padding = new Thickness(2, 15)};
            layout.Orientation = StackOrientation.Horizontal;
            Label nameLabel = new Label (){ HorizontalOptions = LayoutOptions.CenterAndExpand };
            nameLabel.SetBinding (Label.TextProperty, "name");
            nameLabel.SetBinding (Label.TextColorProperty, "color");
            layout.Children.Add (nameLabel);
            
            View = layout;
        }
    }
    
}