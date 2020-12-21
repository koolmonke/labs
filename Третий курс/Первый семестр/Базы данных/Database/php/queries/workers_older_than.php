<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select firstname, lastname, truncate(datediff(curdate(), dob) / 365.25, 0) as age from workers;";
    echo Utils::renderSelectQueryToTable($query, [$_POST["length"]]);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
