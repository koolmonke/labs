<?php

use JetBrains\PhpStorm\ArrayShape;

include "Utils.php";

class CRUD
{
    private PDO $db;

    public function __construct(PDO $db)
    {
        $this->db = $db;
    }

    public function renderTable($selected_seats_pk): string
    {
        $html = "
        <table>
            <tr>
                <th>-</th>
                <th>id</th>
                <th>Номер ряда</th>
                <th>Номер места</th>
                <th class='foreign_items'>Номер зала</th>
                <th class='foreign_items'>Название зала</th>
                <th class='foreign_items'>Описание зала</th>
            </tr>";

        foreach ($this->db->query("select seats.id seats_pk, cinema_halls_id, row_index, seat_index, name_of_hall, description from seats join cinema_halls ch on ch.id = seats.cinema_halls_id order by seats_pk") as $row) {
            $checked = $selected_seats_pk == $row["seats_pk"] ? "checked" : "";
            $html .= "<tr>
                        <th><input type='radio' {$checked} form='crud_form' name='id' id='id' onchange='update_form(this.value)' value={$row['seats_pk']}></th>
                        <th>{$row['seats_pk']}</th>
                        <th>{$row['row_index']}</th>
                        <th>{$row['seat_index']}</th>
                        <th class='foreign_items'>{$row['cinema_halls_id']}</th>
                        <th class='foreign_items'>{$row['name_of_hall']}</th>
                        <th class='foreign_items'>{$row['description']}</th>
                      </tr>";
        }
        $html .= "</table>";
        return $html;
    }

    #[ArrayShape(["duplicate_exist" => "bool", "duplicate_seat" => "?array"])] protected function uniqueSeatCheck($row_index, $seat_index, $cinema_halls_id): array
    {
        $unique_seat_check = $this->db->prepare("select * from seats where row_index = ? and seat_index = ? and cinema_halls_id = ?");
        $unique_seat_check->execute([$row_index, $seat_index, $cinema_halls_id]);
        $duplicate_seats = $unique_seat_check->fetchAll();
        return ["duplicate_exist" => boolval($duplicate_seats), "duplicate_seat" => $duplicate_seats ? $duplicate_seats[0] : null];
    }

    #[ArrayShape(["message" => "string", "info" => "?int"])] public function update(int $id, int $row_index, int $seat_index, int $cinema_halls_id): array
    {
        $update = $this->db->prepare("update seats set cinema_halls_id = ?, row_index = ?, seat_index = ? where id = ?");

        $uniqueSeatCheck = $this->uniqueSeatCheck($row_index, $seat_index, $cinema_halls_id);
        if ($row_index > 0 && $seat_index > 0 && !$uniqueSeatCheck["duplicate_exist"] && $update->execute([$cinema_halls_id, $row_index, $seat_index, $id])) {
            return ["message" => "Данные обновлены успешно", "info" => null];
        } elseif ($uniqueSeatCheck["duplicate_exist"]) {
            return ["message" => "Ошибка в введеных данных: Место с id={$uniqueSeatCheck["duplicate_seat"]["id"]} уже содержит данные с этим номером ряда и номером места", "info" => $id];
        } else {
            return ["message" => "Ошибка в запросе", "info" => null];
        }
    }

    #[ArrayShape(["message" => "string", "info" => "?string"])] public function create(int $row_index, int $seat_index, int $cinema_halls_id): array
    {
        $insert = $this->db->prepare("INSERT INTO seats (cinema_halls_id, row_index, seat_index) VALUES (?, ?, ?)");

        $uniqueSeatCheck = $this->uniqueSeatCheck($row_index, $seat_index, $cinema_halls_id);
        if ($row_index > 0 && $seat_index > 0 && !$uniqueSeatCheck["duplicate_exist"] && $insert->execute([$cinema_halls_id, $row_index, $seat_index])) {
            return ["message" => "Данные введены успешно", "info" => null];
        } elseif ($uniqueSeatCheck) {
            return ["message" => "Ошибка в введеных данных: Место с id={$uniqueSeatCheck["duplicate_seat"]["id"]} уже содержит данные с этим номером ряда и номером места", "info" => $uniqueSeatCheck];
        } else {
            return ["message" => "Ошибка в запросе", "info" => null];
        }
    }

    #[ArrayShape(["message" => "string", "info" => "?string"])] public function delete(int $id): array
    {
        $delete = $this->db->prepare("DELETE FROM seats WHERE id = ?");

        return ["message" => $delete->execute([$id]) ? "Данные удалены успешно" : "Ошибка в запросе", "info" => null];
    }

}

?>
<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Все места</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

<div class="main_content">
    <?php
    $db = Utils::getPDO();
    $crud = new CRUD($db);
    $crud_query_response = match (true) {
        isset($_POST["create"]) => $crud->create($_POST["row_index"], $_POST["seat_index"], $_POST["cinema_halls_id"]),
        isset($_POST["update"]) => $crud->update($_POST["id"], $_POST["row_index"], $_POST["seat_index"], $_POST["cinema_halls_id"]),
        isset($_POST["delete"]) => $crud->delete($_POST["id"]),
        default => ["message" => "Введите запрос"],
    };
    echo $crud->renderTable($crud_query_response['info'] ?? null);
    $classes = "status " . ($crud_query_response["message"] != "Введите запрос" ? (isset($crud_query_response["info"]) ? "failure" : "success") : "");
    echo "<p class='{$classes}'>{$crud_query_response["message"]}</p>";
    ?>
    <form id="crud_form" action="/" method="post">
        <p class="foreign_items">Название зала <label title="cinema_halls_id"><select name="cinema_halls_id"
                                                                                      id="cinema_halls_id">
                    <?php
                    foreach ($db->query("select * from cinema_halls") as $item) {
                        echo "<option value={$item['id']}>{$item['name_of_hall']}</option>";
                    }
                    ?>
                </select></label></p>
        <p>Номер ряда <label title="Номер ряда"><input type="number" name="row_index" id="row_index"></label></p>
        <p>Номер места <label title="Номер места"><input type="number" name="seat_index" id="seat_index"></label></p>
        <input name="create" value="Добавить" type="submit">
        <input name="update" value="Обновить" type="submit">
        <input name="delete" value="Удалить" type="submit">
    </form>
    <a class="buttons" href="queries.php">Запросы к БД</a>
</div>
<script src="update_values.js"></script>
<script>
    const update_form = (id) => update_values(`/api/get_seat_by_id.php?id=${id}`);

    <?php
    $autocomplete_onload = "window.addEventListener('load', () => {
        const id = document.getElementById(\"id\").value;
        update_form(id);
    });";
    if ($crud_query_response['info'] ?? false) {
        echo $autocomplete_onload;
    }
    ?>
</script>
</body>
</html>