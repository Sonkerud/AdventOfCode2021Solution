using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day11
    {
        public static void Day11Part1Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day11", "Day11");
            int[,] todaysInputDataArray = new int[todaysInputData.Count, todaysInputData[0].Length];
            for (int y = 0; y < todaysInputData.Count; y++)
            {
                for (int x = 0; x < todaysInputData[y].Length; x++)
                {
                    todaysInputDataArray[y, x] = int.Parse(todaysInputData[y][x].ToString());
                }
            }
            
            long nrOfFlashes = 0;
            for (int df = 0; df < 100; df++)
            {
                List<int[]> tens = new List<int[]>();

                for (int y = 0; y < todaysInputData.Count; y++)
                {
                    for (int x = 0; x < todaysInputData[y].Length; x++)
                    {
                        if (todaysInputDataArray[y, x] != 10)
                        {
                            if (todaysInputDataArray[y, x] == 9)
                            {
                                tens.Add(new int[] { y, x });
                            }
                            todaysInputDataArray[y, x]++;
                        }
                        else
                        {
                            Console.WriteLine("10 should not exist");
                        }
                    }
                }
                for (int i = 0; i < tens.Count(); i++)
                {
                    int thisNineY = tens[i][0];
                    int thisNineX = tens[i][1];

                    int startX = -1;
                    int endX = 1;
                    int startY = -1;
                    int endY = 1;

                    if (thisNineX == 0)
                    {
                        startX = 0;
                    }
                    if (thisNineX == todaysInputData[0].Length - 1)
                    {
                        endX = 0;
                    }
                    if (thisNineY == 0)
                    {
                        startY = 0;
                    }
                    if (thisNineY == todaysInputData[0].Length - 1)
                    {
                        endY = 0;
                    }

                    for (int checkY = startY; checkY <= endY; checkY++)
                    {
                        for (int checkX = startX; checkX <= endX; checkX++)
                        {
                            if (todaysInputDataArray[thisNineY + checkY, thisNineX + checkX] < 10)
                            {
                                todaysInputDataArray[thisNineY + checkY, thisNineX + checkX]++;

                                if (todaysInputDataArray[thisNineY + checkY, thisNineX + checkX] == 10)
                                {
                                    tens.Add(new int[] { thisNineY + checkY, thisNineX + checkX });
                                }
                            }
                        }
                    }
                }

                for (int y = 0; y < todaysInputData.Count; y++)
                {
                    for (int x = 0; x < todaysInputData[y].Length; x++)
                    {
                        if (todaysInputDataArray[y, x] == 10)
                        {                   
                            todaysInputDataArray[y, x] = 0;
                        }
                    }
                }
                nrOfFlashes += tens.Count();
            }
            Console.WriteLine(nrOfFlashes);
        }


        public static void DrawMap(int[,] todaysInputDataArray)
        {
            for (int y = 0; y < todaysInputDataArray.GetLength(0); y++)
            {
                for (int x = 0; x < todaysInputDataArray.GetLength(1); x++)
                {
                    if (todaysInputDataArray[y, x] == 9)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(x * 2, y);
                    Console.Write(" " + todaysInputDataArray[y, x]);
                }
            }
        }

    }
}






