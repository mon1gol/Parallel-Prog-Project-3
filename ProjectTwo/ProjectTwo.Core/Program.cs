using ProjectTwo.Core.Components;
using System;
using System.Diagnostics;

namespace ProjectTwo.Core
{
    internal class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int hash_length = 6;
            var hg = new HashGenerator();
            string hash = hg.generateHash(hash_length);
            var mainer = new Mainer();

            MPI.Environment.Run(ref args, num =>
            {
                mainer.Launch(hash_length, hash, num);
            });

            Console.ReadLine();
        }
    }
}
