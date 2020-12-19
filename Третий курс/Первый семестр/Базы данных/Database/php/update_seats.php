<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Обновить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main_content">
    <?php
    $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
    if (!empty($_POST)) {
        $update = $db->prepare("update seats set cinema_halls_id = :cinema_halls_id, row_index = :row_index, seat_index = :seat_index where id = :id");

        $unique_seat_check = $db->prepare("select * from seats where row_index=? and seat_index=? and cinema_halls_id=?");
        $unique_seat_check->execute([$_POST["row_index"], $_POST["seat_index"], $_POST['cinema_halls_id']]);
        $duplicate_seats = $unique_seat_check->fetchAll(PDO::FETCH_ASSOC);

        if (!$duplicate_seats && $update->execute($_POST)) {
            echo "Данные обновлены успешно";
        } elseif ($duplicate_seats) {
            echo "Ошибка в введеных данных: Место с данным номером ряда и номером места уже существуют";
        } else {
            echo "Ошибка в запросе";
        }
    }
    ?>

    <form action="update_seats.php" method="post">
        <p>id места <label title="id места">
                <select name="id">
                    <?php
                    foreach ($db->query("select * from seats") as $row) {
                        echo "<option value={$row['id']}>{$row['id']}</option>";
                    }
                    ?>
                </select>
            </label></p>
        <label class="foreign_items" title="Название зала">
            Название зала <select name="cinema_halls_id">
                <?php
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
    <a class="buttons" href="index.php">Назад</a>
</div>
</body>
</html>