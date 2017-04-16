using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObli.Models;
using System.ComponentModel;
using HotelObli.Handler;


namespace HotelObli.Facade
{
    class Viewmodel : INotifyPropertyChanged
    {


        public Guest Guest { get; set; }
        public int Guest_No { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public GuestSingleton GuestSingletonInstance { get; set; }

        public Relaycommand AddGuestCommand { get; set; }
        public Relaycommand DeleteGuestCommand { get; set; }
        public Relaycommand EditGuestCommand { get; set; }

        public Relaycommand GetGuestCommand { get; set; }

        public GuestHandler GuestHandlerInstance { get; set; }

        public Viewmodel()
        {

            Guest_No = Guest.Guest_No;
            Name = Guest.Name;
            Address = Guest.Address;
            GuestHandler GuestHandlerInstance = new GuestHandler();
            AddGuestCommand = new Relaycommand(GuestHandlerInstance.AddGuest);
            DeleteGuestCommand = new Relaycommand(GuestHandlerInstance.RemoveGuest);
            EditGuestCommand = new Relaycommand(GuestHandlerInstance.EditGuest);
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }


        }

        private Guest _selectedGuest;

        public Guest SelectedGuest
        {
            get { return _selectedGuest; }
            set
            {
                _selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));
            }
        }
    }
}
