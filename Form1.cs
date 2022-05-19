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
        //private string labelText = "";
        private readonly Calculator _calculator;

        public Form1()
        {
            InitializeComponent();
            _calculator = new Calculator();
        }

        private void number_press(string num)
        {
            if (this.number_label.Text == "0")
            {
                this.number_label.Text = num;
            }
            else
            {
                this.number_label.Text = this.number_label.Text + num;
            }
        }

        private void operator_press(string op)
        {
            if (this.operator_label.Text == "" && this.number_label.Text == "0")
            {
                return;
            }
            else
            {
                this.operator_label.Text = this.operator_label.Text + this.number_label.Text + " " + op + " ";
            }

            this.number_label.ResetText();
            
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            this.number_label.ResetText();
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

        private void equals_button_Click(object sender, EventArgs e)
        {
            string history = this.operator_label.Text + this.number_label.Text;
            string[] splitHistory = history.Split(' ');
            float number;

            foreach (string numberOrOperator in splitHistory)
            {
                if (float.TryParse(numberOrOperator, out number))
                {
                    _calculator.numbers.Enqueue(number);
                }
                else
                {
                    _calculator.operators.Enqueue(numberOrOperator);
                }
            }

            float result = _calculator.equals();
            this.number_label.Text = result.ToString();
            this.operator_label.ResetText();
        }
    }
}
