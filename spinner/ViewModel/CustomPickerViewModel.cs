using System.Collections.ObjectModel;

namespace spinner
{
    public static class CustomPickerViewModel
    {		
        public static ObservableCollection<CustomPickerItems> CustomPickerItems { get; }

        static CustomPickerViewModel ()
        {
            CustomPickerItems = CustomPickerData.GetListDatas ();
        }
    }
}