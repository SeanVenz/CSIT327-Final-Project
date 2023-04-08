﻿namespace CoffeeShopAPI.Models
{
    public class Barista
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
