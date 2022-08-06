using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.ProgrammersLevelTest
{
    public class SimpleTest
    {
        public static int[] solution(int[] lottos, int[] win_nums)
        {
            int[] answer = new int[2];

            int Max = 7 - lottos.Where(p => p == 0 || win_nums.Contains(p)).Count();
            int Min = 7 - lottos.Where(p => win_nums.Contains(p)).Count();
            answer[0] = Max < 7 ? Max : 6;
            answer[1] = Min < 7 ? Min : 6;

            return answer;
        }

        public static int solution2(string s)
        {
            string stranswer = String.Empty;

            Dictionary<string, string> NumList = new Dictionary<string, string>()
            {
                {"zero", "0" },
                {"one", "1" },
                {"two", "2" },
                {"three", "3" },
                {"four", "4" },
                {"five", "5" },
                {"six", "6" },
                {"seven", "7" },
                {"eight", "8" },
                {"nine", "9" },
            };

            foreach (KeyValuePair<string, string> str in NumList)
            {
                s = s.Replace(str.Key, str.Value);
            }


            //List<char> list = s.ToList();
            char[] arr = s.ToArray();


            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i].ToString(), out int IData))
                {
                    stranswer += IData.ToString();
                }
                else
                {
                    for (int j = 1; j <= arr.Length - i; j++)
                    {
                        char[] Temp = new char[j];
                        Array.Copy(arr, i, Temp, 0, j);

                        if (NumList.TryGetValue(new string(Temp), out string Num))
                        {
                            stranswer += Num;
                            i = i + j - 1;
                            break;
                        }
                    }
                }
            }

            //while (list.Count > 0)
            //{
            //    if (int.TryParse(list[0].ToString(), out int IData))
            //    {
            //        stranswer += IData.ToString();
            //        list.RemoveRange(0, 1);
            //    }
            //    else
            //    {
            //        for (int i = 1; i <= list.Count; i++)
            //        {
            //            if (NumList.TryGetValue(new string(list.Take(i).ToArray()), out string Num))
            //            {
            //                stranswer += Num;
            //                list.RemoveRange(0, i);
            //                break;
            //            }
            //        }
            //    }
            //}

            return Convert.ToInt32(stranswer);
        }

        /// <summary>
        /// 문제 설명
        /// 각 칸마다 S, L, 또는 R가 써져 있는 격자가 있습니다.당신은 이 격자에서 빛을 쏘고자 합니다.
        /// 이 격자의 각 칸에는 다음과 같은 특이한 성질이 있습니다.
        /// 빛이 "S"가 써진 칸에 도달한 경우, 직진합니다.
        /// 빛이 "L"이 써진 칸에 도달한 경우, 좌회전을 합니다.
        /// 빛이 "R"이 써진 칸에 도달한 경우, 우회전을 합니다.
        /// 빛이 격자의 끝을 넘어갈 경우, 반대쪽 끝으로 다시 돌아옵니다. 
        /// 예를 들어, 빛이 1행에서 행이 줄어드는 방향으로 이동할 경우, 같은 열의 반대쪽 끝 행으로 다시 돌아옵니다.
        /// 당신은 이 격자 내에서 빛이 이동할 수 있는 경로 사이클이 몇 개 있고, 각 사이클의 길이가 얼마인지 알고 싶습니다. 
        /// 경로 사이클이란, 빛이 이동하는 순환 경로를 의미합니다.
        /// 예를 들어, 다음 그림은 격자["SL", "LR"] 에서 1행 1열에서 2행 1열 방향으로 빛을 쏠 경우, 
        /// 해당 빛이 이동하는 경로 사이클을 표현한 것입니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int[] solution3(string[] grid)
        {
            CheckArr = new int[grid.Length][][];

            Map = new char[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                Map[i] = grid[i].ToArray();
                CheckArr[i] = new int[Map[i].Length][];

                for (int j = 0; j < Map[i].Length; j++)
                {
                    CheckArr[i][j] = new int[4] { 0, 0, 0, 0 };
                }
            }

            for (int y = 0; y < CheckArr.Length; y++)
            {
                for (int x = 0; x < CheckArr[y].Length; x++)
                {
                    for (int z = 0; z < CheckArr[y][x].Length; z++)
                    {
                        if (CheckArr[y][x][z] == 0)
                        {
                            FindCycle(0, y, x, z);
                        }

                    }
                }
            }


            return CycleList.OrderBy(p=> p).ToArray();
        }

        enum eDirection
        {
            LEFT = 0,
            RIGHT = 1,
            UP = 2,
            DOWN = 3,
        }

        private static char[][] Map;
        private static int[][][] CheckArr;
        private static List<int> CycleList = new();

        private static void FindCycle(int Count, int y, int x, int z)
        {
            if (CheckArr[y][x][z] != 0)
            {
                CycleList.Add(Count);
                return;
            }
            else
            {
                CheckArr[y][x][z] = 1;
                Count++;

                switch ((eDirection)z)
                {
                    case eDirection.LEFT:
                        if ((x - 1) < 0)
                        {
                            x = Map[y].Length - 1;
                        }
                        else
                        {
                            x--;
                        }

                        switch (Map[y][x])
                        {
                            case 'L': z = (int)eDirection.DOWN; break;
                            case 'R': z = (int)eDirection.UP; break;
                        }
                        break;
                    case eDirection.RIGHT:
                        x = (x + 1) > Map[y].Length - 1 ? 0 : x++;

                        switch (Map[y][x])
                        {
                            case 'L': z = (int)eDirection.UP; break;
                            case 'R': z = (int)eDirection.DOWN; break;
                        }

                        break;
                    case eDirection.UP:
                        y = (y - 1) < 0 ? Map.Length - 1 : y--;

                        switch (Map[y][x])
                        {
                            case 'L': z = (int)eDirection.LEFT; break;
                            case 'R': z = (int)eDirection.RIGHT; break;
                        }

                        break;
                    case eDirection.DOWN:
                        if ((y + 1) > Map.Length - 1)
                        {
                            y = 0;
                        }
                        else
                        {
                            ++y;
                        }

                        switch (Map[y][x])
                        {
                            case 'L': z = (int)eDirection.RIGHT; break;
                            case 'R': z = (int)eDirection.LEFT; break;
                        }
                        break;
                }

                FindCycle(Count, y, x, z);
            }

        }
    }
}
