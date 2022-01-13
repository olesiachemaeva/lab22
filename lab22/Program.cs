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
            Console.WriteLine("Введите размерность");
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> func2 = new Action<Task<int[]>>(Metod1);
            Task task2 = task1.ContinueWith(func2);

            Action<Task<int[]>> func3 = new Action<Task<int[]>>(Metod2);
            Task task3 = task1.ContinueWith(func3);

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
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            return array;
        }
        static void Metod1(Task<int[]> task)
        {
            int[] array = task.Result;
            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i];
            }
            Console.WriteLine($"Сумма = {s}");
        }
        static void Metod2(Task<int[]> task)
        {
            int[] array = task.Result;
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine($"Максимальное число {max}");
        }

    }
        //static void PrintArrey(int[]array)
        //{
        //    for()
        //}












    }
}
