using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelObli.Facade;
using System.Threading.Tasks;

namespace HotelObli.Handler
{
    class GuestHandler
    {
        public Viewmodel viewmodel { get; set; }
        public MyGuestHandler(Viewmodel viewmodel)
        {
            this.viewmodel = viewmodel;
        }
    }
}
