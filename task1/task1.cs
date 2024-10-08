using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class task1
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите количество чисел в массиве: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите количество повторений массива: ");
			int m = Convert.ToInt32(Console.ReadLine());

			int[] arr;
			arr = new int[n]; // создание массива длины, заданной пользователем
			for (int i = 1; i < n + 1; i++)
			{
				arr[i-1] = i; // заполнение массива. i-1, так как массив начинается с индекса 0, а содержимое с 1
			}

			int current = 0;
			Console.WriteLine("Путь: ");
			do
			{
				Console.Write(arr[current]); //Вывод первого числа интервала
				current = (current + m - 1) % n; // расчет следующего первого числа нового интервала
												 // Индекс первого числа из изначального массива + сдвиг на количество цифр в интервале - 1, после высчитывается остаток от деления на длинну изначального массива
			} while (current != 0);

			Console.ReadKey();
		}
	}
}
