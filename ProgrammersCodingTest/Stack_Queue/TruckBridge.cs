﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Stack_Queue
{
    public class TruckBridge
    {

        /// <summary>
        /// 트럭 다리 문제 인데 큐에 넣고 트럭과 빈공간 0을 넣어서 밀면서 처리하는것도 방법 
        /// </summary>
        /// <param name="bridge_length"></param>
        /// <param name="weight"></param>
        /// <param name="truck_weights"></param>
        /// <returns></returns>
        public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            int answer = 0;
            List< TruckInfo> WaitingList = new List<TruckInfo>();
            Queue<TruckInfo> BridegeQueue = new Queue<TruckInfo>();

            for (int i = 0; i < truck_weights.Length; i++)
            {
                WaitingList.Add(new TruckInfo(i, truck_weights[i]));
            }

            while (WaitingList.Count > 0)
            {
                answer++;

                BridegeQueue.ToList().ForEach(p => p.MoveTruck());

                if (BridegeQueue.Any(p => p.bridge_Point >= bridge_length))// 빠질차 빠지고 
                {
                    BridegeQueue.Dequeue();
                }

                TruckInfo TI = WaitingList.First();

                if (BridegeQueue.Sum(p => p.weight) + TI.weight <= weight)
                {
                    BridegeQueue.Enqueue(TI);
                    WaitingList.Remove(TI);
                }
            }

            answer += bridge_length;

            return answer;
        }

        public class TruckInfo
        {
            public int bridge_Point { get; set; }
            public int weight { get; set; }
            public int ID { get; set; }

            public TruckInfo(int _ID, int _weight)
            {
                bridge_Point = 0;
                ID = _ID;
                weight = _weight;
            }

            public void MoveTruck()
            {
                bridge_Point++;
            }
        }

    }
}
