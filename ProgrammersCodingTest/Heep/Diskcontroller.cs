using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Heep
{
    public class Diskcontroller
    {
        /// <summary>
        /// 하드디스크는 한 번에 하나의 작업만 수행할 수 있습니다.
        /// 디스크 컨트롤러를 구현하는 방법은 여러 가지가 있습니다.
        /// 가장 일반적인 방법은 요청이 들어온 순서대로 처리하는 것입니다.
        /// 예를들어
        /// - 0ms 시점에 3ms가 소요되는 A작업 요청
        /// - 1ms 시점에 9ms가 소요되는 B작업 요청
        /// - 2ms 시점에 6ms가 소요되는 C작업 요청
        /// 와 같은 요청이 들어왔습니다.이를 그림으로 표현하면 아래와 같습니다.
        /// - A: 3ms 시점에 작업 완료 (요청에서 종료까지 : 3ms)
        /// - B: 1ms부터 대기하다가, 3ms 시점에 작업을 시작해서 12ms 시점에 작업 완료(요청에서 종료까지 : 11ms)
        /// - C: 2ms부터 대기하다가, 12ms 시점에 작업을 시작해서 18ms 시점에 작업 완료(요청에서 종료까지 : 16ms)
        /// 이 때 각 작업의 요청부터 종료까지 걸린 시간의 평균은 10ms(= (3 + 11 + 16) / 3)가 됩니다.
        /// 
        /// 하지만 A → C → B 순서대로 처리하면
        /// 
        /// - A: 3ms 시점에 작업 완료(요청에서 종료까지 : 3ms)
        /// - C: 2ms부터 대기하다가, 3ms 시점에 작업을 시작해서 9ms 시점에 작업 완료(요청에서 종료까지 : 7ms)
        /// - B: 1ms부터 대기하다가, 9ms 시점에 작업을 시작해서 18ms 시점에 작업 완료(요청에서 종료까지 : 17ms)
        /// 이렇게 A → C → B의 순서로 처리하면 각 작업의 요청부터 종료까지 걸린 시간의 평균은 9ms(= (3 + 7 + 17) / 3)가 됩니다.
        /// 각 작업에 대해 [작업이 요청되는 시점, 작업의 소요시간] 을 담은 2차원 배열 jobs가 매개변수로 주어질 때, 
        /// 작업의 요청부터 종료까지 걸린 시간의 평균을 가장 줄이는 방법으로 처리하면 평균이 얼마가 되는지
        /// return 하도록 solution 함수를 작성해주세요. (단, 소수점 이하의 수는 버립니다)
        /// 
        /// 제한 사항
        /// jobs의 길이는 1 이상 500 이하입니다.
        /// jobs의 각 행은 하나의 작업에 대한[작업이 요청되는 시점, 작업의 소요시간] 입니다.
        /// 각 작업에 대해 작업이 요청되는 시간은 0 이상 1,000 이하입니다.
        /// 각 작업에 대해 작업의 소요시간은 1 이상 1,000 이하입니다.
        /// 하드디스크가 작업을 수행하고 있지 않을 때에는 먼저 요청이 들어온 작업부터 처리합니다.
        /// </summary>
        /// <param name="jobs"></param>
        /// <returns></returns>
        public int solution(int[,] jobs)
        {
            int answer = 0;
            List<KeyValuePair<int,int>> T = new List<KeyValuePair<int, int>>();
            for (int x = 0; x < jobs.GetLength(0); x++)
            {
                T.Add(new KeyValuePair<int, int>(jobs[x, 0], jobs[x, 1]));// 요청 시간, 소요 시간 
            }

            for (int i = 0; ; i++)
            {
                if (T.Count() == 0) break;

                // 가장 먼저 수행할 잡 선택
                var cJob = T.Where(x => x.Key <= i).OrderBy(y => y.Value).ToList();// 가용한 프로세스( 들어온시간) 확인 후 가장짧은것부터
                if (cJob.Count == 0) continue;// 아직 할께 없으면 다음 으로 

                // 실행시간 계산
                answer += cJob[0].Key < i ? // 입력시간이 진행 시간보다 작다면(지연 시작된거라면) 
                    i - cJob[0].Key + cJob[0].Value // 지연시간 + 소요시간
                    : cJob[0].Value;// 소요시간 

                // 현재잡 종료시간 계산
                i = i + cJob[0].Value - 1;// 현자프로세스 종료시간으로 시간이동
                // 현재잡 제거
                T.Remove(cJob[0]);// 처리된 프로세스 삭제
            }

            return answer / jobs.GetLength(0);//평균시간 
        }
    }
}
