<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Все места</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<div class="main_content">
    <h2>Все места:</h2>
    <?php
    include "render_seats.php";
    echo render_seats();
    ?>
    <div class="buttons_wrapper">
        <a class="buttons" href="submit_seats.php">Добавить место</a>
        <a class="buttons" href="delete_seats.php">Удалить место</a>
        <a class="buttons" href="update_seats.php">Изменить место</a>
        <a class="buttons" href="queries.php">Запросы к БД</a>
    </div>
</div>
</body>
</html>