using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays
{
    public class ArrayBasic
    {
        //* Passing an array as a parameter means the callee method can only access or manipulate the array data but cannot assign a new array object to the passed array reference.
        //Here Note is the caller, and ChangeReference is the callee.
        //* You can use th immediate window to view object memory address by using & and object name e.g. &nums
        //* Clone will provide a shallow copy which is suitable for one dimensional arrays. For a multi-dimensional array, you need to copy each and every element from the source array to the newarray. This is known as deep copy.
        //* Never compare reference type with == . Instead, use SequenceEqual with arrays
        public void Note()
        {
            var nums = new int[] { 1, 2, 3 };
            Console.WriteLine("[{0}]", string.Join(", ", nums));
            
            ChangeReference(nums); // no change after this executes
            Console.WriteLine("[{0}]", string.Join(",", nums)); // [1,2,3]

            //------------------Out-------------------
            //"Out" indicates to the compiler that the received array reference (in callee method) should be initialized before use and if you try to use the array reference before initialization then it will cause a compilation error.
            ChangeReference(out nums);
            Console.WriteLine("[{0}]", string.Join(",", nums)); // [4,5,6]

            //cannot pass nums as null
            //ChangeReference(out null);

            //------------------Ref-------------------
            //"Ref" is useful when one method wants to send data and receive modified data; it's two way communication. Whereas out is one way communication every time a reference should be initialized
            //Caller method can initialize the reference as null which will crash the application if you perform any operation which required a not-null reference
            //A method cannot be overloaded on the basis of ref and out
            
            PrintArray(ref nums);

            //compile time error, need to assign value to newNums
            //int[] newNums;
            //PrintArray(ref newNums);

            //Runtime error
            //int[] newNums = null;
            //PrintArray(ref newNums); 

            //cannot overload  between ref and out
            //void Print(ref int a)
            //void Print(out int a)

            //------------------Params-------------------
            //The params keyword allows us to receive any arbitrary number of parameters as an array.
            Total(20, 1, 2, 3, 3, 4, 5, 5);
        }

        private void Total(int expectedResult, params int[] items)
        {
            var sum = 0;
            foreach(var i in items)
            {
                sum += i;
            }

            Console.WriteLine("Equals: {0}", sum == expectedResult);
        }

        private void ChangeReference(int[] numbers)
        {
            Console.WriteLine("[{0}]", string.Join(",", numbers)); // [1,2,3]
            numbers = new int[] { 4, 5, 6 };
        }
        private void ChangeReference(out int[] numbers)
        {
            //No matter what numbers was, you have to initialize numbers here before you use it.
            numbers = new int[] { 4, 5, 6 };
        }

        private void PrintArray(ref int[] numbers)
        {
            Console.WriteLine("[{0}]", string.Join(",", numbers));
        }
    }
}
