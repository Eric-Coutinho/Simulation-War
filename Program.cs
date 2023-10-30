using System;

Random rand = new Random();
int N = 1_000;

int armyatt = 1000;
int armydef = 500;

int winAtt = 0;
int winDef = 0;

int roll()
    => rand.Next(6) + 1;

int[] rollatt = new int[3];
int[] rolldef = new int[3];

float percentAtt = (float)winAtt / N;
float percentDef = (float)winDef / N;

Console.WriteLine("% vitória atacantes: " + percentAtt);
Console.WriteLine("% vitória defensores: " + percentDef);

game();

void game()
{
    for (int i = 0; i < N; i++)
    {
        while (armyatt > 1 || armydef != 0)
        {
            round();
        }
        if (armyatt > 1)
        {
            winAtt++;
            Console.WriteLine("win atack" + winAtt);
        }
        else if (armydef > 0)
        {
            winDef++;
            Console.WriteLine("win def" + winDef);
        }
    }
}

void round()
{
    for (int i = 0; i < 3; i++)
    {
        rollatt[i] = roll();
        rolldef[i] = roll();
    }

    Array.Sort(rollatt);
    Array.Sort(rolldef);

    for (int i = 0; i < 3; i++)
    {
        if (rollatt[2 - i] > rolldef[2 - i])
        {
            armydef--;
        }
        else
        {
            armyatt--;
        }
    }
}

