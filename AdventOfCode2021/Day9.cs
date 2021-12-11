using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day9
    {
        public static void Day9Part1Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day9", "Day9");
            int[,] todaysInputDataArray = new int[todaysInputData.Count, todaysInputData[0].Length];
            List<int> depth = new List<int>();
            List<int[]> depthArray = new List<int[]>();

            for (int y = 0; y < todaysInputData.Count; y++)
            {
                for (int x = 0; x < todaysInputData[y].Length; x++)
                {
                    todaysInputDataArray[y, x] = int.Parse(todaysInputData[y][x].ToString());
                }
            }


            for (int y = 0; y < todaysInputData.Count; y++)
            {
                for (int x = 0; x < todaysInputData[y].Length; x++)
                {
                    if (y == 0 && x == 0)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                    else if (y == 0 && x == todaysInputData[y].Length - 1)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                    else if (y == 0)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }

                    else if (y == todaysInputData.Count - 1 && x == todaysInputData[y].Length - 1)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                    else if (y == todaysInputData.Count - 1 && x == 0)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                    else if (y == todaysInputData.Count - 1)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                    else if (x == todaysInputData[y].Length - 1)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }

                    else if (x == 0)
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                    else
                    {
                        if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                        {
                            depth.Add(todaysInputDataArray[y, x] + 1);
                            depthArray.Add(new int[] { y, x });
                        }
                    }
                }
            }

            List<int> resultlist = new List<int>();
            for (int i = 0; i < depthArray.Count; i++)
            {
               int suma = 0;
               suma =  Part2_1(todaysInputData, todaysInputDataArray, depth, depthArray, depthArray[i][1], depthArray[i][0]);
               resultlist.Add(suma);
            }
            var newResultlist = resultlist.OrderByDescending(x => x).ToArray();
            Console.WriteLine(newResultlist[0] * newResultlist[1] * newResultlist[2]);

        }

        public static int Part2_1(List<string> todaysInputData, int[,] todaysInputDataArray, List<int> depth, List<int[]> depthArray, int hX, int hY)
        {

            List<int[]> newdepthArray = new List<int[]>();
            newdepthArray.Add(new int[] { hY, hX });
            int countOfBasins = 0;
            int depthX = 0;
            int depthY = 0;

            for (int p = 0; p < newdepthArray.Count; p++)
            {
                depthX = newdepthArray[p][1];
                depthY = newdepthArray[p][0];

                for (int i = 1; i < todaysInputDataArray.GetLength(0) - depthY; i++)
            {
                if (todaysInputDataArray[depthY + i, depthX] != 9)
                {
                    var testDepth = new int[] { depthY + i, depthX };

                    if (!newdepthArray.Any(intarr => intarr[0] == testDepth[0] && intarr[1] == testDepth[1]))
                    {
                        newdepthArray.Add(new int[] { depthY + i, depthX });
                    }
                }
                else 
                {
                    break;
                }

            }
            for (int i = depthY; i > 0; i--)
            {
                if (todaysInputDataArray[i -1 , depthX] != 9)
                {
                    var testDepth = new int[] { i - 1, depthX };

                    if (!newdepthArray.Any(intarr => intarr[0] == testDepth[0] && intarr[1] == testDepth[1]))
                    {
                        newdepthArray.Add(new int[] { i - 1, depthX });
                    }                  
                }
                else
                {
                    break;
                }
            }

            countOfBasins += newdepthArray.Count;

            
                int x = newdepthArray[p][1];
                int y = newdepthArray[p][0];

                for (int k =1; k < todaysInputDataArray.GetLength(1) - x; k++)
                {
                    if (todaysInputDataArray[y, x + k] != 9)
                    {
                        countOfBasins++;
                        var testDepth = new int[] { y, x + k };

                        if (!newdepthArray.Any(intarr => intarr[0] == testDepth[0] && intarr[1] == testDepth[1]))
                        {
                            newdepthArray.Add(new int[] { y, x + k });
                        }

                    }
                    else
                    {
                        break;
                    }

                }
                for (int k = x -1; k >= 0; k--)
                {
                    if (todaysInputDataArray[y, k] != 9)
                    {
                        var testDepth = new int[] { y, k };
                        if (!newdepthArray.Any(intarr => intarr[0] == testDepth[0] && intarr[1] == testDepth[1]))
                        {
                            newdepthArray.Add(new int[] { y, k });
                        }
                    }
                    else
                    {
                        break;
                    }

                }
               

            }
            return newdepthArray.Count;

            

        }
            

            public static void Part2(List<string> todaysInputData, int[,] todaysInputDataArray, List<int> depth, List<int[]> depthArray, int depthX, int depthY)
             {
            List<int[]> newdepthArray = new List<int[]>();
            newdepthArray.Add(new int[] {depthX,depthY});

            while (true)
            {
                for (int i = 0; i < newdepthArray.Count(); i++)
                {
                    int y = newdepthArray[i][0];
                    int x = newdepthArray[i][1];

                

                if (y == 0 && x == 0)
                {
                    if (todaysInputDataArray[y + 1, x] == todaysInputDataArray[y, x] - 1)
                    {
                        newdepthArray.Add(new int[] { y + 1, x });
                    }
                    if (todaysInputDataArray[y, x + 1] == todaysInputDataArray[y, x] - 1)
                    {
                        newdepthArray.Add(new int[] { y, x + 1 });
                    }
                }
                else if (y == 0 && x == todaysInputData[y].Length - 1)
                {
                    if (todaysInputDataArray[y + 1, x] == todaysInputDataArray[y, x] - 1 && todaysInputDataArray[y, x - 1] == todaysInputDataArray[y, x] -1)
                    {
                            newdepthArray.Add(new int[] { y + 1, x });
                        }
                }
                else if (y == 0)
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }

                else if (y == todaysInputData.Count - 1 && x == todaysInputData[y].Length - 1)
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }
                else if (y == todaysInputData.Count - 1 && x == 0)
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }
                else if (y == todaysInputData.Count - 1)
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }
                else if (x == todaysInputData[y].Length - 1)
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }

                else if (x == 0)
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }
                else
                {
                    if (todaysInputDataArray[y, x] < todaysInputDataArray[y + 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x + 1] && todaysInputDataArray[y, x] < todaysInputDataArray[y - 1, x] && todaysInputDataArray[y, x] < todaysInputDataArray[y, x - 1])
                    {
                        depth.Add(todaysInputDataArray[y, x] + 1);
                    }
                }
                }
            }
        }
    }
}
