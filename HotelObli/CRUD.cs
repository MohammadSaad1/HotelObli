using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using HotelObli.Models;


namespace HotelObli
{
    class CRUD
    {
 
        const string serverUrl = "skoleserver.database.windows.net";
        public static async Task PostGuestHttp(Guest GuestPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await client.PostAsJsonAsync<Guest>("api/guests", GuestPost);
            }
        }

        public static async Task DeleteGuestHTTP(Guest GuestDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                string urlString = "api/guests/" + GuestDelete.Guest_No.ToString();
                await client.DeleteAsync(urlString);
            }
        }

        public static async Task<List<Guest>> GetGuestHTTP()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                var response = await client.GetAsync("api/Guests");
                if (response.IsSuccessStatusCode)
                {
                    var guestListe = await response.Content.ReadAsAsync<List<Guest>>();
                    return guestListe;
                }
                else
                {
                    return null;
                }

            }

        }

        public static async Task ChangeGuestHTTP(Guest GuestEdit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlString = "api/guests/" + GuestEdit.Guest_No.ToString();

                await client.PutAsJsonAsync(urlString, GuestEdit);

            }
        }
        }
    }
