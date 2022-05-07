using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.BinarySearch
{
    public class Immigration
    {
        /// <summary>
        /// n명이 입국심사를 위해 줄을 서서 기다리고 있습니다. 
        /// 각 입국심사대에 있는 심사관마다 심사하는데 걸리는 시간은 다릅니다.
        /// 처음에 모든 심사대는 비어있습니다.
        /// 한 심사대에서는 동시에 한 명만 심사를 할 수 있습니다. 
        /// 가장 앞에 서 있는 사람은 비어 있는 심사대로 가서 심사를 받을 수 있습니다.
        /// 하지만 더 빨리 끝나는 심사대가 있으면 기다렸다가 그곳으로 가서 심사를 받을 수도 있습니다.
        /// 모든 사람이 심사를 받는데 걸리는 시간을 최소로 하고 싶습니다.
        /// 입국심사를 기다리는 사람 수 n, 
        /// 각 심사관이 한 명을 심사하는데 걸리는 시간이 담긴 배열 times가 매개변수로 주어질 때,
        /// 모든 사람이 심사를 받는데 걸리는 시간의 최솟값을 return 하도록 solution 함수를 작성해주세요.
        /// 
        /// 제한사항
        /// 입국심사를 기다리는 사람은 1명 이상 1,000,000,000명 이하입니다.
        /// 각 심사관이 한 명을 심사하는데 걸리는 시간은 1분 이상 1,000,000,000분 이하입니다.
        /// 심사관은 1명 이상 100,000명 이하입니다.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public long solution(int n, int[] times)
        {
            Array.Sort(times);
            long max = (long)times[times.Length - 1] * (long)n;     //가장 느린 사람 혼자 상대했을 경우
            long min = 0;                               //대기인원이 원래 없는 경우
            long mid;
            long people;
            long answer = 0;

            while (min <= max)                          //맥스가 민 이상일 때
            {
                mid = (min + max) / 2;                  //미드값을 정해주고
                people = 0;                             //통과 사람 수를 초기화
                for (int i = 0; i < times.Length; ++i)
                {
                    people += mid / (long)times[i];           //카운터에 있는 사람이 미드값에 비해 처리할 수 있는 일의 양을 저장
                }

                if (people < (long)n)                         //처리 된 사람 수가 대기인원보다 적으면
                {
                    min = mid + 1;                      //민값을 상향
                }
                else                                    //대기 인원 이상이면
                {
                    max = mid - 1;                      //맥스값을 하향
                    answer = mid;
                }
            }
            return answer;
        }

    }
}
