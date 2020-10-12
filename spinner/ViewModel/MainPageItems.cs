using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace spinner
{
    public class MainPageItems : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _selected="";

		public string Selected
		{
			get	{ return _selected;}
			set
			{
				_selected = value;
				OnPropertyChanged();
			}
		}/*
		public MainPageItems(string selected)
		{
			this._selected = selected;
		}*/
		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

