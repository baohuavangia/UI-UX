using MenShopUI.DTOs.Color;
using MenShopUI.DTOs.Fabric;

namespace MenShopUI.Services.Color
{
    public interface IColorService
    {
        public Task<List<ColorModel>> GetColorDtos();
        public Task AddColor(ColorModel colorDto);
        public Task UpdateColor(ColorModel colorDto);

       Task<bool> DeleteColor(int Id);
    }
}
