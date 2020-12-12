<?php
$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
print_r($_POST);
$delete = $db->prepare("DELETE FROM seats WHERE id = :id");

if ($delete->execute($_POST)) {
    echo "Действие было совершено удачно";
}
else {
    echo "Ошибка в запросе";
}