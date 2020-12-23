<?php
include "../Utils.php";

if (!empty($_GET)) {
    header('Content-Type: application/json');
    $db = Utils::getPDO();

    $stmt = $db->prepare("select * from seats where id = ?");
    $stmt->execute([$_GET['id']]);
    $result = $stmt->fetchAll();
    echo json_encode($result ? $result[0] : ["error" => "Нет мест с таким id"]);
}

