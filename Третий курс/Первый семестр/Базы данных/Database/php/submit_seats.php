<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Добавить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main_content">
    <?php
    include "render_seats.php";
    $db = Utils::getPDO();
    $post_result = (function ($db): array {
        if (!empty($_POST)) {
            $insert = $db->prepare("INSERT INTO seats (cinema_halls_id, row_index, seat_index) VALUES (:cinema_halls_id, :row_index, :seat_index)");

            $unique_seat_check = $db->prepare("select * from seats where row_index=:row_index and seat_index=:seat_index and cinema_halls_id=:cinema_halls_id");
            $unique_seat_check->execute($_POST);
            $duplicate_seats = $unique_seat_check->fetchAll(PDO::FETCH_ASSOC);
            if ($_POST['row_index'] > 0 && $_POST['seat_index'] > 0 && !$duplicate_seats && $insert->execute($_POST)) {
                return ["message" => "Данные введены успешно", "info" => null];
            } elseif ($duplicate_seats) {
                return ["message" => "Ошибка в введеных данных: Место с id={$duplicate_seats[0]["id"]} уже содержит данные с этим номером ряда и номером места", "info" => $duplicate_seats[0]];
            } else {
                return ["message" => "Ошибка в запросе", "info" => null];
            }
        } else {
            return ["message" => "Введите запрос", "info" => null];
        }
    })($db);

    echo render_seats();
    ?>
    <form action="submit_seats.php" method="post">
        <p class="foreign_items">
            Название зала<label title="Название зала">
                <select name="cinema_halls_id">
                    <?php
                    foreach ($db->query("select * from cinema_halls") as $row) {
                        echo "<option value={$row['id']}>{$row['name_of_hall']}</option>";
                    }
                    ?>
                </select>
            </label></p>
        <?php
        $seat_index = $post_result['info'] === null ? null : $post_result['info']['seat_index'];
        $row_index = $post_result['info'] === null ? null : $post_result['info']['row_index'];

        echo "<p>Номер ряда
            <label title=\"Номер ряда\">
                <input type=\"number\" name=\"row_index\" value={$row_index}>
            </label></p>
        <p>Номер места
            <label title=\"Номер места\">
                <input type=\"number\" name=\"seat_index\" value={$seat_index}>
            </label></p>
        <p><input type=\"submit\"></p>
        </p>";

        echo "<p>{$post_result["message"]}</p>";
        ?>

        <a class="buttons" href="index.php">Назад</a>
    </form>
</div>
</body>
</html>
