<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select firstname, lastname, truncate(datediff(curdate(), dob) / 365.25, 0) as age from workers where truncate(datediff(curdate(), dob) / 365.25, 0) > ?;";
    echo Utils::renderSelectQueryToTable($query, [$_POST["age"]]);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
