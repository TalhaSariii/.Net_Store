using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProducManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProducManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateProduct(Product product)
        {
            _manager.Product.Create(product);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
           var product= _manager.Product.GetOneProduct(id,trackChanges);
           if(product is null)  
                throw new Exception("Not Foundé!!!");
            return product;
        }
    }
}