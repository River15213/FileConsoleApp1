namespace FileConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"fileEmployees.txt";

            FileWork.CreateFileAndWrite(path);

            Console.WriteLine("Что хотите сделать? \n" +
                              "1. Вывести все данные с файла.\n" +
                              "2. Добавить новые данные в файл.\n" +
                              "3. Просмотр одной записи. Используя ID.\n" +
                              "4. Удаление записи. Используя ID.\n" +
                              "5. Загрузка записей в выбранном диапазоне дат.\n");
            int selectionUser = int.Parse(Console.ReadLine());

            switch (selectionUser)
            {
                case 1:
                    FileWork.ReadFile(path);
                    Console.WriteLine("___________________________________");
                    var listAllEmployess = Repository.GetAllWorkers(path);
                    foreach (var worker in listAllEmployess)
                    {
                        Console.WriteLine($"{worker.EmployeeId} Фамилия:{worker.FirstName} Имя:{worker.Name} Отчество:{worker.LastName} Возраст:{worker.Age} Рост:{worker.Height} Дата рождения:{worker.DateBirth} Город проживания:{worker.PlaceBirth}");
                    }
                    break;
                case 2:
                    FileWork.WriteFile(path);
                    break;
                case 3:
                    Console.WriteLine("Введите ID сотрудника для вывода: ");
                    int IdEmpoyessSelect = int.Parse(Console.ReadLine());
                    var listEmployessById = Repository.GetWorkerById(path, IdEmpoyessSelect);
                    foreach (var worker in listEmployessById)
                    {
                        Console.WriteLine($"{worker.EmployeeId} Фамилия:{worker.FirstName} Имя:{worker.Name} Отчество:{worker.LastName} Возраст:{worker.Age} Рост:{worker.Height} Дата рождения:{worker.DateBirth} Город проживания:{worker.PlaceBirth}");
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите ID сотрудника для удаления: ");
                    int IdEmployeesDelet = int.Parse(Console.ReadLine());
                    Repository.DeleteWorker(path, IdEmployeesDelet);
                    break;
                case 5:
                    Console.WriteLine("Введите диапозон даты от: ");
                    DateTime dateFromInput = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите диапозон даты до: ");
                    DateTime dateToInput = DateTime.Parse(Console.ReadLine());
                    var listSortDateBrith = Repository.GetWorkersBetweenTwoDates(path, dateFromInput, dateToInput);
                    
                    foreach(var worker in listSortDateBrith)
                    {
                        Console.WriteLine($"{worker.EmployeeId} Фамилия:{worker.FirstName} Имя:{worker.Name} Отчество:{worker.LastName} Возраст:{worker.Age} Рост:{worker.Height} Дата рождения:{worker.DateBirth} Город проживания:{worker.PlaceBirth}");
                    }
                    break;
            }

        }

    }
}
