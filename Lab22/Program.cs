using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static int rows;
        static int columns;
        static int[,] array;
        static int sum;
        static int max;

        static void CreateArray()
        {
            Console.WriteLine("\tПолученный массив:");
            Random random = new Random();
            array = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(-100, 100);
                    Console.Write("{0,5}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void ResultValues(Task task)
        {
            max = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sum += array[i, j];
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }
            Console.WriteLine("\n Сумма элементов массива: {0}, наибольшее значение: {1}", sum, max);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\tРабота с TPL\n");

            try
            {
                Console.Write(" Введите количество строк массива: ");
                rows = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Введите количество столбцов массива: ");
                columns = Convert.ToInt32(Console.ReadLine());
                
                Action action = new Action(CreateArray);
                Task task = new Task(action);
                task.Start();

                Action<Task> action1 = new Action<Task>(ResultValues);
                Task task1 = task.ContinueWith(action1);

                task1.Wait();
                Console.WriteLine("\n\tКонец программы.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\tВведите числовое значение!");
            }
            Console.ReadKey();
        }
    }
}
