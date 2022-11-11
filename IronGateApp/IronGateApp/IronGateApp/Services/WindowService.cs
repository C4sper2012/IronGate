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

        public async Task<Tuple<bool, bool, bool>> GetFloorWindowState()
        {
            var response = await client.GetAsync("https://api.thingspeak.com/channels/1916369/feeds.json?api_key=F803W0EVFO7BK3GG&results=1");
            if (response.IsSuccessStatusCode)
            {
                windowControl = await response.Content.ReadFromJsonAsync<WindowControl>();

                int field1 = Convert.ToInt32(windowControl.Feeds.FirstOrDefault().Field1);
                int field3 = Convert.ToInt32(windowControl.Feeds.FirstOrDefault().Field3);
                int field5 = Convert.ToInt32(windowControl.Feeds.FirstOrDefault().Field5);
                return Tuple.Create(
                        Convert.ToBoolean(field1),
                        Convert.ToBoolean(field3),
                        Convert.ToBoolean(field5)
                    );
                //TODO: Add Polly
            }
            return Tuple.Create(false, false, false);

        }

        public async Task<Tuple<bool, bool, bool>> ToggleWindows(string index)
        {
            StringBuilder sb = new StringBuilder();
            Tuple<bool, bool, bool> floorResults = await GetFloorWindowState();

            bool firstFloorWindowOpen = floorResults.Item3;
            bool groundFloorWindowOpen = floorResults.Item2;
            bool basementWindowOpen = floorResults.Item1;

            sb.Append(AppConstants._writeWindow);
            switch (index)
            {
                case "0":
                    sb.Append(AppConstants._basementWindow);
                    if (basementWindowOpen)
                    {
                        basementWindowOpen = false;
                        sb.Append("0");
                    }
                    else
                    {
                        basementWindowOpen = true;
                        sb.Append("1");
                    }
                    break;
                case "1":
                    sb.Append(AppConstants._groundFloorWindow);
                    if (groundFloorWindowOpen)
                    {
                        groundFloorWindowOpen = false;
                        sb.Append("0");
                    }
                    else
                    {
                        groundFloorWindowOpen = true;
                        sb.Append("1");
                    }
                    break;
                case "2":
                    sb.Append(AppConstants._firstFloorWindow);
                    if (firstFloorWindowOpen)
                    {
                        firstFloorWindowOpen = false;
                        sb.Append("0");
                    }
                    else
                    {
                        firstFloorWindowOpen = true;
                        sb.Append("1");
                    }
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

    }
}
