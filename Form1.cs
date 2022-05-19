using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private readonly Calculator _calculator;
        private string operationHistory;

        public Form1()
        {
            InitializeComponent();
            _calculator = new Calculator();
        }

        /*
         * Method called whenever a number button is pressed.
         * Handles updating the number_label text.
         */
        private void number_press(string num)
        {
            //max size of label is 15 chars
            if (this.number_label.Text == "0")
            {
                this.number_label.Text = num;
            }
            else
            {
                this.number_label.Text = this.number_label.Text + num;
            }
        }

        /*
         * Method called whenever an operator button is pressed.
         * Handles updating the operator_label text.
         */
        private void operator_press(string op)
        {
            if (this.number_label.Text == "")
            {
                MessageBox.Show("Cannot have null number", "ERROR!");
                return;
            }
            else if (this.operator_label.Text.Length < 56)
            {
                this.operator_label.Text = this.operator_label.Text + this.number_label.Text + " " + op + " ";
                operationHistory = operationHistory + this.number_label.Text + " " + op + " ";
            }
            else
            {
                int length = this.operator_label.Text.Length;
                int charsToRemove = this.number_label.Text.Length + 3;
                this.operator_label.Text = this.operator_label.Text.Substring(charsToRemove) + this.number_label.Text + " " + op + " ";
                
                operationHistory = operationHistory + this.number_label.Text + " " + op + " ";
            }

            this.number_label.Text = "0";
        }

        //Method called when clear_button is pressed.  Resets text in number_label and operator_label.
        private void clear_button_Click(object sender, EventArgs e)
        {
            this.number_label.Text = "0";
            this.operator_label.ResetText();
        }

        private void zero_button_Click(object sender, EventArgs e)
        {
            number_press("0");
        }

        private void one_button_Click(object sender, EventArgs e)
        {
            number_press("1");
        }

        private void two_button_Click(object sender, EventArgs e)
        {
            number_press("2");
        }

        private void three_button_Click(object sender, EventArgs e)
        {
            number_press("3");
        }

        private void four_button_Click(object sender, EventArgs e)
        {
            number_press("4");
        }

        private void five_button_Click(object sender, EventArgs e)
        {
            number_press("5");
        }

        private void six_button_Click(object sender, EventArgs e)
        {
            number_press("6");
        }

        private void seven_button_Click(object sender, EventArgs e)
        {
            number_press("7");
        }

        private void eight_button_Click(object sender, EventArgs e)
        {
            number_press("8");
        }

        private void nine_button_Click(object sender, EventArgs e)
        {
            number_press("9");
        }

        private void decimal_button_Click(object sender, EventArgs e)
        {
            number_press(".");
        }

        private void mod_button_Click(object sender, EventArgs e)
        {
            operator_press("%");
        }

        private void divide_button_Click(object sender, EventArgs e)
        {
            operator_press("/");
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            operator_press("*");
        }

        private void sub_button_Click(object sender, EventArgs e)
        {
            operator_press("-");
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            operator_press("+");
        }

        /*
         * Method called when equal_button is pressed.
         * Handles parsing the operation history and populating the calculator queues.
         * Calls Calculator.equals() to get the final result and displays it in number_label.
         */
        private void equals_button_Click(object sender, EventArgs e)
        {
            operationHistory = operationHistory + this.number_label.Text;
            string[] splitHistory = operationHistory.Split(' ');
            double number;
            double lastNumEntry;
            string lastOpEntry = "";

            foreach (string numberOrOperator in splitHistory)
            {
                if (double.TryParse(numberOrOperator, out number))
                {
                    if (lastOpEntry == "/" && number == 0)
                    {
                        MessageBox.Show("Cannot divide by zero", "ERROR!");
                        return;
                    }
                    _calculator.numbers.Enqueue(number);
                    lastNumEntry = number;
                }
                else
                {
                    _calculator.operators.Enqueue(numberOrOperator);
                    lastOpEntry = numberOrOperator;
                }
            }

            double result = _calculator.equals();
            this.number_label.Text = result.ToString();
            this.operator_label.ResetText();
        }
    }
}
