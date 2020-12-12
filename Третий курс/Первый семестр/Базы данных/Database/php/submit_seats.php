<?php

$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
print_r($_POST);
$insert = $db->prepare("INSERT INTO seats (cinema_halls_id, row_index, seat_index) VALUES (:cinema_halls_id, :row_index, :seat_index)");

if ($insert->execute($_POST)) {
    echo "Действие было совершено удачно";
}
else {
    echo "Ошибка в запросе";
}