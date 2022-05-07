using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest.Sort
{
    public class IndexK
    {
        public int[] solution(int[] array, int[,] commands)
        {
            List<int> answer = new List<int>();

            for(int i = 0; i < commands.GetLength(0); i++)
            {
                answer.Add(array.ToList().Skip(commands[i, 0]-1).Take(commands[i, 1] - (commands[i, 0] - 1)).OrderBy(p => p).ToList()[commands[i, 2] - 1]);
            }

            return answer.ToArray();
        }
    }
}
