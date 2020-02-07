using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MontyGame
{
    // Random is used for randomized int values
    Random random;

    /// <summary>
    /// Constructor for MontyGame Class
    /// </summary>
    public MontyGame()
    {
        //initialize random
        random = new Random();
    }

    /// <summary>
    /// When called will return bool[] with all set false
    /// except 1 randomly chosen door which will be set true
    /// </summary>
    /// <returns> bool[] of doors</returns>
    private bool[] RandomizeDoors()
    {
        // Choose a random number
        int randomInt = random.Next(0, 2);
        // Create a bool array of all false
        bool[] arrayOfDoors = new bool[3] { false, false, false };
        // Take randomInt and make door at that index true
        arrayOfDoors[randomInt] = true;
        // Return the array
        return arrayOfDoors;
    }

    /// <summary>
    /// Returns players door guess
    /// </summary>
    /// <returns></returns>
    private int PlayerGuess()
    {
        int potentialPlayerGuess;
        string playerInput;
        int playerGuess;

        // Prompt the user to pick a door
        while (true)
        {
            Console.WriteLine("Please pick a door.... 1 | 2 | 3 |");
            playerInput = Console.ReadLine();
            
            // Parse the response and then check if it is a valid door
            if (int.TryParse(playerInput, out potentialPlayerGuess))
            {
                if (3 >= potentialPlayerGuess && potentialPlayerGuess >= 1)
                {
                    playerGuess = potentialPlayerGuess - 1;

                    // Return the players guess if it is valid
                    return playerGuess;
                }
                else
                {
                    Console.WriteLine("That is not a door option");
                }
            }
            else
            {
                Console.WriteLine("That was not a number");
            }
        }
    }

    /// <summary>
    /// Returns a door that monty reveals is false
    /// </summary>
    /// <param name="doors"> bool array of doors</param>
    /// <param name="playerGuess"> int of player guess 0-2</param>
    /// <returns></returns>
    private int MontyRevealedDoor(bool[] doors, int playerGuess)
    {
        int montyDoor = 0;
        // Reveal the first door that is false and isnt the players guess
        for (int i = 0; i < doors.Length; i++)
        {
            if (playerGuess == i)
            {
                continue;
            }
            else if (!doors[i])
            {
                montyDoor = i;
                break;
            }
        }
        // Return the revealed door number
        return montyDoor;
    }

    /// <summary>
    /// returns new int if the player chooses to switch or original if not
    /// </summary>
    /// <param name="doors">bool array of doors</param>
    /// <param name="montysRevealedDoor"> door revealed by monty to be false</param>
    /// <param name="oldGuess">int of player guess 0-2</param>
    /// <returns></returns>
    private int SwitchRequest(bool[] doors, int montysRevealedDoor, int oldGuess)
    {

        char parseResult;
        string playerSwapResponse;
        bool playerWantsToSwap;
        int newGuess = 0;

        // Prompt user about montys revealed door
        Console.WriteLine($"You have chosen door {oldGuess + 1}, Monty has revealed that door {montysRevealedDoor + 1} is a  Goat");

        // Prompt the user and give option to switch doors or not
        while (true)
        {
            Console.WriteLine("Would you like to swap doors? y/n");
            playerSwapResponse = Console.ReadLine().ToLower();

            if (char.TryParse(playerSwapResponse, out parseResult))
            {
                if (parseResult == 'y' || parseResult == 'n')
                {
                    if (parseResult == 'y')
                    {
                        playerWantsToSwap = true;
                    }
                    else
                    {
                        playerWantsToSwap = false;
                    }
                    break;

                }
                else
                {
                    Console.WriteLine($"{parseResult} was not an option");
                }
            }
            else
            {
                Console.WriteLine("Please enter y or n for your decision");
            }

        }
        // if player wants to swap, swap 
        if (playerWantsToSwap)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (i == montysRevealedDoor)
                {
                    continue;
                }
                else if (i == oldGuess)
                {
                    continue;
                }
                else
                {
                    newGuess = i;
                }
            }
        }
        else
        {
            newGuess = oldGuess;
        }
        return newGuess;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="doors">bool array of doors</param>
    /// <param name="montysRevealedDoor">door revealed by monty to be false</param>
    /// <param name="oldGuess">int of player guess 0-2</param>
    /// <returns> returns the switched guess</returns>
    private int AlwaysSwitch(bool[] doors, int montysRevealedDoor, int oldGuess)
    {
        int newGuess = 0;

        // iterate over the doors, if it is a revealed door or original guess continue
        for (int i = 0; i < doors.Length; i++)
        {
            if (i == montysRevealedDoor)
            {
                continue;
            }
            else if (i == oldGuess)
            {
                continue;
            }
            else
            {
                newGuess = i;
            }
        }
        return newGuess;
    }

    /// <summary>
    /// return a string with the results
    /// </summary>
    /// <param name="doors">bool array of doors</param>
    /// <param name="newGuess">int of player guess 0-2</param>
    /// <returns></returns>
    private string PrintResults(bool[] doors, int newGuess)
    {
        // Check and return a message if the door at index guess is True
        string result = "";
        if (doors[newGuess])
        {
            result = " New Car!!";
        }
        else
        {
            result = " Old Goat ";
        }

        return ($"you got the {result}");
    }

    /// <summary>
    /// Returns a bool for win or loss
    /// </summary>
    /// <param name="doors">bool array of doors</param>
    /// <param name="newGuess">int of player guess 0-2</param>
    /// <returns></returns>
    private bool ReturnResults(bool[] doors, int newGuess)
    {
        // Check and return value of the door at index guess
        return doors[newGuess];
    }

    /// <summary>
    /// Runs a playable version of the monty hall problem
    /// </summary>
    public void Play()
    {
        // Call all methods in a order to play the game
        var doors = RandomizeDoors();
        var oldGuess = PlayerGuess();
        var montyDoors = MontyRevealedDoor(doors, oldGuess);
        var newGuess = SwitchRequest(doors, montyDoors, oldGuess);
        var result = PrintResults(doors, newGuess);
        // Print the results
        Console.WriteLine(result);
        Console.Read();
    }

    /// <summary>
    /// Runs a simulated version of monty hall problem
    /// </summary>
    public void Simulate()
    {
        float switchWinCount = 0;
        float noSwitchWinCount = 0;
        string requestedCyclesIntput;
        int requestedCycles;
        
        // Prompt user and request how many simulation cycles
        Console.WriteLine("How many simulations?");
        while (true)
        {

            requestedCyclesIntput = Console.ReadLine();

            if (int.TryParse(requestedCyclesIntput, out requestedCycles))
            {
                break;
            }
            else
            {
                Console.WriteLine($"{requestedCyclesIntput} isn't a positive number");
            }
        }


        // Run through chosen amount of cyles
        for (int cycles = 1; cycles < requestedCycles + 1; cycles++)
        {
            // Declarations for Not switching
            var doorsNoSwitch = RandomizeDoors();
            var guessNoSwitch = random.Next(0, 3);
            float noSwitchWinPercentage;
            // Declarations for always switching
            var doorsSwitch = RandomizeDoors();
            var guessSwitch = random.Next(0, 3);
            var revealedDoor = MontyRevealedDoor(doorsSwitch, guessSwitch);
            int newGuess = 0;
            float switchWinPercentage;
            
            // Determine if a win by not switching
            if (ReturnResults(doorsNoSwitch, guessNoSwitch))
            {
                noSwitchWinCount++;
            }
            
            // Always switch doors
            newGuess = AlwaysSwitch(doorsSwitch, revealedDoor, guessSwitch);
            // Determine if a win by always switching
            if (ReturnResults(doorsSwitch, newGuess))
            {
                switchWinCount++;
            }
            
            // Calculate the win percentages for both cases
            noSwitchWinPercentage = ((noSwitchWinCount / cycles) * 100);
            switchWinPercentage = ((switchWinCount / cycles) * 100);

            // Every 10th cycle print a progress of win precentage
            if (cycles % (requestedCycles / 10) == 0)
            {
                Console.WriteLine($"After {cycles} cycles, by always staying you win: {noSwitchWinPercentage} percent of the time, and lose {100 - noSwitchWinPercentage} percent of the time");
                Console.WriteLine($"After {cycles} cycles, by always switching you win: {switchWinPercentage} percent of the time, and lose {100 - switchWinPercentage} percent of the time\n");
            }

        }
    }

    /// <summary>
    /// promts user to choose which mode to run
    /// </summary>
    public void ChooseMode()
    {
        string playerModeResponse;
        char parseResult;

        // Prompt user for option on mode
        while (true)
        {
            Console.WriteLine("Would you like play or simulate? p/s");
            playerModeResponse = Console.ReadLine().ToLower();

            // Try and parse response for a character that is s or p
            if (char.TryParse(playerModeResponse, out parseResult))
            {
                if (parseResult == 's' || parseResult == 'p')
                {
                    if (parseResult == 'p')
                    {
                        Play();
                    }
                    else
                    {
                        Simulate();
                        Console.Read();
                    }
                    break;

                }
                else
                {
                    Console.WriteLine($"{parseResult} is not an option, s/p");
                }
            }
            else
            {
                Console.WriteLine($"{ parseResult} is not an option, s / p");
            }
        }
    }
}

