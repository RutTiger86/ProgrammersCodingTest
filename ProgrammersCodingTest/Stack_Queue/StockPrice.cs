using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Stack_Queue
{
    public class StockPrice
    {
        /// <summary>
        /// 초 단위로 기록된 주식가격이 담긴 배열 prices가 매개변수로 주어질 때, 
        /// 가격이 떨어지지 않은 기간은 몇 초인지를 return 하도록 solution 함수를 완성하세요.
        /// 제한사항
        /// prices의 각 가격은 1 이상 10,000 이하인 자연수입니다.
        /// prices의 길이는 2 이상 100,000 이하입니다.
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int[] solution(int[] prices)
        {
            int[] answer = new int[prices.Length];

            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    answer[i]++;
                    if (prices[i] > prices[j])
                        break;
                }
            }
            return answer;
        }
              
    }
}
