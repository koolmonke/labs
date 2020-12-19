<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Обновить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main_content">
    <?php
    if (!empty($_POST)) {
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
        $update = $db->prepare("update seats set cinema_halls_id = :cinema_halls_id, row_index = :row_index, seat_index = :seat_index where id = :id");

        if ($update->execute($_POST)) {
            echo "Действие было совершено успешно";
        } else {
            echo "Ошибка в запросе";
        }
    }
    ?>

    <form action="update_seats.php" method="post">
        <p>id места <label title="id места">
                <select name="id">
                    <?php
                    $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
                    foreach ($db->query("select * from seats") as $row) {
                        echo "<option value={$row['id']}>{$row['id']}</option>";
                    }
                    ?>
                </select>
            </label></p>
        <label class="foreign_items" title="Название зала">
            Название зала <select name="cinema_halls_id">
                <?php
                $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
                foreach ($db->query("select * from cinema_halls") as $row) {
                    echo "<option value={$row['id']}>{$row['name_of_hall']}</option>";
                }
                ?>
            </select>
        </label>
        <p>Номер ряда<label title="Номер ряда">
                <input type="number" name="row_index" value="">
            </label></p>
        <p>Номер места<label title="Номер места">
                <input type="number" name="seat_index" value="">
            </label></p>
        <p><input type="submit"></p>
    </form>
</div>
</body>
</html>