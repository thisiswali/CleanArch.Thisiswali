using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task AddProduct(ProductDto product);
        Task UpdateProduct(ProductDto product);
        Task DeleteProduct(int id);
    }
}
