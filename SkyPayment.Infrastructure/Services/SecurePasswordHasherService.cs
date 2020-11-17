using System;
using System.Security.Cryptography;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Infrastructure.Services
{
    public class SecurePasswordHasherService : ISecurePasswordHasherService 
    {
        /// <summary>
        /// Size of salt.
        /// </summary>
        private readonly int _saltSize;

        /// <summary>
        /// Size of hash.
        /// </summary>
        private readonly int _hashSize;

        /// <summary>
        /// Number of iterations
        /// </summary>
        private readonly int _iterations;

        public SecurePasswordHasherService(int saltSize = 16, int hashSize = 20, int iterations = 10000)
        {
            _saltSize = saltSize;
            _hashSize = hashSize;
            _iterations = iterations;
        }

        /// <summary>
        /// Creates a hash from a password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="iterations">Number of iterations.</param>
        /// <returns>The hash.</returns>
        public string Hash(string password)
        {
            // Create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[_saltSize]);

            // Create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations);
            var hash = pbkdf2.GetBytes(_hashSize);

            // Combine salt and hash
            var hashBytes = new byte[_saltSize + _hashSize];
            Array.Copy(salt, 0, hashBytes, 0, _saltSize);
            Array.Copy(hash, 0, hashBytes, _saltSize, _hashSize);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            // Format hash with extra information
            return string.Format("$SKYHASH$V1${0}${1}", _iterations, base64Hash);
        }

        /// <summary>
        /// Checks if hash is supported.
        /// </summary>
        /// <param name="hashString">The hash.</param>
        /// <returns>Is supported?</returns>
        public bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$SKYHASH$V1$");
        }

        /// <summary>
        /// Verifies a password against a hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="hashedPassword">The hash.</param>
        /// <returns>Could be verified?</returns>
        public bool Verify(string password, string hashedPassword)
        {
            // Check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            // Extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace("$SKYHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt
            var salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);

            // Create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(_hashSize);

            // Get result
            for (var i = 0; i < _hashSize; i++)
            {
                if (hashBytes[i + _saltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}