<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    if (!empty($_POST)) {
        include "../Utils.php";
        $query = "select title, count(*) as magnitude from tickets join movie_shows ms on ms.id = tickets.movie_show_id join movies m on m.id = ms.movies_id where is_payed group by m.id order by magnitude desc limit ?";
        echo Utils::renderSelectQueryToTable($query, [$_POST["n"]]);
        echo "<p>Запрос: $query</p>";
    } else {
        echo "<p>Пустой запрос</p>";
    }
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
