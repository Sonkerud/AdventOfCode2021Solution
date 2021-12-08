using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day8
    {
        public static void Day8Part1Calculator()
        {
            var todaysDataInputPart1 = Inputreader.ReadTxtString("Day8", "Day8").ToList()
                .Select(x => x.Split(" | ").ToList())
                .Select(x => x[1]).Select(x => x.Split(" ").ToArray()).SelectMany(x => x).ToList()
                .Where(x => x.Length > 0 && x.Length <= 4 || x.Length == 7).ToList();
            Console.WriteLine(todaysDataInputPart1.Count());
        }



        public static void Day8Part2Calculator()
        {

            var todaysDataInputPart2 = Inputreader.ReadTxtString("Day8", "Day8test").ToList().Select(x => x.Split(" | ").ToArray()).ToList();
            int[,] numbers =
            {
            {0, 1110111}, // abcefg
            {1, 0010010}, // cf
            {2, 1011101}, // acdeg
            {3, 1011011}, // acdfg
            {4, 0111010}, // bcdf
            {5, 1101011}, // abdfg
            {6, 1101111}, // abdefg 
            {7, 1010010}, // acf 
            {8, 1111111}, // abcdefg
            {9, 1111011}  // abcdfg
            };

            // Med 5 bokstäver: 
            // acdeg
            // acdfg
            // abdfg
            int lastResult = 0;
            for (int i = 0; i < todaysDataInputPart2.Count(); i++)
            {
                string[] signalPatterns = new string[7];
                var UniqueSignalPatterns = todaysDataInputPart2[i][0].ToString().Split(" ");
                //foreach (var arrayOfLetters in todaysDataInputPart2)
                //{
                string twoLetters = "";
                string threeLetters = "";
                string fourLetters = "";
                string sevenLetters = "";

                for (int y = 0; y < UniqueSignalPatterns.Count(); y++)
                {
                    

                    switch(UniqueSignalPatterns[y].Length)
                        {
                            case 2:twoLetters = UniqueSignalPatterns[y];
                            break; 
                            
                            case 3: threeLetters = UniqueSignalPatterns[y];
                            break;

                            case 4: fourLetters = UniqueSignalPatterns[y];
                            break;

                            case 7:  sevenLetters = UniqueSignalPatterns[y];
                            break;
                        }


                    List<string> remainingLetters = new List<string>();
                }
                signalPatterns[0] = threeLetters.Except(twoLetters).ToArray()[0].ToString();
                signalPatterns[3] = sevenLetters.Except(fourLetters).ToArray()[0].ToString();
                Console.WriteLine(signalPatterns[0]);
               


                //foreach (var signalPattern in todaysDataInputPart2[i][0].ToString().Split(" "))
                //{

                //    if (signalPattern.Length == 2)
                //    {
                //        signalPatterns[2] = signalPattern.Substring(0, 1);
                //        signalPatterns[5] = signalPattern.Substring(1, 1);
                //    }
                //    else if (signalPattern.Length == 3)
                //    {
                //        signalPatterns[0] = signalPattern.Substring(0, 1);
                //    }
                //    else if (signalPattern.Length == 4)
                //    {
                //        signalPatterns[1] = signalPattern.Substring(0, 1);
                //        signalPatterns[3] = signalPattern.Substring(2, 1);
                //    }
                //}
                //}


                //    //foreach (var arrayOfLetters in todaysDataInputPart2)
                //    //{
                //    //    foreach (var signalPattern in arrayOfLetters[0].ToString().Split(" "))
                //    //    {

                //    //        if (signalPattern.Length == 2)
                //    //        {
                //    //            signalPatterns[2] = signalPattern.Substring(0, 1);
                //    //            signalPatterns[5] = signalPattern.Substring(1, 1);
                //    //        }
                //    //        else if (signalPattern.Length == 3)
                //    //        {
                //    //            signalPatterns[0] = signalPattern.Substring(0, 1);
                //    //        }
                //    //        else if (signalPattern.Length == 4)
                //    //        {
                //    //            signalPatterns[1] = signalPattern.Substring(0, 1);
                //    //            signalPatterns[3] = signalPattern.Substring(2, 1);
                //    //        }
                //    //    }
                //    //}

                //    List<string> remainingLetters = new List<string>();
                //    //foreach (var arrayOfLetters in todaysDataInputPart2)
                //    //{
                //        foreach (var signalPattern in todaysDataInputPart2[i][0].ToString().Split(" "))
                //        {
                //            if (signalPattern.Length == 5)
                //            {
                //                for (int p = 0; p < 5; p++)
                //                {
                //                    if (!signalPatterns.Any(x => x == signalPattern.Substring(p,1)))
                //                    {
                //                        remainingLetters.Add(signalPattern.Substring(p, 1));
                //                    }  
                //                }
                //            }
                //        }
                //    //}

                //    var remainingLetters1= remainingLetters.ToList();

                //    for (int l = 1; l < remainingLetters.Count(); l++)
                //    {
                //        if (remainingLetters[l] == remainingLetters[0])
                //        {
                //            signalPatterns[6] = remainingLetters1[0];

                //        }
                //        else
                //        {
                //            signalPatterns[4] = remainingLetters1[l];
                //        }
                //    }
                //    Console.WriteLine(remainingLetters[0]);


                //    foreach (var arrayOfLetters in todaysDataInputPart2)
                //    {
                //        string outputValuesResultString = "";

                //        foreach (var outputvalue in arrayOfLetters[1].ToString().Split(" "))
                //        {
                //            string[] outputvaluesCorrespondingNr = new string[7];
                //            for (int k = 0; k < outputvalue.Length; k++)
                //            {
                //                for (int j = 0; j < signalPatterns.Length; j++)
                //                {
                //                    if (outputvalue[k].ToString() == signalPatterns[j]) 
                //                    {
                //                        outputvaluesCorrespondingNr[j] = "1";
                //                    }
                //                }  
                //            }

                //            var outputvaluesCorrespondingBitNr = outputvaluesCorrespondingNr.Select(x =>
                //            {
                //                return x != "1" ? x = "0" : x;
                //            }).ToArray();


                //            string bitNumberString = outputvaluesCorrespondingBitNr.Aggregate((total, part) => total +  part);

                //            int bitNumber = int.Parse(bitNumberString);
                //            int outputValueResult = 0;
                //            for (int n = 0; n < numbers.GetLength(0); n++)
                //            {
                //                if(numbers[n,1] == bitNumber)
                //                {
                //                    outputValueResult = numbers[n, 0];
                //                }

                //            }

                //            outputValuesResultString += outputValueResult.ToString();



                //        }
                //        lastResult += int.Parse(outputValuesResultString);


                //    }


                //}
                Console.WriteLine(lastResult);

            }
        }
    }
}
