/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 06/10/2015
 * Время: 10:06
 */
using System;

namespace piramidDigit
{
	class Program
	{
		public static void Main(string[] args)
		{			
			
			// TODO: Implement Functionality Here
			int Height = 0;
			Console.WriteLine("Введите высоту пирамиды :");
			if (int.TryParse(Console.ReadLine(),out Height))
			{
				p = new Piramid(Height);
				Console.WriteLine("Высота пирамиды : {0} Количество элементов : {1} Количество путей : {2}",p.Height,p.Layers.Length, p.CountPath);
				p.PrintPiramid();
				p.CalcMaxPath();
				Console.Write("Press any key to continue . . . ");
			}
			else
			{
				Console.WriteLine("Введен не корректный символ!");
			}
			Console.ReadKey(true);
		}
		static Piramid p /*= new Piramid(11)*/;		
	}
}