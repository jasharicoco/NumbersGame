namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool guessingGame = true;
            int highScore = int.MaxValue;
            const int maxGuesses = 5;

            while (guessingGame)
            {
                Random randomized = new Random();
                int gameNumber = randomized.Next(0, 21);
                int numberOfGuesses = 0;
                bool play = true;

                while (play && numberOfGuesses < maxGuesses)
                {
                    Console.Write($"\n\tGissa på ett tal mellan 1 och 20 (Försök {numberOfGuesses + 1}/{maxGuesses}): ");

                    if (Int32.TryParse(Console.ReadLine(), out int userNumber))
                    {
                        if (userNumber < gameNumber)
                        {
                            Console.WriteLine($"\tDet inmatade talet {userNumber} är för litet, försök igen.");
                            numberOfGuesses++;
                        }
                        else if (userNumber > gameNumber)
                        {
                            Console.WriteLine($"\tDet inmatade talet {userNumber} är för stort, försök igen.");
                            numberOfGuesses++;
                        }
                        else if (userNumber == gameNumber)
                        {
                            numberOfGuesses++;
                            Console.WriteLine("\n\tGrattis, du gissade rätt!");
                            Console.WriteLine($"\tDu gissade rätt på {numberOfGuesses} försök.");
                            if (numberOfGuesses < highScore) highScore = numberOfGuesses;
                            play = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tVänligen ange en giltig siffra.");
                    }
                }

                if (numberOfGuesses >= maxGuesses && play) // Om max antal gissningar uppnås avslutas rundan
                {
                    Console.WriteLine("\n\tTyvärr, du har nått max antal försök. Spelet är över för denna omgång.");
                    play = false;
                }

                // Visa menyn efter spelets omgång, menyn finns som modul längst ner
                ShowMenu();

                bool whatToDoNow = true;
                while (whatToDoNow)
                {
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        whatToDoNow = false;
                    }
                    else if (choice == "2")
                    {
                        if (highScore == int.MaxValue) { Console.WriteLine("\tDu har inte lyckats gissa rätt ännu. Försök igen!"); }
                        else { Console.WriteLine($"\tDet minsta antalet gissningar som gav rätt svar är: {highScore}"); }
                        ShowMenu();
                    }
                    else if (choice == "3")
                    {
                        whatToDoNow = false;
                        guessingGame = false;
                        play = false;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\n\tVänligen välj något av alternativen");
                        ShowMenu();
                    }
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n\tVad vill du göra nu?");
            Console.WriteLine("\t1) Spela igen");
            Console.WriteLine("\t2) Se High Score");
            Console.WriteLine("\t3) Avsluta programmet");
        }
    }
}
