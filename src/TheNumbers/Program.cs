using System.Diagnostics;

var random = new Random();

const int MaxNumber = 42;
int[] cursedNumbers = { 4, 8, 15, 16, 23, 42 };
long attempts = 0;

var stopwatch = Stopwatch.StartNew();

while (true)
{
    attempts++;

    if (DrawMatches())
    {
        break;
    }

    if (attempts % 1_000_000 == 0)
    {
        Console.Clear();
        Console.WriteLine($"{attempts:N0} tries... ({stopwatch.Elapsed:mm\\:ss})");
    }

}

stopwatch.Stop();

Console.Clear();
Console.WriteLine($"🎉 {string.Join(" ", cursedNumbers)}\n");
Console.WriteLine($"Tries: {attempts:N0} - Time: {stopwatch.Elapsed:mm\\:ss\\.fff}");
Console.WriteLine($"Speed: {attempts / stopwatch.Elapsed.TotalSeconds:N0} tries/sec\n");

bool DrawMatches()
{
    for (int i = 0; i < cursedNumbers.Length; i++)
    {
        int number = random.Next(1, MaxNumber + 1);

        // No Repeat: keep drawing until the number isn't one of the earlier matches
        while (Array.IndexOf(cursedNumbers, number, 0, i) >= 0)
        {
            number = random.Next(1, MaxNumber + 1);
        }

        // Wrong number for this position. so this draw can't be the sequence.
        if (number != cursedNumbers[i])
        {
            return false;
        }
    }

    return true;
}