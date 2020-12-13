<!DOCTYPE html>
<html lang="RU-ru">
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
    <p>id записи <input type="number" name="id" value="">
    <p><input type="submit"></p>
</form>
</body>
</html>