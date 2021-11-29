using LG.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.BUSINESS
{
    public interface IProductBusiness
    {
        public List<Product> GetAllProducts();

        public Product GetProductById(int id);

    }
}
