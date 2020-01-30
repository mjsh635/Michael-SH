"""
To execute this code simply have Python 3 installed.
"""
# import libraries that will be needed
import random
import time

"""
Todo List:
create a menu that lets you PLay or Simulate
"""


def start_random_door_positions() -> list:  # list of doors
    """When called will return bool[] with all set false
     except 1 randomly chosen door which will be set true
    """

    random_int = random.randint(0, 2)
    list_of_doors = [False, False, False]
    list_of_doors[random_int] = True
    return list_of_doors


def players_guess() -> int:  # player guess
    """When called will ask for the player to pick a door
    """
    while True:

        # take the user input
        print("Please pick a door....1 | 2 | 3")
        potential_player_guess = input('')

        # filter it to see if it is a digit, and falls in the doors bounds

        if potential_player_guess.isdigit():
            if (int(potential_player_guess) >= 1
                    and int(potential_player_guess) <= 3):

                # if its a valid guess store the guess
                # and set valid Entry = True

                player_guess = int(potential_player_guess) - 1
                break
            else:
                print("""That is not a door, please enter 1, 2, or 3...
                    """)

        else:
            print("""That was not a number, please enter a number...
                """)
        time.sleep(1.5)
    return player_guess


def monty_reveals_door(doors, player_guess) -> int:  # Monty's opened door
    """take doors in, and the door the player guess, reveals a false door
    that isnt the players guess
    """
    for monty_revealed in range(len(doors)):
        if player_guess == monty_revealed:
            continue
        elif not doors[monty_revealed]:
            return monty_revealed


def switch_request(doors, revealed_door, old_guess) -> int:  # New guess
    """show the doors, and montys opened door, ask if they want to switch,
    return new guess if they want to switch
    """
    print(
        f"""You have chosen door {old_guess + 1},\
 Monty has revealed door {revealed_door + 1} is a Goat...""")

    while True:

        # take the user input
        print("Would you like to swap doors? y/n")
        player_swap_response = input('').lower()

        # filter it to see if it is a digit, and falls in the doors bounds

        if player_swap_response.isascii():
            if (player_swap_response == 'y'
                    or player_swap_response == 'n'):
                # if its a valid guess then
                # store the guess and set valid Entry = True
                if player_swap_response == 'y':
                    player_wants_to_swap = True
                else:
                    player_wants_to_swap = False
                break
            else:
                print("""please enter y or n for your decision
                    """)

        else:
            print("""please enter y or n for your decision
                """)
        time.sleep(1.5)

    if player_wants_to_swap:
        for i in range(len(doors)):
            if i == revealed_door:
                continue
            elif i == old_guess:
                continue
            else:
                player_new_guess = i
    else:
        player_new_guess = old_guess

    return player_new_guess


def results(new_guess, doors) -> str:  # message to print
    if doors[new_guess]:
        result = "new Car!"
    else:
        result = "old Goat"
    return f"You got the: {result}"


def play():
    """Starts a playable version of the game,
    to see if you can out smart monty.
    """
    doors = start_random_door_positions()
    guess = players_guess()
    revealed = monty_reveals_door(doors, guess)
    newGuess = switch_request(doors, revealed, guess)
    print(results(newGuess, doors))


def simulate(cycles, door_size):
    """When called will print out the results"""
    pass


def choice_of_operation():
    """When called will prompt the user with play or simulate,
    where they can pick whether to play or simulate, and how many
    cycles"""
    while True:

        # take the user input
        print("would you like to simulate or play? s/p")
        player_operation_choice = input('').lower()

        # filter it to see if it is a digit, and falls in the doors bounds

        if player_operation_choice.isascii():
            if (player_operation_choice == 's'
                    or player_operation_choice == 'p'):

                # if its a valid guess then
                # store the guess and set valid Entry = True
                if player_operation_choice == 's':
                    pass
                else:
                    play()
                break
            else:
                print("""please enter s or p for your decision
                    """)

        else:
            print("""please enter s or p for your decision
                """)
        time.sleep(1.5)


choice_of_operation()
