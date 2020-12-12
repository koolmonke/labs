<?php
$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
print_r($_POST);
$update = $db->prepare("update seats set cinema_halls_id = :cinema_halls_id, row_index = :row_index, seat_index = :seat_index where id = :id");

if ($update->execute($_POST)) {
    echo "Действие было совершено удачно";
}
else {
    echo "Ошибка в запросе";
}