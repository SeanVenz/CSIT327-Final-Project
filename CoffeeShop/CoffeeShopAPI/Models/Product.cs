﻿namespace CoffeeShopAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
