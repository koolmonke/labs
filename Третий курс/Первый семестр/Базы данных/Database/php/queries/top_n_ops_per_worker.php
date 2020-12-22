<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    if (!empty($_POST)) {
        include "../Utils.php";
        $query = "select firstname, lastname, workers_id, count(*) as magnitude from ops_on_tickets join workers w on w.id = ops_on_tickets.workers_id group by workers_id order by magnitude desc limit ?;";
        echo Utils::renderSelectQueryToTable($query, [$_POST['n']]);
        echo "<p>Запрос: $query</p>";
    } else {
        echo "<p>Пустой запрос</p>";
    }
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
