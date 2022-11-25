using Microsoft.EntityFrameworkCore;
using SundSalgBackend.Models;
using System.Linq.Expressions;
using SundSalgBackend.Contracts;
using Microsoft.CodeAnalysis;

namespace SundSalgBackend.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IdentityContext identityContext)
            : base(identityContext)
        {
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToList();
        }
        public Product GetProductById(int productId, bool trackChanges)
        {
            return FindByCondition(product => product.Id.Equals(productId), trackChanges)
                .FirstOrDefault();
        }

        public Product GetProductWithDetails(int productId, bool trackChanges)
        {
            return FindByCondition(product => product.Id.Equals(productId), trackChanges)
                .FirstOrDefault();
        }

        public void CreateProduct(Product product)
        {
            Create(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
            Save();
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
            Save();
        }
    }
}
