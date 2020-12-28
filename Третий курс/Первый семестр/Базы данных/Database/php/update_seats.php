<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Обновить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<script>
    function update_values(id) {
        const current_host = window.location.host;

        const request = async () => {
            const json = await fetch(`http://${current_host}/api/get_seat_by_id.php?id=${id}`).then(response => response.json());
            for (const k in json) {
                if (json.hasOwnProperty(k) && document.getElementById(k) !== null) {
                    document.getElementById(k).value = json[k];
                }
            }
        }
        request();
    }

    window.addEventListener('load', () => {
        const id = document.getElementById("id").value;
        update_values(id);
    });


</script>
<div class="main_content">
    <?php
    include "render_seats.php";
    $db = Utils::getPDO();
    $post_result = (function ($db): array {
        if (!empty($_POST)) {
            $update = $db->prepare("update seats set cinema_halls_id = :cinema_halls_id, row_index = :row_index, seat_index = :seat_index where id = :id");

            $unique_seat_check = $db->prepare("select * from seats where row_index=? and seat_index=? and cinema_halls_id=?");
            $unique_seat_check->execute([$_POST["row_index"], $_POST["seat_index"], $_POST['cinema_halls_id']]);
            $duplicate_seats = $unique_seat_check->fetchAll(PDO::FETCH_ASSOC);
            if ($_POST['row_index'] > 0 && $_POST['seat_index'] > 0 && !$duplicate_seats && $update->execute($_POST)) {
                return ["message" => "Данные обновлены успешно", "info" => null];
            } elseif ($duplicate_seats) {
                return ["message" => "Ошибка в введеных данных: Место с id={$duplicate_seats[0]["id"]} уже содержит данные с этим номером ряда и номером места", "info" => $_POST];
            } else {
                return ["message" => "Ошибка в запросе", "info" => null];
            }
        } else {
            return ["message" => "Введите запрос", "info" => null];
        }
    })($db);
    echo render_seats();
    ?>
    <form id="update_form" action="update_seats.php" method="post">
        <p>id места <label title="id места">
                <select onchange="update_values(this.value)" name="id" id="id">
                    <?php
                    foreach ($db->query("select * from seats") as $row) {
                        echo ($post_result !== null && $post_result["info"]["id"] == $row["id"])
                            ?
                            "<option selected value={$row['id']}>{$row['id']}</option>"
                            :
                            "<option value={$row['id']}>{$row['id']}</option>";

                    }
                    ?>
                </select>
            </label></p>
        <label class="foreign_items" title="Название зала">
            Название зала <select name="cinema_halls_id" id="cinema_halls_id">
                <?php
                foreach ($db->query("select * from cinema_halls") as $row) {
                    echo "<option value={$row['id']}>{$row['name_of_hall']}</option>";
                }
                ?>
            </select>
        </label>
        <p>Номер ряда<label title="Номер ряда">
                <input type="number" name="row_index" id="row_index" value="">
            </label></p>
        <p>Номер места<label title="Номер места">
                <input type="number" name="seat_index" id="seat_index" value="">
            </label></p>
        <p><input type="submit"></p>
    </form>
    <p>
        <?php
        echo $post_result["message"];
        ?>
    </p>
    <a class="buttons" href="index.php">Назад</a>
</div>
</body>
</html>