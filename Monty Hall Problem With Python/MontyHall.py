"""
To execute this code simply have Python 3 installed.

ToDo:

Menu to ask to Play or Simulate
"""
#import libraries that will be needed
import random
import time



def StartRandomDoorPositions() -> 'array of doors':
    """
    When called will return bool[] with all set false except 1 randomly chosen door which will be set true
    """

    randint = random.randint(0,2)
    randomDoors = [False,False,False]
    randomDoors[randint] = True
    return randomDoors

def PlayersGuess(doors) -> 'int of door guessed':
    """
    When called will ask for the player to
    """
    while True: 

            #take the user input
            print("Please pick a door....1 | 2 | 3")
            potentialplayerGuess = input('')

            #filter it to see if it is a digit, and falls in the doors bounds

            if potentialplayerGuess.isdigit():
                if int(potentialplayerGuess) >= 1 and int(potentialplayerGuess) <= 3:

                    #if its a valid guess store the guess and set valid Entry = True

                    playerGuess = int(potentialplayerGuess)
                    break
                else:
                    print("""That is not a door, please enter 1, 2, or 3... 
                    """)
                    
            else:
                print("""That was not a number, please enter a number...
                """)
            time.sleep(2)
    return playerGuess        
    

def MontyReveals(doors,playerGuess) -> "Monty's opened door":
    """
    take doors in, and the door the player guess, reveals a false door that isnt the players guess
    """
    for MontyRevealed in range(len(doors)):
        if playerGuess == MontyRevealed:
            continue
        elif doors[MontyRevealed] == False:
            return MontyRevealed


def SwitchRequest(doors, revealedDoor, oldGuess)-> "players new guess":
    """
    show the doors, and montys opened door, ask if they want to switch, return new guess if they want to switch
    """
    playerNewGuess = 1
    return playerNewGuess

def Results(newGuess, doors) -> "string of results":
    result = True
    return f"You got the: {result}"


    

def Play():
    """
    starts a playable version of the game, to see if you can out smart monty.
    """
    doors = StartRandomDoorPositions()
    guess = PlayersGuess(doors)
    revealed = MontyReveals(doors, guess)
    newGuess = SwitchRequest(doors, revealed, guess)
    print(Results(newGuess,doors))

