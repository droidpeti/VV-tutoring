<?php
    session_start();

    if(isset($_POST["title"]) && $_POST["title"] != ""){
        if(!isset($_SESSION["todos"])){
            $_SESSION["todos"] = [];
        }
        array_push($_SESSION["todos"], $_POST["title"]); 
    }
    
    if(isset($_POST["del"])){
        $id = $_POST["del"];
        array_splice($_SESSION["todos"], $id, 1);
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
            echo "<form method='post'>";
            echo "<ul>";
            for($i = 0; $i < count($_SESSION["todos"]); $i++){
                $del_btn = "<button type='submit' name='del' value='" . $i . "'>Delete " . $i . "</button>";
                $edit_mode = isset($_POST["edit"]) && $_POST["edit"] == $i;

                if(!$edit_mode){
                    $edit_btn = "<button type='submit' name='edit' value='" . $i . "'>Edit " . $i . "</button>";
                    echo "<li>" . $_SESSION["todos"][$i] . $edit_btn . $del_btn . "</li>";
                }
                else{
                    $edit_field = "<input type='text' value'=" . $_SESSION["todos"][$i] . "'>";
                    echo "<li>" . $edit_field . "</li>";
                }
                
            }
            echo "</ul>";
            echo "</form>";
        }
    ?>
    <form method="post">
        <label for="title">Title</label>
        <input type="text" name="title">

        <button type="submit">Add Todo</button>
    </form> 
</body>
</html>