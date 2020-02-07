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
        random = new Random();
    }

    /// <summary>
    /// When called will return bool[] with all set false
    /// except 1 randomly chosen door which will be set true
    /// </summary>
    /// <returns> bool[] of doors</returns>
    private bool[] RandomizeDoors()
    {
        int randomInt = random.Next(0, 2);
        bool[] arrayOfDoors = new bool[3] { false, false, false };
        arrayOfDoors[randomInt] = true;
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
        while (true)
        {
            Console.WriteLine("Please pick a door.... 1 | 2 | 3 |");
            playerInput = Console.ReadLine();

            if (int.TryParse(playerInput, out potentialPlayerGuess))
            {
                if (3 >= potentialPlayerGuess && potentialPlayerGuess >= 1)
                {
                    playerGuess = potentialPlayerGuess - 1;
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

        Console.WriteLine($"You have chosen door {oldGuess + 1}, Monty has revealed that door {montysRevealedDoor + 1} is a  Goat");

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
    /// prints the results
    /// </summary>
    /// <param name="doors">bool array of doors</param>
    /// <param name="newGuess">int of player guess 0-2</param>
    /// <returns></returns>
    private string PrintResults(bool[] doors, int newGuess)
    {
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
    /// Returns the results
    /// </summary>
    /// <param name="doors">bool array of doors</param>
    /// <param name="newGuess">int of player guess 0-2</param>
    /// <returns></returns>
    private bool ReturnResults(bool[] doors, int newGuess)
    {
        return doors[newGuess];
    }

    /// <summary>
    /// Runs a playable version of the monty hall problem
    /// </summary>
    public void Play()
    {
        var doors = RandomizeDoors();
        var oldGuess = PlayerGuess();
        var montyDoors = MontyRevealedDoor(doors, oldGuess);
        var newGuess = SwitchRequest(doors, montyDoors, oldGuess);
        var result = PrintResults(doors, newGuess);
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



        for (int cycles = 1; cycles < requestedCycles + 1; cycles++)
        {
            var doorsNoSwitch = RandomizeDoors();
            var guessNoSwitch = random.Next(0, 3);
            float noSwitchWinPercentage;
            var doorsSwitch = RandomizeDoors();
            var guessSwitch = random.Next(0, 3);
            var revealedDoor = MontyRevealedDoor(doorsSwitch, guessSwitch);
            int newGuess = 0;
            float switchWinPercentage;

            if (ReturnResults(doorsNoSwitch, guessNoSwitch))
            {
                noSwitchWinCount++;
            }

            noSwitchWinPercentage = ((noSwitchWinCount / cycles) * 100);

            for (int i = 0; i < doorsSwitch.Length; i++)
            {
                if (i == revealedDoor)
                {
                    continue;
                }
                else if (i == guessSwitch)
                {
                    continue;
                }
                else
                {
                    newGuess = i;
                }
            }

            if (ReturnResults(doorsSwitch, newGuess))
            {
                switchWinCount++;
            }
            switchWinPercentage = ((switchWinCount / cycles) * 100);
            if (cycles % (requestedCycles / 10) == 0)
            {
                Console.WriteLine($"After {cycles} cycles, by always staying you win: {noSwitchWinPercentage} percent of the time");
                Console.WriteLine($"After {cycles} cycles, by always switching you win: {switchWinPercentage} percent of the time \n");
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

        while (true)
        {
            Console.WriteLine("Would you like play or simulate? p/s");
            playerModeResponse = Console.ReadLine().ToLower();

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

