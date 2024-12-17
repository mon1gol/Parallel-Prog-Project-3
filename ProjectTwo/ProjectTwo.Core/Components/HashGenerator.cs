using System;
using System.Security.Cryptography;

namespace ProjectTwo.Core.Components
{
    public class HashGenerator
    {
        /// <summary>
        /// Генерация начального хэша
        /// </summary>
        /// <param name="N">длина хэша</param>
        /// <returns>строка хэша</returns>
        public string generateHash(int N)
        {
            byte[] bytes = new byte[N];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash_bytes = sha256.ComputeHash(bytes);
                string builder = "";
                foreach (byte b in bytes)
                {
                    builder += b.ToString("x2");
                }
                builder = builder.Substring(0, N);
                Console.WriteLine($"Заданный хэш: {builder}");
                return builder;
            }
        }
    }
}
