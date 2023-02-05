using System;

int fieldSize = int.Parse(Console.ReadLine());

char[,] battlefield = new char[fieldSize,fieldSize];

int cruisersLeft = 3;
int submarineHealth = 3;

int submarineRow = 0;
int submarineCol = 0;


for (int row = 0; row < fieldSize; row++)
{
    char[] colValues = Console.ReadLine().ToCharArray();
    for (int col = 0; col < fieldSize; col++)
    {
        if (colValues[col] == 'S')
        {
            submarineRow = row;
            submarineCol = col;
        }
        battlefield[row,col] = colValues[col];
    }
}

while (cruisersLeft > 0 && submarineHealth > 0)
{
    string direction = Console.ReadLine();

    battlefield[submarineRow, submarineCol] = '-';

    switch (direction)
    {
        case "up":
        {
            submarineRow--;
            break;
        }
        case "down":
        {
            submarineRow++;
            break;
        }
        case "left":
        {
            submarineCol--;
            break;
        }
        case "right":
        {
            submarineCol++;
            break;
        }
    }

    if (battlefield[submarineRow, submarineCol] == '*')
    {
        submarineHealth--;
        battlefield[submarineRow, submarineCol] = 'S';
    }
    else if (battlefield[submarineRow, submarineCol] == 'C')
    {
        cruisersLeft--;
        battlefield[submarineRow, submarineCol] = 'S';
    }
}

if (cruisersLeft == 0)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}

if (submarineHealth == 0)
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
}

for (int row = 0; row < fieldSize; row++)
{
    for (int col = 0; col < fieldSize; col++)
    {
        Console.Write(battlefield[row, col]);
    }
    Console.WriteLine();
}