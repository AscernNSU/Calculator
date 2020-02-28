using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            numText.Background = Brushes.LightGray;
            EqualsButton.Focus(); // Make keyboard input available
        }

        double leftArg = 0, rightArg = 0;

        char operation = '0';

        bool nextArg = false;
        bool doneCalculations = false;
        bool exprWithDot = false;

        void addNum(int n) // When number buttons are clicked, add number to the numText
        {
            if ((numText.Text == "" || numText.Text == "0" || nextArg || doneCalculations) && !exprWithDot)
            {
                if (operation == '0')
                    leftArg = 0;
                numText.Text = n.ToString();
                nextArg = false;
            }
            else
                numText.Text += n.ToString();
            doneCalculations = false;
            if (!SignButton.IsEnabled)
                unlockButtons();
        }

        void decimalPressed()
        {
            SignButton.IsEnabled =
            AddButton.IsEnabled =
            SubtractButton.IsEnabled =
            MultiplyButton.IsEnabled = 
            DivideButton.IsEnabled = 
            SqrtButton.IsEnabled = 
            EqualsButton.IsEnabled = 
            false;
        }

        void unlockButtons()
        {
            SignButton.IsEnabled =
            AddButton.IsEnabled =
            SubtractButton.IsEnabled =
            MultiplyButton.IsEnabled =
            DivideButton.IsEnabled =
            SqrtButton.IsEnabled =
            EqualsButton.IsEnabled =
            true;
        }

        private void ZeroButtonClick(object sender, RoutedEventArgs e) // '0' Button
        {
            addNum(0);
        }

        private void OneButtonClick(object sender, RoutedEventArgs e) // '1' Button
        {
            addNum(1);
        }

        private void TwoButtonClick(object sender, RoutedEventArgs e) // '2' Button
        {
            addNum(2);
        }

        private void ThreeButtonClick(object sender, RoutedEventArgs e) // '3' Button
        {
            addNum(3);
        }

        private void FourButtonClick(object sender, RoutedEventArgs e) // '4' Button
        {
            addNum(4);
        }

        private void FiveButtonClick(object sender, RoutedEventArgs e) // '5' Button
        {
            addNum(5);
        }

        private void SixButtonClick(object sender, RoutedEventArgs e) // '6' Button
        {
            addNum(6);
        }

        private void SevenButtonClick(object sender, RoutedEventArgs e) // '7' Button
        {
            addNum(7);
        }

        private void EightButtonClick(object sender, RoutedEventArgs e) // '8' Button
        {
            addNum(8);
        }

        private void NineButtonClick(object sender, RoutedEventArgs e) // '9' Button
        {
            addNum(9);
        }

        private void AddClick(object sender, RoutedEventArgs e) // '+' Button
        {
            if (leftArg != 0) // Do calculations if left argument is not equal to zero
                EqualsClick(sender, e);
            leftArg = Double.Parse(numText.Text);
            operation = '+';
            nextArg = true;
            exprWithDot = false;
        }

        private void SubtractClick(object sender, RoutedEventArgs e) // '-' Button
        {
            if (leftArg != 0) // Do calculations if left argument is not equal to zero
                EqualsClick(sender, e);
            leftArg = Double.Parse(numText.Text);
            operation = '-';
            nextArg = true;
            exprWithDot = false;
        }

        private void MultiplyClick(object sender, RoutedEventArgs e) // 'x' Button
        {
            if (leftArg != 0) // Do calculations if left argument is not equal to zero
                EqualsClick(sender, e);
            leftArg = Double.Parse(numText.Text);
            operation = '*';
            nextArg = true;
            exprWithDot = false;
        }

        private void DivideClick(object sender, RoutedEventArgs e) // '/' Button
        {
            if (leftArg != 0) // Do calculations if left argument is not equal to zero
                EqualsClick(sender, e);
            leftArg = Double.Parse(numText.Text);
            operation = '/';
            nextArg = true;
            exprWithDot = false;
        }
        
        private void CE_ButtonClick(object sender, RoutedEventArgs e) // 'CE' Button
        {
            leftArg = 0;
            rightArg = 0;
            doneCalculations = false;
            nextArg = false;
            exprWithDot = false;
            operation = '0';
            numText.Text = "0";
        }

        private void SqrtButtonClick(object sender, RoutedEventArgs e) // '√' Button
        {
            if (Double.Parse(numText.Text) >= 0)
                numText.Text = Math.Sqrt(Double.Parse(numText.Text)).ToString();
            else
                MessageBox.Show("Error: square root from negative number is not defined in real numbers!");
        }

        private void C_ButtonClick(object sender, RoutedEventArgs e) // 'C' Button
        {
            numText.Text = "0";
            exprWithDot = false;
        }

        private void PointButtonClick(object sender, RoutedEventArgs e)
        {
            if (!exprWithDot && !doneCalculations)
            {
                numText.Text += ",";
                exprWithDot = true;
            }
            decimalPressed();
        }

        private void SignButtonClick(object sender, RoutedEventArgs e) // '±' Button
        {
            numText.Text = (-1 * (Double.Parse(numText.Text))).ToString();
        }

        private void EqualsClick(object sender, RoutedEventArgs e) // '=' Button
        {
            if (!doneCalculations && leftArg != 0)
            {
                rightArg = Double.Parse(numText.Text);
                switch (operation)
                {
                    case '+':
                        numText.Text = (leftArg + rightArg).ToString();
                        break;
                    case '-':
                        numText.Text = (leftArg - rightArg).ToString();
                        break;
                    case '*':
                        numText.Text = (leftArg * rightArg).ToString();
                        break;
                    case '/':
                        if (rightArg != 0)
                            numText.Text = (leftArg / rightArg).ToString();
                        else
                            MessageBox.Show("Error: Dividing by zero!");
                        break;
                    default:
                        break;
                }
                leftArg = rightArg;
                rightArg = 0;
                doneCalculations = true;
                exprWithDot = false;
                operation = '0';
            }
        }

        private void KeyUpEvent(object sender, KeyEventArgs e) // Numpad implementation
        {
            switch (e.Key)
            {
                case Key.NumPad1:
                    addNum(1);
                    break;
                case Key.NumPad2:
                    addNum(2);
                    break;
                case Key.NumPad3:
                    addNum(3);
                    break;
                case Key.NumPad4:
                    addNum(4);
                    break;
                case Key.NumPad5:
                    addNum(5);
                    break;
                case Key.NumPad6:
                    addNum(6);
                    break;
                case Key.NumPad7:
                    addNum(7);
                    break;
                case Key.NumPad8:
                    addNum(8);
                    break;
                case Key.NumPad9:
                    addNum(9);
                    break;
                case Key.NumPad0:
                    addNum(0);
                    break;
                case Key.Add:
                    AddClick(sender, e);
                    break;
                case Key.Subtract:
                    SubtractClick(sender, e);
                    break;
                case Key.Multiply:
                    MultiplyClick(sender, e);
                    break;
                case Key.Divide:
                    DivideClick(sender, e);
                    break;
                case Key.Enter:
                    EqualsClick(sender, e);
                    break;
                case Key.Decimal:
                    PointButtonClick(sender, e);
                    break;
                default:
                    break;
            }
        }

    }
}
