namespace MenShopUI.DTOs.Payment
{
    public class PaymentDiscountViewModel
    {
        public int DiscountId { get; set; }
        public string? PaymentId { get; set; }
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string? Type { get; set; }
    }
}
