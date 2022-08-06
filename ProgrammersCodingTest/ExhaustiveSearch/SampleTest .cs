using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.ExhaustiveSearch
{
    public class SampleTest
    {
        /// <summary>
        /// 수포자는 수학을 포기한 사람의 준말입니다.
        /// 수포자 삼인방은 모의고사에 수학 문제를 전부 찍으려 합니다.
        /// 수포자는 1번 문제부터 마지막 문제까지 다음과 같이 찍습니다.
        /// 1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
        /// 2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
        /// 3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...
        /// 1번 문제부터 마지막 문제까지의 정답이 순서대로 들은 배열 answers가 주어졌을 때,
        /// 가장 많은 문제를 맞힌 사람이 누구인지 배열에 담아 return 하도록 solution 함수를 작성해주세요.
        /// 제한 조건
        /// 시험은 최대 10,000 문제로 구성되어있습니다.
        /// 문제의 정답은 1, 2, 3, 4, 5중 하나입니다.
        /// 가장 높은 점수를 받은 사람이 여럿일 경우, return하는 값을 오름차순 정렬해주세요.
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public int[] solution(int[] answers)
        {
            int[] nRules1 = new int[] { 1, 2, 3, 4, 5 };// 첫번재 규칙
            int[] nRules2 = new int[] { 2, 1, 2, 3, 2, 4, 2, 5 };// 두번째 규칙
            int[] nRules3 = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };// 세번째 규칙 
            int[] nScores = new int[3];// 정답자 
            for (int i = 0; i < answers.Length; i++)// 답안 수 만큼 검색 
            {
                if (answers[i] == nRules1[i % nRules1.Length]) ++nScores[0];// 첫번째 규칙 대로 했을때 맞으면 점수 +1
                if (answers[i] == nRules2[i % nRules2.Length]) ++nScores[1];// 두번째 규칙 대로 했을때 맞으면 점수 +1
                if (answers[i] == nRules3[i % nRules3.Length]) ++nScores[2];// 세번째 규칙 대로 했을때 맞으면 점수 +1
            }
            List<int> lstAnswer = new List<int>();
            if (nScores[0] == nScores.Max()) lstAnswer.Add(1);// 최고점수가 첫번재면 1번 추가 
            if (nScores[1] == nScores.Max()) lstAnswer.Add(2);// 최고점수가 두번재면 2번 추가 
            if (nScores[2] == nScores.Max()) lstAnswer.Add(3);// 최고점수가 세번재면 3번 추가 
            return lstAnswer.ToArray();
        }
    }
}
