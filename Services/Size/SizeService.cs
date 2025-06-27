using MenShopUI.DTOs.Size;
using MenShopUI.Model;
using MenShopUI.Shared;
using System.Net.Http.Json;

namespace MenShopUI.Services.Size
{
    public class SizeService : ISizeService
    {
        private readonly HttpClient _httpClient;

        public SizeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SizeDto>> GetSizeAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<SizeDto>>>($"{ApiUrl.BaseUrl}api/size");

            return response?.Data ?? new List<SizeDto>();
        }

        public async Task AddSize(SizeDto sizeDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl.BaseUrl}api/size", sizeDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error adding size: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task UpdateSize(SizeDto sizeDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl.BaseUrl}api/size/{sizeDto.SizeId}", sizeDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error updating size: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task<bool> DeleteSize(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl.BaseUrl}api/size/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error deleting size: {response.StatusCode} - {errorContent}");
            }

            return true;
        }
    }
}
