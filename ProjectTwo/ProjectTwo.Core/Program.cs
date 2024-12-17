using ProjectTwo.Core.Components;
using System;

namespace ProjectTwo.Core
{
    internal class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            int[] threads = new int[] { 1, 2, 4, 8, 16 };
            int hash_length = 6;

            var hg = new HashGenerator();
            string hash = hg.generateHash(hash_length);
            var mainer = new Mainer();
            mainer.Launch(hash_length, hash, threads);
            Console.ReadLine();
        }
    }
}
