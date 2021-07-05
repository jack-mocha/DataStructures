using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays
{
    public class MultiDimentionalArray
    {
        public void Note()
        {
            //Multi-dimensional arrays are stored in a linear fashion as one long array. 
            //In memory, there will only be one single array which is logically separated into multiple dimensions of the same size (equal to the number of rows).

            int[,] arr =
            {
                { 1, 2, 3},
                { 4, 5, 6}
            };

            int[,] arr2D = new int[2, 3] //2 is the number of rows and 3 is the size of each row
            {
                { 1, 2, 3},
                { 4, 5, 6}
            };

            // 3D array.
            int[,,] arr3D = new int[,,] 
            { 
                { 
                    { 1, 2, 3 }, 
                    { 4, 5, 6 } 
                },
                { 
                    { 7, 8, 9 }, 
                    { 10, 11, 12 } 
                } 
            };

            //Length gives the number of elements in an array.
            var l = arr.Length; // 6
            
            //Rank gives the number of dimensions of an array.
            var r = arr.Rank; // 2

            //Traversal
            //GetLength gives number of elements of the dimension.
            //accessing element by arr[i, j]
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                    Console.WriteLine(arr[i, j]);
            }

            //You can also foreach multi-dimensional array to traverse each element
            foreach (var i in arr3D)
                Console.WriteLine(i);
        }
    }
}
