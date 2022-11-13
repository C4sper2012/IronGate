using IronGateApp.Constants;
using IronGateApp.Models;
using Polly;
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

        // StringBuilder is faster than normal string concatination.
        StringBuilder sb = new StringBuilder();

        public async Task<Tuple<bool, bool, bool>> GetFloorWindowState()
        {
            //var response = await client.GetAsync(AppConstants._get100WindowFeeds);
            var response = await GetWinddowstateFromPollyAsync(AppConstants._get100WindowFeeds);

            if (response.IsSuccessStatusCode)
            {
                windowControl = await response.Content.ReadFromJsonAsync<WindowControl>();

                // If API returns "1" return Tuple parameter True.
                return Tuple.Create(
                        windowControl.Feeds.Last().Field1.Equals("1"),
                        windowControl.Feeds.Last().Field3.Equals("1"),
                        windowControl.Feeds.Last().Field5.Equals("1")
                    );
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

        private async Task<HttpResponseMessage> GetWinddowstateFromPollyAsync(string url)
        {
            return await Policy
            .HandleResult<HttpResponseMessage>(ex => !ex.IsSuccessStatusCode)
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider:
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (ex, time) =>
                {
                    Debug.WriteLine($"Something went wrong: {ex.Exception},retrying...");
                })
            .ExecuteAsync(async () =>
            {
                Debug.WriteLine($"Trying to fetch remote data...");
                return await client.GetAsync(url);
            });
        }

        private void ToggleFloor(bool firstState, bool groundState, bool baseState)
        {
            //Assembles the entire api post url with StringBuilder.
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
