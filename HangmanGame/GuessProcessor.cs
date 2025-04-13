using System.Linq;

namespace HangmanGame
{
    public class GuessProcessor
    {
        public string wordToGuess { get; }
        private string guessedLetters;
        private int wrongGuesses;

        public GuessProcessor(string wordToGuess)
        {
            this.wordToGuess = wordToGuess;
            this.guessedLetters = "";
            this.wrongGuesses = 0;
        }

        public string GuessedLetters => guessedLetters;
        public int WrongGuesses => wrongGuesses;

        public string ProcessGuess(string guess)
        {
            guess = guess.ToUpper();

            if (guessedLetters.Contains(guess))
            {
                return "Letter already used!";
            }

            guessedLetters += guess;

            if (wordToGuess.Contains(guess))
            {
                return "Good guess!";
            }
            else
            {
                wrongGuesses++;
                return "Wrong guess! Try again.";
            }
        }

        public string GetWordDisplay()
        {
            return string.Join(" ", wordToGuess.Select(c => guessedLetters.Contains(c) ? c.ToString() : "_"));
        }
    }
}