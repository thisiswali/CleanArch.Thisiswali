using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => 
            new ProductDto { 
                ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice 
            });
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return new ProductDto { ProductId = product.ProductId, ProductName = product.ProductName, UnitPrice = product.UnitPrice };
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = new Product { ProductName = productDto.ProductName, UnitPrice = productDto.UnitPrice };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = new Product { ProductId = productDto.ProductId, ProductName = productDto.ProductName, UnitPrice = productDto.UnitPrice };
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
