<link rel="stylesheet" href="../style.css">

<div class="main_content">
        <?php
        include "../Utils.php";
        $query = "select * from movies where begin_film_release > ?";
        echo Utils::renderSelectQueryToTable($query, [$_POST["date"]]);
        echo "<p>Запрос: $query</p>";
        ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
