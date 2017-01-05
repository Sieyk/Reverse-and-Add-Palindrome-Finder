using System;
using System.Linq;
using System.Numerics;

/*
        Written by Matthew Muller, 2016
*/

namespace Pallindrome_Ints
{
    class Program
    {
        static void Main(string[] args)
        {

            //Obscene amounts of BigIntegers due to the nature of this problem involving very large numbers very often

            Console.Out.WriteLine("Please input a number to solve:");
            BigInteger input = BigInteger.Parse(Console.In.ReadLine()); //Is a BigInteger because this still works for very large numbers, it just make take awhile
            string prev = input.ToString(); //Used for the 'next' left side of the addition
            BigInteger left = input;    //Left hand side of the addition
            BigInteger right = input;   //Right hand side of the addition, is the left side reversed
            Console.Out.WriteLine("Please enter how frequently you would like to be updated; input 0 to not be updated until completion:");
            long iterFreq = long.Parse(Console.In.ReadLine());
            long iter = 0;

            for (; !prev.SequenceEqual(prev.Reverse()); iter++)
            {

                left = BigInteger.Parse(prev);  //Take the result of the previous iteration
                char[] temp = left.ToString().ToCharArray();    //Convert left to a char array and make that temp
                Array.Reverse(temp);    //Reverse temp
                right = BigInteger.Parse(new String(temp)); //Turn temp into a BigInteger by converting to a string, then a BigInteger
                prev = (left + right).ToString();   //Doing the addition then converting that to a string, because there's no reason for prev to not be a string
                if (iterFreq > 0 && iter % iterFreq == 0)   //The iteration feature
                {
                    Console.Out.WriteLine("Current iteration: " + (iter+1));
                    Console.Out.WriteLine(left + " + " + right + " = " + prev);
                }
            }

            Console.Out.WriteLine("Solution Found!");
            Console.Out.WriteLine(left + " + " + right + " = " + prev);

            Console.In.Read();
        }
    }
}