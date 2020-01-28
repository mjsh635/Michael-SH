"""
To execute this code simply have Python 3 installed.

ToDo:

Menu to ask to Play or Simulate
"""
#import libraries that will be needed
import random



def StartRandomDoorPositions() -> 'Bool array':
    """
    When called will return bool[] with all set false except 1 randomly chosen door which will be set true
    """

    montysRandomDoor = random.randint(0,2)
    montysDoors = [False,False,False]
    montysDoors[montysRandomDoor] = True
    return montysDoors

def PlayersGuess() -> 'int of door guessed':
    """
    When called will ask for the player to
    """

def Play():
    """
    starts a playable version of the game, to see if you can out smart monty.
    """
    randomizedDoors = StartRandomDoorPositions()

    validEntry = False

    #Ensure that the player enters a valid door selection

    while not validEntry: 

        #take the user input
        print("Please pick a door....1 | 2 | 3")
        potentialplayerGuess = input('')

        #filter it to see if it is a digit, and falls in the doors bounds

        if potentialplayerGuess.isdigit():
            if int(potentialplayerGuess) >= 1 and int(potentialplayerGuess) <= 3:

                #if its a valid guess store the guess and set valid Entry = True

                playerGuess = int(potentialplayerGuess)
                validEntry = True
            else:
                validEntry = False
                print("please enter 1, 2, or 3")
        else:
            validEntry = False
            print("please enter a number between 1 and 3")

    print(f"player guessed:  {playerGuess}")

Play()