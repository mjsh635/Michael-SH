using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MontyGame
{
    Random random = new Random();

    /// <summary>
    /// When called will return bool[] with all set false
    /// except 1 randomly chosen door which will be set true
    /// </summary>
    /// <returns> bool[] of doors</returns>
    private bool[] StartRandomDoorPositions()
    {
        int randomInt = random.Next(0, 2);
        bool[] arrayOfDoors = new bool[3] { false, false, false };
        arrayOfDoors[randomInt] = true;
        return arrayOfDoors;
    }

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

    private string ResultPrint(bool[] doors, int newGuess)
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
    private bool Result(bool[] doors, int newGuess)
    {
        return doors[newGuess];
    }

    public void Play()
    {
        var doors = StartRandomDoorPositions();
        var oldGuess = PlayerGuess();
        var montyDoors = MontyRevealedDoor(doors, oldGuess);
        var newGuess = SwitchRequest(doors, montyDoors, oldGuess);
        var result = ResultPrint(doors, newGuess);
        Console.WriteLine(result);
        Console.Read();
    }

    public void Simulate()
    {
        float switchWinCount = 0;
        float noSwitchWinCount = 0;
        string requestedCyclesIntput = "";
        int requestedCycles = 1000;

        for (int cycles = 1; cycles < requestedCycles + 1; cycles++)
        Console.WriteLine("How many simulations?");
        {
            var doorsNoSwitch = StartRandomDoorPositions();
            var guessNoSwitch = random.Next(0,3);
            float noSwitchWinPercentage;

            if (Result(doorsNoSwitch,guessNoSwitch))
            {
                noSwitchWinCount++;
            }

            noSwitchWinPercentage = ((noSwitchWinCount / cycles) * 100);

            if (cycles % (requestedCycles/10) == 0)
            {
                Console.WriteLine($"{requestedCyclesIntput} isn't a positive number");
            }

            var doorsSwitch = StartRandomDoorPositions();
            var guessSwitch = random.Next(0, 3);
            var revealedDoor = MontyRevealedDoor(doorsSwitch, guessSwitch);
            int newGuess = 0;
            float switchWinPercentage;

            if (true)
            {
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
            }

            if (Result(doorsSwitch,newGuess))
            {
                switchWinCount++;
            }
            switchWinPercentage = ((switchWinCount/cycles)*100);
            if (cycles % (requestedCycles / 10) == 0)
            {
                Console.WriteLine($"After {cycles} cycles, by always staying you win: {noSwitchWinPercentage} percent of the time");
                Console.WriteLine($"After {cycles} cycles, by always switching you win: {switchWinPercentage} percent of the time \n");
            }
            
        }
}

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

