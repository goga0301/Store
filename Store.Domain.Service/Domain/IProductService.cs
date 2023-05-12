﻿using Store.Domain.Entities;

namespace Store.Domain.Service.Domain
{
    public interface IProductService 
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
        Task<IEnumerable<Product>> GetAllProducts();

    }
}
