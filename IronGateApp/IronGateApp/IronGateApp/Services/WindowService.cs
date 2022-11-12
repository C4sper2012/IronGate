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

        public async Task<Tuple<bool, bool, bool>> ToggleWindows(string index)
        {
            Tuple<bool, bool, bool> floorResults = await GetFloorWindowState();

            bool firstFloorWindowOpen = floorResults.Item3;
            bool groundFloorWindowOpen = floorResults.Item2;
            bool basementWindowOpen = floorResults.Item1;

            sb.Append(AppConstants._writeWindow);
            switch (index)
            {
                case "0":
                    sb.Append(AppConstants._basementWindow);
                    RoomSelectHelper(basementWindowOpen);
                    break;
                case "1":
                    sb.Append(AppConstants._groundFloorWindow);
                    RoomSelectHelper(groundFloorWindowOpen);
                    break;
                case "2":
                    sb.Append(AppConstants._firstFloorWindow);
                    RoomSelectHelper(firstFloorWindowOpen);
                    break;
                default:
                    break;
            }

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, sb.ToString());
            HttpResponseMessage response = new HttpResponseMessage();

            await client.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Request sent!");
            }
            return Tuple.Create(basementWindowOpen, groundFloorWindowOpen, firstFloorWindowOpen);

        }


        private void RoomSelectHelper(bool floor)
        {
            if (floor)
            {
                floor = false;
                sb.Append("0");
            }
            else
            {
                floor = true;
                sb.Append("1");
            }

        }

    }
}
