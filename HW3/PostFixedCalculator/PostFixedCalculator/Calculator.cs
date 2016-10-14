using System;

namespace PostFixedCalculator
{
    class Calculator
    {
        private StackADT stack = new LinkedStack();

        public static void main()
        {

        }

        private Boolean doCalculation()
        {
            Console.WriteLine("please enter q to quit");
            string input = "2 2 +";
            Console.Write("> ");
            input = Console.ReadLine();
            
            if(input.StartsWith("q") || input.StartsWith("Q") ){ return false; }
            String output = "4";
            try
            {
                output = ePostFixInput(input);
            }
            catch(ArgumentException e)
            {
                output = e.Message;
            }
            Console.WriteLine("\n\t{0}={1}", input, output);
            return true;
        }

        private string ePostFixInput(string input)
        {
            throw new NotImplementedException();
        }
    }
}