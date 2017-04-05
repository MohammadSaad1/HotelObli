using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace HotelObli
{
    class CRUD
    {
        const string serverUrl = "skoleserver.database.windows.net";
        public void PostGuestHttp()
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
            }

        } }
}
