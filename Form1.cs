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
        private string[] operatorSymbols = { "+", "-", "*", "/", "%" };

        // TODO: exception handling limits the number size

        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Method called to calculate current expression.
         * Follows PEMDAS order of operations.
         * Catches and displays exceptions thrown during calculation.
         * Returns a string of the calculated result.
         */
        private string Calculation(string expression)
        {
            if (expression == "")
            {
                MessageBox.Show("Cannot have null number", "ERROR!");
                return "ERROR";
            }

            string[] splitEquation = expression.Split(' ');
            splitEquation = splitEquation.Where(symbol => !string.IsNullOrEmpty(symbol)).ToArray();
            string lastElement = splitEquation[splitEquation.Length - 1];

            double check;
            if (!double.TryParse(lastElement, out check))
            {
                //last element must be a number to perform any calculations
                MessageBox.Show("Cannot have two consecutive operators", "ERROR!");
                return "ERROR";
            }

            try
            {
                DataTable dt = new DataTable();
                var dc = new DataColumn("Eval", typeof(double), expression);
                dt.Columns.Add(dc);
                dt.Rows.Add(0);
                double result = (double)(dt.Rows[0]["Eval"]);
                return result.ToString();
            }
            catch (Exception e)
            {
                var errorBuilder = new StringBuilder();
                errorBuilder.Append("Error in computation.  Resetting.");
                errorBuilder.AppendLine();
                errorBuilder.Append(e);
                errorBuilder.AppendLine();
                MessageBox.Show(errorBuilder.ToString(), "ERROR!");
                this.number_label.Text = "0";
                this.operation_textbox.ResetText();
                return "ERROR";
            }
        }

        /*
         * Method called whenever an operator button is pressed.
         * Handles updating the operation_textbox text.
         */
        private void operator_press(string op)
        {
            string result = Calculation(this.operation_textbox.Text);
            if (result == "ERROR")
            {
                return;
            }
            else
            {
                this.number_label.Text = result;
                this.operation_textbox.Text = this.operation_textbox.Text + " " + op + " ";
            }
        }

        /*
         * Method called when clear_button is pressed.
         * Resets text in number_label and operation_textbox.
         */
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

        private void sign_button_Click(object sender, EventArgs e)
        {
            string[] splitEquation = operation_textbox.Text.Split(' ');
            splitEquation = splitEquation.Where(symbol => !string.IsNullOrEmpty(symbol)).ToArray();
            string lastElement = splitEquation[splitEquation.Length - 1];
            int substringLength = operation_textbox.Text.Length - lastElement.Length;
            
            double num;
            if (double.TryParse(lastElement, out num))
            {
                num = -num;
                this.operation_textbox.Text = this.operation_textbox.Text.Substring(0, substringLength) + num;
            }
            else
            {
                return;
            }
        }

        /*
         * Method called when equal_button is pressed.
         * Updates number_label and operation_textbox.
         */
        private void equals_button_Click(object sender, EventArgs e)
        {
            string result = Calculation(this.operation_textbox.Text);
            if (result == "ERROR")
            {
                return;
            }
            else
            {
                this.number_label.Text = result;
                this.operation_textbox.Text = result;
            }
        }
    }
}
