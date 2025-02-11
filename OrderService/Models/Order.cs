﻿namespace OrderService.Models
{
    public class Order
    {
        public string? Id { get; set; }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
