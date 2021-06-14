using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FunctionBuilder
{
	public class InputOutput
	{
		//создаёт относительный путь к фалйу
		private string GetPathToFile(string fileName)
		{
			string filePath = Environment.CurrentDirectory;
			filePath = filePath.Substring(0, filePath.IndexOf("bin")) + fileName;
			return filePath;
		}

		//считывает данные из файла и возвращает массив строк
		public string[] ReadFile()
		{
			string[] input = new string[4];
			string path = GetPathToFile("input.txt");
			int i = 0;
			foreach(string line in File.ReadLines(path))
			{
				input[i] = line;
				i++;
			}
			return input;
		}

		//В работе
		public void WriteInFile()
		{
			string path = GetPathToFile("output.txt");
			using (StreamWriter sw = new StreamWriter(path))
			{
				//sw.Write(content);	//запись данных
			}
		}

		
	}
}
