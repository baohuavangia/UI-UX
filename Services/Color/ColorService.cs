using MenShopUI.DTOs.Color;
using MenShopUI.Model;
using MenShopUI.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MenShopUI.Services.Color
{
    public class ColorService : IColorService
    {
        private readonly HttpClient _httpClient;

        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ColorModel>> GetColorDtos()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<ColorModel>>>($"{ApiUrl.BaseUrl}api/color");
            return response?.Data ?? new List<ColorModel>();
        }

        public async Task<ColorModel> GetColorId(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<ColorModel>>($"{ApiUrl.BaseUrl}api/color/{id}");
            return response?.Data ?? new ColorModel();
        }

        public async Task AddColor(ColorModel colorDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl.BaseUrl}api/color", colorDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error adding color: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task UpdateColor(ColorModel colorDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl.BaseUrl}api/color/{colorDto.ColorId}", colorDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error updating color: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task<bool> DeleteColor(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl.BaseUrl}api/color/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error deleting color: {response.StatusCode} - {errorContent}");
            }

            return true;
        }
    }
}
