using LG.DOMAIN.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace LG.BUSINESS
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Token üretecek metot.
        public string CreateAccessToken(UserLogin userLogin)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
              Configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

            //Token tokenInstance = new Token();

            ////Security  Key'in simetriğini alıyoruz.
            //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));

            ////Şifrelenmiş kimliği oluşturuyoruz.
            //SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            ////Oluşturulacak token ayarlarını veriyoruz.
            //tokenInstance.Expiration = DateTime.Now.AddMinutes(5);
            //JwtSecurityToken securityToken = new(
            //    issuer: Configuration["Jwt:Issuer"],
            //    audience: Configuration["Jwt:Issuer"],
            //    expires: tokenInstance.Expiration,//Token süresini 5 dk olarak belirliyorum
            //    notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
            //    signingCredentials: signingCredentials
            //    );

            ////Token oluşturucu sınıfında bir örnek alıyoruz.
            //JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            ////Token üretiyoruz.
            //tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

            ////Refresh Token üretiyoruz.
            //tokenInstance.RefreshToken = CreateRefreshToken();
            //return tokenInstance;
        }

        //Refresh Token üretecek metot.
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
