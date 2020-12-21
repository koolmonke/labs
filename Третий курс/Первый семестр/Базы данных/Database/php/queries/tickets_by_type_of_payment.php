<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select * from tickets where type_of_payment=?";
    echo Utils::renderSelectQueryToTable($query, [$_POST["type_of_payment"]]);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
