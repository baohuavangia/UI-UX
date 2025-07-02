using MenShopUI.DTOs.BranchProduct;
using MenShopUI.Model;
using MenShopUI.Shared;
using System.Net.Http.Json;

namespace MenShopUI.Services.BranchProduct
{
    public class BranchProductService : IBranchProductService
    {
        private readonly HttpClient _httpClient;

        public BranchProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BranchProductModel>> GetBranchProduct(string branchId)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<BranchProductModel>>>(
                $"{ApiUrl.BaseUrl}api/branch/{branchId}/products"
            );

            return response?.Data ?? new List<BranchProductModel>();
        }

        public async Task<List<BranchProductDetailModel>> GetBranchProductDetail(string branchId, string productId)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<BranchProductDetailModel>>>(
                $"{ApiUrl.BaseUrl}api/branch/{branchId}/products/{productId}/details"
            );

            return response?.Data ?? new List<BranchProductDetailModel>();
        }
    }
}
