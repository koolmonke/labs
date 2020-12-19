<!DOCTYPE html>
<html lang="RU-ru" xmlns="http://www.w3.org/1999/html">
<head>
    <title>Удалить место</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main_content">
    <?php
    if (!empty($_POST)) {
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
        $delete = $db->prepare("DELETE FROM seats WHERE id = :id");

        if ($delete->execute($_POST)) {
            echo "Действие было совершено успешно";
        } else {
            echo "Ошибка в запросе";
        }
    }
    ?>

    <form action="delete_seats.php" method="post">
        <p>id места<label title="id места">
                <select name="id">
                    <?php
                    $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');
                    foreach ($db->query("select * from seats") as $row) {
                        echo "<option value={$row['id']}>{$row['id']}</option>";
                    }
                    ?>
                </select>
            </label></p>
        <p><input type="submit"></p>
    </form>
    <a class="buttons" href="index.php">Назад</a>
</div>
</body>
</html>