using ProgrammersCodingTest._2021DevMatching;
using ProgrammersCodingTest.BFS;
using ProgrammersCodingTest.DFS;
using ProgrammersCodingTest.Stack_Queue;

namespace ProgrammersCodingTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            //AlgorithmDFSCall();
            //AlgorithmBFSCall();
            //AlgorithmStack_Queue();
            _2021DevMatching();
        }
        private static void _2021DevMatching()
        {
            int[,] queries1 = { {2,2,5,4},{3,3,6,6},{5,1,6,3} };

            int[] result1 = MatrixRotation.solution(6, 6, queries1);
            foreach (int s in result1)
            {
                Console.WriteLine(s);
            }


            int[,] queries2 = { { 1, 1, 2, 2 }, { 1, 2, 2, 3 }, { 2, 1, 3, 2 }, { 2, 2, 3, 3 } };

            int[] result2 = MatrixRotation.solution(3, 3, queries2);
            foreach (int s in result2)
            {
                Console.WriteLine(s);
            }

            int[,] queries3 = { { 1, 1, 100, 97 } };

            int[] result3 = MatrixRotation.solution(100, 97, queries3);
            foreach (int s in result3)
            {
                Console.WriteLine(s);
            }


        }

        private static void AlgorithmStack_Queue()
        {
            int[] Progresses1 = new int[] { 93, 30, 55 };
            int[] Speeds1= new int[] { 1, 30, 5 };

            int[] result = FuncDev.solution(Progresses1, Speeds1);
            foreach (int s in result)
            {
                Console.WriteLine(s);
            }

            int[] Progresses2 = new int[] { 95, 90, 99, 99, 80, 99 };
            int[] Speeds2 = new int[] { 1, 1, 1, 1, 1, 1 };

            int[] result2 = FuncDev.solution(Progresses2, Speeds2);
            foreach (int s in result2)
            {
                Console.WriteLine(s);
            }
        }

        private static void  AlgorithmDFSCall()
        {
            //string[,] tickets = new string[5, 2]{
            //    {"ICN", "SFO"},
            //    {"ICN", "ATL"},
            //    {"SFO", "ATL"},
            //    {"ATL", "ICN"},
            //    {"ATL", "SFO"}
            //};

            //string[] result =  TravelRoute.DFSSolution(tickets);
            //foreach(string s in result)
            //{
            //    Console.WriteLine(s);
            //}


            //int[] numbers = { 4, 1, 2, 1 };

            //int Result =  TargetNumber.solution(numbers, 4);

            //Console.WriteLine(Result);



            int[,] Computers = new int[,] { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } };

            int NetworkResult = Network.solution(3, Computers);

            Console.WriteLine(NetworkResult);

            //int[,] Computers2 = new int[,] { { 1, 1, 0 }, { 1, 1, 1 }, { 0, 1, 1 } };

            //int NetworkResult2 = Network.solution(3, Computers2);

            //Console.WriteLine(NetworkResult2);

            //int[,] Computers3 = new int[,] { { 1, 1, 0, 1 }, { 1, 1, 0, 0 }, { 0, 0, 1, 1 }, { 1, 0, 1, 1 } };

            //int NetworkResult3 = Network.solution(4, Computers3);
            //Console.WriteLine(NetworkResult3);

        }

        private static void AlgorithmBFSCall()
        {
            string[] words = new string[6] { "hot", "dot", "dog", "lot", "log", "cog" };

            int answer = WordConversion.BFSSolution("hit", "cog", words);
            Console.WriteLine(answer);


            string[] words2 = new string[5] { "hot", "dot", "dog", "lot", "log" };

            int answer2 = WordConversion.BFSSolution("hit", "cog", words2);
            Console.WriteLine(answer2);

            string[] words3 = new string[2] { "abb", "aba" };

            int answer3 = WordConversion.BFSSolution("aab", "aba", words3);
            Console.WriteLine(answer3);
        }

    }

}