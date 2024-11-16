﻿using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductDescription { get; set; }

        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}