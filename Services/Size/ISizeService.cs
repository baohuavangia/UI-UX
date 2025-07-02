using MenShopUI.DTOs.Fabric;
using MenShopUI.DTOs.Size;

namespace MenShopUI.Services.Size
{
    public interface ISizeService
    {
        public Task<List<SizeModel>> GetSizeAsync();

        public Task AddSize(SizeModel size);
        public Task UpdateSize(SizeModel sizeDto);

        public Task<bool> DeleteSize(int Id);
    }
}
