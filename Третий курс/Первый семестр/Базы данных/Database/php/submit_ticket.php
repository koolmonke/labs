<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Билеты</title>
</head>
<body>

<?php

$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
if (!empty($_POST)) {
    print_r($_POST);
    $free_seats = $db->query("select seats_id from kinos.seats left join kinos.tickets on seats.id = tickets.seats_id where tickets.seats_id is null");
//    print_r($free_seats->fetchAll());
    $some_seat = $free_seats->fetchColumn();
    print_r($some_seat);
    $insert = $db->prepare("insert into kinos.tickets (movie_show_id, seats_id, is_payed, is_booked, type_of_payment) VALUES (?, ?, true, true, 'картой')");
    $insert->execute([$_POST['movie_show'], $some_seat]);
    print_r($insert);
}


?>

</body>
</html>