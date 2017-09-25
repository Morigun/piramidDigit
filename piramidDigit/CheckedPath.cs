/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 06/16/2015
 * Время: 10:07
 */
using System;

namespace piramidDigit
{
	/// <summary>
	/// Description of CheckedPath.
	/// </summary>
	public class CheckedPath
	{
		#region constructs
		public CheckedPath(int i)
		{
			this.Path = new int[i];
		}
		#endregion
		#region params
		public int[] Path;
		#endregion
		#region private procedure
		private void SetLayer()
		{
			for(int x = 0; x < this.Path.Length; x++)
				this.Path[x] = 0;
		}
		#endregion
		#region public procedure
		public void NextPath()
		{
			for(int x = this.Path.Length-1; x >= 0; x--)
			{
				if(this.Path[x] == 0)
				{
					this.Path[x] = 1;
					break;
				}
				else
					this.Path[x] = 0; 
			}
		}
		public string GetPath()
		{
			string ret = "";
			foreach(int i in this.Path)
				ret = ret + i.ToString();
			return ret;
		}
		#endregion
	}
}
