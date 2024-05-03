using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConsoleApp1
{
    internal class FileWork
    {
        public static void CreateFileAndWrite(string path)
        {

            if (File.Exists(path))
            {
                Console.WriteLine("Файл существует");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    Console.WriteLine("Файл создан");
                }
            }
        }

        public static void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string textFile = sr.ReadLine();
                    string splitText = textFile.Replace("#", " ");
                    Console.WriteLine(splitText);
                }
            }
        }
        public static void WriteFile(string path)
        {

            Console.WriteLine("Введите через пробел Ф.И.О, возраст, рост, дату рождения, место рождения. ");
            string inputUser = Console.ReadLine();

            string[] splitText = inputUser.Split(" ");

            string firstName = splitText[0];
            string name = splitText[1];
            string lastName = splitText[2];
            int age = int.Parse(splitText[3]);
            double height = double.Parse(splitText[4]);
            DateTime dateBirth = DateTime.Parse(splitText[5]);
            string placeBirth = splitText[6];

            Employees employees = new Employees(firstName, name, lastName, age, height, dateBirth, placeBirth);

            using (StreamReader sw = new StreamReader(path))
            {
                string textFile = null;
                while (!sw.EndOfStream)
                {
                    textFile = sw.ReadLine();
                }
                string[] textFileLastLine = textFile.Split("#");

                if (int.TryParse(textFileLastLine[0], out int idEmp))
                {
                    employees.EmployeeId = idEmp;
                }
                else
                {
                    Console.WriteLine("Неверное ID.");
                }
            }
            using (StreamWriter sr = new StreamWriter(path, true))
            {

                sr.WriteLine($"{employees.EmployeeId + 1}#{employees.DateTimeAdd}#{employees.FirstName}#{employees.Name}#{employees.LastName}#{employees.Age}#{employees.Height}#{employees.DateBirth}#{employees.PlaceBirth}#");
                Console.WriteLine("Данные записаны в файл");
            }
            
        }
    }
}
