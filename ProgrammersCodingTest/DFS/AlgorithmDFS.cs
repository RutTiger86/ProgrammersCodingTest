using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.DFS
{
    public class AlgorithmDFS
    {


        private static List<string> _airPortsList = new List<string>();

        /// <summary>
        /// 여행경로
        /// 주어진 항공권을 모두 이용하여 여행경로를 짜려고 합니다. 항상 "ICN" 공항에서 출발합니다.
        /// 항공권 정보가 담긴 2차원 배열 tickets가 매개변수로 주어질 때, 방문하는 공항 경로를 배열에 담아 return 하도록 solution 함수를 작성해주세요.
        /// 
        /// 제한사항
        /// 모든 공항은 알파벳 대문자 3글자로 이루어집니다.
        /// 주어진 공항 수는 3개 이상 10,000개 이하입니다.
        /// tickets의 각 행[a, b] 는 a 공항에서 b 공항으로 가는 항공권이 있다는 의미입니다.
        /// 주어진 항공권은 모두 사용해야 합니다.
        /// 만일 가능한 경로가 2개 이상일 경우 알파벳 순서가 앞서는 경로를 return 합니다.
        /// 모든 도시를 방문할 수 없는 경우는 주어지지 않습니다.
        /// </summary>
        /// <param name="tickets">항공권 정보가 담긴 2차원 배열</param>
        /// <returns></returns>
        public static string[] DFSSolution(string[,] tickets)
        {
            string[] answer = new string[] { };

            answer = BestSolution(tickets);

            return answer;
        }



        /// <summary>
        /// 프로그래머스 확인 BestSolution 
        /// 개발 실패(TC 1,2 돌파 불가) 
        /// </summary>
        /// <param name="tickets">항공권 정보가 담긴 2차원 배열</param>
        /// <returns></returns>
        private static string[] BestSolution(string[,] tickets)
        {
            string[] answer = new string[] { };

            List<string[]> vs = new List<string[]>();

            for (int i = 0; i < tickets.GetLength(0); i++)
            {
                vs.Add(new string[] { tickets[i, 0], tickets[i, 1] });
            }

            string airports = "ICN";//경로 리스트
            FindAirport(airports, "ICN", vs.ToArray());

            _airPortsList.Sort();
            answer = _airPortsList.First().Split(',');

            return answer;
        }

        /// <summary>
        /// 현재 티켓의 모든경로를 찾아본다.
        /// </summary>
        /// <param name="airports">여태까지의 경로</param>
        /// <param name="lastAirPort">마지막 경로</param>
        /// <param name="remainTickets">남은 티켓 </param>
        private static void FindAirport(string airports, string lastAirPort, string[][] remainTickets)
        {
            foreach (string[] item in remainTickets.Where(s => s[0] == lastAirPort))// 모든 경우를  돌아본다. 
            {
                string tempAirports = string.Format("{0},{1}", airports, item[1]);
                if (remainTickets.Count() == 1)
                {
                    _airPortsList.Add(tempAirports);
                    return;
                }
                List<string[]> tempTickets = remainTickets.ToList();// 현재 티켓 리스트 복사 
                tempTickets.Remove(item);// 마지막 선택 경로 티켓 삭제 
                FindAirport(tempAirports, item[1], tempTickets.ToArray());// 해당 티켓들로 다시 탐색 (재귀호출) 
            }
        }

    }
}
