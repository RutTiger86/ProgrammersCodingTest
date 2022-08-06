using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.BFS
{
    public class WordConversion
    {

        private static List<int> BFSanswer = new List<int>();

        /// <summary>
        /// 단어변환
        /// 두 개의 단어 begin, target과 단어의 집합 words가 있습니다.
        /// 아래와 같은 규칙을 이용하여 begin에서 target으로 변환하는 가장 짧은 변환 과정을 찾으려고 합니다.
        /// 1. 한 번에 한 개의 알파벳만 바꿀 수 있습니다.
        /// 2. words에 있는 단어로만 변환할 수 있습니다.
        /// 
        /// 제한사항     
        /// 각 단어는 알파벳 소문자로만 이루어져 있습니다.
        /// 각 단어의 길이는 3 이상 10 이하이며 모든 단어의 길이는 같습니다.
        /// words에는 3개 이상 50개 이하의 단어가 있으며 중복되는 단어는 없습니다.
        /// begin과 target은 같지 않습니다.
        /// 변환할 수 없는 경우에는 0를 return 합니다.
        /// </summary>
        /// <param name="begin">출발 단어</param>
        /// <param name="target">도착 단어</param>
        /// <param name="words">가용 단어 집합</param>
        /// <returns></returns>
        public static int BFSSolution(string begin, string target, string[] words)
        {
            List<char[]> wordsList = new List<char[]>();
            BFSanswer = new List<int>();

            foreach (string word in words)
            {
                wordsList.Add(word.ToArray());
            }

            BFS(1,begin.ToArray(), target, wordsList);

            if (BFSanswer.Count > 0)
            {
                return BFSanswer.Min();
            }
            else
            {
                return 0;
            }
        }

        private static void BFS(int answer, char[] begin, string target, List<char[]> wordsList)
        {
            foreach (char[] Words in GetTargetWordList(begin, wordsList))
            {
                int Tempanswer = answer + 1;// 횟수 추가 
                if (new string(Words) == target)// 타겟 단어가 되면 스톱
                {
                    BFSanswer.Add(answer);// 타겟 단어가 되면 여태까지의 횟수 기록
                    break;
                }
                else
                {
                    List<char[]> tempwordsList = wordsList.ToList();
                    tempwordsList.Remove(Words);       
                    BFS(Tempanswer,Words,target,tempwordsList);// 사용단어 빼고 다시 검색 
                }

            }
        }

        private static List<char[]> GetTargetWordList(char[] begin, List<char[]> wordsList)
        {
            List<char[]> TargetWordList = new List<char[]>();

            foreach (char[] word in wordsList)
            {
                int checkCount = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (begin[i] != word[i])// 위치별로 비교 필요 
                    {
                        checkCount++;// 다른 단어 (두단어 이상 다르면안됨)
                    }

                    if (checkCount > 1)// 두단어이상다름
                    {
                        break;
                    }
                }

                if (checkCount == 1)// 한단어만 다름 
                {
                    TargetWordList.Add(word);
                }
            }

            return TargetWordList;
        }


    }
}
