using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace HangmanGame
{
    public partial class MainWindow : Window
    {
        private GuessProcessor? guessProcessor;
        private readonly WordFetcher wordFetcher;
        private HangmanFigure hangmanFigure;
        private GameResetHandler? gameResetHandler;
        private GameOverHandler? gameOverHandler;

        public MainWindow()
        {
            InitializeComponent();
            wordFetcher = new WordFetcher();
            FetchRandomWordAsync();
            hangmanFigure = new HangmanFigure(hangmanCanvas);
            gameResetHandler = new GameResetHandler(guessedLettersTextBlock, messageTextBlock, restartButton, guessButton, this);
            gameOverHandler = new GameOverHandler(wordTextBlock, messageTextBlock, guessButton, restartButton);

        }
        // Fetches a random word asynchronously and initializes the GuessProcessor.
        public async void FetchRandomWordAsync()
        {
            string word = await wordFetcher.FetchRandomWordAsync();
            guessProcessor = new GuessProcessor(word);
            // Displays an error message if the word fetch fails.
            if (word == "ERROR")
            {
                MessageBox.Show("Kunde inte hämta ett ord. Försök igen senare.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateWordDisplay();
        }
        /// Handles the click event for the "Guess" button.
        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessGuess();
        }
        // Handles the KeyDown event for the guessTextBox and pressing Enter.
        private void GuessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (restartButton.Visibility == Visibility.Visible)
                {
                    RestartButton_Click(sender, e);
                }
                else
                {
                    ProcessGuess();
                }
            }
        }
        // Processes the user's guess, validates it, and updates the game state/Displays appropriate messages and updates the UI.
        private void ProcessGuess()
        {
            string guess = guessTextBox.Text.Trim().ToUpper();
            guessTextBox.Clear();

            if (guess.Length == 1 || guess.Length == guessProcessor.GetWordDisplay().Replace(" ", "").Length)
            {
                string message = guessProcessor.ProcessGuess(guess);
                messageTextBlock.Text = message;

                UpdateGuessedLettersDisplay();
                UpdateWordDisplay();
                UpdateHangman();
                CheckGameOver();
            }
            else
            {
                messageTextBlock.Text = "You need to write a single letter or the whole word!";
            }
        }
        // Updates the display of guessed letters in the guessedLettersTextBlock.
        private void UpdateGuessedLettersDisplay()
        {
            guessedLettersTextBlock.Text = string.Join("\n", guessProcessor.GuessedLetters.ToCharArray());
        }
        // Updates the display of the word being guessed in the wordTextBlock.
        private void UpdateWordDisplay()
        {
            wordTextBlock.Text = guessProcessor.GetWordDisplay();
        }
        // Updates the hangman figure based on the number of wrong guesses.
        private void UpdateHangman()
        {
                hangmanFigure.UpdateFigure(guessProcessor.WrongGuesses);
        }
        // Checks if the game is over (win or lose) and updates the UI accordingly.
        private void CheckGameOver()
        {
            if (guessProcessor == null) return;

            gameOverHandler?.CheckGameOver(
                guessProcessor.GuessedLetters,
                guessProcessor.wordToGuess,
                guessProcessor.WrongGuesses
            );
        }
        // Handles the click event for the "Restart" button.
        public void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            gameResetHandler?.ResetGame();
        }
    }
}
