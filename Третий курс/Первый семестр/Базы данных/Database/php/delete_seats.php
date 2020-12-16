<!DOCTYPE html>
<html lang="RU-ru" xmlns="http://www.w3.org/1999/html">
<head>
    <title>Места</title>
</head>
<body>


<?php

if (!empty($_POST)) {
    $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
    print_r($_POST);
    $delete = $db->prepare("DELETE FROM seats WHERE id = :id");

    if ($delete->execute($_POST)) {
        echo "Действие было совершено удачно";
    } else {
        echo "Ошибка в запросе";
    }
}
?>

<form action="delete_seats.php" method="post">
    <p>id места <select name="id">
        <?php
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
        foreach ($db->query("select * from seats") as $row) {
            echo "<option value={$row['id']}>{$row['id']}</option>";
        }
        ?>
        </select></p>
    <p><input type="submit"></p>
</form>
</body>
</html>