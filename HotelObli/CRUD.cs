using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Newtonsoft.Json;
using HotelObli.Models;



namespace HotelObli
{
    class CRUD
    {
        const string serverUrl = "skoleserver.database.windows.net";
        public void PostGuestHttp(Guest guest)
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

             

                try
                {
                    var response = client.PostAsJsonAsync<Guest>("API/Guests", guest).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        string successresponse = $"Gæst indsat ({response.Content.ReadAsStringAsync()})";
                    }
                    else
                    {
                        string failresponse = $"Gæst ikke indsat({response.StatusCode})";
                    } }

                catch (Exception e)
                {
                    string fejlmeddelselse = $"Der er sket en fejl: {e.Message}";
                }
                
            }
           
           

        } }
}
