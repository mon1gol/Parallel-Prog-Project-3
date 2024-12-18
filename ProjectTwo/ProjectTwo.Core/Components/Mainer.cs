using System;
using System.Diagnostics;
using System.IO;
using MPI;

namespace ProjectTwo.Core.Components
{
    public class Mainer
    {
        private const string FILE_PATH = "ThreadsInfo.txt";

        public void Launch(int N, string target_hash, Intracommunicator num)
        {
            hashSelectionSeveralThreads(N, target_hash, num);
        }

        public void hashSelectionSeveralThreads(int N, string target_hash, Intracommunicator num)
        {
            string hash_symbols = "0123456789abcdef";
            int num_combinations = (int)Math.Pow(hash_symbols.Length, N);
            int size = num.Size;
            int rank = num.Rank;

            int combinations_per_process = num_combinations / size;
            int start_index = rank * combinations_per_process;
            int end_index = (rank == size - 1) ? num_combinations : start_index + combinations_per_process;

            var st = new Stopwatch();
            st.Start();
            bool found = false;

            for (int i = start_index; i < end_index; i++)
            {
                string tmp = generateMaybeHashString(i, N, hash_symbols);

                if (hashChecking(tmp, target_hash))
                {
                    Console.WriteLine($"Подбор завершен, результат: {tmp} от процесса {rank}");
                    st.Stop();
                    File.AppendAllText(FILE_PATH, size + "\t" + st.Elapsed.Milliseconds.ToString() + System.Environment.NewLine);

                    found = true;
                    break;
                }
            }

            bool[] foundArray = num.Allgather(found);
            bool overallFound = false;

            foreach (var f in foundArray)
            {
                if (f)
                {
                    overallFound = true;
                    break;
                }
            }

            if (overallFound)
            {
                Console.WriteLine($"Процесс {rank} завершает работу.");
            }
        }

        public string generateMaybeHashString(int index, int N, string hash_symbols)
        {
            char[] result = new char[N];
            for (int i = 0; i < N; i++)
            {
                result[N - 1 - i] = hash_symbols[index % hash_symbols.Length];
                index /= hash_symbols.Length;
            }
            return new string(result);
        }

        public bool hashChecking(string maybe_str, string target_hash)
        {
            return maybe_str == target_hash;
        }
    }
}
