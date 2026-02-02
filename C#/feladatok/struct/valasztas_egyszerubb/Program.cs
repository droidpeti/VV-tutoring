namespace valasztas_egyszerubb;
class Program
{
    struct Jelolt
    {
        public int kerulet;
        public int szavazatok;
        public string vezeteknev;
        public string keresztnev;
        public string part;
    }

    static void Main(string[] args)
    {        
        // 1. Feladat
        Jelolt[] jeloltek = new Jelolt[100];
        int db = 0;

        string file = "szavazatok.txt";
        FileStream fs = new FileStream(file, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        while (!sr.EndOfStream)
        {
            string[] sor = sr.ReadLine().Split(" ");
            jeloltek[db++] = new Jelolt
            {
                kerulet = int.Parse(sor[0]),
                szavazatok = int.Parse(sor[1]),
                vezeteknev = sor[2],
                keresztnev = sor[3],
                part = sor[4]
            };
        }
        sr.Close();
        fs.Close();

        // 2. Feladat
        Console.WriteLine($"A helyhatósági választáson {db} képviselőjelölt indult.");


        // 3. Feladat
        Console.Write("Kérem a képviselőjelölt Vezetéknevét: ");
        string vezetek = Console.ReadLine();
        Console.Write("Kérem a képviselőjelölt Keresztnevét: ");
        string kereszt = Console.ReadLine();

        bool talalt = false;

        for (int i = 0; i < db; i++)
        {
            if (jeloltek[i].vezeteknev == vezetek && jeloltek[i].keresztnev == kereszt)
            {
                Console.WriteLine($"A jelölt {jeloltek[i].szavazatok} szavazatot kapott.");
                talalt = true;
                break;
            }
        }

        if (talalt == false)
        {
            Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
        }


        // 4. Feladat
        int osszSzavazat = 0;
        int jogosultak = 12345;

        for (int i = 0; i < db; i++)
        {
            osszSzavazat += jeloltek[i].szavazatok;
        }

        double arany = (double)osszSzavazat / jogosultak * 100;
        
        Console.WriteLine($"A választáson {osszSzavazat} állampolgár, a jogosultak {arany.ToString("0.00")}%-a vett részt.");


        // 5. Feladat
        // Itt lehet külön változókat is csinálni nekik
        int gyep = 0, hep = 0, tisz = 0, zep = 0, fuggetlen = 0;

        for (int i = 0; i < db; i++)
        {
            if (jeloltek[i].part == "GYEP") gyep += jeloltek[i].szavazatok;
            else if (jeloltek[i].part == "HEP") hep += jeloltek[i].szavazatok;
            else if (jeloltek[i].part == "TISZ") tisz += jeloltek[i].szavazatok;
            else if (jeloltek[i].part == "ZEP") zep += jeloltek[i].szavazatok;
            else fuggetlen += jeloltek[i].szavazatok;
        }

        // Kiíratásnál számoljuk a százalékot
        Console.WriteLine($"Gyümölcsevők Pártja= {((double)gyep / osszSzavazat * 100).ToString("0.00")}%");
        Console.WriteLine($"Húsevők Pártja= {((double)hep / osszSzavazat * 100).ToString("0.00")}%");
        Console.WriteLine($"Tejivók Szövetsége= {((double)tisz / osszSzavazat * 100).ToString("0.00")}%");
        Console.WriteLine($"Zöldségevők Pártja= {((double)zep / osszSzavazat * 100).ToString("0.00")}%");
        Console.WriteLine($"Független jelöltek= {((double)fuggetlen / osszSzavazat * 100).ToString("0.00")}%");


        // 6. Feladat
        Console.WriteLine("\n6. feladat");
        int maxSzavazat = -1;

        // 1. lépés: Megkeressük, mennyi a legtöbb szavazatok
        for (int i = 0; i < db; i++)
        {
            if (jeloltek[i].szavazatok > maxSzavazat)
            {
                maxSzavazat = jeloltek[i].szavazatok;
            }
        }

        // 2. lépés: Kiírunk mindenkit, akinek ennyi szavazata van
        for (int i = 0; i < db; i++)
        {
            if (jeloltek[i].szavazatok == maxSzavazat)
            {
                string partNev = jeloltek[i].part;
                if (partNev == "-") partNev = "független";
                
                Console.WriteLine($"{jeloltek[i].vezeteknev} {jeloltek[i].keresztnev} {partNev}");
            }
        }


        // 7. Feladat
        // Tudjuk, hogy 8 kerület van (1-től 8-ig)
        // Végigmegyünk a számokon 1-től 8-ig
        
        string kimenet = "kepviselok.txt";
        fs = new FileStream(kimenet, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        for (int k = 1; k <= 8; k++) // k = kerület száma
        {
            int keruletMax = -1;
            int nyertesIndex = -1;

            // Megkeressük az adott kerületben a legtöbb szavazatot
            for (int i = 0; i < db; i++)
            {
                if (jeloltek[i].kerulet == k)
                {
                    if (jeloltek[i].szavazatok > keruletMax)
                    {
                        keruletMax = jeloltek[i].szavazatok;
                        nyertesIndex = i; // Megjegyezzük, hogy HANYADIK elem a tömbben
                    }
                }
            }

            // Ha találtunk nyertest, kiírjuk
            if (nyertesIndex != -1)
            {
                Jelolt nyertes = jeloltek[nyertesIndex];
                string partNev = nyertes.part;
                if (partNev == "-") partNev = "független";

                sw.WriteLine($"{nyertes.kerulet} {nyertes.vezeteknev} {nyertes.keresztnev} {partNev}");
            }
        }
        sw.Close();
    }
}
