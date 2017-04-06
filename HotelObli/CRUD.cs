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
        public void PostGuestHttp()
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                var response = client.PostAsJsonAsync<Guest>("API/Guests", null ).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    string successresponse = $"Hotel indsat ({response.Content.ReadAsStringAsync()})";
                }
                else
                {
                    string failresponse = $"Hotel ikke indsat({response.StatusCode})";
                }
            
            }
           
           

        } }
}
