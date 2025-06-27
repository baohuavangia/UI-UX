using MenShopUI.DTOs.Color;
using MenShopUI.DTOs.Fabric;

namespace MenShopUI.Services.Fabric
{
    public interface IFabricService
    {
        public Task<List<FabricDto>> GetFabricDtos();
        public Task AddFabric(FabricDto fabricDto);
        public Task UpdateFabric(FabricDto fabricDto);

        public Task<bool> DeleteFabric(int Id);
    }
}
