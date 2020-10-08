using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace spinner
{
    public static class CustomPickerData
    {
        public static ObservableCollection<CustomPickerItems> getListDatas()
        {
            ObservableCollection<CustomPickerItems> CustomPickerItems = new ObservableCollection<CustomPickerItems> () {
                new CustomPickerItems("General", Color.Red),
                new CustomPickerItems("Health", Color.Orange),
                new CustomPickerItems("Career", Color.Yellow),
                new CustomPickerItems("Relationship", Color.Green),
                new CustomPickerItems("Learning", Color.Blue),
                new CustomPickerItems("Enjoyment", Color.DarkBlue),
                new CustomPickerItems("Wealth", Color.Purple),
                new CustomPickerItems("Travel", Color.Black)
            };
            return CustomPickerItems;
        }
    }
}