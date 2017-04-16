using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelObli.Models
{
    class Guest : INotifyPropertyChanged
    {

        public int Guest_No { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }


        public override string ToString()
        {
            return $"{Guest_No} : {Name} , {Address}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
