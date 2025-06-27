using MenShopUI.DTOs.Fabric;
using MenShopUI.DTOs.Size;

namespace MenShopUI.Services.Size
{
    public interface ISizeService
    {
        public Task<List<SizeDto>> GetSizeAsync();

        public Task AddSize(SizeDto size);
        public Task UpdateSize(SizeDto sizeDto);

        public Task<bool> DeleteSize(int Id);
    }
}
