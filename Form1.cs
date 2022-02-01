using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2del2
{
    public partial class CalculatorForm : Form
    {
        string checkOperation="";
        double firstNumber;
        public double secondNumber;
        public double result;
        public CalculatorForm()
        {
            InitializeComponent();
        }
        /*
         
         ----Att-Göra----
        * Byt namn på alla knapper till typ btnClick så slipper man ha 10000funcktioner
        * Samma för operations maybz
        * validering;:D;DD;D;
        * Om nr överstiger max-int
        * Om man tar typ endast "55=" ska detta resultera i 55
        * fixa clearBtn som egen operation?
        * help-knapp som egen operation?
        * kör if(resultlabel.text.length-1 =="-") isyället för att ha contains för att kunna räkna
        * med negativa tal........
        * Fixa så att talet kan vara 0 och man fortfarande kan göra uträkningar
         */

        //Function that does all the calculations depending on which 
        //operation was clicked
        public void checkCalc()
        {
            try
            {
                secondNumber = double.Parse(TextBox.Text);
                if (ResultLabel.Text.Contains("-"))
                {
                    result = (firstNumber - secondNumber);
                }
                if (ResultLabel.Text.Contains("X"))
                {
                    result = (firstNumber * secondNumber);
                }
                if (ResultLabel.Text.Contains("/"))
                {
                    if (secondNumber == 0)
                    {
                        clearAll();
                        throw new Exception("Cannot divide by 0, please try again!");
                    }
                    result = (firstNumber / secondNumber);
                }
                if (ResultLabel.Text.Contains("+"))
                {
                    result = (firstNumber + secondNumber);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Error:\n{e.Message}");
            }
        }
        //Function that clears the form by resetting the values 
        public void clearAll()
        {
            TextBox.Text = "";
            ResultLabel.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
        }

        //Function that prints the number clicked onto the textbox and label.
        private void ButtonOne_Click(object sender, EventArgs e)
        {
            var btnCheck = (Button)sender;
            if (TextBox.Text == "0" && TextBox.Text != null)//TextBox.Text == "0" && 
            {
                TextBox.Text = btnCheck.Text;
                ResultLabel.Text = btnCheck.Text;
            }
            else
            {
                TextBox.Text += btnCheck.Text;
                ResultLabel.Text += btnCheck.Text;
            }
            checkCalc();
        }

        //Function that checks which operation is clicked
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                var btnCheck = (Button)sender;
                if (firstNumber != 0)
                {
                    firstNumber = result;
                    ResultLabel.Text = $"{result.ToString()} {btnCheck.Text} ";
                }
                else
                {
                    firstNumber = double.Parse(TextBox.Text);
                    ResultLabel.Text = $"{firstNumber.ToString()} {btnCheck.Text} ";
                }
                checkOperation = $"{btnCheck.Text}";

                TextBox.Text = "";
                if (result > double.MaxValue)
                {
                    throw new Exception("The result exceeded the maximum value, please try again");
                }
                if (checkOperation == "=")
                {
                    ResultLabel.Text = result.ToString();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show($"Error:\n{err.Message}");
            }
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
