using System.Text.Json;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Models.Entities;

namespace W4S.PostingService.Domain
{
    public class AddressApi
    {
        private readonly ILogger<AddressApi> logger;

        public AddressApi(ILogger<AddressApi> logger)
        {
            this.logger = logger;
        }

        public async Task UpdateAddress(Address address)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "W4SBackend");
            string query = $"https://nominatim.openstreetmap.org/search?country={address.Country}&state={address.Region}&city={address.City}&street={address.Building} {address.Street}&format=json";

            var rawResponse = await client.GetAsync(query);
            var responseBody = await rawResponse.Content.ReadAsStringAsync();
            logger.LogInformation("Got address {Address}", responseBody);

            var response = JsonSerializer.Deserialize<List<GeographicData>>(responseBody)?.FirstOrDefault();

            if (response is not null)
            {
                logger.LogInformation("Found location at coordinates: Lon: {lon} Lat: {lat}", response.lon, response.lat);
                address.Longitude = Convert.ToDouble(response.lon);
                address.Latitude = Convert.ToDouble(response.lat);
            }

        }
    }
}
