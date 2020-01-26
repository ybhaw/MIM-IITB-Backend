using System;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;

namespace MIM_IITB.Helpers
{
    public static class Authentication
    {
        private const string Algorithm = "HMACSHA256";
        private const int SaltLength = 32;

        public static byte[] GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltLength];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        public static string GenerateToken(User user)
        {
            string token;
            byte[] salt = GenerateSalt();
            using (var hmac = HMAC.Create(Algorithm))
            {
                hmac.Key = salt;
                hmac.ComputeHash(Encoding.UTF8.GetBytes(string.Join(":", user.Name, user.Email, user.PasswordHash)));
                token = Convert.ToBase64String(hmac.Hash);
            }
            return token;
        }

        public static byte[] GeneratePassword(string password, byte[] salt)
        {
            byte[] hash;
            using (var hmac = HMAC.Create(Algorithm))
            {
                hmac.Key = salt;
                hmac.ComputeHash(Encoding.UTF32.GetBytes(password));
                hash = hmac.Hash;
            }

            return hash;
        }

        public static bool Validate(string password, byte[] salt, byte[] hash) =>
            GeneratePassword(password, salt).SequenceEqual(hash);

        public static bool ValidateUser(User user, string password) =>
            Validate(password, user.PasswordSalt, user.PasswordHash);
    }

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthUserRepository authUserRepository)
        {
            var headers = context.Request.Headers;
            var tokenString = headers["authorize"].ToString();
            if (tokenString == "") await _next(context);
            else
            {
                var userQuery = authUserRepository.Find(c => c.Token == tokenString && (c.ExpiresIn > DateTime.Now || c.Remember == true));
                if (userQuery.Any()) 
                {
                    var user = authUserRepository.GetUser(tokenString);
                    context.Items.Add("User",user);
                }
            }
            await _next(context);
        }
    }

    public static class AuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}