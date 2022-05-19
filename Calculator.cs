using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{

    public class Calculator
        
    {
        public Queue<double> numbers = new Queue<double>();
        public Queue<string> operators = new Queue<string>();

        public Calculator()
        {
        }

        public double addition(double x, double y)
        {
            return x + y;
        }
        
        public double subtraction(double x, double y)
        {
            return x - y;
        }

        public double multiply(double x, double y)
        {
            return x * y;
        }

        public double divide(double x, double y)
        {
            return x / y;
        }

        public double modulus(double x, double y)
        {
            return x % y;
        }

        public double equals()
        {
            if (numbers.Count == 0 || operators.Count == 0)
            {
                return 0f;
            }

            double total = numbers.Dequeue();  //get first number
            while (numbers.Count != 0)
            {
                double number = numbers.Dequeue();
                string op = operators.Dequeue();

                // Note: currently does not follow PEMDAS order of operations,
                //       it follows the order of entry in the queue
                switch (op)
                {
                    case "+":
                        total = addition(total, number);
                        break;

                    case "-":
                        total = subtraction(total, number);
                        break;

                    case "*":
                        total = multiply(total, number);
                        break;

                    case "/":
                        total = divide(total, number);
                        break;

                    case "%":
                        total = modulus(total, number);
                        break;
                }
            }
            return total;
        }
    }
}
