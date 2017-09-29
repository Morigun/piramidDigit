/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 06/10/2015
 * Время: 10:07
 */
using System;

namespace piramidDigit
{
	/// <summary>
	/// Description of Piramid.
	/// </summary>
	public class Piramid
	{		
		#region constructs
		/// <summary>
		/// Конструктор по умолчанию, умолчательное значение высоты пирамиды = 5
		/// </summary>
		public Piramid()
		{
			this.Height = 5;
			this.Layers = new int[this._height,(this._height*2)+1];
			this.CountPath = (int)Math.Pow(2,this._height);
			this._cp = new CheckedPath(this._height);
			this.SetValueLayers();
		}
		/// <summary>
		/// Конструктор создающий пирамидку
		/// </summary>
		/// <param name="height">Высота пирамиды(Кол-во слоев)</param>
		public Piramid(int height)
		{
			try
			{
				this.Height = height;
				this.Layers = new int[height,(height*2)+1];
				this.CountPath = (int)Math.Pow(2,this._height-1);
				this._cp = new CheckedPath(this._height);
				this.SetValueLayers();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		#endregion		
		#region private params
		/// <summary>
		/// Высота
		/// </summary>
		private int _height;
		/// <summary>
		/// Слои
		/// </summary>
		private int[,] _layers;
		/// <summary>
		/// Кол-во путей
		/// </summary>
		private int _count_path;
		/// <summary>
		/// Таблица путей
		/// </summary>
		private CheckedPath _cp;
		#endregion
		#region public params
		/// <summary>
		/// Высота
		/// </summary>
		public int Height
		{
			get { return this._height; }
			set { this._height = value; }
		}
		/// <summary>
		/// Слои
		/// </summary>
		public int[,] Layers
		{
			get { return this._layers; }
			set { this._layers = value; }
		}
		/// <summary>
		/// Количество путей
		/// </summary>
		public int CountPath
		{
			get { return this._count_path; }
			set { this._count_path = value; }
		}
		#endregion		
		#region private procedure
		/// <summary>
		/// Установка значений слоя
		/// </summary>
		void SetValueLayers()
		{			
			Random rnd = new Random(2);
			for(int i = 0; i < this._height; i++)
			{
				for(int j = 0; j < (this._height*2) + 1; j++)
				{
					if(i%2 == 0)
					{
						if(j%2 != 0 && (j > i && j < ((this._height*2)+1)-i))
							Layers[i,j] = rnd.Next(1,10);
						else
							Layers[i,j] = 0;
					}
					else
					{
						if(j%2 == 0 && (j > i && j < ((this._height*2)+1)-i))
							Layers[i,j] = rnd.Next(1,10);
						else
							Layers[i,j] = 0;
					}	
				}
			}
			rnd = null;
		}
		/// <summary>
		/// Следующий элемент
		/// </summary>
		/// <param name="w">Предыдущий элемент</param>
		/// <param name="p">Переход вправо или влево</param>
		/// <returns></returns>
		int GetNextEl(int w, int p)
		{
			if(p == 0)
				return w+1;
			else
				return w-1;
		}
		#endregion
		#region public procedure
		/// <summary>
		/// Напечатать пирамиду
		/// </summary>
		public void PrintPiramid()
		{
			for(int i = this._height-1; i >= 0; i--)
			{
				for(int j = (this._height*2); j >= 0; j--)
				{
					Console.Write(Layers[i,j]);
				}
				Console.WriteLine();
			}
		}
		/// <summary>
		/// Рассчет пути с максимальным весом
		/// </summary>
		public void CalcMaxPath()
		{
			int iTecPos = this._height, sum = 0, count = 0, MaxPath = 0, numPath = 0;
			string lengthPath = "";
			Console.WriteLine("Start time {0}",DateTime.Now.TimeOfDay);
			for (int z = 0; z < this.CountPath; z++)
			{
				iTecPos = this._height;
				count = 0;
				sum = 0;
				for(int x = this._height-1; x >= 0; x--)
				{
                    iTecPos = this.GetNextEl(iTecPos, _cp.Path[count]);
                    sum = sum + Layers[x,iTecPos-1];
                    count++;
				}
                if (MaxPath < sum)
				{
					MaxPath = sum;
					numPath = z;	
					lengthPath = _cp.GetPath();
				}
				_cp.NextPath();
			}	
			Console.WriteLine("End time {0}",DateTime.Now.TimeOfDay);			
			Console.WriteLine("MaxPath {0} NumPath {1} PATH {2}", MaxPath, numPath, lengthPath);
		}
		#endregion
	}
}
