using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms_Lab3
{
    public static class CommandGenerator
    {
        public static string[][] MakeMassives(int n)
        {
            string[][] arrays = new string[n][];
            for (int j = 0; j < n; j++)
            {
                arrays[j] = new string[j];
                arrays[j] = GenerateCommands(j);
            }
            return arrays;
        }
        public static string[] GenerateCommands(int size)
        {
            string[] array = new string[size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int commandType = random.Next(1, 6); 

                if (commandType == 1)
                {
                    
                    array[i] = "1,cat";
                }
                else
                {
                    // Добавляем команды Pop, Top, IsEmpty и Print по номеру команды
                    array[i] = commandType.ToString();
                }
            }

            return array;
        }
    }
}
