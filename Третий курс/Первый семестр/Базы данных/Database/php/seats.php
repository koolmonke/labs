<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Места</title>
</head>
<body>

<?php
include 'cinema_halls.php';

$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
echo "Все места:";
echo '<table border="1" width="100%" cellpadding="5">';
echo '<tr>';
echo "<th>id</th>";
echo "<th style='color: blue' '>Номер зала</th>";
echo "<th>Номер ряда</th>";
echo "<th>Номер места</th>";
echo "</tr>";
foreach ($db->query('select * from kinos.seats') as $row) {
    echo '<tr>';
    echo "<th>{$row['id']}</th>";
    echo "<th style='color: blue'>{$row['cinema_halls_id']}</th>";
    echo "<th>{$row['row_index']}</th>";
    echo "<th>{$row['seat_index']}</th>";
    echo "</tr>";
}
echo "</table>";

?>
<p>Добавить место</p>
<form action="submit_seats.php" method="post">
    <p style='color: blue'>Номер зала <input type="number" name="cinema_halls_id" value="">
    <p>Номер ряда <input type="number" name="row_index" value="">
    <p>Номер места<input type="number" name="seat_index" value="">
    <p><input type="submit"></p>
</form>

<p>Удалить место</p>
<form action="delete_seats.php" method="post">
    <p>id записи <input type="number" name="id" value="">
    <p><input type="submit"></p>
</form>

<p>Изменить место</p>
<form action="update_seats.php" method="post">
    <p>id записи <input type="number" name="id" value="">
    <p style='color: blue'>Номер зала <input type="number" name="cinema_halls_id" value="">
    <p>Номер ряда <input type="number" name="row_index" value="">
    <p>Номер места<input type="number" name="seat_index" value="">
    <p><input type="submit"></p>
</form>
</body>
</html>