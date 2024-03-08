using System;

class SecondConsoleGame
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\t\t\t\t\t\t\t   ********************************");
                Console.WriteLine("\t\t\t\t\t\t\t   **        PinoyScramble:      **");
                Console.WriteLine("\t\t\t\t\t\t\t   **       Unravel the Fun,     **");
                Console.WriteLine("\t\t\t\t\t\t\t   **    Guess the Destination!  **");
                Console.WriteLine("\t\t\t\t\t\t\t   ********************************");

                // array of Philippine tourist destinations to guess
                string[] destinations = { "CHOCOLATE HILLS", "PALAWAN", "BANAUE RICE TERRACES", "SIARGAO", "MAYON VOLCANO" };
                Random random = new Random();
                int randomIndex = random.Next(destinations.Length);
                string jumbledWord = JumbleWord(destinations[randomIndex]);

         
                string clue = "Clue: The jumbled word is related to the destination: " + jumbledWord;

                Console.WriteLine("\n\t\t\t\t\t" + clue);

                //// guess attempts counter
                int attempts = 0;
                const int maxAttempts = 3;

                while (attempts < maxAttempts)
                {
                    Console.Write("\n\t\t\t\t\tYour guess: ");
                    string userGuess = Console.ReadLine()?.ToUpper();

                    // check if the user's guess is correct
                    if (userGuess == destinations[randomIndex])
                    {
                        Console.WriteLine("\n\t\t\t\t\tCongratulations! You guessed the correct tourist destination.");
                        break;
                    }
                    else
                    {
                        attempts++;
                        int remainingAttempts = maxAttempts - attempts;

                        if (remainingAttempts > 0)
                        {
                            Console.WriteLine($"\n\t\t\t\t\tSorry, that's incorrect. You have {remainingAttempts} {(remainingAttempts > 1 ? "attempts" : "attempt")} left. Try again.");
                        }
                        else
                        {
                            Console.WriteLine($"\n\t\t\t\t\tYou've reached the maximum number of attempts. The correct destination is: {destinations[randomIndex]}");
                            break;
                        }
                    }
                }

                Console.Write("\n\t\t\t\t\tDo you want to play again? (Y/N): ");
                Console.WriteLine();
                string continuePlaying = Console.ReadLine()?.ToUpper();

                while (continuePlaying != "Y" && continuePlaying != "N")
                {
                    Console.WriteLine("\t\t\t\t\tInvalid input. Please enter 'Y' or 'N'.");
                    Console.Write("\t\t\t\t\tDo you want to play again? (Y/N): ");
                    continuePlaying = Console.ReadLine()?.ToUpper();
                }

                if (continuePlaying == "N")
                {
                    Console.WriteLine("\n\t\t\t\t\tThanks for playing! Press any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\t\t\t\t\tAn error occurred: " + ex.Message);
            }
        }
    }

    //function to jumble the letters of a word
    static string JumbleWord(string word)
    {
        char[] characters = word.ToCharArray();
        Random random = new Random();

        for (int i = 0; i < characters.Length; i++)
        {
            int randomIndex = random.Next(i, characters.Length);
            char temp = characters[i];
            characters[i] = characters[randomIndex];
            characters[randomIndex] = temp;
        }

        return new string(characters);
    }
}
