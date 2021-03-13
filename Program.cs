using System;
using System.Data;
using System.IO;

namespace SortingAlgoritms
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = Factory.RandomArray(20000);

            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}

            //Sorter.HeapSort(array);

            //foreach (var item in array)
            //{
            //Console.WriteLine(item);
            //}

            Logger.TestSorting(10, 10000, 10);
        }
    }

    abstract class Logger
    {
        static public void TestSorting(int start, int end, int step)
        {
            int[] array;

            DataTable rez = new DataTable();

            rez.Columns.Add("ELEMENTS", typeof(int));
            rez.Columns.Add("SORTING TYPE", typeof(string));
            rez.Columns.Add("ARRAY TYPE", typeof(string));
            rez.Columns.Add("OPERATIONS COUNT", typeof(int));

            for (int i = start; i < end+1; i+=step)
            {
                //UPPER
                array = Factory.UpperArray(i);
                rez.Rows.Add(i, "BUBBLE SORT", "UPPER ARRAY", Sorter.BubbleSort(array));
                array = Factory.UpperArray(i);
                rez.Rows.Add(i, "INSERT SORT", "UPPER ARRAY", Sorter.InsertSort(array));
                array = Factory.UpperArray(i);
                rez.Rows.Add(i, "SHELL SORT", "UPPER ARRAY", Sorter.ShellSort(array));
                array = Factory.UpperArray(i);
                rez.Rows.Add(i, "QUICK SORT", "UPPER ARRAY", Sorter.QuickSort(array));
                array = Factory.UpperArray(i);
                rez.Rows.Add(i, "HEAP SORT", "UPPER ARRAY", Sorter.HeapSort(array));

                //LOWER
                array = Factory.LowerArray(i);
                rez.Rows.Add(i, "BUBBLE SORT", "LOWER ARRAY", Sorter.BubbleSort(array));
                array = Factory.LowerArray(i);
                rez.Rows.Add(i, "INSERT SORT", "LOWER ARRAY", Sorter.InsertSort(array));
                array = Factory.LowerArray(i);
                rez.Rows.Add(i, "SHELL SORT", "LOWER ARRAY", Sorter.ShellSort(array));
                array = Factory.LowerArray(i);
                rez.Rows.Add(i, "QUICK SORT", "LOWER ARRAY", Sorter.QuickSort(array));
                array = Factory.LowerArray(i);
                rez.Rows.Add(i, "HEAP SORT", "LOWER ARRAY", Sorter.HeapSort(array));

                //RANDOM
                array = Factory.RandomArray(i);
                rez.Rows.Add(i, "BUBBLE SORT", "RANDOM ARRAY", Sorter.BubbleSort(array));
                array = Factory.RandomArray(i);
                rez.Rows.Add(i, "INSERT SORT", "RANDOM ARRAY", Sorter.InsertSort(array));
                array = Factory.RandomArray(i);
                rez.Rows.Add(i, "SHELL SORT", "RANDOM ARRAY", Sorter.ShellSort(array));
                array = Factory.RandomArray(i);
                rez.Rows.Add(i, "QUICK SORT", "RANDOM ARRAY", Sorter.QuickSort(array));
                array = Factory.RandomArray(i);
                rez.Rows.Add(i, "HEAP SORT", "RANDOM ARRAY", Sorter.HeapSort(array));

                //UNIQUE RANDOM
                array = Factory.RandomUniqueArray(i);
                rez.Rows.Add(i, "BUBBLE SORT", "RANDOM UNIQUE ARRAY", Sorter.BubbleSort(array));
                array = Factory.RandomUniqueArray(i);
                rez.Rows.Add(i, "INSERT SORT", "RANDOM UNIQUE ARRAY", Sorter.InsertSort(array));
                array = Factory.RandomUniqueArray(i);
                rez.Rows.Add(i, "SHELL SORT", "RANDOM UNIQUE ARRAY", Sorter.ShellSort(array));
                array = Factory.RandomUniqueArray(i);
                rez.Rows.Add(i, "QUICK SORT", "RANDOM UNIQUE ARRAY", Sorter.QuickSort(array));
                array = Factory.RandomUniqueArray(i);
                rez.Rows.Add(i, "HEAP SORT", "RANDOM UNIQUE ARRAY", Sorter.HeapSort(array));

                //UPPER COEF 0.3
                array = Factory.ArrayMixer(Factory.UpperArray(i), 0.3f);
                rez.Rows.Add(i, "BUBBLE SORT", "UPPER MIXED ARRAY", Sorter.BubbleSort(array));
                array = Factory.ArrayMixer(Factory.UpperArray(i), 0.3f);
                rez.Rows.Add(i, "INSERT SORT", "UPPER MIXED ARRAY", Sorter.InsertSort(array));
                array = Factory.ArrayMixer(Factory.UpperArray(i), 0.3f);
                rez.Rows.Add(i, "SHELL SORT", "UPPER MIXED ARRAY", Sorter.ShellSort(array));
                array = Factory.ArrayMixer(Factory.UpperArray(i), 0.3f);
                rez.Rows.Add(i, "QUICK SORT", "UPPER MIXED ARRAY", Sorter.QuickSort(array));
                array = Factory.ArrayMixer(Factory.UpperArray(i), 0.3f);
                rez.Rows.Add(i, "HEAP SORT", "UPPER MIXED ARRAY", Sorter.HeapSort(array));

                //LOWER COEF 0.3
                array = Factory.ArrayMixer(Factory.LowerArray(i), 0.3f);
                rez.Rows.Add(i, "BUBBLE SORT", "LOWER MIXED ARRAY", Sorter.BubbleSort(array));
                array = Factory.ArrayMixer(Factory.LowerArray(i), 0.3f);
                rez.Rows.Add(i, "INSERT SORT", "LOWER MIXED ARRAY", Sorter.InsertSort(array));
                array = Factory.ArrayMixer(Factory.LowerArray(i), 0.3f);
                rez.Rows.Add(i, "SHELL SORT", "LOWER MIXED ARRAY", Sorter.ShellSort(array));
                array = Factory.ArrayMixer(Factory.LowerArray(i), 0.3f);
                rez.Rows.Add(i, "QUICK SORT", "LOWER MIXED ARRAY", Sorter.QuickSort(array));
                array = Factory.ArrayMixer(Factory.LowerArray(i), 0.3f);
                rez.Rows.Add(i, "HEAP SORT", "LOWER MIXED ARRAY", Sorter.HeapSort(array));
            }

            ToCSV(rez, @"rez.csv");
        }

        public static void SaveArrayAsCSV<T>(T[] arrayToSave, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (T item in arrayToSave)
                {
                    file.Write(item + ", ");
                }
            }
        }

        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }

    abstract class Sorter
    {
        //BUBBLE SORT
        static public int BubbleSort(int[] items)
        {
            bool swapped;
            int operations = 0;

            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i-1] < items[i])
                    {
                        Swap(items, i - 1, i);
                        operations++;
                        swapped = true;
                    }
                }
            } while (swapped != false);

            return operations;
        }

        static void Swap(int[] items, int left, int right)
        {
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        //INSERT SORT
        static public int InsertSort(int[] items)
        {
            int sortedRangeEndIndex = 1;
            int operations = 0;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex] < (items[sortedRangeEndIndex - 1]))
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                    operations++;
                }

                sortedRangeEndIndex++;
            }

            return operations;
        }


        static private int FindInsertionIndex(int[] items, int valueToInsert)
        {
            for (int index = 0; index < items.Length; index++)
            {
                if (items[index].CompareTo(valueToInsert) > 0)
                {
                    return index;
                }
            }

            throw new InvalidOperationException("The insertion index was not found");
        }

        static private void Insert(int[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            int temp = itemArray[indexInsertingAt];
            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];

            for (int i = indexInsertingFrom; i > indexInsertingAt; i--)
            {
                itemArray[i] = itemArray[i - 1];
            }

            itemArray[indexInsertingAt + 1] = temp;
        }

        //SHELL SORT
        static public int ShellSort(int[] arr)
        {
            int i, j, pos = 3, temp, operations = 0;

            while (pos > 0)
            {
                for (i = 0; i < arr.Length; i++)
                {
                    j = i;
                    temp = arr[i];

                    while ((j >= pos) && (arr[j - pos] > temp))
                    {
                        arr[j] = arr[j - pos];
                        j = j - pos;
                        operations++;
                    }

                    arr[j] = temp;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }

            return operations;
        }

        //QUICK SORT
        static public int QuickSort(int[] items)
        {
            return quicksort(items, 0, items.Length - 1);
        }

        static private int quicksort(int[] items, int left, int right)
        {
            int operations = 1;
            Random rng = new Random();

            if (left < right)
            {
                int pivotIndex = rng.Next(left, right);
                int newPivot = partition(items, left, right, pivotIndex);

                operations += quicksort(items, left, newPivot - 1);
                operations += quicksort(items, newPivot + 1, right);
            }

            return operations;
        }

        static private int partition(int[] items, int left, int right, int pivotIndex)
        {
            int pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }

        //HEAP SORT
        static public int HeapSort(int[] arr)
        {
            int operations = 0;
            
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                operations+=heapify(arr, arr.Length, i);
            }
                
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                operations += heapify(arr, i, 0);
            }

            return operations;
        }
        static int heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
                return 1;
            }
            return 0;
        }
    }
    
    abstract class Factory
    {
        static bool inArray(int[] array, int number)
        {
            foreach (int item in array)
            {
                if (item == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static int[] UpperArray(int len)
        {
            int[] rez = new int[len];

            for (int i = 0; i < rez.Length; i++)
            {
                rez[i] = i;
            }

            return rez;
        }

        public static int[] LowerArray(int len)
        {
            int[] rez = new int[len];
            int j = rez.Length;

            for (int i = 0; i < rez.Length; i++)
            {
                j--;
                rez[i] = j;
            }

            return rez;
        }

        public static int[] RandomArray(int len)
        {
            int[] rez = new int[len];
            Random rand = new Random();

            for (int i = 0; i < rez.Length; i++)
            {
                rez[i] = rand.Next();
            }

            return rez;
        }

        public static int[] RandomUniqueArray(int len)
        {
            int[] rez = new int[len];
            Random rand = new Random();

            for (int i = 0; i < rez.Length; i++)
            {
                int num = rand.Next();
                while (inArray(rez, num))
                {
                    num = rand.Next();
                }
                rez[i] = num;
            }

            return rez;
        }

        public static int[] ArrayMixer(int[] rez, float coef)
        {
            int saved, index, saved2, index2;
            Random rand = new Random();

            for (int i = 0; i < rez.Length * coef/2; i++)
            {
                index = rand.Next(0, rez.Length);
                saved = rez[index];
                index2 = rand.Next(0, rez.Length);
                saved2 = rez[index];
                //Console.WriteLine($"{index} and {index2}");

                rez[index2] = saved;
                rez[index] = saved2;
            }
            
            return rez;
        }

    }
}
