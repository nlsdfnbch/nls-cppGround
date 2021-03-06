using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = RandomArray(10, 10);
            arr = BubbleSort(arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            arr = RandomArray(10, 10);
            MergeSort(ref arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            arr = RandomArray(10, 10);
            arr = InsertionSort(arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            arr = RandomArray(10, 10);
            QuickSort(0, arr.Length-1, ref arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            Console.ReadKey();
        }

        private static int[] RandomArray(int arraySize, int maxNumber)
        {
            Random rand = new Random();
            int[] arr = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = rand.Next(0, maxNumber);
            }
            return arr;
        }

        // BubbleSort, with optimization
        private static int[] BubbleSort(int[] arr)
        {
            int l = arr.Length;
            bool cont = true;//initial value 1 to kick off while loop
            int tmp;

            int index = 1; //tracker for index
            while (cont)
            {
                cont = false;
                for (int i = 0; i < l - index; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // 
                        tmp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = tmp;
                        cont = true;
                    }
                }
                index++;
            }
            return arr;
        }

        // MERGE SORT
        public static void MergeSort(ref int[] arr)
        {

            if (arr.Length > 1)
            {
                int mid = Convert.ToInt32(arr.Length / 2); // should be modulo op, 

                int[] left = new int[mid];
                for (int i = 0; i <= left.Length - 1; i++)
                {
                    left[i] = arr[i];
                }

                int[] right = new int[arr.Length - mid];
                for (int i = mid; i <= arr.Length - 1; i++)
                {
                    right[i - mid] = arr[i];
                }

                MergeSort(ref left);
                MergeSort(ref right);

                arr = merge(ref left, ref right);
            }
        }

        private static int[] merge(ref int[] left, ref int[] right)
        {
            int[] newArr = new int[left.Length + right.Length];
            int indexLeft = 0;
            int indexRight = 0;
            int indexResult = 0;

            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] < right[indexRight])
                {
                    newArr[indexResult] = left[indexLeft];
                    indexLeft += 1;
                }
                else
                {
                    newArr[indexResult] = right[indexRight];
                    indexRight += 1;
                }
                indexResult += 1;
            }

            while (indexLeft < left.Length)
            {
                newArr[indexResult] = left[indexLeft];
                indexLeft += 1;
                indexResult += 1;
            }

            while (indexRight < right.Length)
            {
                newArr[indexResult] = right[indexRight];
                indexRight += 1;
                indexResult += 1;
            }

            return newArr;
        }

        // InsertionSort; Generic, Call by Value;
        public static T[] InsertionSort<T>(T[] inputarray, Comparer<T> comparer = null)
        {
            var equalityComparer = comparer ?? Comparer<T>.Default;
            for (var counter = 0; counter < inputarray.Length - 1; counter++)
            {
                var index = counter + 1;
                while (index > 0)
                {
                    if (equalityComparer.Compare(inputarray[index - 1], inputarray[index]) > 0)
                    {
                        var temp = inputarray[index - 1];
                        inputarray[index - 1] = inputarray[index];
                        inputarray[index] = temp;
                    }
                    index--;
                }
            }
            return inputarray;
        }

        // Quicksort 
        public static void sort(ref int[] array)
        {
            QuickSort(0, array.Length - 1, ref array);
        }
        private static void QuickSort(int left, int right, ref int[] data)
        {
            if (left < right)
            {
                int pivot = split(left, right, ref data);
                QuickSort(left, pivot - 1, ref data);
                QuickSort(pivot + 1, right, ref data);
            }
        }
        private static int split(int left, int right, ref int[] data)
        {
            int i = left;
            int j = right - 1;
            int pivot = data[right];

            do
            {
                //Search bigger element on the left
                while (data[i] <= pivot && i < right)
                    i += 1;

                //Search  smaller element on the right
                while (data[j] >= pivot && j > left)
                    j -= 1;

                if (i < j)
                {
                    // swap values
                    int z = data[i];
                    data[i] = data[j];
                    data[j] = z;
                }

            } while (i < j);

            if (data[i] > pivot)
            {
                //swap values
                int z = data[i];
                data[i] = data[right];
                data[right] = z;
            }
            return i;
        }
    }
}
