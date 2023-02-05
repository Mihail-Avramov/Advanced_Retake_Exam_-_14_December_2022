using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> dailyFood = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

Queue<int> dailyStamina = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

Queue<string> conqueredPeaks = new Queue<string>();

Dictionary<string, int> peaksNamesAndDifficulties = new Dictionary<string, int>()
{
    {"Vihren" , 80},
    {"Kutelo", 90},
    {"Banski Suhodol", 100},
    {"Polezhan", 60},
    {"Kamenitza", 70}
};

Queue<string> peaksNames = new Queue<string>(peaksNamesAndDifficulties.Keys);

while (dailyFood.Any() && dailyStamina.Any() && peaksNames.Any())
{
    string peakToClimb = peaksNames.Peek();
    if (dailyFood.Peek() + dailyStamina.Peek() >= peaksNamesAndDifficulties[peakToClimb])
    {
        dailyFood.Pop();
        dailyStamina.Dequeue();
        peaksNames.Dequeue();
        conqueredPeaks.Enqueue(peakToClimb);
    }
    else
    {
        dailyFood.Pop();
        dailyStamina.Dequeue();
    }
}

if (peaksNames.Any())
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
else
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}

if (conqueredPeaks.Any())
{
    Console.WriteLine("Conquered peaks:");
    Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
}