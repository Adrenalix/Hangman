using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

public class HangmanFigure
{
    private readonly UIElement[] figureParts;

    public HangmanFigure(Canvas hangmanCanvas)
    {
        figureParts = new UIElement[]
        {
            (UIElement)hangmanCanvas.FindName("head"),
            (UIElement)hangmanCanvas.FindName("body"),
            (UIElement)hangmanCanvas.FindName("leftArm"),
            (UIElement)hangmanCanvas.FindName("rightArm"),
            (UIElement)hangmanCanvas.FindName("leftLeg"),
            (UIElement)hangmanCanvas.FindName("rightLeg")
        };
    }

    public void UpdateFigure(int wrongGuesses)
    {
        for (int i = 0; i < figureParts.Length; i++)
        {
            figureParts[i].Visibility = i < wrongGuesses ? Visibility.Visible : Visibility.Hidden;
        }
    }
}