using LG.DATA.Repository;
using LG.DOMAIN.Model;
using System.Collections.Generic;

namespace LG.BUSINESS
{
    public class ProductBusiness : IProductBusiness
    {
        public List<Product> GetAllProducts()
        {
            var productRepository = new ProductRepository();
            return productRepository.GetAllProducts();
        }
        public Product GetProductById(int id)
        {
            var productRepository = new ProductRepository();
            return productRepository.GetProductById(id);
        }
        

    }
}
