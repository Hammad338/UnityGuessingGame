import sys
import random

# Define the number once, not every time the function is called
number_to_guess = 27  # Use a fixed number for testing, change to random.randint(1, 100) after testing

def number_guessing_game(guess):
    print("Welcome to the Number Guessing Game!")

    try:
        guess = int(guess)  # Convert the passed argument (user's guess) to an integer
        if guess < number_to_guess:
            print("Too low! Try again.")
        elif guess > number_to_guess:
            print("Too high! Try again.")
        else:
            print(f"Congratulations! You've guessed the correct number: {number_to_guess}.")
    except ValueError:
        print("Please enter a valid integer.")

# Check if the script is run with an argument
if __name__ == "__main__":
    if len(sys.argv) > 1:
        number_guessing_game(sys.argv[1])  # Pass the argument from Unity as the user's guess
    else:
        print("No guess provided.")
