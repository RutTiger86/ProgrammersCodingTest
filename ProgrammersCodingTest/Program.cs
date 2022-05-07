using ProgrammersCodingTest._2021DevMatching;
using ProgrammersCodingTest._2021KakaoIntern;
using ProgrammersCodingTest.BFS;
using ProgrammersCodingTest.DFS;
using ProgrammersCodingTest.DynamicProgramming;
using ProgrammersCodingTest.ExhaustiveSearch;
using ProgrammersCodingTest.Hash;
using ProgrammersCodingTest.Sort;
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
            //_2021DevMatching();
            //_KakaoIntern();
            //AlgorithmHashCall();
            //AlgorithmExhaustiveSearch();
            //AlgorithmSort();
            AlgorithmDynamicProgramming();
        }

        private static void AlgorithmDynamicProgramming()
        {
            NDisplay ND = new NDisplay();
            Console.WriteLine(ND.solution(5, 12));
            Console.WriteLine(ND.solution(2, 11));
            Console.WriteLine(ND.solution(6, 254));// 66*6

        }

        private static void AlgorithmSort()
        {
            IndexK ik = new();
            int[] result = ik.solution(new int[] { 1, 5, 2, 6, 3, 7, 4 }, new int[,] { { 2, 5, 3 }, { 4, 4, 1 }, { 1, 7, 3 } });

            foreach (int s in result)
            {
                Console.WriteLine(s);
            }
        }

        private static void AlgorithmExhaustiveSearch()
        {
            FindPrime fp = new FindPrime();

            Console.WriteLine(fp.solution("17"));

            Console.WriteLine(fp.solution("011"));
        }

        private static void AlgorithmHashCall()
        {
            //Camouflage cf = new Camouflage();
            //string[,] Clothes = { { "yellowhat", "headgear" }, { "bluesunglasses", "eyewear" }, { "green_turban", "headgear" } };
            //Console.WriteLine(cf.solution(Clothes));

            //string[,] Clothes2 = { { "crowmask", "face" }, { "bluesunglasses", "face" }, { "smoky_makeup", "face" } };
            //Console.WriteLine(cf.solution(Clothes2));



            BestAlbum bestAlbum = new BestAlbum();
            string[] genres = { "classic", "pop", "classic", "classic", "pop" };
            int[] plays = { 500, 600, 150, 800, 2500 };

            int[] result = bestAlbum.solution(genres, plays);

            foreach (int s in result)
            {
                Console.WriteLine(s);
            }

            //Printer printer = new Printer();

            //Console.WriteLine(printer.solution(new int[] {2,1,3,2 }, 2));

            //Console.WriteLine(printer.solution(new int[] { 1, 1, 9, 1, 1, 1 },0));

            //TruckBridge tb = new TruckBridge();

            //Console.WriteLine(tb.solution(2, 10, new int[] { 7,4,5,6 }));

            //Console.WriteLine(tb.solution(100, 100, new int[] { 10 }));

            //Console.WriteLine(tb.solution(100, 100, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));


            // StockPrice sp = new StockPrice();

            //int[] result = sp.solution(new int[] {1, 2, 3, 2, 3});

            //foreach (int s in result)
            //{
            //    Console.WriteLine(s);
            //}
        }

        private static void _KakaoIntern()
        {
            KeepDistance kd = new KeepDistance();

            string[,] places = {{"POOOP", "OXXOX", "OPXPX", "OOXOX", "POXXP"}, {"POOPX", "OXPXP", "PXXXO", "OXXXO", "OOOPP"}, {"PXOPX", "OXOXP", "OXPOX", "OXXOP", "PXPOX"}, {"OOOXX", "XOOOX", "OOOXX", "OXOOX", "OOOOO"}, {"PXPXP", "XPXPX", "PXPXP", "XPXPX", "PXPXP"}};
            //string[,] places = { { "XXXXX", "XXXXX", "XPOPX", "XXXXX", "XXXXX" } };

            int[] result =  kd.solution(places);

            foreach (int s in result)
            {
                Console.WriteLine(s);
            }
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