using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0; // size of array
            int minim = 0;
            int maxim = 0;

            Console.WriteLine("Please write the array size: ");
            // read the size of array from user input
            while ( !(int.TryParse(Console.ReadLine(), out size)) )
            {
               Console.WriteLine("Please enter proper array size again: ");
            }

            int[] arrayA = InitArray(size); // initialize array

            Console.WriteLine("Please enter array's elements one-by-one: ");
            fillArray(arrayA, size); // fill array with values from user input
            swapArray(arrayA, size, ref minim, ref maxim); // methods for searching minimal and maximal numbers

            Console.WriteLine("The minimum number is: " + minim);
            Console.WriteLine("The maximum number is: " + maxim);
            Console.WriteLine("Press ENTER to quite");
            Console.Read();
        }
        // method that initialize array of the defined size
        static int[] InitArray(int sizeArr)
        {
            int[] array = new int[sizeArr];
            return array;
        }
        // method that read user input, validate it , and put in array
        static void fillArray(int[] arrayIn, int sizeIn)
        {
            string input;
            int i = 0;
            int elem = 0;
            
            while(i < sizeIn)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out elem))
                {
                    arrayIn[i] = elem;
                    i++;
                }
                else
                {
                    Console.WriteLine("Enter the proper array element #" , i++ , " again: ");
                }
            }
        }
        // method compare each value in array between each other, and search, and return the minimum value and maximum in the array
        // this method takes refereneces to the minimum and maximum variables, and updates them according to the search results
        static void swapArray(int[] arrayInA, int sizeA, ref int minNum, ref int maxNum)
        {
            minNum = arrayInA[0];  // initialize min value with 
            maxNum = arrayInA[0];
            for (int i = 0; i < sizeA; i++) // set "reference index (i)" to the begining of the array , and iterate it
            {
                for (int j = 0; j < sizeA; j++) // iterate "moving index (j)" through the array until end 
                {
                    if (arrayInA[i] < arrayInA[j]) // if value under "reference index (i)" is less than "moving index (j)" then
                    {                              // make the value under "moving index (j)" a new maximum unless it is not smaller than the last maximum
                        if (maxNum < arrayInA[j])
                        {
                            maxNum = arrayInA[j];
                        }
                        else if(minNum > arrayInA[j]) // check if the "potential" maximum is not really a minimum
                        {
                            minNum = arrayInA[j];
                        }
                    }
                    else // if value under "reference index (i)" is more than one under "moving index (j)" then
                    {    // check if value under "moving index (j)" is a new minimum
                        if (minNum > arrayInA[j])
                        {
                            minNum = arrayInA[j];
                        }
                    }
                }
            }
        }
    }
}