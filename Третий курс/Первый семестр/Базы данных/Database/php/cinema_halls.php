<link rel="stylesheet" href="style.css">
<div class="main_content">
    <p>Все залы:</p>
    <table>
        <tr>
            <th>id</th>
            <th>Название зала</th>
            <th>Описание зала</th>
        </tr>
        <?php
        $db = new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass');

        foreach ($db->query('select * from cinema_halls') as $row) {
            echo '<tr>';
            echo "<th>{$row['id']}</th>";
            echo "<th>{$row['name_of_hall']}</th>";
            echo "<th>{$row['description']}</th>";
            echo "</tr>";
        }
        ?>
    </table>
</div>
