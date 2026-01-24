namespace FileReadStore;

class Program
{
    static void Main(string[] args)
    {

        string file_name = "fruits.txt";
        // Állíts be egy nagy méretet a tömbödnek, ahol biztos elfér az összes adat
        string[] fruits = new string[100];
        // Csinálj egy számlálót, ahol azt tároljuk hogy hány eleme lesz a tömbünknek
        int db = 0;
        FileStream fs = new FileStream(file_name, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        while (!sr.EndOfStream)
        {
            // A létrehozott számlálót használd a sorok eltárolásához, és ezt nőveld ahogy olvasod a fájlt
            string line = sr.ReadLine();
            fruits[db++] = line;
        }
        fs.Close();
        sr.Close();

        Console.WriteLine("A beolvasott gyümölcsök:");
        for(int i = 0; i < db; i++)
        {
            Console.WriteLine(fruits[i]);
        }
    }
}