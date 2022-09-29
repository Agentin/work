using System;
using System.IO;

namespace HelloApp
{
    class Program
    {
        //задание 1
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }

            // создаем каталог для файла
            string path = @"C:\Users\Александр\Desktop\File";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            //File.Create(@"C:\Users\Александр\Desktop\File\note.txt");
         
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            // запись в файл
            using (FileStream fstream = new FileStream(@"C:\Users\Александр\Desktop\File\note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"C:\Users\Александр\Desktop\File\note.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
            File.Delete(@"C:\Users\Александр\Desktop\File\note.txt");
        }
    }
}