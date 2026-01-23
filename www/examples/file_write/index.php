<?php
    $saved = false;
    if(isset($_POST["fruit"]) && $_POST["fruit"] != ""){
        $file_name = "../fruits.txt";
        $fruit = htmlspecialchars($_POST["fruit"]);
        file_put_contents($file_name, $fruit . "\n", FILE_APPEND | LOCK_EX);
        $saved = true;
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Fruit File Write</title>
</head>
<body>
    <h1>Fruit App</h1>
    <form method="post">
        <label for="fruit">Fruit name: </label>
        <input type="text" name="fruit">
        <button type="submit">Add Fruit</button>
    </form>
    <?php
        if($saved){
            echo "<p style='color: green;'>Successfully saved fruit!</p>";
        }
    ?>
</body>
</html>
