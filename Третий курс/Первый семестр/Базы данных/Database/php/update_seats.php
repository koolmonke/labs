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
    <p>id записи <input type="number" name="id" value="">
    <p style='color: blue'>Номер зала <input type="number" name="cinema_halls_id" value="">
    <p>Номер ряда <input type="number" name="row_index" value="">
    <p>Номер места<input type="number" name="seat_index" value="">
    <p><input type="submit"></p>
</form>
</body>
</html>