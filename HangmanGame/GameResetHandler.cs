using System.Windows.Controls;
using HangmanGame;

public class GameResetHandler
{
    private readonly TextBlock guessedLettersTextBlock;
    private readonly TextBlock messageTextBlock;
    private readonly Button restartButton;
    private readonly Button guessButton;
    private readonly MainWindow mainWindow;

    public GameResetHandler(TextBlock guessedLettersTextBlock, TextBlock messageTextBlock, Button restartButton, Button guessButton, MainWindow mainWindow)
    {
        this.guessedLettersTextBlock = guessedLettersTextBlock;
        this.messageTextBlock = messageTextBlock;
        this.restartButton = restartButton;
        this.guessButton = guessButton;
        this.mainWindow = mainWindow;
    }

    public void ResetGame()
    {
        mainWindow.FetchRandomWordAsync();
        guessedLettersTextBlock.Text = "";
        messageTextBlock.Text = "";
        restartButton.Visibility = System.Windows.Visibility.Collapsed;
        guessButton.Visibility = System.Windows.Visibility.Visible;
    }
}