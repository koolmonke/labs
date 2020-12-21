<!DOCTYPE html>
<html lang="RU-ru" xmlns="http://www.w3.org/1999/html">
<head>
    <title>Удалить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main_content">

    <form action="delete_seats.php" method="post">
        <p>id места<label title="id места">
                <select name="id">
                    <?php
                    include "Utils.php";
                    $db = Utils::getPDO();
                    foreach ($db->query("select * from seats") as $row) {
                        echo "<option value={$row['id']}>{$row['id']}</option>";
                    }
                    ?>
                </select>
            </label></p>
        <p><input type="submit"></p>
    </form>
    <p>
        <?php
        if (!empty($_POST)) {
            $delete = $db->prepare("DELETE FROM seats WHERE id = :id");

            if ($delete->execute($_POST)) {
                echo "Данные удалены успешно";
            } else {
                echo "Ошибка в запросе";
            }
        }
        else {
            echo "Введите запрос";
        }
        ?>
    </p>
    <a class="buttons" href="index.php">Назад</a>
</div>
</body>
</html>