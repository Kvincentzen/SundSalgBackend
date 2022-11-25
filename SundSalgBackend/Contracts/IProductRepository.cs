using SundSalgBackend.Models;
using SundSalgBackend.Models.DataTransferObjects;

namespace SundSalgBackend.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProducts(bool trackchanges);
        Product GetProductById(int productId, bool trackChanges);
        Product GetProductWithDetails(int productId, bool trackChanges);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
