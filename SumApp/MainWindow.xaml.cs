using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SumApp;

public partial class MainWindow : Window
{
    private static readonly Brush OkBg = Brush("#E8F0FE"), OkFg = Brush("#1967D2");
    private static readonly Brush ErrBg = Brush("#FCE8E6"), ErrFg = Brush("#D93025");

    private static Brush Brush(string hex) => (Brush)new BrushConverter().ConvertFromString(hex)!;

    public MainWindow()
    {
        InitializeComponent();
        txtEnd.Focus();
    }

    private void TxtEnd_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) Calculate();
    }

    private void BtnCalc_Click(object sender, RoutedEventArgs e) => Calculate();

    private void Calculate()
    {
        resultBox.Visibility = Visibility.Visible;

        if (!long.TryParse(txtEnd.Text.Trim(), out long n) || n < 1)
        {
            resultBox.Background = ErrBg;
            lblResult.Foreground = ErrFg;
            lblResult.Text = "1 이상의 정수를 입력하세요.";
            return;
        }

        // n(n+1)/2 — 오버플로 방지를 위해 decimal 사용
        decimal sum = (decimal)n * (n + 1) / 2;

        resultBox.Background = OkBg;
        lblResult.Foreground = OkFg;
        lblResult.Text = $"합계: {sum:N0}";
    }
}
