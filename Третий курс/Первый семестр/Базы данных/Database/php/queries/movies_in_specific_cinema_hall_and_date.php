<link rel="stylesheet" href="../style.css">

<div class="main_content">
    <?php
    include "../Utils.php";
    $query = "select title from movie_shows join movies m on m.id = movie_shows.movies_id where cinema_halls_id=? and cast(start_of_show as date)=?";
    echo Utils::renderSelectQueryToTable($query, [$_POST["cinema_halls_id"], $_POST["date"]]);
    echo "<p>Запрос: $query</p>";
    ?>
    <a class="buttons" href="../queries.php">Назад</a>
</div>
