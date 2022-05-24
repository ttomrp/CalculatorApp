using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private string[] operatorSymbols = { "+", "-", "*", "/", "%" };

        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Method called whenever an operator button is pressed.
         * Handles updating the operator_label text.
         */
        private void operator_press(string op)
        {
            string[] splitEquation = operation_textbox.Text.Split(' ');
            splitEquation = splitEquation.Where(symbol => !string.IsNullOrEmpty(symbol)).ToArray();
            string lastElement = splitEquation[splitEquation.Length - 1];

            if (operatorSymbols.Contains(lastElement))
            {
                //last element must be a number to perform any calculations
                MessageBox.Show("Cannot have two consecutive operators.", "ERROR!");
                return;
            }

            if (this.operation_textbox.Text == "")
            {
                MessageBox.Show("Cannot have null number.", "ERROR!");
                return;
            }

            DataTable dt = new DataTable();
            try
            {
                var result = dt.Compute(operation_textbox.Text, "");
                this.number_label.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Error in computation.  Resetting.", "ERROR!");
                this.number_label.Text = "0";
                this.operation_textbox.ResetText();
                return;
            }
            
            this.operation_textbox.Text = this.operation_textbox.Text + " " + op + " ";
        }

        //Method called when clear_button is pressed.  Resets text in number_label and operator_label.
        private void clear_button_Click(object sender, EventArgs e)
        {
            this.number_label.Text = "0";
            this.operation_textbox.ResetText();
        }

        private void zero_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "0";
        }

        private void one_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "1";
        }

        private void two_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "2";
        }

        private void three_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "3";
        }

        private void four_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "4";
        }

        private void five_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "5";
        }

        private void six_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "6";
        }

        private void seven_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "7";
        }

        private void eight_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "8";
        }

        private void nine_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + "9";
        }

        private void decimal_button_Click(object sender, EventArgs e)
        {
            this.operation_textbox.Text = this.operation_textbox.Text + ".";
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
            string[] splitEquation = operation_textbox.Text.Split(' ');
            string lastElement = splitEquation[splitEquation.Length - 1];

            if (operatorSymbols.Contains(lastElement))
            {
                //last element must be a number to perform any calculations
                MessageBox.Show("Cannot have two consecutive operators", "ERROR!");
                return;
            }
            if (this.operation_textbox.Text == "")
            {
                MessageBox.Show("Cannot have null number", "ERROR!");
                return;
            }

            DataTable dt = new DataTable();
            try
            {
                var result = dt.Compute(operation_textbox.Text, "");
                this.number_label.Text = result.ToString();
                this.operation_textbox.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Error in computation.  Resetting.", "ERROR!");
                this.number_label.Text = "0";
                this.operation_textbox.ResetText();
                return;
            }
        }
    }
}
