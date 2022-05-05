using ProgrammersCodingTest.BFS;
using ProgrammersCodingTest.DFS;

namespace ProgrammersCodingTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            //AlgorithmDFSCall();
            AlgorithmBFSCall();
        }

        private static void  AlgorithmDFSCall()
        {
            string[,] tickets = new string[5, 2]{
                {"ICN", "SFO"},
                {"ICN", "ATL"},
                {"SFO", "ATL"},
                {"ATL", "ICN"},
                {"ATL", "SFO"}
            };

            string[] result =  AlgorithmDFS.DFSSolution(tickets);
            foreach(string s in result)
            {
                Console.WriteLine(s);
            }
        }

        private static void AlgorithmBFSCall()
        {
            string[] words = new string[6] { "hot", "dot", "dog", "lot", "log", "cog" };

            int answer = AlgorithmBFS.BFSSolution("hit", "cog", words);
            Console.WriteLine(answer);


            string[] words2 = new string[5] { "hot", "dot", "dog", "lot", "log" };

            int answer2 = AlgorithmBFS.BFSSolution("hit", "cog", words2);
            Console.WriteLine(answer2);

            string[] words3 = new string[2] { "abb", "aba" };

            int answer3 = AlgorithmBFS.BFSSolution("aab", "aba", words3);
            Console.WriteLine(answer3);
        }

    }

}