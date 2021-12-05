using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day5
    {

        public static void Day5Part1Calculator()
        {
            int[,] Day5Parts = new int[500,4];
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day5", "Day5").Select( x => {return x.ToString().Replace(" -> ", ","); }).ToList();
            var todaysInput = todaysInputData.Select(x => x.ToString().Split(",").Select(x => int.Parse(x)).ToArray()).ToList();
            List<VentSpot> ventSpots = new List<VentSpot>();
            Console.WriteLine("Hej hej");

            //int[] todaysInputInts = todaysInput.Select(x => int.Parse(x)).ToArray();  
            for (int i = 0; i < todaysInput.Count; i++)
            {
                int x1 = todaysInput[i][0];
                int y1 = todaysInput[i][1];
                int x2 = todaysInput[i][2];
                int y2 = todaysInput[i][3];

                int x12abs = Math.Abs(x1 - x2);
                int y12abs = Math.Abs(y1 - y2);

                if (x12abs == y12abs)
                {

                    for (int o  = 0; o <= x12abs; o++)
                    {
                        if (x1 < x2 && y1 < y2)
                        {
                           

                            if (ventSpots.Any(x => x.X == x1+o && x.y == y1+o))
                            {
                                ventSpots.Where(x => x.X == x1+o && x.y == y1+o).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = x1+o, y = y1+o, NrOfHits = 1 });
                            }
                        }
                        else if (x1 > x2 && y1 < y2)
                        {
                            if (ventSpots.Any(x => x.X == x1 - o && x.y == y1 + o))
                            {
                                ventSpots.Where(x => x.X == x1 - o && x.y == y1 + o).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = x1 - o, y = y1 + o, NrOfHits = 1 });
                            }
                        }
                        else if (x1 < x2 && y1 > y2)
                        {
                            if (ventSpots.Any(x => x.X == x1 + o && x.y == y1 - o))
                            {
                                ventSpots.Where(x => x.X == x1 + o && x.y == y1 - o).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = x1 + o, y = y1 - o, NrOfHits = 1 });
                            }
                        }
                        else if (x1 > x2 && y1 > y2)
                        {
                            if (ventSpots.Any(x => x.X == x1 - o && x.y == y1 - o))
                            {
                                ventSpots.Where(x => x.X == x1 - o && x.y == y1 - o).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = x1 - o, y = y1 - o, NrOfHits = 1 });
                            }
                        }
                    }
                    

                    Console.WriteLine($"{x1},{x2} -> {y1},{y2} BA = {x12abs}");


                }

                if (x1 == x2)
                {
                    if (y1 < y2)
                    {

                        int length = y2;
                        for (int p = y1; p <= length; p++)
                        {
                            if (ventSpots.Any(x => x.X == x1 && x.y == p))
                            {
                                ventSpots.Where(x => x.X == x1 && x.y == p).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = x1, y = p, NrOfHits = 1 });
                            }
                        }
                    }
                    else if (y1 > y2)
                    {
                        int length = y1;
                        for (int p = y2; p <= length; p++)
                        {
                            if (ventSpots.Any(spot => spot.X == x1 && spot.y == p))
                            {
                                ventSpots.Where(spot => spot.X == x1 && spot.y == p).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = x1, y = p, NrOfHits = 1 });
                            }
                        }
                    }

                }
                else if (y1 == y2)
                {
                    if (x1 < x2)
                    {

                        int length = x2;
                        for (int p = x1; p <= length; p++)
                        {
                            if (ventSpots.Any(x => x.X == p && x.y == y1))
                            {
                                ventSpots.Where(x => x.X == p && x.y == y1).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = p, y = y1, NrOfHits = 1 });
                            }
                        }
                    }
                    else if (x1 > x2)
                    {

                        int length = x1;
                        for (int p = x2; p <= length; p++)
                        {
                            if (ventSpots.Any(x => x.X == p && x.y == y1))
                            {
                                ventSpots.Where(x => x.X == p && x.y == y1).FirstOrDefault().NrOfHits++;

                            }
                            else
                            {
                                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = p, y = y1, NrOfHits = 1 });
                            }
                        }
                    }

                }



            }

            var hej = ventSpots.Where(x => x.NrOfHits > 1).ToList();

            Console.WriteLine($"hej {hej.Count}"); ;

        }
    }
}
