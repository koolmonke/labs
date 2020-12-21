<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select * from workers where lastname like ?";
    echo Utils::renderSelectQueryToTable($query, ['%'.$_POST['lastname']]);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
