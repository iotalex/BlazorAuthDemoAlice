//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace BlazorAuthDemo.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<(string Username, string EncryptedPassword)> _users = new()
        {
            ("alice", Encrypt("password1")),
            ("bob", Encrypt("password2"))
        };

        public bool IsAuthenticated { get; private set; } = false;

        public bool Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == default) return false; //auth fails because username doesn’t exist

            var decrypted = Decrypt(user.EncryptedPassword);
            if (decrypted == password)
            {
                IsAuthenticated = true;
                return true;
            }
            return false;
        }

        private static string Encrypt(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        private static string Decrypt(string input)
        {
            var bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
