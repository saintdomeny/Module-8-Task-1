namespace Module_8_Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                deleteFolder(path);
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }

        }
        private static void deleteFolder(string folder)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo f in fi)
                {
                    if (DateTime.Now - f.LastAccessTime > TimeSpan.FromMinutes(30) && f.Exists) 
                    {
                        f.Delete();
                    }
                }
                foreach (DirectoryInfo df in diA)
                {
                    if (df.Exists)
                    {
                        deleteFolder(df.FullName);
                    }
                    else
                    {
                        Console.WriteLine("Папки не существует");
                    }

                }
                if (di.GetDirectories().Length == 0 && di.GetFiles().Length == 0) di.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}