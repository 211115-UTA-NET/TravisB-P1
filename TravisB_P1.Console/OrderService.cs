using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net.Mime;
using TravisB_P1.App.Dtos;
using TravisB_P1.App.Exceptions;
using Microsoft.AspNetCore.WebUtilities;

namespace TravisB_P1.App
{
    public class OrderService : IOrderService
    {
        private static readonly HttpClient _httpClient = new();

        public OrderService(Uri serverUri)
        {
            _httpClient.BaseAddress = serverUri;
        }

        public async void GetInventoryAsync(Locations location)
        {
            Dictionary<string, string?> query = new() { ["location"] = location.ToString() };
            string requestUri = QueryHelpers.AddQueryString("/api/inventory", query);

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw new UnexpectedServerBehaviorException("network error", ex);
            }

            response.EnsureSuccessStatusCode();

            if(response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
            {
                throw new UnexpectedServerBehaviorException();
            }

            var inventory = await response.Content.ReadFromJsonAsync<List<Inventory>>();
            if (inventory == null)
            {
                throw new UnexpectedServerBehaviorException();
            }
            
            foreach(Inventory inventoryItem in inventory)
            {
                Console.WriteLine($"{inventoryItem.item.ToString()}\t{inventoryItem.itemDescription.ToString()}\t{inventoryItem.itemPrice.ToString()}\t{inventoryItem.quantityAvailable}");
            }
        }

        public static async Task<int> GetStoreAmountByItem(string itemName, Locations location)
        {
            Dictionary<string, string?> query = new() { ["storeinventory"] = location.ToString() };
            string requestUri = QueryHelpers.AddQueryString("/api/inventory", query);

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw new UnexpectedServerBehaviorException("network error", ex);
            }

            response.EnsureSuccessStatusCode();

            if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
            {
                throw new UnexpectedServerBehaviorException();
            }

            int totalAvailable = await response.Content.ReadFromJsonAsync<int>();

            return totalAvailable;

        }
        public async void FinalizeOrderAsync(Order order, Customer customer)
        {
            //await response = "";
            //return;
            throw new NotImplementedException();
        }
    }
}
