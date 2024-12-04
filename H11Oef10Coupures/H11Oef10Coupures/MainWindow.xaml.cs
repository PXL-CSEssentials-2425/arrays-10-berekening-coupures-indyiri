using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H11Oef10Coupures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            moneyTextBox.Clear();
            resultTextBox.Clear();
            moneyTextBox.Focus();
        }

        string inputMoney;
        double money;

        double[] moneyOptions = new double[] {500.00, 100.00, 50.00, 20.00, 10.00, 5.00, 2.00, 1.00, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01};
        int[] amountOfMoneyPieces = new int[14];

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();

            inputMoney = moneyTextBox.Text;
            bool isInputValid = double.TryParse(inputMoney, out money);

            money = Math.Round(money, 2);

            if (!isInputValid || money < 0)
            {
                MessageBox.Show("Voer een geldig bedrag is!","Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                moneyTextBox.Clear();
                moneyTextBox.Focus();
            }
            else
            {
                for (int i = 0; i <= moneyOptions.Length - 1; i++)
                {
                    amountOfMoneyPieces[i] = (int)(money / moneyOptions[i]);
                    money -= amountOfMoneyPieces[i] * moneyOptions[i];
                    money = Math.Round(money, 2);
                }

                for (int i = 0; i <= moneyOptions.Length - 1; i++)
                {
                    if (amountOfMoneyPieces[i] > 0)
                    {
                        resultTextBox.Text += $"{amountOfMoneyPieces[i]} stuk(s) van € {moneyOptions[i]:0.00} \n";
                    }
                }
            }   
        }
    }
}