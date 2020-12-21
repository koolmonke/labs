<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select * from movies where duration < ?";
    echo Utils::renderSelectQueryToTable($query, [$_POST["length"]]);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
