<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Фильмы</title>
</head>
<body>

<?php

$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
echo "Все фильмы:";
echo '<table border="1" width="100%" cellpadding="5">';
foreach($db->query('select * from kinos.movies') as $row) {
    echo '<tr>';
    echo "<th>{$row['id']}</th>";
    echo "<th>{$row['title']}</th>";
    echo "<th>{$row['duration']}</th>";
    echo "<th>{$row['begin_film_release']}</th>";
    echo "<th>{$row['end_film_release']}</th>";
    echo "<th>{$row['distributor']}</th>";
    echo "</tr>";
}
echo "</table>"


?>

</body>
</html>