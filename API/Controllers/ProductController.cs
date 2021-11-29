using LG.BUSINESS;
using LG.BUSINESS.Common;
using LG.DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace LG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductBusiness _productBusiness;
        public ProductController(ILogger<ProductController> logger, IProductBusiness productBusiness)
        {
            this._logger = logger;
            this._productBusiness = productBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var response = _productBusiness.GetAllProducts();

            #region Save Log
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ControllerContext.ActionDescriptor.ActionName;

            var responseStr = JsonConvert.SerializeObject(response);

            _logger.LogInformation("Controller : {0}, Action : {1}, Response : {2}", controllerName, actionName, responseStr);
            #endregion

            return response;
        }
        
        [HttpPost]
        public ActionResult<Product> GetProductById(int id)
        {
            var response = _productBusiness.GetProductById(id);

            #region Save Log
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            
            var responseStr = JsonConvert.SerializeObject(response);

            _logger.LogInformation("Controller : {0}, Action : {1}, Model : {2}, Response : {3}", controllerName, actionName, id, responseStr);
            #endregion

            return response;
        }
    }
}
