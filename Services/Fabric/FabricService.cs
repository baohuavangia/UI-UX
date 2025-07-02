using MenShopUI.DTOs.Fabric;
using MenShopUI.Model;
using MenShopUI.Shared;
using System.Net.Http.Json;

namespace MenShopUI.Services.Fabric
{
    public class FabricService : IFabricService
    {
        private readonly HttpClient _httpClient;

        public FabricService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FabricModel>> GetFabricDtos()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<FabricModel>>>($"{ApiUrl.BaseUrl}api/fabric");

            return response?.Data ?? new List<FabricModel>();
        }

        public async Task AddFabric(FabricModel fabricDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl.BaseUrl}api/fabric", fabricDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error adding fabric: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task UpdateFabric(FabricModel fabricDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl.BaseUrl}api/fabric/{fabricDto.FabricId}", fabricDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error updating fabric: {response.StatusCode} - {errorContent}");
            }
        }

        public async Task<bool> DeleteFabric(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl.BaseUrl}api/fabric/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error deleting fabric: {response.StatusCode} - {errorContent}");
            }

            return true;
        }
    }
}
