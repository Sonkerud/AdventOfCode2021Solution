// See https://aka.ms/new-console-template for more information

AdventOfCode2021.Day3.Day3Part2Calculator();

/*var file = System.IO.File.OpenText("C:\\Users\\sonerale\\OneDrive - TietoEVRY\\Evry\\AdventOfCode2021\\Day3\\Day3.txt");
var input = file.ReadToEnd()
    .Split("\r\n")
    .Select(l => l.Select(c => uint.Parse(c.ToString())).ToList())
    .ToList();

//--- p1 ---
var countZeroOnes = input.Aggregate(
    Enumerable.Repeat<(int, int)>((0, 0), input.First().Count()).ToArray(),
    (acc, line) =>
    {
        for (int i = 0; i < line.Count(); i++)
        {
            acc[i] = line[i] switch
            {
                1 => (acc[i].Item1, ++acc[i].Item2),
                0 => (++acc[i].Item1, acc[i].Item2),
                _ => acc[i]
            };
        }
        return acc;
    });

var gammaBinary = countZeroOnes.Select(v => v.Item1 > v.Item2 ? 0 : 1);
var epsilonBinary = countZeroOnes.Select(v => v.Item1 > v.Item2 ? 1 : 0);

var gamma = Convert.ToInt32(string.Join("", gammaBinary), 2);
var epsilon = Convert.ToInt32(string.Join("", epsilonBinary), 2);

Console.WriteLine($"P1: {gamma * epsilon}");

//--- p2 ---
Func<List<List<uint>>, Func<uint, (int zero, int one), bool>, int> extractValue = (searchList, filter) => {
    var result = 0;
    var currentBit = 0;
    while (true)
    {
        var currentBitCount = searchList.Aggregate(
            (zero: 0, one: 0),
            (acc, line) => line[currentBit] switch
            {
                1 => (acc.zero, ++acc.one),
                0 => (++acc.zero, acc.one),
                _ => acc
            });
        searchList = searchList.Where(line => filter(line[currentBit], currentBitCount)).ToList();
        if (searchList.Count() == 1)
        {
            result = Convert.ToInt32(string.Join("", searchList.First()), 2);
            break;
        }
        else
        {
            currentBit++;
        }
    }
    return result;
};

var o2Value = extractValue(input, (currentBitValue, currentBitCount) => currentBitValue == (currentBitCount.one >= currentBitCount.zero ? 1 : 0));
var co2Value = extractValue(input, (currentBitValue, currentBitCount) => currentBitValue == (currentBitCount.one < currentBitCount.zero ? 1 : 0));

Console.WriteLine($"P2: o2Value {o2Value} co2Value {co2Value} = {o2Value * co2Value}");
*/