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

        public async Task<List<ColorDto>> GetColorDtos()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<ColorDto>>>($"{ApiUrl.BaseUrl}api/color");
            return response?.Data ?? new List<ColorDto>();
        }

        public async Task<ColorDto> GetColorId(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<ColorDto>>($"{ApiUrl.BaseUrl}api/color/{id}");
            return response?.Data ?? new ColorDto();
        }

        public async Task AddColor(ColorDto colorDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl.BaseUrl}api/color", colorDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error adding color: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task UpdateColor(ColorDto colorDto)
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
