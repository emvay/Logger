using LG.BUSINESS;
using LG.DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Get All Products

        #endregion

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var productBusiness = new ProductBusiness();
            return productBusiness.GetAllProducts();
        }
        
        [HttpPost]
        public ActionResult<Product> GetProductById(int id)
        {
            var productBusiness = new ProductBusiness();
            return productBusiness.GetProductById(id);
        }
    }
}
