public class Program
{
    public static void Main()
    {
        int[,] playfield = new int[9, 9];

        //Sudoku Werte setzen

        playfield[0, 0] = 3;
        playfield[0, 3] = 6;
        playfield[0, 7] = 9;
        playfield[1, 1] = 4;
        playfield[1, 4] = 2;
        playfield[1, 7] = 5;
        playfield[2, 1] = 8;
        playfield[2, 4] = 7;
        playfield[2, 6] = 1;
        playfield[2, 7] = 6;

        playfield[3, 0] = 9;
        playfield[3, 3] = 3;
        playfield[3, 5] = 4;
        playfield[3, 6] = 7;
        playfield[4, 1] = 5;
        playfield[4, 4] = 8;
        playfield[4, 7] = 2;
        playfield[5, 2] = 1;
        playfield[5, 3] = 9;
        playfield[5, 8] = 6;

        playfield[6, 1] = 2;
        playfield[6, 2] = 7;
        playfield[6, 4] = 3;
        playfield[6, 7] = 4;
        playfield[7, 1] = 9;
        playfield[7, 4] = 6;
        playfield[7, 7] = 1;
        playfield[8, 1] = 3;
        playfield[8, 5] = 5;
        playfield[8, 8] = 8;

        while (IsCompleted(playfield) == false)
        {
            DisplaySudoku(playfield);
            EnterValue(playfield);
        }

        //var m = 4 + 9;
        //var p = "a" + "b" + "c";
        //var u = "a" + 7 + "b" + "c";
        //var h = "p" + 7 + 4 + 9;

        DisplaySudoku(playfield);

        EnterValue(playfield);

        IsCompleted(playfield);
    }

    public static bool IsCompleted(int[,] playfield)
    {
        for (int sReihe = 0; sReihe <= 8; sReihe++)
        {
            for (int sSpalte = 0; sSpalte <= 8; sSpalte++)
            {
                if (playfield[sReihe, sSpalte] == 0)
                    return false;
            }
        }
        return true;
    }

    public static void DisplaySudoku(int[,] playfield)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sudokuuu!");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("-------------------------");

        for (int rowIndex = 0; rowIndex <= 8; rowIndex++)
        {
            if (rowIndex == 3 || rowIndex == 6)
            {
                Console.Write("\n-------------------------");
            }
            Console.WriteLine();

            Console.Write("| " + EraseZero(playfield[rowIndex, 0]) + " " + EraseZero(playfield[rowIndex, 1]) + " " + EraseZero(playfield[rowIndex, 2]) + " ");
            Console.Write("| " + EraseZero(playfield[rowIndex, 3]) + " " + EraseZero(playfield[rowIndex, 4]) + " " + EraseZero(playfield[rowIndex, 5]) + " ");
            Console.Write("| " + EraseZero(playfield[rowIndex, 6]) + " " + EraseZero(playfield[rowIndex, 7]) + " " + EraseZero(playfield[rowIndex, 8]) + " |");
        }
        Console.WriteLine();
        Console.WriteLine("-------------------------");
    }

    public static string EraseZero(int zahl)
    {
        if (zahl == 0)
        {
            return " ";
        }

        else
        {
            return zahl.ToString();
        }
    }

    public static bool EnterValue(int[,] playfield)
    {
        Console.WriteLine("Gebe eine Zahl ein");
       
        int wert = Convert.ToInt32(Console.ReadLine());
        if (wert == 0 || wert > 9)
        {
            Console.WriteLine("Die eingegebene Zahl muss zwischen 1 und 9 sein");
            return false;
        }

        Console.WriteLine("In welcher Reihe?");
        int reiheEingabe = Convert.ToInt32(Console.ReadLine());
        if (reiheEingabe == 0 || reiheEingabe > 9)
        {
            Console.WriteLine("Die eingegebene Zahl muss zwischen 1 und 9 sein");
            return false;
        }
        reiheEingabe = reiheEingabe - 1;

        Console.WriteLine("In welcher Spalte?");
        int spalteEingabe = Convert.ToInt32(Console.ReadLine());
        if (spalteEingabe == 0 || spalteEingabe > 9)
        {
            Console.WriteLine("Die eingegebene Zahl muss zwischen 1 und 9 sein");
            return false;
        }
        spalteEingabe = spalteEingabe - 1;

        // Prüfe, ob der eingegebe Wert in der eingegeben Reihe bereits vorkommt

        for(int spalte = 0; spalte <= 8; spalte++)
        {
            if (playfield[reiheEingabe, spalte] == wert)
            {
                Console.WriteLine("Die eingegebene Zahl kommt bereits auf der selben Reihe vor.");
                return false;
            }
        }

        // Prüfe, ob der eingegebe Wert in der eingegeben Spalte bereits vorkommt

        for (int reihe = 0; reihe <= 8; reihe++)
        {
            if (playfield[reihe, spalteEingabe] == wert)
            {
                Console.WriteLine("Die eingegebene Zahl kommt bereits auf der selben Spalte vor.");
                return false;
            }
        }

        // Prüfe, ob der eingegebene Wert im 3x3 Block bereits vorkommt

        int startReihe = 0;

        if (reiheEingabe == 0 || reiheEingabe == 1 || reiheEingabe == 2)
        {
            startReihe = 0;
        }

        if (reiheEingabe == 3 || reiheEingabe == 4 || reiheEingabe == 5)
        {
            startReihe = 3;
        }

        if (reiheEingabe == 6 || reiheEingabe == 7 || reiheEingabe == 8)
        {
            startReihe = 6;
        }

        int endReihe = startReihe + 2;

        int startSpalte = 0;

        if (spalteEingabe == 0 || spalteEingabe == 1 || spalteEingabe == 2)
        {
            startSpalte = 0;
        }

        if (spalteEingabe == 3 || spalteEingabe == 4 || spalteEingabe == 5)
        {
            startSpalte = 3;
        }

        if (spalteEingabe == 6 || spalteEingabe == 7 || spalteEingabe == 8)
        {
            startSpalte = 6;
        }

        int endSpalte = startSpalte + 2;

        for (int sReihe = startReihe; sReihe <= endReihe; sReihe++)
        {
            for (int sSpalte = startSpalte; sSpalte <= endSpalte; sSpalte++)
            {
                if (playfield[sReihe, sSpalte] == wert)
                {
                    Console.WriteLine("Die eingegebene Zahl kommt bereits im selben Block vor.");
                    return false;
                }
            }
        }
        playfield[reiheEingabe, spalteEingabe] = wert;
        DisplaySudoku(playfield);

        return true;
    }
}