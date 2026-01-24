<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cars File Read</title>
</head>
<body>
    <h1>Cars</h1>
    <table>
        <thead>
            <tr>
                <?php 
                    // Fájl beolvasása
                    $file_name = "../files/cars.txt";
                    $file_contents = file($file_name, FILE_IGNORE_NEW_LINES);

                    // A seperator, az ami mentén el kell majd választani a mezőket
                    $seperator = ";";

                    /* 
                        Az explode azt csinálja a mint a többi programozási nyelvben a Split, a sperator mentén elválaszt egy stringet, és tömböt csinál belőle
                        A fájlunknak a legelső sorában van a fejléc, így ezt kiíratjuk
                        Ha nem a fájlban van tárolva a fejléc, akkor it csak simán kiíratod HTML-ben a mezőket
                    */
                    $header = explode($seperator, $file_contents[0]);

                    // For ciklusban kiíratjuk a táblázat fejlécébe a fájlban tárolt fejléc minden egyes celláját
                    for($i = 0; $i < count($header); $i++){
                        echo "<th>" . $header[$i] . "</th>";
                    }
                ?>
            </tr>
        </thead>
        <tbody>
            <?php 
                /* 
                    Mivel az első eleme a fájlunknak a fejléc, ezért ezt kihagyjuk, ha nem a fájlban van tárolva, akkor nem kell splice-ot használni hozzá
                    Az array_splice függvénnyel kilehet elemeket törölni egy tömbből, első paraméternek a tömböt várja, 
                    másodiknak hogy hány elemet hagyjon ki belőle az elejétől kezdve (vagy a végétől kezdve ha negatív számot adsz meg)
                */
                $cars = array_splice($file_contents, 1);
                // Egy for ciklussal bejárjuk a cars tömb összes elemét
                for($i = 0; $i < count($cars); $i++){
                    // Megkezdünk egy új sort a táblázaton belül
                    echo "<tr>";
                    // A cur_car változóba eltároljuk a jelenleg vizsgált autót tömbként, a seperator mentén elválasztva
                    $cur_car = explode($seperator, $cars[$i]);
                    // For ciklussal bejárjuk a jelenlegi autót, és minden elemét egy oszlopba kiíratjuk
                    for($j = 0; $j < count($cur_car); $j++){
                        echo "<td>" . $cur_car[$j] . "</td>";
                    }
                    // Lezárjuk a táblázatban lévő sort
                    echo "</tr>";
                }
            ?>
        </tbody>
    </table>
</body>
</html>
