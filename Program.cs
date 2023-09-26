//Olof Maleki Nordin
//Labb 2 - Gissa numret
//.NET23 OOP

//A simple number guessing game where the user can change the difficulty

namespace GissaNumret
{
    class Methods
    {
        //Init list for showing leaderboard
        List<int> highScore = new List<int>();

        //Init number of guesses per game
        int guesses = 10;

        //Init variable to keep track of guesses left
        int guessesLeft = 10;

        //Init amount of numbers
        int numberSpan = 50;

        //variable for holding chosen dofficulty 
        string gameMode = "Medel";

        //Variable for holding user guess to
        //pick response in GetResponse()
        bool isUserGuessTooHigh = true;

        //Variable for selected response in GetResponse()
        string selectedResponse = "";

        //Init a random object
        Random random = new Random();

        //Welcome screen, print menu
        public void Run()
        {
            MainMenu();
        }

        //Method for picking random responses when user guess is wrong
        public string GetResponse(bool isUserGuessTooHigh)
        {

            //Variable for holding which row of responses to pick
            int rowIndex = 0;

            string[,] responses =
{
            {"Ajdå för högt...Prova igen",
            "Hoppsan du siktade för högt! Prova igen",
            "Nu vart det lite väl högt. Testa igen",
            "Nope, för högt. Testa igen", },

            {"Aj aj för lågt...Prova igen",
            "På tok för lågt! Prova igen",
            "Nu blev det lite lågt. Testa igen",
            "Nope, för lågt. Testa igen", }
        };
            
            //Check if user guess is too high or low,
            //then assign the corresponding row of strings  
            if (isUserGuessTooHigh == true) {
                rowIndex = 0;
            }
            else
            {
                rowIndex = 1;
            }

            //Once the row is set, pick a random string in the array
            int columnIndex = random.Next(responses.GetLength(1));
            selectedResponse = responses[rowIndex, columnIndex];

            //Return the picked response
            return selectedResponse;

        }


        //Method for handling user input errors
        public int GetUserInput(int errorMessageType)
        {
            string errorMessage = "";

            // Set the error message based on the errorMessageType parameter
            switch (errorMessageType)
            {
                //For main menu
                case 1:
                    errorMessage = "Skriv in ett giltigt menyval";
                    break;

                //For game play
                case 2:
                    errorMessage = "Skriv in ett giltigt tal.";
                    break;
            }

            while (true)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    if (result == 0 || result > numberSpan)
                    {
                        Console.WriteLine("Talet är för högt eller 0, skriv in ett giltigt tal");
                    }
                    else 
                    return result;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        //+++++++++++++++++++++++MENU++++++++++++++++++++++++++++++++++

        public void MainMenu()
        {
            //Menu loop
            while (true)
            {

                //Print menu
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine("Välkommen till det\n" + "världsberömda spelet\n");
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█▀▀░▀█▀░█▀▀░█▀▀░█▀█░░░░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█░█░░█░░▀▀█░▀▀█░█▀█░░░░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░░░░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█▀█░█░█░█▄█░█▀▄░█▀▀░▀█▀░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█░█░█░█░█░█░█▀▄░█▀▀░░█░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░▀░▀░▀▀▀░▀░▀░▀░▀░▀▀▀░░▀░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Thread.Sleep(30);
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("[1]  Spela");
                Console.WriteLine("[2]  Se high score");
                Console.WriteLine("[3]  Ändra svårighetsgrad");
                Console.WriteLine("[4]  Avsluta");
                Console.WriteLine("+++++++++++++++++++++++++++");

                //Store menu choice & catch user input error.
                //Also set parameter for which error message to display   
                int menuChoice = GetUserInput(1);

                //Alternative 1 - Play
                if (menuChoice == 1)
                {
                    Play();
                }

                //Alternative 2 - See High score
                if (menuChoice == 2)
                {
                    HighScore();
                }

                //Alternative 3 - Set Game mode 
                if (menuChoice == 3)
                {
                    Difficulty();
                }

                //Alternative 4 - Quit
                if (menuChoice == 4)
                {
                    break;
                }
            }
        }

        //+++++++++++++++++++++++++HIGH SCORE+++++++++++++++++++++++++
        public void HighScore()
        {
            //Variable for ranking
            int playerRank = 1;

            Console.Clear();
            Console.WriteLine("High score denna omgång");
            Console.WriteLine("++++++++++++++++++++++++++\n");

            //Check if high score list if empty
            if (highScore.Any() != true)
            {
                Console.WriteLine("Du måste spela först!\n");
            }

            //When list is not empty, print high score
            else
            {
                //Sort the items in the list by ascending
                highScore.Sort();

                Console.WriteLine($"Ranking\t\tGissningar" );
                //print each list item with ranking, score and game mode
                foreach (int score in highScore)
                {
                    Console.WriteLine($"[{playerRank}]\t\t{score}\t");
                    playerRank++;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("++++++++++++++++++++++++++\n");
            Console.WriteLine("Tryck för att gå tillbaka\n");
            Console.ReadKey();

            //Return to main menu
            MainMenu();
        }

        //+++++++++++++++++++++++++GAME MODE+++++++++++++++++++++++++
        public void Difficulty()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Svårighetsgrad");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("[1] Lätt - 20 tal 10 gissningar");
                Console.WriteLine("[2] Medel - 50 tal 10 gissningar (DEFAULT)");
                Console.WriteLine("[3] Hardcore - 100 tal 5 gissningar");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");

                //Store menu choice & catch user input error.
                //Also set parameter for which error message to display (See method GetUserInput)   
                int difficultyChoice = GetUserInput(1);

                if (difficultyChoice == 1)
                {
                    guesses = 10;
                    numberSpan = 20;
                    gameMode = "Lätt";

                    break;
                }

                if (difficultyChoice == 2)
                {
                    guesses = 10;
                    numberSpan = 50;
                    gameMode = "Medel";

                    break;
                }

                if (difficultyChoice == 3)
                {
                    guesses = 5;
                    numberSpan = 100;
                    gameMode = "Hardcore";

                    break;
                }

                else
                {
                    Console.WriteLine("Skriv in ett giltigt menyval.");
                    Console.ReadKey();
                }

                MainMenu();
            }
        }


        //+++++++++++++++++++++++++GAME+++++++++++++++++++++++++++++++++
        public void Play()
        {
            Console.Clear();

            //Generate a random number within the given 
            //range & assign to secret number
            int secretNumber = random.Next(1, numberSpan + 1);

            //Init variable to store the guessed number
            int guessNumber = 0;
            
            //reset guess counter to initial value
            guessesLeft = guesses;

            //Print start message
            Console.WriteLine($"Då sätter vi igång. Hoppas du är redo.\n" + $"Du har {guesses} försök på dig.\n");
            Console.WriteLine("Tryck för att börja.");

            //Print secret number (debugging)
            //Console.WriteLine($"{secretNumber}");

            Console.ReadKey();
            Console.Clear();

            //Loop for the game
            do
            {
                //Get the number from user
                Console.WriteLine($"Vilket tal mellan 1 och {numberSpan} tror du vi har idag?\n");

                //Store guess number & catch user input error.
                //Also set parameter for which error message to display   
                guessNumber = GetUserInput(2);

                //Check if user guess is correct, exit loop
                //Not good! Should check before getting into the loop with bool,
                //but how to not repeat first line of code in loop?
                if (guessNumber == secretNumber)
                {
                    break;
                }

                //check if input number is larger than secret number
                else if (guessNumber > secretNumber)
                {
                    //check if input number is within the range of given number (3)
                    if (guessNumber - secretNumber <= 3)
                    {
                        Console.WriteLine("Lite väl högt, men det bränns...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    //If not, print too high
                    else
                    {
                        //Run method for picking a random respons
                        GetResponse(true);

                        //Prints the respons
                        Console.WriteLine(selectedResponse);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                //check if input number is smaller than secret number
                else if (guessNumber < secretNumber)
                {
                    //check if input number is within the range of given number (3)
                    if (secretNumber - guessNumber <= 3)
                    {
                        Console.WriteLine("Lite väl lågt, men det bränns...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    //If not, print too low
                    else
                    {
                        GetResponse(false);
                        Console.WriteLine(selectedResponse);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                //Keep track of how many guesses user have left. Added "-1" so 
                //the printed and calculated number match up
                Console.WriteLine($"Du har [{guessesLeft - 1}] försök kvar\n");

                //Subtract 1 for every loop 
                guessesLeft--;

                //Keep loop going as long as it's above 0 
            } while (guessesLeft > 0);


            //Init variable for showing number of guesses
            int score = guesses - guessesLeft + 1;

            //When user guesses right - print congrats!
            if (secretNumber == guessNumber)
            {

                highScore.Add(score);


                Console.Clear();
                Console.WriteLine("Där satt den!!\n");
                Console.WriteLine($"Det tog [{score}] försök.\n");
                Console.WriteLine("Tryck för att komma tillbaka till menyn\n");
                Console.ReadKey();
            }

            //Users guesses reaches zero and game ends.
            else
            {
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█▀▀░█▀█░█▄█░█▀▀░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█░█░█▀█░█░█░█▀▀░░");
                Thread.Sleep(30);
                Console.WriteLine("░░▀▀▀░▀░▀░▀░▀░▀▀▀░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█▀█░█░█░█▀▀░█▀▄░░");
                Thread.Sleep(30);
                Console.WriteLine("░░█░█░▀▄▀░█▀▀░█▀▄░░");
                Thread.Sleep(30);
                Console.WriteLine("░░▀▀▀░░▀░░▀▀▀░▀░▀░░");
                Thread.Sleep(30);
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░\n");

                //reveals the secret number
                Console.WriteLine($"talet var {secretNumber}\n");
                Console.WriteLine("Tryck för att komma\ntillbaka till menyn\n");

                //hold screen
                Console.ReadKey();
                Console.Clear();

                MainMenu();

            }
        }
    }

     class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of the class Methods
            var Game = new Methods();

            //Start the game
            Game.Run();
        }
    }
}