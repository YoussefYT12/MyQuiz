

class Program
{
    static void Main(string[] args)
    {

        string directoryPath = @"D:\\Youssef\MyQuiz\\MyQuiz.Localization\\";
        if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
        {
            Console.WriteLine("Please provide a valid directory path.");
            return;
        }
        ModifyResourceDesignerFiles(directoryPath);


    }






    private static void ModifyResourceDesignerFiles(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            return;
        }

        var files = Directory.GetFiles(directoryPath, "*.Designer.cs", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("internal static"))
                {
                    lines[i] = lines[i].Replace("internal static", "public static");
                }
                else if (lines[i].Contains("internal"))
                {
                    lines[i] = lines[i].Replace("internal", "public");
                }
            }
            File.WriteAllLines(file, lines);



        }



    }
}

