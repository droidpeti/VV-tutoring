<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h3>Names</h3>
    <ul>
        <?php 
            $rows = file("names.txt", FILE_IGNORE_NEW_LINES);
            for($i = 0; $i < count($rows); $i++){
                $row = $rows[$i];
                echo "<li>$row</li>";
            }
        ?>
    </ul>
</body>
</html>