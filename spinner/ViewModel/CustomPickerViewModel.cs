using System.Collections.ObjectModel;

namespace spinner
{
    public static class CustomPickerViewModel
    {		
        public static ObservableCollection<CustomPickerItems> CustomPickerItems { get; set; }

        static CustomPickerViewModel ()
        {
            CustomPickerViewModel.CustomPickerItems = CustomPickerData.getListDatas ();
        }
    }
}