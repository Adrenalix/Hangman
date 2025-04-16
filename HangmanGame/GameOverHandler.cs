using System.Windows.Controls;
using System.Windows;

public class GameOverHandler
{
    private readonly TextBlock wordTextBlock;
    private readonly TextBlock messageTextBlock;
    private readonly Button guessButton;
    private readonly Button restartButton;

    public GameOverHandler(TextBlock wordTextBlock, TextBlock messageTextBlock, Button guessButton, Button restartButton)
    {
        this.wordTextBlock = wordTextBlock;
        this.messageTextBlock = messageTextBlock;
        this.guessButton = guessButton;
        this.restartButton = restartButton;
    }

    public void CheckGameOver(string guessedLetters, string wordToGuess, int wrongGuesses)
    {
        if (wordTextBlock.Text.Replace(" ", "") == guessedLetters)
        {
            messageTextBlock.Text = "Congratulations, You Won!";
            guessButton.Visibility = Visibility.Collapsed;
            restartButton.Visibility = Visibility.Visible;
        }
        else if (wrongGuesses >= 6)
        {
            wordTextBlock.Text = wordToGuess;
            messageTextBlock.Text = "Sorry, You Lost!";
            guessButton.Visibility = Visibility.Collapsed;
            restartButton.Visibility = Visibility.Visible;
        }
    }
}