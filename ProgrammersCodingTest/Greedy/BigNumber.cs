using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Greedy
{
    public class BigNumber
    {
        /// <summary>
        /// 어떤 숫자에서 k개의 수를 제거했을 때 얻을 수 있는 가장 큰 숫자를 구하려 합니다.
        /// 예를 들어, 숫자 1924에서 수 두 개를 제거하면[19, 12, 14, 92, 94, 24] 를 만들 수 있습니다.이 중 가장 큰 숫자는 94 입니다.
        /// 문자열 형식으로 숫자 number와 제거할 수의 개수 k가 solution 함수의 매개변수로 주어집니다.
        /// number에서 k 개의 수를 제거했을 때 만들 수 있는 수 중 가장 큰 숫자를 문자열 형태로 return 하도록 solution 함수를 완성하세요.
        /// 
        /// 제한 조건
        /// number는 2자리 이상, 1,000,000자리 이하인 숫자입니다.
        /// k는 1 이상 number의 자릿수 미만인 자연수입니다.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string solution(string number, int k) 
        {
            string answer = "";
            number = "9" + number;// 이전 값과의 오류 방지를 위하여 9추가(나중에 제거 ) 9는 무조건 크다
            StringBuilder sb = new StringBuilder(number);

            int index = 0;
            for (int i = 0; i < k; i++)// 빼는 횟수 
            {
                while (true)
                {
                    if (index + 1 == sb.Length)//길이+1이 전체 길이 와 같으면
                    {
                        sb.Remove(index, 1);// 
                        index--;
                        break;
                    }

                    if (sb[index] < sb[index + 1])// 지금 값보다 다음 값이 크면 
                    {
                        sb.Remove(index, 1);
                        index--;
                        break;
                    }
                    index++;
                }
            }

            return answer = sb.Remove(0, 1).ToString();// 첫번재꺼 빼고 전달 
        }

    }
}
