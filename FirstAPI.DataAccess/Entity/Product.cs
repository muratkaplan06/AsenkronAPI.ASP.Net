﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstAPI.DataAccess.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Sku { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
       
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
