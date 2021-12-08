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
            var todaysDataInputPart2 = Inputreader.ReadTxtString("Day8", "Day8").ToList().Select(x => x.Split(" | ").ToArray()).ToList();
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
                string fiveLetters = "";
                string sevenLetters = "";
                string sixLetters = "";
                string eightLetters = "";
                
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

                            case 5: fiveLetters += ";" + UniqueSignalPatterns[y];
                            break;

                            case 6: sixLetters += ";" + UniqueSignalPatterns[y];
                            break;

                            case 7:  sevenLetters = UniqueSignalPatterns[y];
                            break;
                        }
                }

                signalPatterns[0] = threeLetters.Except(twoLetters).ToArray()[0].ToString();

                foreach (var item in sixLetters.Substring(1).Split(';'))
                {
                    if (item.Except(fourLetters).Count() == 2)
                    {
                        var twoRemainingLetters = item.Except(fourLetters).ToList().Select(x => x.ToString()).ToList();
                        foreach (var letter in twoRemainingLetters)
                        {
                            if (letter != signalPatterns[0])
                            {
                                signalPatterns[6] = letter;
                            }
                        }
                    }
                }
                //nr5
                foreach (var item in fiveLetters.Substring(1).Split(';'))
                {
                    if (item.Except(fourLetters).Count() == 3)
                    {
                        var threeRemainingLetters = item.Except(fourLetters).ToList().Select(x => x.ToString()).ToList();
                        foreach (var letter in threeRemainingLetters)
                        {
                            if (letter != signalPatterns[0] && letter != signalPatterns[6])
                            {
                                signalPatterns[4] = letter;
                            }
                        }
                    }
                }
                
                //nr4
                fiveLetters = fiveLetters.Replace(";", "");
                var listOfFiveLetters = fiveLetters.ToArray().Select(x => x.ToString()).ToList().GroupBy(x => x);
                foreach (var item in listOfFiveLetters)
                {
                    if (item.Count() == 3)
                    {
                        if (signalPatterns.Any(x => x == item.Key))
                        { 
                         
                        }
                        else 
                        {
                            signalPatterns[3] = item.Key;
                        }
                    }
                    
                }
                signalPatterns[1] = fourLetters.Except(twoLetters).Select(x => x.ToString()).Where(x => x != signalPatterns[3]).ToArray()[0];

                string signalPatternString = "";
                for (int k = 0; k < signalPatterns.Length; k++)
                {
                    signalPatternString += signalPatterns[k];
                }

                foreach (var item in sixLetters.Substring(1).Split(';'))
                {
                    if (item.Except(fourLetters).Count() == 3)
                    {
                        
                        if (item.Except(signalPatternString).Select(x=>x.ToString()).ToList().Count() == 1)
                        {
                            signalPatterns[5] = item.Except(signalPatternString).Select(x => x.ToString()).ToArray()[0];
                           
                        }

                    }
                }
                signalPatternString += signalPatterns[5];
                signalPatterns[2] = sevenLetters.Except(signalPatternString).Select(x => x.ToString()).ToArray()[0];

                var outputValuesList = todaysDataInputPart2[i][1].ToString().Split(" ");
                
                    string outputValuesResultString = "";

                    foreach (var outputvalue in outputValuesList)
                    {
                        string[] outputvaluesCorrespondingNr = new string[7];
                        for (int k = 0; k < outputvalue.Length; k++)
                        {
                            for (int j = 0; j < signalPatterns.Length; j++)
                            {
                                if (outputvalue[k].ToString() == signalPatterns[j])
                                {
                                    outputvaluesCorrespondingNr[j] = "1";
                                }
                            }
                        }

                        var outputvaluesCorrespondingBitNr = outputvaluesCorrespondingNr.Select(x =>
                        {
                            return x != "1" ? x = "0" : x;
                        }).ToArray();

                        string bitNumberString = outputvaluesCorrespondingBitNr.Aggregate((total, part) => total + part);

                        int bitNumber = int.Parse(bitNumberString);
                        int outputValueResult = 0;
                        for (int n = 0; n < numbers.GetLength(0); n++)
                        {
                            if (numbers[n, 1] == bitNumber)
                            {
                                outputValueResult = numbers[n, 0];
                            }
                        }
                        outputValuesResultString += outputValueResult.ToString();
                    }
                    lastResult += int.Parse(outputValuesResultString);
            } 
            Console.WriteLine(lastResult);
        }
    }
}
