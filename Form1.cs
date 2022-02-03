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
        string resultHistory; //Variable that saves all calculations
        public CalculatorForm()
        {
            InitializeComponent();
        }
        /*
         
         ----Att-Göra----
        * validering;:D;DD;D;
         */

        //Function that does all the calculations depending on which 
        //operation was clicked
        public void checkCalc()
        {
            try
            {
                secondNumber = double.Parse(TextBox.Text); //Tries to parse the textbox text to a double
                                                           //and store it in secondNumber
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
                        throw new Exception("Cannot divide by 0, please try again!"); //Exception handling for /0
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
            try
            {
                var btnCheck = (Button)sender; //btnCheck represents the clicked button
                if (TextBox.Text == "0" && TextBox.Text != null)
                {
                    TextBox.Text = btnCheck.Text;
                    ResultLabel.Text = btnCheck.Text;
                }
                else
                {
                    TextBox.Text += btnCheck.Text;
                    ResultLabel.Text += btnCheck.Text;
                }
                resultHistory += " " + btnCheck.Text;
                checkCalc();
            }
            catch(Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
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
                    ResultLabel.Text = $"{result.ToString()} {btnCheck.Text} "; //Prints result and operation on the resultLabel
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
                resultHistory +=" "+ checkOperation;
            }
            catch(Exception err)
            {
                MessageBox.Show($"Error:\n{err.Message}");
            }
        }
        //If C is pressed...
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        //Function that prints the calculation history when "history" is clicked
        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{resultHistory} = {result.ToString()}");
        }
    }
}
