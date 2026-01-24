<!-- VS Code-ban nyomd meg a !+TAB billentyűkombinációt egy ilyen sablon készítéséhez -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Contents of the fruits file</h1>
    <ul>
        <?php 
            // Fálból való beolvasás, a file_name-ban a fájl elérési útvonalát tároljuk, a ../ az az egy mappával feljebbi mappát jelenti
            $file_name = "../files/fruits.txt";
            $fruits = file($file_name, FILE_IGNORE_NEW_LINES);
            
            // For ciklus a fájl sorai kiíratásához li elemekbe
            for($i = 0; $i < count($fruits); $i++){
                echo "<li>" . $fruits[$i] . "</li>";
            }
        ?>
    </ul>
</body>
</html>