using AwesomeBankingApp.Authorization.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AwesomeBankingApp.Authorization.Services
{
    public class UserService : IUserService
    {
        private readonly string validUsername;
        private readonly string validPassword;

        public UserService(IOptions<AuthorizationModuleConfiguration> options)
        {
            validUsername = options?.Value?.Username 
                ?? throw new ArgumentException($"Default {nameof(options.Value.Username)} not provided");

            validPassword = options?.Value?.Password
                ?? throw new ArgumentException($"Default {nameof(options.Value.Password)} not provided");
        }

        public bool IsValidUser(string username, string password)
        {
            // For demo purposes, credentials are stored in configuration. 
            // In real, production implementation, there should be some user repository
            // or IdentityServer/OAuth2.
            return validUsername == ComputeSha256Hash(username) && validPassword == ComputeSha256Hash(password);
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            // Convert byte array to a string   
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
