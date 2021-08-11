using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StockSpan
    {
        public int[] GetStockSpanUsingStack(int[] prices)
        {
            var indices = new Stack<int>();
            var span = new int[prices.Length];
            span[0] = 1; //first is always 1
            indices.Push(0); //first index

            for(int i = 1; i < prices.Length; i++)
            {
                while (indices.Count > 0 && prices[indices.Peek()] <= prices[i])
                    indices.Pop();

                span[i] = indices.Count == 0 ? i + 1 : i - indices.Peek();
                indices.Push(i);
            }

            return span;
        }

        public int[] GetStockSpan(int[] prices)
        {
            var span = new int[prices.Length];
            span[0] = 1;

            for(int i = 1; i < prices.Length; i++)
            {
                span[i] = 1;
                for (int j = i - 1; j >= 0 && prices[j] <= prices[i]; j--)
                    span[i]++;
            }

            return span;
        }

        public int[] NextGreaterElement(int[] numbers)
        {
            var res = new int[numbers.Length];

            for(int i = 0; i < numbers.Length; i++)
            {
                var next = -1;
                for(int j = i + 1; j < numbers.Length; j++)
                {
                    if(numbers[j] > numbers[i])
                    {
                        next = numbers[j];
                        break;
                    }
                }
                res[i] = next;
            }
            return res;
        }

        public string Print(int[] input)
        {
            var builder = new StringBuilder();
            builder.Append("[");
            for(int i = 0; i < input.Length; i++)
            {
                builder.Append(input[i]);
                if (i != input.Length - 1)
                    builder.Append(", ");
            }
            builder.Append("]");

            return builder.ToString();
        }
    }
}
