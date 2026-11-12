using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SumApp;

public partial class MainWindow : Window
{
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
        if (!long.TryParse(txtEnd.Text.Trim(), out long n) || n < 1)
        {
            lblResult.Foreground = Brushes.Red;
            lblResult.Text = "1 이상의 정수를 입력하세요.";
            return;
        }

        // 등차수열 합 공식 (큰 수에서도 빠르게): n(n+1)/2 — 오버플로 방지를 위해 decimal 사용
        decimal sum = (decimal)n * (n + 1) / 2;

        lblResult.Foreground = Brushes.Black;
        lblResult.Text = $"합계: {sum:N0}";
    }
}
