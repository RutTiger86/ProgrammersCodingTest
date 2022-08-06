using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.ProgrammersLevelTest
{
    public class Solution2
    {
        /// <summary>
        /// 피보나치 수는 F(0) = 0, F(1) = 1일 때, 1 이상의 n에 대하여 F(n) = F(n-1) + F(n-2) 가 적용되는 수 입니다.
        /// 예를들어
        /// F(2) = F(0) + F(1) = 0 + 1 = 1
        /// F(3) = F(1) + F(2) = 1 + 1 = 2
        /// F(4) = F(2) + F(3) = 1 + 2 = 3
        /// F(5) = F(3) + F(4) = 2 + 3 = 5
        /// 와 같이 이어집니다.
        /// 
        /// 2 이상의 n이 입력되었을 때, n번째 피보나치 수를 1234567으로 나눈 나머지를 리턴하는 함수, solution을 완성해 주세요.
        /// 제한 사항
        /// n은 2 이상 100,000 이하인 자연수입니다.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int solution(int n)
        {
            List<int> TList = new List<int>() { 0,1};

            for(int i = 2; i <= n; i++)
            {
                TList.Add((TList[i - 1] + TList[i - 2])%1234567);
            }

            return TList.Last();
        }


        /// <summary>
        /// 문자열 s에는 공백으로 구분된 숫자들이 저장되어 있습니다. str에 나타나는 숫자 중 최소값과 최대값을 찾아 이를 "(최소값) (최대값)"형태의 문자열을 반환하는 함수, solution을 완성하세요.
        /// 예를들어 s가 "1 2 3 4"라면 "1 4"를 리턴하고, "-1 -2 -3 -4"라면 "-4 -1"을 리턴하면 됩니다.
        /// 제한 조건
        /// s에는 둘 이상의 정수가 공백으로 구분되어 있습니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string solution2(string s)
        {
            List<int> TList = s.Split(' ').Select(int.Parse).ToList();

            return $"{TList.Min()} {TList.Max()}";
        }

    }
}
