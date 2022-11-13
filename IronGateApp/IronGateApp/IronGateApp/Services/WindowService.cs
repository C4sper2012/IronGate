using IronGateApp.Constants;
using IronGateApp.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;

namespace IronGateApp.Services
{
    public class WindowService
    {
        HttpClient client;

        public WindowService()
        {
            this.client = new HttpClient();
        }

        WindowControl windowControl;
        StringBuilder sb = new StringBuilder();

        public async Task<Tuple<bool, bool, bool>> GetFloorWindowState()
        {
            var response = await client.GetAsync("https://api.thingspeak.com/channels/1916369/feeds.json?api_key=F803W0EVFO7BK3GG&results=100");

            if (response.IsSuccessStatusCode)
            {
                windowControl = await response.Content.ReadFromJsonAsync<WindowControl>();



                // If API returns "1" make Tuple parameter True.
                return Tuple.Create(
                        windowControl.Feeds.Last().Field1.Equals("1"),
                        windowControl.Feeds.Last().Field3.Equals("1"),
                        windowControl.Feeds.Last().Field5.Equals("1")
                    );
                //TODO: Add Polly
            }
            return Tuple.Create(false, false, false);

        }

        public async Task<bool> ToggleWindows(bool firstState, bool groundState, bool baseState)
        {
            sb.Append(AppConstants._writeWindow);

            ToggleFloor(firstState, groundState, baseState);
          
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, sb.ToString());
            HttpResponseMessage response = new HttpResponseMessage();

            await client.SendAsync(httpRequestMessage);

            sb.Clear();

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Request sent!");
                return true;

            }
            return false;
        }


        private void ToggleFloor(bool firstState, bool groundState, bool baseState)
        {
            sb.Append(AppConstants._basementWindow);
            sb.Append(Convert.ToInt32(baseState));
            sb.Append("&");
            sb.Append(AppConstants._groundFloorWindow);
            sb.Append(Convert.ToInt32(groundState));
            sb.Append("&");
            sb.Append(AppConstants._firstFloorWindow);
            sb.Append(Convert.ToInt32(firstState));

        }

    }
}
