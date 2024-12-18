using MPI;
using ProjectTwo.Core.Components;

namespace ProjectTwo.Core
{
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Environment.Run(ref args, num =>
            {
                int hash_length = 6;
                var hg = new HashGenerator();
                string hash = string.Empty;

                if (num.Rank == 0)
                {
                    hash = hg.generateHash(hash_length);
                }

                Communicator.world.Broadcast(ref hash, 0);

                var mainer = new Mainer();
                mainer.Launch(hash_length, hash, num);
            });
        }
    }
}
