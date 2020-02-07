"""
To execute this code simply have Python 3 installed.
"""
# import libraries that will be needed
import random
import time

def _start_random_door_positions() -> list:  # list of doors
    """When called will return bool[] with all set false
     except 1 randomly chosen door which will be set true
    """

    random_int = random.randint(0, 2)
    list_of_doors = [False, False, False]
    list_of_doors[random_int] = True
    return list_of_doors


def _players_guess() -> int:  # player guess
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


def _monty_reveals_door(doors, player_guess) -> int:  # Monty's opened door
    """take doors in, and the door the player guess, reveals a false door
    that isnt the players guess
    """
    for monty_revealed in range(len(doors)):
        if player_guess == monty_revealed:
            continue
        elif not doors[monty_revealed]:
            return monty_revealed


def _switch_request(doors, revealed_door, old_guess) -> int:  # New guess
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


def _results_with_message(new_guess, doors) -> str:  # message to print
    """Take the guess and doors and return a win or lose
    message.
    """
    if doors[new_guess]:
        result = "new Car!"
    else:
        result = "old Goat"
    return f"You got the: {result}"

def _results(new_guess, doors):
    """Take the guess and doors and return whether true
    or false.
    """
    return doors[new_guess]

def play():
    """Starts a playable version of the game,
    to see if you can out smart monty.
    """
    doors = _start_random_door_positions()
    guess = _players_guess()
    revealed = _monty_reveals_door(doors, guess)
    newGuess = _switch_request(doors, revealed, guess)
    print(_results_with_message(newGuess, doors))

def simulate():
    """When called will print out the results
    """
    switch_win_count = 0
    noswitch_win_count = 0
    requested_cycles = input('How many simulated cycles would you like?')
    # run the simulation for target amount of cycles
    for cycle in range(1, int(requested_cycles) + 1):
        #create a setup and always stay
        doors = _start_random_door_positions()
        guess = random.randint(0,2)
        if (_results(guess, doors)):
            noswitch_win_count += 1
        noswitch_win_percentage = 100 * (noswitch_win_count/cycle)
        # every 10th cycle print an update
        if cycle % (int(requested_cycles)/10) == 0:
            print(f"After {cycle} cycles, by always staying you win: \
 {noswitch_win_percentage:.3f} percent of the time")
 
        # create a setup and always switch
        doors = _start_random_door_positions()
        guess = random.randint(0,2)
        revealed = _monty_reveals_door(doors, guess)
        if True:
                for i in range(len(doors)):
                    if i == revealed:
                        continue
                    elif i == guess:
                        continue
                    else:
                        new_guess = i
        
        if (_results(new_guess, doors)):
            switch_win_count += 1
        switch_win_percentage = 100 * (switch_win_count /cycle )
        # every 10th cycle print an update
        if cycle % (int(requested_cycles)/10) == 0:
            print(f"After {cycle} cycles, by always switching you win:\
 {switch_win_percentage:.3f} percent of the time")

def choice_of_operation():
    """When called will prompt the user with play or simulate,
    where they can pick whether to play or simulate, and how many
    cycles
    """
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
                    simulate()
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
