using System;
using System.Text;
using System.IO;

namespace FileReadExample;

class Program
{
    static void Main(string[] args)
    {
        string file_name = "names.txt";
        FileStream fs = new FileStream(file_name, FileMode.Open);
        StreamReader sr = new StreamReader(fs, Encoding.UTF8);
        while (!sr.EndOfStream)
        {
            string row = sr.ReadLine();
            System.Console.WriteLine($"{row}");
        }
        sr.Close();
        fs.Close();

        Console.ReadLine();
    }
}
