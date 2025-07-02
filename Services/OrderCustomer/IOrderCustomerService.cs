using MenShopUI.DTOs.OrderCustomer;
using MenShopUI.DTOs.ProductDetail;

namespace MenShopUI.Services.OrderCustomer
{
    public interface IOrderCustomerService
    {
        Task CancelOrderAsync(string orderId);
        Task<List<OrderCustomerModel>> GetOrderCustomerAsync(string customerId);
        Task<OrderCustomerModel> GetOrderCustomerDetailsAsync(string orderId);
    }
}