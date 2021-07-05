using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays
{
    public class JaggedArray
    {
        public void Note()
        {
            //Jagged array can contain references to other arrays, and the sizes of other arrays can be different.
            //The elementts of jagged arrays are array references.
            //C# cannot do int[][] arr = new int[3][3] //throws an error
            //C# encourages the use of multi-dimensional arrays over jagged arrays because multi-dimensional arrays are more efficient, in terms of memory access and memory consumption.
            //Multi-dimensional arrays are optimized for memory access and consumption because they are stored in a continuous memory location. This can be an issue when there is no large memory block available for multi-dimensional array.
            //ref: https://www.pluralsight.com/guides/multidimensional-arrays-csharp

            //One way to initialize int[][]
            int[][] arr = new int[3][]
            {
                new int[] {1, 2},
                new int[] {3, 4},
                new int[] {5, 6}
            };

            //Another way to initialize int[][]
            int[][] arr2 = new int[3][];
            arr2[0] = new int[2] { 1, 2 };
            arr2[1] = new int[3] { 1, 2, 3 };
            //arr2[2] is null if not assigned.

            //Assign value
            arr[0][0] = 0;

            //One way to traverse int[][]
            foreach(var teams in arr)
            {
                foreach(var elements in teams)
                    Console.WriteLine(elements);
            }

            //Another way to traverse int[][]
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                    Console.WriteLine(arr[i][j]);
            }
        }

        private int[][] InitializeMatrix(int r, int c)
        {
            int[][] newMatrix = new int[r][];
            for (int i = 0; i < r; i++)
                newMatrix[i] = new int[c];

            return newMatrix;
        }

        //1. Check edge cases
        //2. Initialize a new matrix of r by c
        //3. Traverse the old matrix and assign each element to the new matrix.
        //4. During the traversal, keep 2 index. 1 for the row and the other for the column of the new matrix.
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            var total = mat.Length * mat[0].Length;
            if (r * c < total) //new matrix needs to be able to hold all elements of the old matrix.
                return mat;
            if (total % c != 0)
                return mat;
            if ((total / c) % r != 0)
                return mat;

            int[][] newMatrix = InitializeMatrix(r, c);
            var row = 0;
            var column = 0;
            foreach (var team in mat)
            {
                foreach (var element in team)
                {
                    if (column < c)
                    {
                        newMatrix[row][column] = element;
                        column++;
                    }
                    else
                    {
                        row++;
                        column = 0;
                        newMatrix[row][column] = element;
                        column++;
                    }
                }
            }

            return newMatrix;
        }

        public int[][] MatrixReshapeBetter(int[][] nums, int r, int c)
        {
            int n = nums.Length, m = nums[0].Length;
            if (r * c != n * m) return nums; //highlight.

            int[][] res = InitializeMatrix(r, c);
            for (int i = 0; i < r * c; i++) //highlight.
                res[i / c][i % c] = nums[i / m][i % m]; //highlight. 
            
            return res;
        }

        public string ToString(int[][] arr)
        {
            var builder = new StringBuilder();
            builder.Append("[");
            for(int i = 0; i < arr.Length; i++)
            {
                builder.Append("[");
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if (!IsLast(j, arr[i].Length))
                    {
                        builder.Append(arr[i][j]);
                        builder.Append(", ");
                    }
                    else
                        builder.Append(arr[i][j]);
                }
                builder.Append("]");
            }
            builder.Append("]");

            return builder.ToString();
        }

        private bool IsLast(int idx, int length)
        {
            return idx == length - 1;
        }
    }
}
