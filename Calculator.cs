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
        public Queue<float> numbers = new Queue<float>();
        public Queue<string> operators = new Queue<string>();

        public Calculator()
        {
        }

        public float addition(float x, float y)
        {
            return x + y;
        }
        
        public float subtraction(float x, float y)
        {
            return x - y;
        }

        public float multiply(float x, float y)
        {
            return x * y;
        }

        public float divide(float x, float y)
        {
            return x / y;
        }

        public float modulus(float x, float y)
        {
            return x % y;
        }

        public float equals()
        {
            if (numbers.Count == 0 || operators.Count == 0)
            {
                return 0f;
            }

            float total = numbers.Dequeue();  //get first number
            while (numbers.Count != 0)
            {
                float number = numbers.Dequeue();
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
