<?php
    session_start();

    if(!isset($_SESSION["todos"])){
        $_SESSION["todos"] = [];
    }

    if(isset($_POST["title"]) && $_POST["title"] != ""){
        array_push($_SESSION["todos"], $_POST["title"]); 
    }
    
    if(isset($_POST["del"])){
        $id = $_POST["del"];
        array_splice($_SESSION["todos"], $id, 1);
    }

    if(isset($_POST["save_id"]) && isset($_POST["new_title"])){
        $id = $_POST["save_id"];
        $_SESSION["todos"][$id] = $_POST["new_title"];
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Todo App</title>
</head>
<body>
    <h1>Todo App</h1>
    
    <?php
        if(isset($_SESSION["todos"]) && count($_SESSION["todos"]) > 0){
            echo "<form method='post'>";
            echo "<ul>";
            
            for($i = 0; $i < count($_SESSION["todos"]); $i++){
                                $edit_mode = isset($_POST["edit"]) && $_POST["edit"] == $i;

                if(!$edit_mode){
                    $text = htmlspecialchars($_SESSION["todos"][$i]);
                    
                    $edit_btn = " <button type='submit' name='edit' value='" . $i . "'>Edit</button>";
                    $del_btn = " <button type='submit' name='del' value='" . $i . "'>Delete</button>";
                    
                    echo "<li>" . $text . $edit_btn . $del_btn . "</li>";
                }
                else{
                    $safe_value = htmlspecialchars($_SESSION["todos"][$i]);
                    $edit_field = "<input type='text' name='new_title' value='" . $safe_value . "'>";
                    $save_btn = " <button type='submit' name='save_id' value='" . $i . "'>Save</button>";
                    $cancel_btn = " <button type='submit'>Cancel</button>";

                    echo "<li>" . $edit_field . $save_btn . $cancel_btn . "</li>";
                }
            }
            echo "</ul>";
            echo "</form>";
        }
    ?>

    <hr>
    
    <form method="post">
        <label for="title">Title</label>
        <input type="text" name="title" required>
        <button type="submit">Add Todo</button>
    </form> 
</body>
</html>
