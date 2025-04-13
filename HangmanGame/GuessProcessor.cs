using System.Linq;

namespace HangmanGame
{
    public class GuessProcessor
    {
        private string wordToGuess;
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
                return "Bokstav redan använd!";
            }

            guessedLetters += guess;

            if (wordToGuess.Contains(guess))
            {
                return "Bra gissat!";
            }
            else
            {
                wrongGuesses++;
                return "Fel gissning! Försök igen.";
            }
        }

        public string GetWordDisplay()
        {
            return string.Join(" ", wordToGuess.Select(c => guessedLetters.Contains(c) ? c.ToString() : "_"));
        }
    }
}