namespace Module8.Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Path = @"C:\Downloads\123";

            ClearDirectory(Path);

        }

        static void ClearDirectory(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                if (Directory.Exists(path))
                {

                    foreach (var dir in directory.GetDirectories())
                    {

                        if ((DateTime.Now - Directory.GetLastAccessTime(dir.FullName)).TotalMinutes > 30)
                        {
                            Directory.Delete(dir.FullName, true);
                        }
                        else
                        {
                            ClearDirectory(dir.FullName);
                        }
                    }

                    foreach (var file in directory.GetFiles())
                    {

                        if ((DateTime.Now - Directory.GetLastAccessTime(file.FullName)).TotalMinutes > 30)
                        {
                            File.Delete(file.FullName);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Директория {path} отсутствует.");
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Директория не обнаружена! {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Отсутствует доступ! {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошибка: {e.Message}");
            }
        }
    }
}