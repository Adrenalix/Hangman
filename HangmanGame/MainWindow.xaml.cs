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
        private GuessProcessor guessProcessor;
        private readonly WordFetcher wordFetcher;

        public MainWindow()
        {
            InitializeComponent();
            wordFetcher = new WordFetcher();
            FetchRandomWordAsync();
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
            string guess = guessTextBox.Text;
            guessTextBox.Clear();

            string message = guessProcessor.ProcessGuess(guess);
            messageTextBlock.Text = message;

            UpdateGuessedLettersDisplay();
            UpdateWordDisplay();
            UpdateHangman();
            CheckGameOver();
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
            string[] hangmanStages = new string[]
            {
                "",
                "O",          // Huvud
                "O\n|",       // Kropp
                "O\n/|",      // En arm
                "O\n/|\\",    // Två armar
                "O\n/|\\\n/", // Ett ben
                "O\n/|\\\n/ \\" // Två ben
            };

            if (guessProcessor.WrongGuesses >= hangmanStages.Length)
            {
                hangmanTextBlock.Text = hangmanStages[hangmanStages.Length - 1];
            }
            else
            {
                hangmanTextBlock.Text = hangmanStages[guessProcessor.WrongGuesses];
            }
        }

        private void CheckGameOver()
        {
            if (wordTextBlock.Text.Replace(" ", "") == guessProcessor.GuessedLetters)
            {
                messageTextBlock.Text = "Grattis, du vann!";
                guessButton.Visibility = Visibility.Collapsed;
                restartButton.Visibility = Visibility.Visible;
            }
            else if (guessProcessor.WrongGuesses >= 6)
            {
                messageTextBlock.Text = "Tyvärr, du förlorade!";
                guessButton.Visibility = Visibility.Collapsed;
                restartButton.Visibility = Visibility.Visible;
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            FetchRandomWordAsync();
            guessedLettersTextBlock.Text = "";
            hangmanTextBlock.Text = "";
            messageTextBlock.Text = "";
            restartButton.Visibility = Visibility.Collapsed;
            guessButton.Visibility = Visibility.Visible;
        }
    }
}
