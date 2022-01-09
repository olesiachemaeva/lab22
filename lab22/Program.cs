using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*Сформировать массив случайных целых чисел (размер  задается пользователем). 
    Вычислить сумму чисел массива и максимальное число в массиве.  
    Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.*/

namespace lab22
{
    class Program
    {
        static void Main(string[] args)

        {
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

 Action<Task<int>> func2 = new Action<Task<int>>(Metod1);
            Task task2 = task1.ContinueWith<int[]>(Action);
            task2.Start();


            Func<Task<int[]>, int[]> func3 = new Func<Task<int[]>, int[]>(Metod2);
            Task<int[]> task3 = task2.ContinueWith<int[]>(func3, array);
            task3.Start();





            task1.Start();
            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)

            {
                array[i] = random.Next(0, 98);
            }
            return array;
        }
        static int[] Metod1(Task <int>  task)
        {
            Console.WriteLine("сумма чисел массива...");
            int n = task.Result;
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                s += i;
                Thread.Sleep(200);
            }
            Console.WriteLine($"Сумма = {s}");
            return n;
        }
        static int[] Metod2(Task <int[]> task)
        {
            int[] array = task.Result;
            int max = (int)array[0];
            for (int i = 0; i > array; i++)
            {
                if (arrey[i] > max)
                {
                    max = array[i];

                }
            }
            
            Console.WriteLine($"Максимальное число  + {array}");
            return array;

        }
        //static void PrintArrey(int[]array)
        //{
        //    for()
        //}












    }
}
