using LG.DOMAIN.Model;
using System.Collections.Generic;
using System.Linq;

namespace LG.DATA.Repository
{
    public class ProductRepository
    {
        readonly List<Product> Products = new()
        {
            new Product{Id=1,Name="Pimtaş 3'' PVC Nipel",Price=5.09,Stock=100},
            new Product{Id=2,Name="Pimtaş U-PVC Zonder Boru",Price=12.79,Stock=100},
            new Product{Id=3,Name="Pimtaş PP Serbest Flanş",Price=20.76,Stock=100},
            new Product{Id=4,Name="Pimtaş 3'' PVC Nipel",Price=15.34,Stock=100}
        };
        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetProductById(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
