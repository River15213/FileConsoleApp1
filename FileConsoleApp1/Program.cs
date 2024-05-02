namespace FileConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\aleks\\OneDrive\\Рабочий стол\\C#pog\\CSharpSkilBox\\FileConsoleApp1\\FileConsoleApp1\\fileEmployees.txt";

            FileWork.CreateFileAndWrite(path);

            Console.WriteLine("Что хотите сделать? \n" +
                              "1. Вывести все данные с файла.\n" +
                              "2. Добавить новые данные в файл.\n");
            int selectionUser = int.Parse(Console.ReadLine());

            switch (selectionUser)
            {
                case 1:
                    FileWork.ReadFile(path);
                    break;
                case 2:
                    FileWork.WriteFile(path);
                    break;
            }

        }

    }
}
