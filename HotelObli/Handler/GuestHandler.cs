using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelObli.Facade;
using System.Threading.Tasks;
using HotelObli.Models;


namespace HotelObli.Handler
{
    class GuestHandler
    {
        public Viewmodel viewmodel { get; set; }
        public void MyGuestHandler(Viewmodel viewmodel)
        {
            this.viewmodel = viewmodel;
        }
        
        public void AddGuest()
        {
            Guest tempGuest = new Guest();
            tempGuest.Address = viewmodel.Guest.Address;
            tempGuest.Guest_No = viewmodel.Guest.Guest_No;
            tempGuest.Name = viewmodel.Guest.Name;
         GuestSingleton.instance.AddGuest(tempGuest);
            GuestSingleton.instance.LoadGuestJson();
        }

        public void RemoveGuest()
        {
            GuestSingleton.instance.DeleteGuest(viewmodel.SelectedGuest);
        }

        public void EditGuest()
        {
            GuestSingleton.instance.EditGuest(viewmodel.SelectedGuest);
        }

    }
}
