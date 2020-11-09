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

namespace BasicCalculator
{
	public partial class MainWindow : Window
	{
		public double savedValue { get; set; } = 0;
		public string history { get; set; } = "";
		public string currentOperation { get; set; } = "";

		public int DigitNumber()
		{
			int count = 0;
			for (int i = 0; i < resultScreen.Text.Length; i++)
			{
				if (char.IsNumber(resultScreen.Text[i]))
				{
					count++;
				}
			}
			return count;
		}

		public void AppendDigit(string content)
		{
			if (content == "," && resultScreen.Text.Contains(","))
			{
				return;
			}

			if (content != ",")
			{
				if (resultScreen.Text.Length == 1 && resultScreen.Text.StartsWith("0"))
				{
					resultScreen.Text = "";
				}
				else if (!resultScreen.Text.Contains(","))
				{
					GiveDigitSpacing();
				}
			}

			resultScreen.Text += content;
			savedValue = Convert.ToDouble(resultScreen.Text.ToString());
		}

		private void GiveDigitSpacing()
		{
			StringBuilder sb = new StringBuilder(resultScreen.Text);
			for (int i = 0; i < sb.Length-1; i++)
			{
				if (sb[i] == ' ')
				{
					sb[i] = sb[i + 1];
					sb[i + 1] = ' ';
					i++;
				}
			}

			if (DigitNumber() % 3 == 0)
			{
				sb.Insert(1, " ");
			}

			resultScreen.Text = sb.ToString();
		}

		public MainWindow()
		{
			InitializeComponent();
		}

		public void DigitButtonClick(object sender, RoutedEventArgs e)
		{
			string digit = ((Button)sender).Content.ToString();
			AppendDigit(digit);
		}

		public void OperatorButtonClick(object sender, RoutedEventArgs e)
		{
			string operation = ((Button)sender).Content.ToString();
			double newValue = Convert.ToDouble(resultScreen.Text.ToString());
			updateHistory(operation);
			applyOperation(operation, newValue);
		} 

		public void applyOperation(string operation, double newValue)
		{
			switch (operation)
			{
				case "+":
					savedValue = savedValue + newValue;
					break;

				case "-":
					savedValue = savedValue - newValue;
					break;

				case "×":
					savedValue = savedValue * newValue;
					break;

				case "÷":
					savedValue = savedValue / newValue;
					break;

				case "1/x":
					savedValue = 1 / newValue;
					break;

				case "x^2":
					savedValue = newValue * newValue;
					break;

				case "√x":
					savedValue = Math.Sqrt(newValue);
					break;
				case "+/-":
					savedValue = - newValue;
					break;
				case "%":
					percentageOperation();
					break;

			}

		}
		public void percentageOperation()
		{

		}

		public void updateHistory(string operation)
		{

		}
	}
}
