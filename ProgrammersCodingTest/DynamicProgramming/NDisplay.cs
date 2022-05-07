using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.DynamicProgramming
{
    public class NDisplay
    {
        /// <summary>
        /// 아래와 같이 5와 사칙연산만으로 12를 표현할 수 있습니다.
        /// 12 = 5 + 5 + (5 / 5) + (5 / 5)
        /// 12 = 55 / 5 + 5 / 5
        /// 12 = (55 + 5) / 5
        /// 5를 사용한 횟수는 각각 6,5,4 입니다.그리고 이중 가장 작은 경우는 4입니다.
        /// 이처럼 숫자 N과 number가 주어질 때,
        /// N과 사칙연산만 사용해서 표현 할 수 있는 방법 중 N 사용횟수의 최솟값을 return 하도록 solution 함수를 작성하세요.
        /// 
        /// 제한사항
        /// N은 1 이상 9 이하입니다.
        /// number는 1 이상 32,000 이하입니다.
        /// 수식에는 괄호와 사칙연산만 가능하며 나누기 연산에서 나머지는 무시합니다.
        /// 최솟값이 8보다 크면 -1을 return 합니다.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public int solution(int N, int number)
        {
            answer = 9;

            DFS(N, number, 0, 0);

            if(answer>8)// 초기값 9 였음
            {
                return -1;
            }

            return answer;
        }
        int answer = 9;
        public void DFS(int N, int number, int count , int sum )
        {
            if(count>8)// 8 넘으면 리턴 
            {
                return;
            }

            if(sum==number)
            {
                answer = count<answer ? count : answer;  // 작은값 취합
            }

            int temp = 0;
            for(int i= 0; i<(8-count); i++)
            {
                temp = (temp * 10) + N; //N이 5면 ,,,    5 , 55, 555, 55555

                DFS(N, number, count + i + 1, sum + temp);//위에 5를 한번 사용해서 +1 , 한번 돌때마다 5가 추가되니 i+, 상위 메소드에서 사용한 수량이 count
                DFS(N, number, count + i + 1, sum - temp);
                DFS(N, number, count + i + 1, sum * temp);
                DFS(N, number, count + i + 1, sum / temp);

            }

        }

    }
}
