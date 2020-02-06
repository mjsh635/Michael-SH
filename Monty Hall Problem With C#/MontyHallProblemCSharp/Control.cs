using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Control
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
                    Console.WriteLine("That is not a door, please enter 1, 2, or 3...");
                }
            }
            else
            {
                Console.WriteLine("That was not a number, please enter a number...");
            }
        }
    }

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

        Console.WriteLine(string.Format("you have chosen door {0}, Monty has revealed that door {1} is a  Goat", oldGuess + 1, montysRevealedDoor + 1));

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
                    Console.WriteLine("Please enter y or n for your decision");
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

        return string.Format("you got the {0}", result);
    }

    public void Play()
    {
        var doors = StartRandomDoorPositions();
        var oldGuess = PlayerGuess();
        var montyDoors = MontyRevealedDoor(doors, oldGuess);
        var newGuess = SwitchRequest(doors, montyDoors, oldGuess);
        var result = ResultPrint(doors, newGuess);
        Console.WriteLine(result);
    }

    public void Simulate()
    {

    }
    
    public void ChooseMode()
    {

    }
}

