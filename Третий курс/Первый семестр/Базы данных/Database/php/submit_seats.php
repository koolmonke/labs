<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Места</title>
</head>
<body>

<?php

if (!empty($_POST)) {
    $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
    $insert = $db->prepare("INSERT INTO seats (cinema_halls_id, row_index, seat_index) VALUES (:cinema_halls_id, :row_index, :seat_index)");

    if ($insert->execute($_POST)) {
        echo "Действие было совершено успешно";
    } else {
        echo "Ошибка в запросе";
    }
}
?>
<form action="submit_seats.php" method="post">
    <p>Название зала<label title="Название зала">
            <select name="cinema_halls_id">
                <?php
                $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
                foreach ($db->query("select * from cinema_halls") as $row) {
                    echo "<option value={$row['id']}>{$row['name_of_hall']}</option>";
                }
                ?>
            </select>
        </label></p>
    <p>Номер ряда
        <label title="Номер ряда">
            <input type="number" name="row_index" value="">
        </label></p>
    <p>Номер места
        <label title="Номер места">
            <input type="number" name="seat_index" value="">
        </label></p>
    <p><input type="submit"></p>
</form>
</body>
</html>
