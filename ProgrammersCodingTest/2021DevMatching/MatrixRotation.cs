using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersCodingTest._2021DevMatching
{
    public class MatrixRotation
    {
        /// <summary>
        /// rows x columns 크기인 행렬이 있습니다. 행렬에는 1부터 rows x columns까지의 숫자가 한 줄씩 순서대로 적혀있습니다.
        /// 이 행렬에서 직사각형 모양의 범위를 여러 번 선택해, 테두리 부분에 있는 숫자들을 시계방향으로 회전시키려 합니다.
        /// 각 회전은 (x1, y1, x2, y2)인 정수 4개로 표현하며, 그 의미는 다음과 같습니다.
        /// x1 행 y1 열부터 x2 행 y2 열까지의 영역에 해당하는 직사각형에서 테두리에 있는 숫자들을 한 칸씩 시계방향으로 회전합니다.
        /// 행렬의 세로 길이(행 개수) rows, 가로 길이(열 개수) columns, 그리고 회전들의 목록 queries가 주어질 때,
        /// 각 회전들을 배열에 적용한 뒤, 
        /// 그 회전에 의해 위치가 바뀐 숫자들 중 가장 작은 숫자들을 순서대로 배열에 담아 return 하도록 solution 함수를 완성해주세요.
        /// 제한사항
        /// rows는 2 이상 100 이하인 자연수입니다.
        /// columns는 2 이상 100 이하인 자연수입니다.
        /// 처음에 행렬에는 가로 방향으로 숫자가 1부터 하나씩 증가하면서 적혀있습니다.
        /// 즉, 아무 회전도 하지 않았을 때, i 행 j 열에 있는 숫자는 ((i-1) x columns + j)입니다.
        /// queries의 행의 개수(회전의 개수)는 1 이상 10,000 이하입니다.
        /// queries의 각 행은 4개의 정수[x1, y1, x2, y2]입니다.
        /// x1 행 y1 열부터 x2 행 y2 열까지 영역의 테두리를 시계방향으로 회전한다는 뜻입니다.
        /// 1 ≤ x1<x2 ≤ rows, 1 ≤ y1<y2 ≤ columns입니다.
        /// 모든 회전은 순서대로 이루어집니다.
        /// 예를 들어, 두 번째 회전에 대한 답은 첫 번째 회전을 실행한 다음, 그 상태에서 두 번째 회전을 실행했을 때 이동한 숫자 중 최솟값을 구하면 됩니다.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static int[] solution(int rows, int columns, int[,] queries)
        {
            List<int> answer = new List<int>();

            int[][] matrix = CreateMetrix(rows, columns);

            List<cPoint> PointList = CreatePointList(queries);

            for (int i = 0; i < PointList.Count; i++)
            {
                cPoint TP = PointList[i];

                int MinValue = int.MaxValue;
                //차라리 모두 팝하고 하나씩 다시 넣자  그게 좋겠네 ㅡㅡ;

                int[][] Tempmatrix = (int[][])matrix.Clone();

                for (int x = TP._x1; x < TP._x2; x++)
                {
                    int temp = Tempmatrix[x][TP._y1];

                    matrix[x + 1][TP._y1] = temp;

                    if (MinValue > Tempmatrix[x][TP._y1])
                    {
                        MinValue = Tempmatrix[x][TP._y1];
                    }
                }

                for (int y = TP._y1; y < TP._y2; y++)
                {
                    matrix[TP._x2][y+1] = Tempmatrix[TP._x2][y];

                    if (MinValue > Tempmatrix[TP._x2][y])
                    {
                        MinValue = Tempmatrix[TP._x2][y];
                    }
                }

                for (int x = TP._x2; x > TP._x1; x--)
                {
                    matrix[x - 1][TP._y2] = Tempmatrix[x][TP._y2];

                    if (MinValue > Tempmatrix[x][TP._y2])
                    {
                        MinValue = Tempmatrix[x][TP._y2];
                    }
                }

                for (int y = TP._y2; y > TP._y1; y--)
                {
                    matrix[TP._x1][y - 1] = Tempmatrix[TP._x1][y];

                    if (MinValue > Tempmatrix[TP._x1][y])
                    {
                        MinValue = Tempmatrix[TP._x1][y];
                    }
                }

                answer.Add(MinValue);
            }


            return answer.ToArray();
        }

        public class cPoint
        {
            public int _x1 { get; set; }
            public int _y1 { get; set; }

            public int _x2 { get; set; }
            public int _y2 { get; set; }

            public cPoint(int Row1, int Column1, int Row2, int Column2)
            {
                _x1 = Column1-1;
                _y1 = Row1-1;

                _x2 = Column2-1;
                _y2 = Row2-1;
            }
        }


        public static List<cPoint> CreatePointList(int[,] queries)
        {
            List<cPoint> PointList = new List<cPoint>();

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                PointList.Add(new cPoint(queries[i, 0], queries[i, 1], queries[i, 2], queries[i, 3]));
            }

            return PointList;
        }

        public static int[][] CreateMetrix(int rows, int columns)
        {
            int[][] matrix = new int[rows][];
            int CellData = 1;
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[columns];

                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = CellData;
                    CellData++;
                }
            }

            return matrix;
        }
    }
}
