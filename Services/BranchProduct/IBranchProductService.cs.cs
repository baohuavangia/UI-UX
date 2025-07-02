using MenShopUI.DTOs.BranchProduct;

namespace MenShopUI.Services.BranchProduct
{
    public interface IBranchProductService
    {
        public Task<List<BranchProductModel>> GetBranchProduct(string branchId);

        public Task<List<BranchProductDetailModel>> GetBranchProductDetail(string branchid, string productid);
    }
}
