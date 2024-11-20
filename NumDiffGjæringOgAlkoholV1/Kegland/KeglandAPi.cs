using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KegLandForms
{

    public class KeglandApiService
    {
        private static readonly string TokenUrl = "https://id.rapt.io/connect/token";
        private static readonly string ClientId = "rapt-user"; // client_id provided by API
        private readonly string _username;
        private readonly string _apiSecret; // API Secret as the password

        public KeglandApiService(string username, string apiSecret)
        {
            _username = username;
            _apiSecret = apiSecret;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", _username),
                new KeyValuePair<string, string>("password", _apiSecret)
            });

                // Set the content type header
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(TokenUrl, content);

                // Ensure response success
                response.EnsureSuccessStatusCode();

                // Read and parse the response
                var jsonString = await response.Content.ReadAsStringAsync();
                //   var jsonObject = JObject.Parse(jsonString);

                // Extract the access token
                //            string accessToken = jsonObject["access_token"]?.ToString();
                var jsonDocument = JsonDocument.Parse(jsonString);
                var root = jsonDocument.RootElement;

                if (root.TryGetProperty("access_token", out JsonElement accessTokenElement))
                {
                    string accessToken = accessTokenElement.GetString();
                    return accessToken;
                }
                return null;
            }
        }

        public async Task<List<Hydrometer>> GetHydrometersAsync(string jwtToken)
        {
            using (var client = new HttpClient())
            {
                // Set the Authorization header with the Bearer token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                // Send GET request to the Hydrometers API
                HttpResponseMessage response = await client.GetAsync("https://api.rapt.io/api/Hydrometers/GetHydrometers");

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a JSON string
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Hydrometer> hydrometers = JsonSerializer.Deserialize<List<Hydrometer>>(jsonResponse);
                return hydrometers;
            }
        }

        public async Task<List<Telemetry>> GetTelemetryAsync(string jwtToken, string hydrometerId, string startDate, string endDate)
        {
            using (var client = new HttpClient())
            {
                // Set the Authorization header with the Bearer token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                // Build the request URL with query parameters
                var requestUrl = $"https://api.rapt.io/api/Hydrometers/GetTelemetry?hydrometerId={hydrometerId}&startDate={startDate}&endDate={endDate}";

                // Send GET request to the GetTelemetry API
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a JSON string
                string jsonResponse = await response.Content.ReadAsStringAsync();


                List<Telemetry> telemetry = JsonSerializer.Deserialize<List<Telemetry>>(jsonResponse);
                return telemetry;

            }
        }


    }


    //Models by jo Arild

    public class ActiveProfileSession
    {
        public string name { get; set; }
        public string hydrometerId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public string id { get; set; }
        public bool deleted { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
    }

    public class Hydrometer
    {
        public double temperature { get; set; }
        public double gravity { get; set; }
        public int battery { get; set; }
        public string name { get; set; }
        public string macAddress { get; set; }
        public string deviceType { get; set; }
        public bool active { get; set; }
        public bool disabled { get; set; }
        public DateTime lastActivityTime { get; set; }
        public int rssi { get; set; }
        public string firmwareVersion { get; set; }
        public bool isLatestFirmware { get; set; }
        public ActiveProfileSession activeProfileSession { get; set; }
        public DateTime modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public string id { get; set; }
        public bool deleted { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
    }


    public class Telemetry
    {
        public double? temperature { get; set; }
        public double? gravity { get; set; }
        public double? gravityVelocity { get; set; }
        public int? battery { get; set; }
        public string version { get; set; }
        public string rowKey { get; set; }
        public DateTime? createdOn { get; set; }
        public string macAddress { get; set; }
        public int? rssi { get; set; }
    }
}