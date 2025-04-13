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

        public MainWindow()
        {
            InitializeComponent();
            wordFetcher = new WordFetcher();
            FetchRandomWordAsync();
            hangmanFigure = new HangmanFigure(hangmanCanvas);
        }

        private async void FetchRandomWordAsync()
        {
            string word = await wordFetcher.FetchRandomWordAsync();
            guessProcessor = new GuessProcessor(word);
            if (word == "ERROR")
            {
                MessageBox.Show("Kunde inte hämta ett ord. Försök igen senare.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateWordDisplay();
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessGuess();
        }

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

        private void UpdateGuessedLettersDisplay()
        {
            guessedLettersTextBlock.Text = string.Join("\n", guessProcessor.GuessedLetters.ToCharArray());
        }

        private void UpdateWordDisplay()
        {
            wordTextBlock.Text = guessProcessor.GetWordDisplay();
        }

        private void UpdateHangman()
        {
                hangmanFigure.UpdateFigure(guessProcessor.WrongGuesses);
        }

        private void CheckGameOver()
        {
            if (wordTextBlock.Text.Replace(" ", "") == guessProcessor.GuessedLetters)
            {
                messageTextBlock.Text = "Congratulations, You Won!";
                guessButton.Visibility = Visibility.Collapsed;
                restartButton.Visibility = Visibility.Visible;
            }
            else if (guessProcessor.WrongGuesses >= 6)
            {
                wordTextBlock.Text = guessProcessor.wordToGuess;
                messageTextBlock.Text = "Sorry, You Lost!";
                guessButton.Visibility = Visibility.Collapsed;
                restartButton.Visibility = Visibility.Visible;
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            FetchRandomWordAsync();
            guessedLettersTextBlock.Text = "";
            messageTextBlock.Text = "";
            restartButton.Visibility = Visibility.Collapsed;
            guessButton.Visibility = Visibility.Visible;
        }
    }
}
