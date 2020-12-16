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
    $update = $db->prepare("update seats set cinema_halls_id = :cinema_halls_id, row_index = :row_index, seat_index = :seat_index where id = :id");

    if ($update->execute($_POST)) {
        echo "Действие было совершено удачно";
    } else {
        echo "Ошибка в запросе";
    }
}
?>

<form action="update_seats.php" method="post">
    <p>id места<select name="id">
        <?php
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
        foreach ($db->query("select * from seats") as $row) {
            echo "<option value={$row['id']}>{$row['id']}</option>";
        }
        ?>
        </select></p>
    <select name="cinema_halls_id">
        <?php
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
        foreach ($db->query("select * from cinema_halls") as $row) {
            echo "<option value={$row['id']}>{$row['name_of_hall']}</option>";
        }
        ?>
    </select>
    <p>Номер ряда <input type="number" name="row_index" value="">
    <p>Номер места<input type="number" name="seat_index" value="">
    <p><input type="submit"></p>
</form>
</body>
</html>