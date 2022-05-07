using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Greedy
{
    public class LostReserve
    {
        /// <summary>
        /// 점심시간에 도둑이 들어, 일부 학생이 체육복을 도난당했습니다. 
        /// 다행히 여벌 체육복이 있는 학생이 이들에게 체육복을 빌려주려 합니다. 
        /// 학생들의 번호는 체격 순으로 매겨져 있어, 바로 앞번호의 학생이나 바로 뒷번호의 학생에게만 체육복을 빌려줄 수 있습니다. 
        /// 예를 들어, 4번 학생은 3번 학생이나 5번 학생에게만 체육복을 빌려줄 수 있습니다. 
        /// 체육복이 없으면 수업을 들을 수 없기 때문에 체육복을 적절히 빌려 최대한 많은 학생이 체육수업을 들어야 합니다.
        /// 전체 학생의 수 n, 체육복을 도난당한 학생들의 번호가 담긴 배열 lost, 
        /// 여벌의 체육복을 가져온 학생들의 번호가 담긴 배열 reserve가 매개변수로 주어질 때, 
        /// 체육수업을 들을 수 있는 학생의 최댓값을 return 하도록 solution 함수를 작성해주세요.
        /// 
        /// 제한사항
        /// 전체 학생의 수는 2명 이상 30명 이하입니다.
        /// 체육복을 도난당한 학생의 수는 1명 이상 n명 이하이고 중복되는 번호는 없습니다.
        /// 여벌의 체육복을 가져온 학생의 수는 1명 이상 n명 이하이고 중복되는 번호는 없습니다.
        /// 여벌 체육복이 있는 학생만 다른 학생에게 체육복을 빌려줄 수 있습니다.
        /// 여벌 체육복을 가져온 학생이 체육복을 도난당했을 수 있습니다.
        /// 이때 이 학생은 체육복을 하나만 도난당했다고 가정하며, 
        /// 남은 체육복이 하나이기에 다른 학생에게는 체육복을 빌려줄 수 없습니다.
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="lost"></param>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public int solution(int n, int[] lost, int[] reserve)
        {
            TotalCount = 0;
            List<int> Rlost = lost.Where(p => !reserve.Any(q => q == p)).ToList();// 여분 에서 읿어버린사람 제거
            List<int> Rreserve = reserve.Where(p => !lost.Any(q => q == p)).ToList();// 여분에서 잃어버린 사람 제거 

            CheckCloth(n, Rlost, Rreserve);

            return TotalCount;
        }

        int TotalCount = 0;

        void CheckCloth(int n, List<int> lost, List<int> reserve)
        {
            if (TotalCount == n)
            {
                return;
            }

            if (reserve.Count == 0)
            {
                TotalCount = TotalCount < (n - lost.Count) ? (n - lost.Count) : TotalCount;
            }

            for (int i = 0; i < reserve.Count(); i++)
            {
                int ri = reserve[i];

                List<int> tempreserve = reserve.ToList();
                tempreserve.Remove(ri);

                if (lost.Any(p => p == ri - 1 || p == ri + 1))
                {
                    foreach (int li in lost.Where(p => p == ri - 1 || p == ri + 1))
                    {
                        List<int> templost = lost.ToList();
                        templost.Remove(li);
                        CheckCloth(n, templost, tempreserve);
                    }
                }
                else
                {
                    CheckCloth(n, lost, tempreserve);
                }
            }

        }


        public int Bestsolution(int n, int[] lost, int[] reserve)
        {
            int answer = 0;
            Queue<int> que = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (lost.Contains(i))
                {
                    if (reserve.Contains(i))
                    {
                        answer++;
                        que.Enqueue(i);
                    }
                    else if (reserve.Contains(i - 1) && lost.Contains(i - 1) == false && que.Contains(i - 1) == false)
                    {
                        answer++;
                        que.Enqueue(i - 1);
                    }
                    else if (reserve.Contains(i + 1) && lost.Contains(i + 1) == false && que.Contains(i + 1) == false)
                    {
                        answer++;
                        que.Enqueue(i + 1);
                    }
                }
                else answer++;
            }

            return answer;
        }

    }
}
