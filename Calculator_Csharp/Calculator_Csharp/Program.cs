/** 
 * Created with Visual Studio Community 2017 for Mac Version 7.1 (build 1297). 
 * Author: 王瑞鹏 
 * Date: Sep 22 2017 
 * Filename: assignment_0922
 * Version: 1.0
 * Description: Simulation of simple calculator, calculate addition, subtraction, multiplication and division.
 */



using System;

namespace Calculator_Csharp
{
    class MainClass
    {
        public static void Main(string[] args) {

            //Get operator

            Console.WriteLine("Pealse input the operator:");
            string Operator = Console.ReadLine();

            //Get operands

            Console.WriteLine("Pealse input two number for calculate:");
            float number_1 = float.Parse(Console.ReadLine());
            float number_2;
            if (!float.TryParse(Console.ReadLine(), out number_2)) {
                Console.WriteLine("Not a valid float");
            }


            //Check operator

            switch (Operator) {
                case "+":
                    Addition addition = new Addition();
                    addition.additive(number_1, number_2);
                    break;
                case "-":
                    Subtraction subtraction = new Subtraction();
                    subtraction.subtractive(number_1, number_2);
                    break;
                case "*":
                    Multiplication mulitiplication = new Multiplication();
                    mulitiplication.mulitiplicative(number_1, number_2);
                    break;
                case "/":
                    Division divison = new Division();
                    divison.division(number_1, number_2);
                    break;

            }
        }
    }

    class Addition
    {
        private float addend;
        private float augend;
        public void additive(float addend, float augend) {
            this.addend = addend;
            this.augend = augend;
            Console.Write(addend + " + " + augend + " = " + (addend + augend));
        }
    }

    class Subtraction
    {
        private float minuend;
        private float subtrahend;
        public void subtractive(float minuend, float subtrahend) {
            this.subtrahend = subtrahend;
            this.minuend = minuend;
            Console.Write(minuend + " - " + subtrahend + " = " + (minuend - subtrahend));
        }
    }

    class Multiplication
    {
        private float multiplier;
        private float multiplicand;
        public void mulitiplicative(float multiplier, float multiplicand) {
            this.multiplier = multiplier;
            this.multiplicand = multiplicand;
            Console.Write(multiplier + " * " + multiplicand + " = " + multiplier * multiplicand);
        }
    }

    class Division
    {
        private float dividend;
        private float divisor;
        public void division(float dividend, float divisor) {
            this.dividend = dividend;
            this.divisor = divisor;
            // Throw exception: divisor is zero.
            try {
                Console.Write(dividend + " / " + divisor + " = " + dividend / divisor);
            }
            catch (DivideByZeroException e) {
                Console.WriteLine("Exception caught: {0}", e);
            }
        }
    }
}
