using DataStructures.Arrays.Example1;
namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new Array(4);
            arr.Insert(1);
            arr.Insert(2);
            arr.Insert(3);
            arr.Insert(4);
            arr.RemoveAt(3);
            //arr.InsertAt(100, 0);
            //arr.InsertAt(100, 1);
            //arr.InsertAt(100, 2);
            //arr.InsertAt(100, 3);
            arr.Print();
            var arr2 = new Array(5);
            arr2.Insert(1);
            arr2.Insert(5);
            arr2.Insert(3);
            arr2.Print();
            var intersection = arr.Intersect(arr2);
            System.Console.WriteLine("---------------------");
            intersection.Print();
        }
    }
}
