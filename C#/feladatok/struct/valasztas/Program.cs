namespace valasztas;

class Program
{

    public struct Jelolt
    {
        public int kerulet;
        public int szavazatok;
        public string vezeteknev;
        public string keresztnev;
        public string part;
    }

    public struct Part
    {
        public int szavazatok;
        public string nev;
    }

    public struct Kerulet
    {
        public int szam;
        public string nyertes_nev;
        public string nyertes_part;
        public int nyertes_szavazatok;
    }


    static void Main(string[] args)
    {
        // 1. Feladat
        Jelolt[] jeloltek = new Jelolt[100];
        int jelolt_szam = 0;
        string file = "szavazatok.txt";
        FileStream fs = new FileStream(file, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        while (!sr.EndOfStream)
        {
            string[] sor = sr.ReadLine().Split(" ");
            jeloltek[jelolt_szam++] = new Jelolt
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
        Console.WriteLine($"A helyhatósági választáson {jelolt_szam} képviselőjelölt indult.");

        // 3. Feladat
        Console.Write($"Kérem adja meg az ember nevét akit keres: ");
        string[] keresett_nev_split = Console.ReadLine().Split(" ");
        int keresett_index = -1;

        if(keresett_nev_split.Length >= 2)
        {
            for(int i = 0; i < jelolt_szam; i++)
            {
                if(keresett_nev_split[0] == jeloltek[i].vezeteknev && keresett_nev_split[1] == jeloltek[i].keresztnev)
                {
                    keresett_index = i;
                    break;
                }
            }
        }

        if (keresett_index != -1)
        {
            Console.WriteLine($"{jeloltek[keresett_index].vezeteknev} {jeloltek[keresett_index].keresztnev} {jeloltek[keresett_index].szavazatok} szavazatot kapott.");
        }
        else
        {
            Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
        }


        // 4. Feladat
        int jogosultak = 12345;
        int reszt_vett = 0;
        for(int i = 0; i < jelolt_szam; i++)
        {
            reszt_vett += jeloltek[i].szavazatok;
        }
        Console.WriteLine($"A választáson {reszt_vett} állampolgár, a jogosultak {(100*((float)reszt_vett/(float)jogosultak)).ToString("0.00")}%-a vett részt.");

        // 5. Feladat
        Part[] partok = new Part[100];
        int partszam = 0;

        for(int i = 0; i < jelolt_szam; i++)
        {
            // -1 -> nem szerepelt
            // különben a szerepel lesz az a szám amelyik indexen szerepelt
            int szerepel = -1;
            for(int j = 0; j < partszam; j++)
            {
                if(partok[j].nev == jeloltek[i].part)
                {
                    szerepel = j;
                    break;
                }
            }

            // Ha eddig nem szerepelt ez a párt, akkor hozzáadjuk a pártok tömbhöz
            if(szerepel == -1)
            {
                partok[partszam++] = new Part{
                    nev = jeloltek[i].part,
                    szavazatok = jeloltek[i].szavazatok
                };
                continue;
            }
            // Különben megnöveljük a talált pártnak a szavazatai számát
            partok[szerepel].szavazatok += jeloltek[i].szavazatok;
        }

        for(int i = 0; i < partszam; i++)
        {
            string nev = partok[i].nev;
            if(nev == "-")
            {
                nev = "Független jelöltek";
            }
            Console.WriteLine($"{nev} = {(100*((float)partok[i].szavazatok / (float)reszt_vett)).ToString("0.00")}%");
        }

        // 6. Feladat
        // Maximum keresés
        int max_szavazatok = jeloltek[0].szavazatok;
        for(int i = 1; i < jelolt_szam; i++)
        {
            if (max_szavazatok < jeloltek[i].szavazatok)
            {
                max_szavazatok = jeloltek[i].szavazatok;
            }
        }
        // A feladat kéri hogy ha több van mindegyiket kikell írni, ezért egy másik ciklusban kiírjuk azokat akik ennyi szavazatot kaptak
        Console.WriteLine("A legtöbb szavazatott kapott jelölt(ek)");
        for(int i = 0; i < jelolt_szam; i++)
        {
            if(max_szavazatok == jeloltek[i].szavazatok)
            {
                string part = jeloltek[i].part;
                if(part == "-")
                {
                    part = "független";
                }
                Console.WriteLine($"{jeloltek[i].vezeteknev} {jeloltek[i].keresztnev} {part}");
            }
        }
        // 7. Feladat
        Kerulet[] keruletek = new Kerulet[100];
        int kerulet_szam = 0;
        // Mint amikor a pártokat számoltuk meg, itt is ugyanúgy kell.
        for(int i = 0; i < jelolt_szam; i++)
        {
            // -1 -> nem szerepelt
            // különben a szerepel lesz az a szám amelyik indexen szerepelt
            int szerepel = -1;
            for(int j = 0; j < kerulet_szam; j++)
            {
                if(keruletek[j].szam == jeloltek[i].kerulet)
                {
                    szerepel = j;
                    break;
                }
            }

            // Ha eddig nem szerepelt ez a kerület, akkor hozzáadjuk a kerületek tömbhöz
            if(szerepel == -1)
            {
                keruletek[kerulet_szam++] = new Kerulet{
                    szam = jeloltek[i].kerulet,
                    nyertes_nev = jeloltek[i].vezeteknev + " " + jeloltek[i].keresztnev,
                    nyertes_part = jeloltek[i].part,
                    nyertes_szavazatok = jeloltek[i].szavazatok
                };
                continue;
            }
            // Különben megnézzük hogy a jelenleg vizsgált ember a kerületből több szavazatot ért-e el mint akit eddig tároltunk
            if(keruletek[szerepel].nyertes_szavazatok < jeloltek[i].szavazatok)
            {
                string partnev = jeloltek[i].part;
                if(partnev == "-")
                {
                    partnev = jeloltek[i].part;
                }
                keruletek[szerepel].nyertes_szavazatok = jeloltek[i].szavazatok;
                keruletek[szerepel].nyertes_part = partnev;
                keruletek[szerepel].nyertes_nev = jeloltek[i].vezeteknev + " " + jeloltek[i].keresztnev;
            }
        }

        // És kiíratjuk egy fájlba mindegyik kerületet
        string kimenet = "kepviselok.txt";
        fs = new FileStream(kimenet, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        // A feladat kéri, hogy a kerületek száma szerint rendezve kell rendezni őket, ehhez az Array.Sort-ot fogom használni
        // De használhatsz hozzá buburékrendezést, vagy bármilyen más rendező algoritmust is
        // Viszont az Array.Sort-hoz kell egy függvényt is megadni 2. paraméterben, hogy mi alapján rendezze, ez lesz nálam az Osszehasonlit
        // Mielőtt rendezni tudnánk Array.Sort-tal előtte kikell törölni az üres elemeket a tömbből, ezt az Array.Resize-al lehet

        Array.Resize(ref keruletek, kerulet_szam);
        Array.Sort(keruletek, Osszehasonlit);
        for(int i = 0; i < kerulet_szam; i++)
        {
            sw.WriteLine($"{keruletek[i].szam} {keruletek[i].nyertes_nev} {keruletek[i].nyertes_part}");
        }
        sw.Close();
        fs.Close();
    }

    static int Osszehasonlit(Kerulet x, Kerulet y)
    {
        if(x.szam > y.szam)
        {
            return 1;
        }
        else if(x.szam < y.szam)
        {
            return -1;
        }
        return 0;
    }
}
