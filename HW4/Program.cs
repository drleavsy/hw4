using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//using InputSimulator;
using WindowsInput;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select one of the following option: 1=Buble Sort, 2=Insertion Sort, 3=Stack, 4=Circular Buffer");
            Console.Write("Please enter your selection: ");
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_4);
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.RETURN);
            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                case "Bubble Sort":
                    bubble_sort();
                    break;
                case "2":
                case "Insertion Sort":
                    insertion_sort();
                    break;
                case "3":
                case "Stack":
                    stack_custom();
                    break;
                case "4":
                case "Circular Buffer":
                    circular_buffer();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3, or 4.");
                    break;
            }
            Console.WriteLine("Good!");
            Console.WriteLine("Press ENTER to quite");
            Console.Read();
        }
        // method that initialize array of the defined size
        static int[] InitArray(int sizeArr)
        {
            int[] array = new int[sizeArr];
            for(int i = 0; i < sizeArr; i++)
            {
                array[i] = - 1;
            }
            return array;
        }
        // method that read user input, validate it , and put in array
        static void fillArray(int[] arrayIn, int sizeIn)
        {
            string input;
            int i = 0;
            int elem = 0;
            //Random rnd = new Random();

            while (i < sizeIn)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out elem))
                {
                    arrayIn[i] = /*rnd.Next(9999);*/elem;
                    i++;
                }
                else
                {
                    Console.WriteLine("Enter the proper array element #", i, " again: ");
                }
            }
            foreach (var item in arrayIn)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine("\n");
        }
        static bool swapArr(int[] arrayIn, int sizeIn, int inx1, int inx2)
        {
            int temp1 = 0;
            int temp2 = 0;

            if (inx1 < sizeIn && inx2 < sizeIn) // check if index is array 
            {
                if (arrayIn[inx1] > arrayIn[inx2]) // check if 1st element is greater than 2nd
                {                                  // if yes swap and return true , if no - return false
                    temp1 = arrayIn[inx1];
                    temp2 = arrayIn[inx2];
                    arrayIn[inx1] = temp2;
                    arrayIn[inx2] = temp1;
                    return true;
                }
                else                              // if 2nd element is greater than 1st one: return false, no swap
                {
                    return false;
                }
            }
            return false; // if index is larger than array size 
        }

        static void bubble_sort()
        {
            int sizeIn = 0;
            int ind1 = 0; // start sorting from thr 1st element
            int ind2 = 1; // start comparison from the 2nd element
            int ind_last = 0;
            int swap_counter = 1;
            Console.WriteLine("Please write the array size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeIn)))
            {
                Console.WriteLine("Please enter proper array size again: ");
            }

            int[] arrayA = InitArray(sizeIn); // initialize array
            ind_last = sizeIn + 1; // initilize last first sorted index for buble sort: index until which sorting is done, above this index array will be sorted
                                   //  which means initially array is unsorted by default
            Console.WriteLine("Please enter array's elements one-by-one: ");
            fillArray(arrayA, sizeIn); // fill array with values from user input
            //Stopwatch sw = Stopwatch.StartNew(); // count time for buble sort
            while (swap_counter >= 0)
            {
                if (ind1 == ind_last || ind1 == sizeIn) // if we compared all elements in the array, then we go to the beginning of the array 
                {                   // and start comparison cycle all over again
                    if (swap_counter == 0)  // if at the end of array there were no any swaps, then 
                    {
                        break;
                    }
                    ind_last = ind1 - 1; // set index to the last sorted index 
                                         // (- 1 because even after the index was already sorted, it is incremented in the end of while loop)
                    ind1 = 0;       // start comparison cycle from the beginning of the array,
                    ind2 = 1;       // meaning reset all indexes--
                    swap_counter = 0;
                }
                if (ind2 < ind_last && swapArr(arrayA, sizeIn, ind1, ind2))
                {
                    swap_counter++;
                }
                ind1++;
                ind2++;
            }
            //sw.Stop();
            Console.WriteLine("Your buble sorted array is: ");
            foreach (var item in arrayA)
            {
                Console.Write(item.ToString() + " ");
            }
            //Console.WriteLine("Time taken: {0} ms \n", sw.Elapsed.TotalMilliseconds);
        }
        static void insertion_sort()
        {
            int sizeIn = 0;
            int ind1 = 0; // start sorting from thr 1st element
            int ind2 = 0; // start comparison from the 2nd element

            Console.WriteLine("Please write the array size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeIn)))
            {
                Console.WriteLine("Please enter proper array size again: ");
            }

            int[] arrayA = InitArray(sizeIn); // initialize array
            Console.WriteLine("Please enter array's elements one-by-one: ");
            fillArray(arrayA, sizeIn); // fill array with values from user input
            //Stopwatch sw = Stopwatch.StartNew(); // count time for insertion sort
            while (ind2 < sizeIn)
            {
                ind1 = ind2;
                ind2++;
                while (ind1 >= 0 && swapArr(arrayA, sizeIn, ind1, ind2))
                {
                    ind1--;
                    ind2--;
                }
            }
            //sw.Stop();
            Console.WriteLine("Your insertion sorted array is: ");
            foreach (var item in arrayA)
            {
                Console.Write(item.ToString() + " ");
            }
            //Console.WriteLine("Time taken: {0} ms \n", sw.Elapsed.TotalMilliseconds);
        }
        static void stack_custom()
        {
            int top = 0;
            // start sorting from thr 1st element
            int sizeIn = 0;
            Console.Write("Please write the stack size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeIn)))
            {
                Console.Write("Please write the stack size: ");
            }
            int[] arrayA = InitArray(sizeIn); // initialize array
            string str = ""; // for input from console
            int count = 0; // size of stack
            while (str != "q")
            {
                Console.WriteLine("Please select one of the following option: 1=push, 2=pop, q=quit");
                //Console.WriteLine("Please enter your selection: ");
                str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                    case "push":
                        // return true if stack is still not full, otherwise return false
                        if (stack_push(arrayA, sizeIn, ref top, ref count))
                        {
                            Console.Write("Your stack is: ");
                            print_stack(arrayA, sizeIn, count);// print the stack current status
                        }
                        else
                        {
                            Console.WriteLine("The stack is full");
                        }
                        break;
                    case "2":
                    case "pull":
                        int val;
                        // return true if stack is still not empty, otherwise return false
                        if (stack_pull(arrayA, sizeIn, ref top, out val, ref count))
                        {
                            Console.Write("Your stack is: ");
                            print_stack(arrayA, sizeIn, count); // print the stack current status
                            Console.WriteLine("The value pulled from top is: " + val);
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty ");
                        }
                        break;
                    case "q":
                    case "quite":
                        break;
                    default:
                        Console.Write("Invalid selection. ");
                        break;
                }
            }
        }
        static bool stack_push(int[] arrayIn, int sizeIn,ref int topIn, ref int count)
        {
            int val1 = 0;
            Console.Write("Please enter the value to push: ");
            while (!(int.TryParse(Console.ReadLine(), out val1))) // validate the input from console
            {
                Console.Write("Wrong value. Please enter the value to push: ");
            }
            if ((topIn < sizeIn) && topIn >= 0) // push if stack is not full
            {
                arrayIn[topIn] = val1; // push one element
                topIn++; // move cursor to the top of the stack
                count++; // increase the size of stack
                return true;
            }
            return false; // if stack full then return false
        }
        static bool stack_pull(int[] arrayIn, int sizeIn, ref int topIn, out int val1, ref int count)
        {
            if ((topIn <= sizeIn) && topIn > 0) // check if stack is not empty already
            {
                val1 = arrayIn[topIn-1];  // save value from the top and pass it out from the method 
                arrayIn[topIn - 1] = -1; // delete value 
                topIn--; // move top one step back
                count--;  // increase the size of the stack
                return true;
            }
            else if (topIn == 0 || sizeIn==0) // stack is empty
            {
                val1 = -1;
                return false;
            }
            val1 = -1;
            return false;
        }
        static void circular_buffer() // ring buffer method
        {
            int sizeIn = 0; // size of the array datastructure
            int tail = 0; // tail points to the first element to read/delete from the buffer
            int head = 0; // head points to the last element to write to the buffer
            Console.Write("Please write the circular buffer size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeIn)))
            {
                Console.Write("Wrong input. Please write the buffer size: ");
            }
            int[] arrayA = InitArray(sizeIn); // initialize array
            string str = "";
            int counter = 0; // the actual size of the buffer
            while (str != "q")
            {
                Console.WriteLine("\nPlease select one of the following option: 1=enqueue, 2=queue q=quit");
                str = Console.ReadLine();  // read user input from the console
                switch (str)
                {
                    case "1":
                    case "enqueue": // write new element to the buffer from the head
                        enqueueC_1(arrayA, sizeIn, ref tail, ref head, ref counter);
                        print_buf(arrayA, sizeIn, tail, head, counter);
                        break;
                    case "2":
                    case "queue": // delete first element from the buffer from the tail
                        queueC_1(arrayA, sizeIn, ref tail, ref head, ref counter);
                        print_buf(arrayA, sizeIn, tail, head, counter);
                        break;
                    case "q":
                    case "quit":
                        break;
                    default:
                        Console.Write("Invalid selection. ");
                    break;
                }
            }    
        }
        // write new element to the buffer from the head
        static void enqueueC_1(int[] arrayIn, int sizeIn, ref int tail, ref int head, ref int counter)
        {
            string input;
            int elem = 0;
            // read the new value to be inserted
            Console.Write("Please enter the value to enqueue (add new from head): ");
            input = Console.ReadLine();
            if (int.TryParse(input, out elem))
            {
                if (counter < sizeIn )  // check if the buffer is not full yet
                {
                    if (head < sizeIn)  // check if head index is less than the array size
                    {
                        arrayIn[head] = elem; // adding new element
                        head++; // move "writing" index one ste forward
                        counter++; // increase the size of buffer
                    }
                    else // if (head == sizeIn) , if head index reached the end of array
                    {
                        head = 0; // move the head "write index" to the beginning of the array
                        arrayIn[head] = elem; // add new element to the beginning of the array
                        counter++;// increase the size of buffer
                        head++; // move the head index to the 2nd cell of array, after the first one was already written
                    }
                }
                else
                {
                    Console.WriteLine("The buffer is full.");
                }
            }
            else
            {
                Console.WriteLine("Wrong input. Enter the buffer element again: ");
            }
        }
        // delete/read element from the buffer at the taill index
        static void queueC_1(int[] arrayIn, int sizeIn, ref int tail, ref int head, ref int counter)
        {
            if (counter <= sizeIn && counter > 0) // if the buffer in not empty
            {
                if (tail < sizeIn) // if the tail is less than the size of array
                {
                    arrayIn[tail] = -1; // remove element at the tail index (first index in the ring buffer)
                    tail++; // move tail step forward
                    counter--; // reduce the size of the buffer
                }
                else // if (tail == sizeIn)
                {
                    tail = 0; // if last removewas at the end of the array , then set tail to the beginning of the array
                    arrayIn[tail] = -1; // remove element under tail index
                    counter--; // reduce the size of buffer
                    tail++; // move tail one step forward
                }
            }
            else
            {
                Console.WriteLine("The buffer is empty.");
            }
        }
        // prints ring buffer
        static void print_buf(int[] arrayIn, int sizeIn, int tail, int head, int counterInner)
        {
            int i = tail;
            if(counterInner == 0) // if buffer is empty print [ ]
            {
                Console.Write("[ ]");
            }
            while (counterInner > 0)
            {
                if (i < sizeIn) // if printed element is less than the maximum of the array
                {
                    if (tail == i)
                    {
                        Console.Write("[ " + arrayIn[i]); // print the first element sof the buffer
                        i++;
                    }
                    else if (tail != i)
                    {
                        Console.Write(", " + arrayIn[i]); // middle element
                        i++;
                    }
                }
                else if (i >= sizeIn) // if index exceed the size of the array
                {
                    i = 0;
                    if (tail == sizeIn) // print start position of the buffer
                    {
                        Console.Write("[ " + arrayIn[i]);
                        i++;
                    }
                    else // print the middle elements of the buffer
                    {
                        Console.Write(", " + arrayIn[i]);
                        i++;
                    }
                }
                counterInner--; // reduce the size of printed array
                if (counterInner == 0)
                {
                    Console.Write(" ]");
                }
            }
        }
        // print the stack 
        static void print_stack(int[] arrayIn, int sizeIn, int counterInner)
        {
            int i = 0;
            if (counterInner == 0)
            {
                Console.Write("[ "); // beginning of the stack which is the same as 1st element in the array
            }
            while (counterInner > 0)
            {
                if (i == 0)
                {
                    Console.Write("[ " + arrayIn[i]); // print start of the stack
                    i++;
                }
                else
                {
                    Console.Write(", " + arrayIn[i]); // print middle of the stack
                    i++;
                }
                counterInner--; // reduce the size of the printed elements
            }
            Console.WriteLine(" ]"); // print the last element of the stack
        }
    }
}