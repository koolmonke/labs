<!DOCTYPE html>
<html lang="RU-ru">
<head>
    <title>Билеты</title>
</head>
<body>

<?php

$db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');

echo '<form action="submit_ticket.php" method="post">';

echo '<select id = "movie_show" name="movie_show">';
echo '<option disabled selected>Выберите сеанс</option>';
foreach ($db->query('select * from kinos.movie_shows join kinos.movies m on m.id = movie_shows.movies_id') as $row) {
    echo "<option value = {$row['id']}>{$row["title"]} {$row['start_of_show']}</option>";
}
echo "</select>";

echo '<input type="submit" onclick="this.form.submit()"/>
    </form>'

?>

</body>
</html>