<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    if (!empty($_POST)) {
        include "../Utils.php";
        $query = "select title, start_of_show, name_of_hall from movie_shows join cinema_halls ch on ch.id = movie_shows.cinema_halls_id join movies m on m.id = movie_shows.movies_id where date(start_of_show) = ?";
        echo Utils::renderSelectQueryToTable($query, [$_POST["date"]]);
        echo "<p>Запрос: $query</p>";
    } else {
        echo "<p>Пустой запрос</p>";
    }
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
