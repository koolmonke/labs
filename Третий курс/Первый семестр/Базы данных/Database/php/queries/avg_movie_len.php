<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select sec_to_time(avg(time_to_sec(duration))) as avg_duration from movies";
    echo Utils::renderSelectQueryToTable($query, []);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
