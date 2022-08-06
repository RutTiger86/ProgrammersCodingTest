using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.DFS
{
    public class TravelRoute
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

            answer = solution(tickets);

            return answer;
        }

        static List<string> RouteList = new List<string>();

        public static string[] solution(string[,] tickets)
        {

            List < string[]> ticketList = new List<string[]>();

            for(int i =0; i<tickets.GetLength(0);i++)
            {
                ticketList.Add(new string[] { tickets[i, 0], tickets[i, 1] });
            }

            RouteList = new List<string>();

            int[] bulbs = new int[10];

            CalcRoute("ICN", "ICN", ticketList);

            return RouteList.OrderBy(p => p).First().Split('|');
        }

        public static void CalcRoute(string Source ,string NowRoute, List<string[]> ticketList)
        {
            int[] bulbs = new int[10];
            bulbs.All(p => p > 0);
            bulbs.Count(p => p > 0);
            bulbs.ToArray();

            int stp = 0;
            int enp = 0;

            for(int i= stp-1; i<enp; i++)
            {

            }

            foreach (string[] Tour in ticketList.Where(p=>p[0].Equals(Source)))
            {
                string TempRoute = NowRoute + $"|{Tour[1]}";

                if(ticketList.Count==1)
                {
                    RouteList.Add(TempRoute);
                    break;
                }

                List<string[]> TempTicketList =  ticketList.ToList();

                TempTicketList.Remove(Tour);

                CalcRoute(Tour[1],  TempRoute, TempTicketList);

            }

        }

    }
}
