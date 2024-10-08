using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
	class task2
	{
		static void Main(string[] args)
		{
			double x0, y0, r;
			
			string text = File.ReadAllText("Circle.txt");
			string[] lines = text.Split(new string[] { "\r\n", "\r", "\n", " " }, StringSplitOptions.None);

			x0 = Convert.ToDouble(lines[0]);
			y0 = Convert.ToDouble(lines[1]);
			r = Convert.ToDouble(lines[2]);

			string text2 = File.ReadAllText("Dots.txt");
			string[] lines2 = text2.Split(new string[] { "\r\n", "\r", "\n", " " }, StringSplitOptions.None);
			int j = 0;
			for (int i = 0; i < lines2.Length-1; i=i+2)
			{
				double x = Convert.ToDouble(lines2[i]);
				double y = Convert.ToDouble(lines2[i+1]);

				double h = Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0));// Рассчет гипотенузы
				if (h == Convert.ToDouble(r))
					Console.WriteLine("0"); // На окружности
				else if (h < r)
					Console.WriteLine("1"); // В окружности
				else
					Console.WriteLine("2"); // Вне окружности
			}
			Console.ReadKey();
		}
	}
}
