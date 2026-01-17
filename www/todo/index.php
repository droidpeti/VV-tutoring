<?php
    session_start();

    if(isset($_POST["title"]) && $_POST["title"] != ""){
        if(!isset($_SESSION["todos"])){
            $_SESSION["todos"] = [];
        }
        array_push($_SESSION["todos"], $_POST["title"]); 
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Todo App</h1>
    <?php
        if(isset($_SESSION["todos"]) && count($_SESSION["todos"]) > 0){
            echo "<ul>";
            for($i = 0; $i < count($_SESSION["todos"]); $i++){
                $del_btn = "<form method='post'><button type='submit' name='" . $i . "'>Delete " . $i . "</button>";
                echo "<li>" . $_SESSION["todos"][$i] . $del_btn . "</li>";
            }
            echo "</ul>";
        }
    ?>
    <form method="post">
        <label for="title">Title</label>
        <input type="text" name="title">

        <button type="submit">Add Todo</button>
    </form> 
</body>
</html>