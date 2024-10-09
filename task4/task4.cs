using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
	class task4
	{
		static void Main(string[] args)
		{         
            if (args.Length != 1)
            {
                Console.WriteLine("Используйте: <Numb.txt>");
                return;
            }

            string inputFilePath = args[0];

            try
            {
                //Чтение чисел из файла
                string text = File.ReadAllText(inputFilePath);
                string[] NumbArray = text.Split(new string[] { " " }, StringSplitOptions.None);
                int[] nums = new int[NumbArray.Length];
                for (int i = 0; i < NumbArray.Length; i++)
                {
                    nums[i] = Convert.ToInt32(NumbArray[i]);
                }

                // Вычисление минимального количества ходов
                int minMoves = CalculateMinMoves(nums);

                Console.WriteLine($"Минимальное количество ходов: {minMoves}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static int CalculateMinMoves(int[] nums)
        {
            // Находим медиану
            Array.Sort(nums);
            int median = nums[nums.Length / 2];

            // Вычисляем количество ходов
            return nums.Sum(num => Math.Abs(num - median));
        }
    }
}

