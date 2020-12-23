<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Обновить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<script>
    function update_values() {
        const current_host = window.location.host;
        const select_value = document.getElementById("id").value;
        const request = async () => {
            const response = await fetch(`http://${current_host}/api/get_seat_by_id.php?id=${select_value}`);
            const json = await response.json();
            console.log(json);
            document.getElementById("row_index").value = json["row_index"];
            document.getElementById("seat_index").value = json["seat_index"];
            document.getElementById("cinema_halls_id").value = json["cinema_halls_id"];
        }
        request();
    }

    window.addEventListener('load', () => {
        update_values();
    });


</script>
<div class="main_content">
    <?php
    include "render_seats.php";
    echo render_seats();
    ?>
    <form id="update_form" action="update_seats.php" method="post">
        <p>id места <label title="id места">
                <select onchange="update_values()" name="id" id="id">
                    <?php
                    $db = Utils::getPDO();
                    foreach ($db->query("select * from seats") as $row) {
                        echo "<option value={$row['id']}>{$row['id']}</option>";
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
        if (!empty($_POST)) {
            $update = $db->prepare("update seats set cinema_halls_id = :cinema_halls_id, row_index = :row_index, seat_index = :seat_index where id = :id");

            $unique_seat_check = $db->prepare("select * from seats where row_index=? and seat_index=? and cinema_halls_id=?");
            $unique_seat_check->execute([$_POST["row_index"], $_POST["seat_index"], $_POST['cinema_halls_id']]);
            $duplicate_seats = $unique_seat_check->fetchAll(PDO::FETCH_ASSOC);
            if ($_POST['row_index'] > 0 && $_POST['seat_index'] > 0 && !$duplicate_seats && $update->execute($_POST)) {
                echo "Данные обновлены успешно";
            } elseif ($duplicate_seats) {
                echo "Ошибка в введеных данных: Место с данным номером ряда и номером места уже существуют";
            } else {
                echo "Ошибка в запросе";
            }
        } else {
            echo "Введите запрос";
        }
        ?>
    </p>
    <a class="buttons" href="index.php">Назад</a>
</div>
</body>
</html>