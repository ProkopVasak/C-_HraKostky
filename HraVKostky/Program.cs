using HraVKostky;

Dice[] kostky = new Dice[5];
Dice[] kostky2 = new Dice[5];

for (int i = 0; i < 5; i++)
{
    kostky[i] = new Dice();
    kostky2[i] = new Dice();
}

Game hra = new Game(kostky, kostky2);
int[] prazdno = {};
int cisloKola = 0;

while (!hra.End)
{

    if ((++cisloKola % 4) % 3 == 0 && cisloKola > 0)
    {
        if (cisloKola % 2 == 0)
        {
            Console.Write("Hráč č.2: ");
        }
        else
        {
            Console.Write("Hráč č.1: ");
        }
        Console.Write("Zadejte čísla kostek k zamknutí (nehodí se s nimi): ");
        int vstup;

        bool chyba = false;
        int[] p;

        do
        {
            chyba = false;
            while (!Int32.TryParse(Console.ReadLine(), out vstup))
            {
                Console.WriteLine("Zadejte vstup správně!");
            }

            p = GetIntArray(vstup);

            if (p.Length > 5 || vstup < 0)
            {
                chyba = true;
            }

            for (int j = 0; j < p.Length; j++)
            {
                if (p[j] > 5 || p[j] < 0)
                {
                    chyba = true;
                }
            }

            if(chyba) Console.WriteLine("Zadejte vstup správně!");

        } while (chyba);



        Console.WriteLine(hra.Next(p));
    }
    else
    {
        Console.WriteLine(hra.Next(prazdno));
    }

    Console.ReadLine();

}

Console.WriteLine(hra.Vyhodnoceni());





int[] GetIntArray(int num)
{
    List<int> listOfInts = new List<int>();
    while (num > 0)
    {
        listOfInts.Add(num % 10);
        num = num / 10;
    }
    listOfInts.Reverse();
    return listOfInts.ToArray();
}

void RemoveIndex(int[] pole, int i)
{
    if (pole.Length > 0)
    {
        int[] tempPole = new int[pole.Length - 1];
        for (int e = 0; e < pole.Length; e++)
        {

            if (e < i)
            {
                tempPole[e] = pole[e];
            }
            else if (e > i)
            {

                tempPole[e - 1] = pole[e];
            }
            else if (e == i)
            {

            }

        }
        pole = tempPole;
    }

}