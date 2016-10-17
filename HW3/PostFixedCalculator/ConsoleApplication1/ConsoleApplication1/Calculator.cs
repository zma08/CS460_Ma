using System;

namespace PostFixedCalculator
{
    class Calculator
    {
        private StackADT stack = new LinkedStack();
        //Main method for the app
        public static void Main()
        {
            Calculator app = new Calculator();
            bool play = true;
            while (play)//the calculate is a loop till user want to quit
            {
                play = app.doCalculation();
            }

            Console.Write("bye...");
        }

        private Boolean doCalculation()
        {
            Console.WriteLine("please enter q to quit");
            string input = "2 2 +";
            Console.Write(">>>> ");
            input = Console.ReadLine();
            //if user input a word startwith q case insensitive
            if (input.StartsWith("q") || input.StartsWith("Q")) { return false; }
            String output = "4";
            try
            {
                output = ePostFixInput(input);
            }
            catch (ArgumentException e)
            {
                output = e.Message;
            }


            Console.WriteLine("\n\t>>>{0} = {1}", input, output);

            return true;
        }

        private string ePostFixInput(string input)
        {
            if (input.Equals(" ") || input == null) //if user input is empty program will catch it as a exception
            { throw new ArgumentException(); }
            // make sure start the calculation with a clear stack
            stack.clear();
            //String.split(char del) will convert a string to an array holds string
            string[] inputStr = input.Split(' ');
            int i = inputStr.Length;// tracking the length of array
            int l = inputStr.Length;


            double a, b;
            double d;
            while (i > 0)
            {
                string test = inputStr[l - i];// start checking from the first element of the array
                if (Double.TryParse(test, out d))//try to parse the string to a double by Double.TryParse(string, out double) will return a boolean
                { stack.push(Convert.ToDouble(test)); }//if double confirmed then push it to our stack
                else//if it is not a number then it should be a operator + - * /...
                {
                    if (test.Length > 1) { throw new ArgumentException(); }//if it is a oprator then its length should be 1 or it is not an operator then throw
                    if (stack.isEmpty()) { throw new ArgumentException(); }//if it is a operator then we need number in our stack if there is no number to be operated then throw
                    a = Convert.ToDouble(stack.pop());//if there is number in stack pop it up
                    if (stack.isEmpty()) { throw new ArgumentException(); }//we at least need to 2 number in the stack to operated or throw
                    b = Convert.ToDouble(stack.pop());//pop the second number

                    stack.push(toCal(b, a, test));//do the calculation and push it back to the stack and repeat


                }

                i--;//moving to the next string in the array/input
            }

            return stack.pop().ToString();//eventully pop the number from the stack and it's the result
        }
        private double toCal(double a, double b, string c)
        {
            double s = 0.0;
            if (c == "+") { s = a + b; }
            else if (c == "-") { s = a - b; }
            else if (c == "*") { s = a * b; }
            else if (c == "/")
            {
                try { s = a / b; }
                catch (ArithmeticException e)//if devide by a zero then throw and catch it
                {
                    //Console.WriteLine(e.Message);
                    throw new DivideByZeroException(e.Message);
                }

            }


            else { throw new ArgumentException("improper input " + c + " is not one of + - * /"); }

            return s;
        }
    }
}