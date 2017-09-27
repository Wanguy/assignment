/** 
 * Created with Visual Studio Community 2017 for Mac Version 7.1 (build 1297). 
 * Author: 王瑞鹏 
 * Date: Sep 27 2017 
 * Filename: assignment_0922
 * Version: 1.1
 * Update: overload additive and subtractive.
 *         add function: connect character strings, remove characters from the other character string.
 * Description: Simulation of simple calculator, calculate addition, subtraction, multiplication and division.
 */



using System;

namespace Calculator_Csharp
{
    class MainClass
    {
        public static void Main(string[] args) {

            Console.WriteLine("Please enter the number to select the operation you want to do:");
            Console.WriteLine("1: Arithmetic operation\t 2: Characters operation");

            string select_number = Console.ReadLine();
            if (select_number == "1") {
                //Get operator

                Console.WriteLine("Please input the operator:");
                string Operator = Console.ReadLine();


                //Get operands

                Console.WriteLine("Please input two number for calculate:");
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

            if (select_number == "2") {
                Console.WriteLine("Please input the operator:");
                string Operator = Console.ReadLine();
                Console.WriteLine("Please input two character string:");
                string character_1 = Console.ReadLine();
                string character_2 = Console.ReadLine();
                switch (Operator) {
                    case "+":
                        Addition addition = new Addition();
                        addition.additive(character_1, character_2);
                        break;
                    case "-":
                        Subtraction subraction = new Subtraction();
                        subraction.subtractive(character_1, character_2);
                        break;
                }
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

        // overload: connect str_2 to str_1.
        public void additive(string str_1, string str_2) {
            Console.WriteLine(str_1 + str_2);
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

        // overload: remove the second string from the first string.
        public void subtractive(string str_1, string str_2) {
            char[] NewChar = str_2.ToCharArray();               // convert string to char array.
            string NewString = str_1.TrimEnd(NewChar);
            Console.WriteLine(NewString);
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
