using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest._2021KakaoIntern
{
    public class KeepDistance
    {

        public int[] solution(string[,] places)
        {
            List<int> answer = new List<int>();

            for (int i = 0; i < places.GetLength(0); i++)
            {
                char[][] matrix = new char[5][];
                int[][] checkMatrix = new int[5][];
                for (int y = 0; y < 5; y++)
                {
                    matrix[y] = places[i, y].ToArray();
                    checkMatrix[y] = new int[]{0,0,0,0,0};
                }


                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if (matrix[y][x].Equals('P'))
                        {
                            checkMatrix [y][x] = checkMatrix[y][x]-1;// 자기위치
                            if (y-1>0)
                            {
                                checkMatrix[y-1][x] = checkMatrix[y-1][x] - 1;// 위에 한칸
                            }

                            if(y+1<5)
                            {
                                checkMatrix[y+1][x] = checkMatrix[y+1][x] - 1;// 아래 한칸
                            }

                            if(x-1>0)
                            {
                                checkMatrix[y][x-1] = checkMatrix[y][x-1] - 1;// 왼쪽한칸
                            }

                            if(x+1<5)
                            {
                                checkMatrix[y][x+1] = checkMatrix[y][x+1] - 1;// 오른쪽 한칸
                            }
                            
                        }else if (matrix[y][x].Equals('X'))
                        {
                            checkMatrix[y][x] = checkMatrix[y][x] +100;// 칸막이 방어력 100
                        }
                    }
                }

                int Result = 1;
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if(checkMatrix[y][x] < -1)// -2인 (영향이 겹치는) 공간 이 있으면 안됨
                        {
                            Result = 0;
                            break;
                        }
                    }

                    if(Result == 0)
                    {
                        break;
                    }
                }

                answer.Add(Result);
            }
            return answer.ToArray();
        }


    }
}
