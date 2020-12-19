<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Вывод фильмов</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<table>
    <?php

    $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
    echo "Все фильмы:";

    foreach ($db->query('select * from movies') as $row) {
        echo '<tr>';
        echo "<th>{$row['id']}</th>";
        echo "<th>{$row['title']}</th>";
        echo "<th>{$row['duration']}</th>";
        echo "<th>{$row['begin_film_release']}</th>";
        echo "<th>{$row['end_film_release']}</th>";
        echo "<th>{$row['distributor']}</th>";
        echo "</tr>";
    }
    ?>
</table>
</body>
</html>