using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem
{
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

        public int PlayerGuess()
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
                System.Threading.Thread.Sleep(1500);
            }
        }

        public int MontyRevealedDoor(bool[] doors, int playerGuess)
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

        public int SwitchRequest(bool[] doors, int montysRevealedDoor, int oldGuess)
        {
            int playerNewGuess = 0;
            return playerNewGuess;
        }

        public string ResultPrint(bool[] doors, int newGuess)
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

        public string Play()
        {
            var doors = StartRandomDoorPositions();
            var oldGuess = PlayerGuess();
            var montyDoors = MontyRevealedDoor(doors, oldGuess);
            var newGuess = SwitchRequest(doors, montyDoors, oldGuess);
            var result = ResultPrint(doors, newGuess);
            return result;
        }

    }
}
