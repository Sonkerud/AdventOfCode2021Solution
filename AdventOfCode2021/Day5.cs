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
            var todaysInput = AdventOfCode2021.Inputreader.ReadTxtString("Day5", "Day5")
                    .Select(x => { return x.ToString().Replace(" -> ", ","); }).ToList()
                    .Select(x => x.ToString().Split(",")
                    .Select(x => int.Parse(x)).ToArray()).ToList();

            List<VentSpot> ventSpots = new List<VentSpot>();
            
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
                            ventSpots = HitVentSpots(ventSpots,x1+o,y1+o);
                        }
                        else if (x1 > x2 && y1 < y2)
                        {
                            ventSpots = HitVentSpots(ventSpots, x1 - o, y1 + o);   
                        }
                        else if (x1 < x2 && y1 > y2)
                        {
                            ventSpots = HitVentSpots(ventSpots, x1 + o, y1 - o); 
                        }
                        else if (x1 > x2 && y1 > y2)
                        {
                            ventSpots = HitVentSpots(ventSpots, x1 - o, y1 - o);
                        }
                    }
                }

                if (x1 == x2)
                {
                    if (y1 < y2)
                    {
                        int length = y2;
                        for (int p = y1; p <= length; p++)
                        {
                            HitVentSpots(ventSpots,x1,p);
                        }
                    }
                    else if (y1 > y2)
                    {
                        int length = y1;
                        for (int p = y2; p <= length; p++)
                        {
                            HitVentSpots(ventSpots, x1, p);
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
                            HitVentSpots(ventSpots, p, y1);
                        }
                    }
                    else if (x1 > x2)
                    {
                        int length = x1;
                        for (int p = x2; p <= length; p++)
                        {
                            HitVentSpots(ventSpots, p, y1);
                        }
                    }
                }
            }
            var nrOfVentsWithAtLeastTwoHits = ventSpots.Where(x => x.NrOfHits > 1).ToList();
            Console.WriteLine($"nrOfVentsWithAtLeastTwoHits: {nrOfVentsWithAtLeastTwoHits.Count}"); ;
        }
        public static List<VentSpot>HitVentSpots(List<VentSpot> ventSpots, int _x, int _y)
        {
            if (ventSpots.Any(x => x.X == _x && x.y == _y))
            {
                ventSpots.Where(x => x.X == _x && x.y == _y).FirstOrDefault().NrOfHits++;
            }
            else
            {
                ventSpots.Add(new VentSpot { VentNr = ventSpots.Count + 1, X = _x, y = _y, NrOfHits = 1 });
            }
            return ventSpots;
        }
    }
}
