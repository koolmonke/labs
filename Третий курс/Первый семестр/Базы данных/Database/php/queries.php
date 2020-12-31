<!DOCTYPE html>
<meta charset="UTF-8">
<html lang="RU-ru">
<head>
    <title>Запросы к БД</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main_content">
    <ol>
        <li>
            <form action="queries/lastnames.php" method="post">
                Работники, фамилии которых заканчиваются на
                <label title="Фамилия">
                    <input type="text" name="lastname" required>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/avg_movie_len.php" method="post">
                Средняя длина фильма
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/count_seats_in_cinema_hall.php" method="post">
                Количество мест в зале
                <label title="Название зала">
                    <select name="cinema_halls_id">
                        <?php
                        include "Utils.php";
                        $db = Utils::getPDO();
                        foreach ($db->query("select * from cinema_halls") as $item) {
                            echo "<option value={$item['id']}>{$item['name_of_hall']}</option>";
                        }
                        ?>
                    </select>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/movie_shows_on_date.php" method="post">
                Все сеансы в конкретный день
                <label title="Дата сеансов">
                    <select name="date">
                        <?php
                        foreach ($db->query("select distinct date(start_of_show) as new_start from movie_shows order by new_start") as $item) {
                            echo "<option value={$item['new_start']}>{$item['new_start']}</option>";
                        }
                        ?>
                    </select>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/movies_newer_than_date.php" method="post">
                Все фильмы, премьеры которых произошли после даты
                <label title="Дата премьеры">
                    <select name="date">
                        <?php
                        foreach ($db->query("select distinct date(start_of_show) as new_start from movie_shows order by new_start") as $item) {
                            echo "<option value={$item['new_start']}>{$item['new_start']}</option>";
                        }
                        ?>
                    </select>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/movies_shorter_than_time.php" method="post">
                Все фильмы, которые короче какой-то продолжительности
                <label title="Продолжительности фильма">
                    <input type="time" name="length" required>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/movies_in_specific_cinema_hall_and_date.php" method="post">
                Все фильмы в определенном зале, в определенный день
                <label title="Название зала">
                    <select name="cinema_halls_id">
                        <?php
                        foreach ($db->query("select id, name_of_hall from cinema_halls order by id") as $row) {
                            echo "<option value={$row['id']}>{$row['name_of_hall']}</option>";
                        }
                        ?>
                    </select>
                </label>
                <label title="Дата фильма">
                    <select name="date">
                        <?php
                        foreach ($db->query("select distinct date(start_of_show) as new_start from movie_shows order by new_start") as $item) {
                            echo "<option value={$item['new_start']}>{$item['new_start']}</option>";
                        }
                        ?>
                    </select>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/tickets_by_type_of_payment.php" method="post">
                Билеты по типу оплаты
                <label title="Вид оплаты">
                    <select name="type_of_payment">
                        <option value="картой">картой</option>
                        <option value="наличный расчет">наличный расчет</option>
                    </select>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/workers_older_than.php" method="post">
                Работники старше определенного возраста
                <label title="Возраст">
                    <input type="number" min="16" name="age" required>
                </label>
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/top_n_ops_per_worker.php" method="post">
                Топ <label title="Кол-во работников">
                    <input type="number" min="1" name="n" required>
                </label> работников по количествую операций
                <input type="submit" value="Выполнить">
            </form>
        </li>
        <li>
            <form action="queries/top_n_movies_by_amount_of_tickets_sold.php" method="post">
                Топ <label title="Кол-во фильмов">
                    <input type="number" min="1" name="n" required>
                </label> фильмов по количеству проданных билетов
                <input type="submit" value="Выполнить">
            </form>
        </li>
    </ol>
    <a style="margin: 25px" class="buttons" href="index.php">Назад</a>
</div>

</body>
</html>