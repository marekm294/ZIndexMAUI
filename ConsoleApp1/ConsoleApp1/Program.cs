var input = Console.ReadLine();

if (!int.TryParse(input, out var lineCount))
{
    throw new ArgumentException();
}

var inputLines = new string[lineCount];
for (int i = 0; i < lineCount; i++)
{
    var line = Console.ReadLine();
    if (line is not null)
    {
        inputLines[i] = line.Trim();
    }
}

for (int i = 0; i < lineCount; i++)
{
    var lineWords = inputLines[i].Split(' ');
    lineWords = lineWords.Reverse().ToArray();
    inputLines[i] = string.Join(' ', lineWords);

    Console.WriteLine(inputLines[i]);
}

