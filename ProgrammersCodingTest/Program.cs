using ProgrammersCodingTest.DFS;

namespace ProgrammersCodingTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            AlgorithmDFSCall();
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

    }

}