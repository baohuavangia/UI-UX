using MenShopUI.DTOs.Color;
using MenShopUI.DTOs.Fabric;

namespace MenShopUI.Services.Color
{
    public interface IColorService
    {
        public Task<List<ColorDto>> GetColorDtos();
        public Task AddColor(ColorDto colorDto);
        public Task UpdateColor(ColorDto colorDto);

       Task<bool> DeleteColor(int Id);
    }
}
