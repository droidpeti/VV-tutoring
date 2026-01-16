<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <table class="center">
        <thead>
            <tr>
                <th>Brand</th>
                <th>Model</th>
                <th>Year</th>
                <th>Color</th>
            </tr>
        </thead>
        <tbody>
            <?php
                $cars = file("cars.txt", FILE_IGNORE_NEW_LINES);
                $cur_tr = "<tr>";

                for($i = 0; $i < count($cars); $i++){
                    $cur_car = explode(";", $cars[$i]);
                    
                    for($j = 0; $j < count($cur_car); $j++){
                        $cur_tr = $cur_tr . "<td>" . $cur_car[$j] . "</td>";
                    }
                    $cur_tr = $cur_tr . "</tr>";
                }
                echo $cur_tr;
            ?>
        </tbody>
    </table>
</body>
</html>
