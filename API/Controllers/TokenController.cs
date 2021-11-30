using LG.BUSINESS;
using LG.DOMAIN.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        readonly IConfiguration _configuration;
        public TokenController(ILogger<ProductController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost(nameof(AccessToken))]
        public object AccessToken([FromBody] UserLogin userLogin)
        {
            UserLogin user = new UserLogin() { Email = "Test", Password = "123" };
            IActionResult response = Unauthorized();
                
            if (user.Email == userLogin.Email && user.Password == userLogin.Password)
            {
                TokenHandler tokenHandler = new(_configuration);
                var tokenString = tokenHandler.CreateAccessToken(userLogin);
                response = Ok(new { Token = tokenString, Message = "Success" });

                #region Save Log
                var controllerName = ControllerContext.ActionDescriptor.ControllerName;
                var actionName = ControllerContext.ActionDescriptor.ActionName;

                var responseStr = JsonConvert.SerializeObject(response);
                var modelStr = JsonConvert.SerializeObject(userLogin);

                _logger.LogInformation("Controller : {0}, Action : {1}, Model : {2}, Response : {3}", controllerName, actionName, modelStr, responseStr);
                #endregion

                return response;
            }
            return response;
        }
    }
}
