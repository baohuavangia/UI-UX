﻿using MenShopUI.DTOs.Payment;
using MenShopUI.DTOs.ProductDetail;

namespace MenShopUI.DTOs.OrderCustomer
{
    public class OrderCustomerModel
    {
        public string OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? EmployeeName { get; set; }
        public string? ShipperName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? Status { get; set; }
        public string? IsOnline { get; set; }
        public string? Address { get; set; }
        public decimal? Total { get; set; }
        public List<ProductDetailViewModel>? Details { get; set; }
        public List<PaymentViewModel>? Payments { get; set; }
    }
}
