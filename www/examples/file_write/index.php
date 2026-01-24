<?php
    // Egy változó, ahol figyeljük, hogy lefutott-e a mentés, alapból hamis, ha lefut átállítjuk igazra
    $saved = false;
    /*
        Minden mező ami egy post method-ú formban van, annak a tartalmát a $_POST[]-al lehet elérni, a []-ba írd az input mező name-jét
        Az isset-tel lehet megnézni, hogy be lett-e már állítva egy ilyen mező
    */
    if(isset($_POST["fruit"]) && $_POST["fruit"] != ""){
        // It a ../ csak annyit jelent, hogy egy mappával feljebb lépünk, a files, meg a mappa ahol van a fájlunk
        $file_name = "../files/fruits.txt";
        // A htmlspecialchars függvénnyel lehet tisztán elmenteni egy string értékét, lekezeli a nem valid karaktereket
        $fruit = htmlspecialchars($_POST["fruit"]);
        /* 
            A file_put_contents-el tudsz egy fájlba írni
            Az első paramétere, a fájl elérési útvonala ahova írni szeretnél
            A második paramétere a szöveg amit beleszeretnél írni a fájlba (a "\n" annyit jelent, hogy írjon egy új sort is a fájlba)
            A harmadik paramétere, hogy mit szeretnél csinálni a fájlal, a FILE_APPEND, az hogy a végébe szeretnél beleírni,
            a LOCK_EX az hogy csak ez a program tudjon bele írni, a | pedig összeköti őket
        */
        file_put_contents($file_name, $fruit . "\n", FILE_APPEND | LOCK_EX);
        $saved = true;
    }
?>

<!-- VS Code-ban használd a !+TAB billentyűkombinációt egy alap HTML sablon készítéséhez -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Fruit File Write</title>
</head>
<body>
    <h1>Fruit App</h1>
    <!-- A bemeneti mezőket tedd egy 'post' method-ú form tagbe -->
    <form method="post">
        <!-- A labelben tudod megjeleníteni a szöveget ami egy mezőhöz tartozik. a for részhez írd a name-ét az inputodnak -->
        <label for="fruit">Fruit name: </label>
        <input type="text" name="fruit">
        <!-- Egy submit type-ú buttonnal lehet megerősíteni és elküldeni a válaszodat -->
        <button type="submit">Add Fruit</button>
    </form>
    <?php
        // Ha igaz a saved változó értéke, akkor írja ki zölden, hogy sikeres volt a mentés
        if($saved){
            echo "<p style='color: green;'>Successfully saved fruit!</p>";
        }
    ?>
</body>
</html>
