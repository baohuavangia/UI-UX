using MenShopUI.DTOs.OrderCustomer;
using MenShopUI.DTOs.ProductDetail;
using MenShopUI.DTOs.Size;
using MenShopUI.Model;
using MenShopUI.Shared;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MenShopUI.Services.OrderCustomer
{
    public class OrderCustomerService : IOrderCustomerService
    {
        private readonly HttpClient _httpClient;

        public OrderCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderCustomerModel>> GetOrderCustomerAsync(string customerId)
        {
            return await _httpClient.GetFromJsonAsync<List<OrderCustomerModel>>($"{ApiUrl.BaseUrl}api/Order/getorder?customerId={customerId}");

        }

        public async Task<OrderCustomerModel> GetOrderCustomerDetailsAsync(string orderId)
        {
            return await _httpClient.GetFromJsonAsync<OrderCustomerModel>($"{ApiUrl.BaseUrl}api/Order/getorderdetail/{orderId}");
        }
        public async Task CancelOrderAsync(string orderId)
        {
            var content = new StringContent(JsonSerializer.Serialize(orderId), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{ApiUrl.BaseUrl}api/Order/cancel", content);
            response.EnsureSuccessStatusCode();
        }
    }

}
