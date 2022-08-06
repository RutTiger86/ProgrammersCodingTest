using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.ProgrammersLevelTest
{
    public class Solution1
    {
        /// <summary>
        /// 자연수 n이 주어졌을 때, n의 다음 큰 숫자는 다음과 같이 정의 합니다.
        /// 조건 1. n의 다음 큰 숫자는 n보다 큰 자연수 입니다.
        /// 조건 2. n의 다음 큰 숫자와 n은 2진수로 변환했을 때 1의 갯수가 같습니다.
        /// 조건 3. n의 다음 큰 숫자는 조건 1, 2를 만족하는 수 중 가장 작은 수 입니다.
        /// 예를 들어서 78(1001110)의 다음 큰 숫자는 83(1010011)입니다.
        /// 
        /// 자연수 n이 매개변수로 주어질 때, n의 다음 큰 숫자를 return 하는 solution 함수를 완성해주세요.
        /// 제한 사항
        /// n은 1,000,000 이하의 자연수 입니다.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int solution(int n)
        {
            int countOfOne = Convert.ToString(n, 2).ToArray().Where(p => p.Equals('1')).Count();

            while (true)
            {
                n++;

                if (countOfOne == Convert.ToString(n, 2).ToArray().Where(p => p.Equals('1')).Count())
                {
                    break;
                }
            }

            return n;
        }


        /// <summary>
        /// 자연수 n이 주어졌을 때, n의 다음 큰 숫자는 다음과 같이 정의 합니다.
        /// 조건 1. n의 다음 큰 숫자는 n보다 큰 자연수 입니다.
        /// 조건 2. n의 다음 큰 숫자와 n은 2진수로 변환했을 때 1의 갯수가 같습니다.
        /// 조건 3. n의 다음 큰 숫자는 조건 1, 2를 만족하는 수 중 가장 작은 수 입니다.
        /// 예를 들어서 78(1001110)의 다음 큰 숫자는 83(1010011)입니다.
        /// 
        /// 자연수 n이 매개변수로 주어질 때, n의 다음 큰 숫자를 return 하는 solution 함수를 완성해주세요.
        /// 제한 사항
        /// n은 1,000,000 이하의 자연수 입니다.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int solution2(int n, int[,] wires)
        {
            List<int[]> ticketList = new List<int[]>();

            for (int i = 0; i < wires.GetLength(0); i++)
            {
                ticketList.Add(new int[] { wires[i, 0], wires[i, 1] });
            }
            answer = ticketList.Count + 1;
            
            for(int i = 0; i < ticketList.Count; i++)
            {
                List<int[]> TempList = ticketList.ToList();
                TempList.RemoveAt(i);





            }




            return answer;
        }

        private static int answer;

        public static void Calc(int[] Point ,  List<int[]> TempList)
        {
            

        }

    }
}
