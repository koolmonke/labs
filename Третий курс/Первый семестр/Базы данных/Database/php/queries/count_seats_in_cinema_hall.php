<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    if (!empty($_POST)) {
        include "../Utils.php";
        $query = "select count(id) from seats where cinema_halls_id=?";
        echo Utils::renderSelectQueryToTable($query, [$_POST["cinema_halls_id"]]);
        echo "<p>Запрос: $query</p>";
    } else {
        echo "<p>Пустой запрос</p>";
    }
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
