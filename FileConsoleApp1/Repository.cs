using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                    int.TryParse(splitText[0], out int empId);
                    DateTime.TryParse(splitText[1], out DateTime DateTA);
                    int.TryParse(splitText[5], out int age);
                    double.TryParse(splitText[6], out double height);
                    DateTime.TryParse(splitText[7], out DateTime dateBirth);

                    Employees employees = new Employees
                    {
                        EmployeeId = empId,
                        DateTimeAdd = DateTA,
                        FirstName = splitText[2],
                        Name = splitText[3],
                        LastName = splitText[4],
                        Age = age,
                        Height = height,
                        DateBirth = dateBirth,
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

                    if (int.TryParse(splitText[0], out int empId) && empId == targetId)
                    {
                        DateTime.TryParse(splitText[1], out DateTime DateTA);
                        int.TryParse(splitText[5], out int age);
                        double.TryParse(splitText[6], out double height);
                        DateTime.TryParse(splitText[7], out DateTime dateBirth);

                        Employees employees = new Employees
                        {
                            EmployeeId = empId,
                            DateTimeAdd = DateTA,
                            FirstName = splitText[2],
                            Name = splitText[3],
                            LastName = splitText[4],
                            Age = age,
                            Height = height,
                            DateBirth = dateBirth,
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

                    if (int.TryParse(splitText[0], out int empId) && empId == targetId)
                    {
                        DateTime.TryParse(splitText[1], out DateTime DateTA);
                        int.TryParse(splitText[5], out int age);
                        double.TryParse(splitText[6], out double height);
                        DateTime.TryParse(splitText[7], out DateTime dateBirth);

                        Employees employees = new Employees
                        {
                            EmployeeId = empId,
                            DateTimeAdd = DateTA,
                            FirstName = splitText[2],
                            Name = splitText[3],
                            LastName = splitText[4],
                            Age = age,
                            Height = height,
                            DateBirth = dateBirth,
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

                    if (DateTime.TryParse(splitText[7], out DateTime dateBirth) && dateBirth >= dateFrom && dateBirth <= dateTo)
                    {
                        int.TryParse(splitText[0], out int empId);
                        DateTime.TryParse(splitText[1], out DateTime DateTA);
                        int.TryParse(splitText[5], out int age);
                        double.TryParse(splitText[6], out double height);
                        ;
                        Employees employees = new Employees
                        {
                            EmployeeId = empId,
                            DateTimeAdd = DateTA,
                            FirstName = splitText[2],
                            Name = splitText[3],
                            LastName = splitText[4],
                            Age = age,
                            Height = height,
                            DateBirth = dateBirth,
                            PlaceBirth = splitText[8]
                        };
                        resultList.Add(employees);
                    }
                }
                resultList = resultList.OrderBy(x => x.DateBirth).ToList();
                return resultList.ToArray();
            }
        }

        public static bool EmptyFile(string path) 
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.Peek() == -1;
            }
        }
    }
}
