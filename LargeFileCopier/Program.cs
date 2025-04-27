using System.Diagnostics;

class Program
{
    static async Task Main()
    {
        string sourceFile = "test.dat";
        int sizeMB = 10240;
        CreateTestFile(sourceFile, sizeMB);
    }

    static void CreateTestFile(string path, int sizeMB)
    {
        byte[] buffer = new byte[1024 * 1024];
        Random rnd = new Random();

        using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        for (int i = 0; i < sizeMB; i++)
        {
            rnd.NextBytes(buffer);
            fs.Write(buffer, 0, buffer.Length);
        }
    }
}