using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Hash
{
    public class Camouflage
    {
        /// <summary>
        /// 스파이들은 매일 다른 옷을 조합하여 입어 자신을 위장합니다.
        /// 예를 들어 스파이가 가진 옷이 아래와 같고 오늘 스파이가 동그란 안경,
        /// 긴 코트, 파란색 티셔츠를 입었다면 다음날은 청바지를 추가로 입거나 동그란 안경 대신 검정 선글라스를 착용하거나 해야 합니다.
        /// 
        /// 종류	이름
        /// 얼굴 동그란 안경, 검정 선글라스
        /// 상의 파란색 티셔츠
        /// 하의  청바지
        /// 겉옷  긴 코트
        /// 
        /// 스파이가 가진 의상들이 담긴 2차원 배열 clothes가 주어질 때 서로 다른 옷의 조합의 수를 return 하도록 solution 함수를 작성해주세요.
        /// 
        /// 제한사항
        /// clothes의 각 행은[의상의 이름, 의상의 종류] 로 이루어져 있습니다.
        /// 스파이가 가진 의상의 수는 1개 이상 30개 이하입니다.
        /// 같은 이름을 가진 의상은 존재하지 않습니다.
        /// clothes의 모든 원소는 문자열로 이루어져 있습니다.
        /// 모든 문자열의 길이는 1 이상 20 이하인 자연수이고 알파벳 소문자 또는 '_' 로만 이루어져 있습니다.
        /// 스파이는 하루에 최소 한 개의 의상은 입습니다.
        /// 
        /// [["yellowhat", "headgear"], ["bluesunglasses", "eyewear"], ["green_turban", "headgear"]] 5
        /// </summary>
        /// <param name="clothes"></param>
        /// <returns></returns>
        public int solution(string[,] clothes)
        {
            int answer = 1;
            List< ClthInf> ClthInfList = new List<ClthInf>();

            for (int i = 0; i < clothes.GetLength(0); i++)
            {
                ClthInfList.Add(new ClthInf(clothes[i, 0], clothes[i, 1]));
            }
            
            foreach(var groupClth in ClthInfList.GroupBy(p => p._Type))
            {
                answer = answer * (groupClth.Count()+1);
            }

            answer = answer - 1;

            return answer;
        }



        private class ClthInf
        {
            public string _Name { get; set; }
            public string _Type { get; set; }

            public ClthInf(string Name, string Type)
            {
                _Name = Name;
                _Type = Type;
            }
        }


        //private int answer = 0;

        //private void MathClothInfo(List<ClthInf> ClthInfList)
        //{
        //    while (ClthInfList.Count > 0)
        //    {
        //        ClthInf Target = ClthInfList.First();

        //        answer++;

        //        List<ClthInf> TempClthInfList = ClthInfList.Where(p => !p._Type.Equals(Target._Type)).ToList();

        //        MathClothInfo(TempClthInfList);

        //        ClthInfList.Remove(Target);
        //    }
           
        //}


    }
}
