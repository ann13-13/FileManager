using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkWithDirectoriesFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //каталоги диска С
            string dirName = "C:\\";
        
            int tabs0 = Console.WindowWidth - dirName.Length;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(dirName.PadLeft(dirName.Length + tabs0, '\0'));
            Console.ResetColor();
            if (Directory.Exists(dirName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Каталоги:");

                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);

                }
                Console.ResetColor();
                Console.WriteLine("\n=====\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Файлы:");
                string[] file = Directory.GetFiles(dirName);
                foreach (string s in file)
                {
                    Console.WriteLine(s);
                }
                Console.ResetColor();

            }
            //переход в подкаталог, который указывает пользователь
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nВведите название каталога, в который хотите перейти: ");
            string subdir = Console.ReadLine();
            string newDir = String.Concat(dirName, subdir);
            int tabs = Console.WindowWidth - newDir.Length;
            Console.WriteLine(newDir.PadLeft(newDir.Length + tabs, '\0'));
            Console.ResetColor();

            try
            {
                if (Directory.Exists(newDir))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Подкаталоги:");
                    string[] dir = Directory.GetDirectories(newDir);
                    foreach (string s in dir)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("\n=====\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Файлы:");
                    string[] file = Directory.GetFiles(newDir);
                    foreach (string s in file)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка.({ex})");
            }



        backChoice:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n\nВведите цифру, в соответствии с тем, что хотите сделать:");
            Console.ResetColor();
            Console.Write(
               "\n1.Остаться в данном каталоге(возможные команды:статистика по каталогам/файлам, создание/чтение файлов и тд.)" +
               "\n2.Перейти дальше(вниз по каталогу)." +
               "\n3.Вернуться к предыдущему списку каталогов." +
               "\n4.Получить системную информацию по дискам." +
               "\nОтвет: ");
             Console.ResetColor();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    goto choice;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Введите название каталога, в который хотите перейти:  ");
                    string subdirAppDate = Console.ReadLine();                    
                    newDir = newDir + @"\" + subdirAppDate;
                    int tabs2 = Console.WindowWidth - newDir.Length;
                    Console.WriteLine(newDir.PadLeft(newDir.Length + tabs2, '\0'));
                    Console.ResetColor();

                    try
                    {
                        if (Directory.Exists(newDir))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Подкаталоги:");
                            string[] dir = Directory.GetDirectories(newDir);
                            foreach (string s in dir)
                            {
                                Console.WriteLine(s);
                            }
                            Console.WriteLine("\n=====\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Файлы:");
                            string[] file = Directory.GetFiles(newDir);
                            foreach (string s in file)
                            {
                                Console.WriteLine(s);
                            }
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Произошла ошибка.({ex})");
                    }
                    goto backChoice;
                case 3:
                   

                   
                    DirectoryInfo parentDirectory = Directory.GetParent(newDir);
                    newDir = parentDirectory.FullName;
                    int tabs3 = Console.WindowWidth - newDir.Length;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(newDir.PadLeft(newDir.Length + tabs3, '\0'));
                    Console.ResetColor();
                    if (parentDirectory == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Произошла ошибка.");
                    }
                    
                    else
                    {                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Подкаталоги:");
                        string[] dir = Directory.GetDirectories(newDir);
                        foreach (string s in dir)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("\n=====\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Файлы:");
                        string[] file = Directory.GetFiles(newDir);
                        foreach (string s in file)
                        {
                            Console.WriteLine(s);
                        }
                        Console.ResetColor();
                    }
                    goto backChoice;
                case 4:
                    //инф-ция по дискам
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    DriveInfo[] drives = DriveInfo.GetDrives();

                    foreach (DriveInfo drive in drives)
                    {
                        Console.WriteLine($"\nНазвание: {drive.Name}");
                        Console.WriteLine($"Тип: {drive.DriveType}");
                        if (drive.IsReady)
                        {
                            Console.WriteLine($"Объем диска: {drive.TotalSize}");
                            Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                            Console.WriteLine($"Метка: {drive.VolumeLabel}");
                        }

                    }
                    Console.ResetColor();
                    goto backChoice;
                default:
                    Console.WriteLine("Некорректно введены данные, введите цифру.");
                    goto backChoice;
            }

        //выбор команды 
        choice:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\nВведите цифру, в соответствии с тем, что хотите сделать:");
            Console.ResetColor();
            Console.Write(
                 "\n1.Посмотреть статисику по файам." +
                 "\n2.Посмотреть статисику по каталогам." +
                 "\n3.Создать файл с типом данных: *.txt, *.csv." +
                 "\n4.Вернуться назад." +
                 "\n5.Прочитать файл/записать данные в файл" +
                 "\nОтвет: ");
             Console.ResetColor();
            int func = Convert.ToInt32(Console.ReadLine());
            switch (func)
            {
                case 1:
                    //статистика по файлам                                   
                    Console.Write("Введите имя файла(вместе с расширением): ");
                    string fail = Console.ReadLine();
                    string pathToFali = Path.Combine(newDir,fail);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    FileInfo fileInf = new FileInfo(pathToFali);
                    if (fileInf.Exists)
                    {
                        Console.WriteLine("Имя файла: {0}", fileInf.Name);
                        Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                        Console.WriteLine("Размер: {0}", fileInf.Length);
                        Console.WriteLine("Время последней записи: {0}", fileInf.LastWriteTime);
                        Console.WriteLine("Расширение файла: {0}", fileInf.Extension);
                    } 
                    Console.ResetColor();
                    goto choice;
                case 2:
                    //статистика по каталогам
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    DirectoryInfo dirInfo = new DirectoryInfo(newDir);

                    Console.WriteLine($"Название каталога: {dirInfo.Name}");
                    Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
                    Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                    Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
                    Console.WriteLine("Время последней записи: {0}", dirInfo.LastWriteTime);
                    Console.ResetColor();
                    goto choice;

                case 3:
                    //Создать файл
                    try
                    {
                        using (FileStream fs = File.Create(newDir))
                        {
                            Console.Write("Назовите файл: ");
                            string nameFail = Console.ReadLine();
                            Console.WriteLine("Какой тип файла вы хотите создать? *.txt(1) *.csv(2)");
                            int type = int.Parse(Console.ReadLine());
                            switch (type)
                            {
                                case 1:
                                    string extensionTxt = ".txt";
                                    string path = String.Concat(nameFail, extensionTxt);
                                    if (!File.Exists(nameFail))
                                    {
                                        File.Create(path).Close();
                                        Console.WriteLine("Файл создан");
                                    }
                                    break;

                                case 2:
                                    string extensionCsv = ".csv";
                                    string path2 = String.Concat(nameFail, extensionCsv);
                                    if (!File.Exists(nameFail))
                                    {
                                        File.Create(path2).Close();
                                        Console.WriteLine("Файл создан");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Некорректно введены данные, введите цифру.");
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    goto choice;
                case 4:
                    goto backChoice;
                case 5:
                    goto doWithFile;
                default:
                    Console.WriteLine("Некорректно введены данные, введите цифру.");
                    goto backChoice;
            }
            doWithFile:
            Console.ForegroundColor = ConsoleColor.Blue;
            int tabs4 = Console.WindowWidth - newDir.Length;
            Console.WriteLine(newDir.PadLeft(newDir.Length + tabs4, '\0'));
            Console.ResetColor();
            Console.Write("Что хотите сделать с файлом?" +
                "\n1.записать данные" +
                "\n2.прочитать данные" +
                "\n3.вернуться назад" +
                "\nОтвет: ");
            int doing = int.Parse(Console.ReadLine());
            switch (doing)
            {
                case 1:
                    // добавляем инфу в файл
                    Console.Write("Введите полный путь до файла, в который вы хотите записать данные: ");
                    string pathWrite = Console.ReadLine();
                    Console.WriteLine("Введите строку для записи в файл: ");
                    string text = Console.ReadLine();
                    using (FileStream fstream = new FileStream($"{pathWrite}", FileMode.OpenOrCreate))
                    {
                        // преобразуем строку в байты
                        byte[] array = System.Text.Encoding.Default.GetBytes(text);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                        Console.WriteLine("Текст записан в файл!");
                    }
                    break;
                case 2:
                    //чтение файла
                    try
                    {
                        Console.Write("Введите название файла(с расширением): ");
                        string pathRead = Console.ReadLine();
                        string pathtoRead = Path.Combine(newDir, pathRead);
                        using (FileStream fstream = File.OpenRead(pathtoRead))
                        {
                            // преобразуем строку в байты
                            byte[] array = new byte[fstream.Length];
                            // считываем данные
                            fstream.Read(array, 0, array.Length);
                            // декодируем байты в строку
                            string textFromFile = Encoding.Default.GetString(array);
                            Console.WriteLine($"Текст из файла: {textFromFile}");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Нельзя прочесть файл:");
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 3:
                    goto choice;
                default:
                    break;
            }
        }
    }
}
