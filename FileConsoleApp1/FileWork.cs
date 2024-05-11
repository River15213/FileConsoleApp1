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

            Console.WriteLine("Введите через пробел Ф.И.О ");
            string inputUser = Console.ReadLine();

            string[] splitText = inputUser.Split(" ");

            if(splitText.Length < 3)
            {
                Console.WriteLine("Неправильный ввод ФИО");
                return;
            }
            string firstName = splitText[0];
            string name = splitText[1];
            string lastName = splitText[2];
            Console.WriteLine("Введите возраст ");
            inputUser = Console.ReadLine();
            int.TryParse(inputUser, out int age);

            Console.WriteLine("Введите рост ");
            double.TryParse(Console.ReadLine(), out double height);
            Console.WriteLine("Введите дату рождения ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dateBirth);

            Console.WriteLine("Введите город проживания ");
            string placeBirth = Console.ReadLine();

            Employees employees = new Employees(firstName, name, lastName, age, height, dateBirth, placeBirth);

            using (StreamReader sw = new StreamReader(path))
            {
                string textFile = null;
                while (!sw.EndOfStream)
                {
                    textFile = sw.ReadLine();

                }
                if (textFile == null)
                {
                    textFile = "0#";
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
