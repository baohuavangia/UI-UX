using MenShopUI.DTOs.Color;
using MenShopUI.DTOs.Fabric;

namespace MenShopUI.Services.Fabric
{
    public interface IFabricService
    {
        public Task<List<FabricModel>> GetFabricDtos();
        public Task AddFabric(FabricModel fabricDto);
        public Task UpdateFabric(FabricModel fabricDto);

        public Task<bool> DeleteFabric(int Id);
    }
}
