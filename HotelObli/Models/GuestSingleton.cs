using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObli.Handler;
using HotelObli.Models;
using HotelObli.Facade;

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

        public Guest Guest { get; set; }
        private List<Guest> e;

        public List<Guest> GuestList
        {
            get { return e; }
            set
            {
                e = value;
                OnPropertyChanged(nameof(GuestList));
            }
        }

        public CRUD CRUD { get; set; }
        public static GuestSingleton instance { get; set; } = new GuestSingleton();

        public GuestSingleton()
        {
            GuestList = new List<Guest>();
            LoadGuestJson();
        }

        public async void DeleteGuest(Guest GuestDelete)
        {
            await CRUD.DeleteGuestHTTP(GuestDelete);
            LoadGuestJson();
        }
        public async void AddGuest(Guest PostGuest)
        {
            await CRUD.PostGuestHttp(PostGuest);
            LoadGuestJson();
        }

        public async void EditGuest(Guest EditGuest)
        {
            await CRUD.ChangeGuestHTTP(EditGuest);
            LoadGuestJson();
        }

        public async void LoadGuestJson()
        {
            try
            {
                GuestList = await CRUD.GetGuestHTTP();
            }
            catch (Exception exception)
            {
                string Message = $"Der er sket en fejl: ({exception.Message})";

            }
        }

    }
}
    