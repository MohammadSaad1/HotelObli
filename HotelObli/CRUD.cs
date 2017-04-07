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

                var response = client.PostAsJsonAsync<Guest>("API/Guests", null).Result;

                if (response.IsSuccessStatusCode)
                {
                    string successresponse = $"Gæst indsat ({response.Content.ReadAsStringAsync()})";
                }
                else
                {
                    string failresponse = $"Kunne ikke indsætte gæst ({response.StatusCode})";
                }
            }
        }

        public void DeleteGuestHTTP()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/hotels/1015";

                try
                {
                    HttpResponseMessage response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string succesresponse = $"Gæst slettet ({response.StatusCode})";
                    }
                    else
                    {
                        string failresponse = $"Kunne ikke slette gæst ({response.StatusCode})";
                    }
                }
                catch (Exception e)
                {
                    string failresponse = $"Der er sket en fejl : ({e.Message})";
                }
            }
        }

        public void GetGuestHTTP()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/guests";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var GæstList = response.Content.ReadAsAsync<List<Guest>>().Result;
                        foreach (var gæst in GæstList)
                        {
                            string succesresponse = $"Oplysninger om gæst : ({response.StatusCode})";
                        }
                    }
                }
                catch (Exception e)
                {
                    string failresponse = $"Der er sket en fejl : ({e.Message})";
                }

            }

        }

        public void ChangeGuestHTTP()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PutAsJsonAsync<Guest>("API/Hotels/1015", null).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string successrephose = $"Gæsten er ændret ({response.Content.ReadAsStringAsync()})";
                    }
                    else
                    {
                        string failresponse = $"Gæsten er ikke ændret ({response.StatusCode})";
                    }
                }
                catch (Exception e)
                {
                    string failresponse = $"Der er sket en fejl : ({e.Message})";
                }
            }
        }
    }
}