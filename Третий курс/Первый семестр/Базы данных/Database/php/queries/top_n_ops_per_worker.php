<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select firstname, lastname, workers_id, count(*) as magnitude from ops_on_tickets join workers w on w.id = ops_on_tickets.workers_id group by workers_id order by magnitude desc limit {$_POST['n']};";
    echo Utils::renderSelectQueryToTable($query, []);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
