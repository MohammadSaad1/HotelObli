using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelObli.Models
{
    class GuestSingleton : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Guest FileGuest { get; set; }
        private ObservableCollection<Guest> e;

        public ObservableCollection<Guest> GuestList
        {
            get { return e; }
            set
            {
                e = value;
                OnPropertyChanged(nameof(GuestList));
            }
        }
        public static GuestSingleton instance { get; set; } = new GuestSingleton();

    }
}
