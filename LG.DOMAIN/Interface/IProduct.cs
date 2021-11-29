using LG.DOMAIN.Model;
using System.Collections.Generic;

namespace LG.DOMAIN.Interface
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
