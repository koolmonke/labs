<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Места</title>
</head>
<body>

<?php

$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
echo "Все места:";
echo '<table border="1" width="100%" cellpadding="5">';
echo '<tr>';
echo "<th>id</th>";
echo "<th>Номер зала</th>";
echo "<th>Номер ряда</th>";
echo "<th>Номер места</th>";
echo "</tr>";
foreach($db->query('select * from kinos.seats') as $row) {
    echo '<tr>';
    echo "<th>{$row['id']}</th>";
    echo "<th>{$row['cinema_halls_id']}</th>";
    echo "<th>{$row['row_index']}</th>";
    echo "<th>{$row['seat_index']}</th>";
    echo "</tr>";
}
echo "</table>"


?>

</body>
</html>