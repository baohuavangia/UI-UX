using MenShopUI.DTOs.BranchProduct;

namespace MenShopUI.Services.BranchProduct
{
    public interface IBranchProductService
    {
        public Task<List<BranchProductDto>> GetBranchProduct(string branchId);

        public Task<List<BranchProductDetailDto>> GetBranchProductDetail(string branchid, string productid);
    }
}
