<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Все места</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<div class="main_content">
    <h2>Все места:</h2>
    <table>
        <tr>
            <th>id</th>
            <th>Номер ряда</th>
            <th>Номер места</th>
            <th class="foreign_items">Номер зала</th>
            <th class="foreign_items">Название зала</th>
            <th class="foreign_items">Описание зала</th>
        </tr>
        <?php
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');

        foreach ($db->query('select seats.id seats_pk, cinema_halls_id, row_index, seat_index, name_of_hall, description from kinos.seats join cinema_halls ch on ch.id = seats.cinema_halls_id order by seats_pk') as $row) {
            echo '<tr>';
            echo "<th>{$row['seats_pk']}</th>";
            echo "<th>{$row['row_index']}</th>";
            echo "<th>{$row['seat_index']}</th>";
            echo "<th class='foreign_items'>{$row['cinema_halls_id']}</th>";
            echo "<th class='foreign_items'>{$row['name_of_hall']}</th>";
            echo "<th class='foreign_items'>{$row['description']}</th>";
            echo "</tr>";
        }
        ?>
    </table>

    <div class="buttons_wrapper">
        <a class="buttons" target="_blank" href="submit_seats.php">Добавить место</a>
        <a class="buttons" target="_blank" href="delete_seats.php">Удалить место</a>
        <a class="buttons" target="_blank" href="update_seats.php">Изменить место</a>
        <a class="buttons" target="_blank" href="queries.php">Запросы к БД</a>
    </div>
</div>
</body>
</html>