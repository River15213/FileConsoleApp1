using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConsoleApp1
{
    internal class Repository
    {
        public static Employees[] GetAllWorkers(string path )
        {
            List<Employees> resultList = new List<Employees>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string textFile = sr.ReadLine();
                    string[] splitText = textFile.Split("#");

                    Employees employees = new Employees
                    {
                        EmployeeId = int.Parse(splitText[0]),
                        DateTimeAdd = DateTime.Parse(splitText[1]),
                        FirstName = splitText[2],
                        Name = splitText[3],
                        LastName = splitText[4],
                        Age = int.Parse(splitText[5]),
                        Height = double.Parse(splitText[6]),
                        DateBirth = DateTime.Parse(splitText[7]),
                        PlaceBirth = splitText[8]
                    };
                    resultList.Add(employees);
                }
            }
            return resultList.ToArray();
        }

        public static Employees[] GetWorkerById(string path,int targetId)
        {
            List<Employees> resultList = new List<Employees>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string textFile = sr.ReadLine();
                    string[] splitText = textFile.Split("#");

                    if (int.Parse(splitText[0]) == targetId) 
                    {
                        Employees employees = new Employees
                        {
                            EmployeeId = int.Parse(splitText[0]),
                            DateTimeAdd = DateTime.Parse(splitText[1]),
                            FirstName = splitText[2],
                            Name = splitText[3],
                            LastName = splitText[4],
                            Age = int.Parse(splitText[5]),
                            Height = double.Parse(splitText[6]),
                            DateBirth = DateTime.Parse(splitText[7]),
                            PlaceBirth = splitText[8]
                        };
                        resultList.Add(employees);
                    }                  
                }
                return resultList.ToArray();
            }
        }

        public static void DeleteWorker(string path, int targetId)
        {
            List<Employees> resultList = new List<Employees>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string textFile = sr.ReadLine();
                    string[] splitText = textFile.Split("#");

                    if (int.Parse(splitText[0]) != targetId)
                    {
                        Employees employees = new Employees
                        {
                            EmployeeId = int.Parse(splitText[0]),
                            DateTimeAdd = DateTime.Parse(splitText[1]),
                            FirstName = splitText[2],
                            Name = splitText[3],
                            LastName = splitText[4],
                            Age = int.Parse(splitText[5]),
                            Height = double.Parse(splitText[6]),
                            DateBirth = DateTime.Parse(splitText[7]),
                            PlaceBirth = splitText[8]
                        };
                        resultList.Add(employees);
                    }
                }
            }
            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var employees in resultList)
                {
                    sr.WriteLine($"{employees.EmployeeId}#{employees.DateTimeAdd}#{employees.FirstName}#{employees.Name}#{employees.LastName}#{employees.Age}#{employees.Height}#{employees.DateBirth}#{employees.PlaceBirth}#");
                }
                Console.WriteLine($"Сотрудник {targetId} удален.");
            }
        }

        public static Employees[] GetWorkersBetweenTwoDates(string path, DateTime dateFrom, DateTime dateTo)
        {
            List<Employees> resultList = new List<Employees>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string textFile = sr.ReadLine();
                    string[] splitText = textFile.Split("#");

                    if (DateTime.Parse(splitText[7]) >= dateFrom && DateTime.Parse(splitText[7]) <= dateTo)
                    {
                        Employees employees = new Employees
                        {
                            EmployeeId = int.Parse(splitText[0]),
                            DateTimeAdd = DateTime.Parse(splitText[1]),
                            FirstName = splitText[2],
                            Name = splitText[3],
                            LastName = splitText[4],
                            Age = int.Parse(splitText[5]),
                            Height = double.Parse(splitText[6]),
                            DateBirth = DateTime.Parse(splitText[7]),
                            PlaceBirth = splitText[8]
                        };
                        resultList.Add(employees);
                    }
                }
                resultList = resultList.OrderBy(x => x.DateBirth).ToList();
                return resultList.ToArray();
            }
        }
    }
}
