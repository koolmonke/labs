<?php

include "Utils.php";
function render_seats(): string
{
    $html = '<table>
        <tr>
            <th>id</th>
            <th>Номер ряда</th>
            <th>Номер места</th>
            <th class="foreign_items">Номер зала</th>
            <th class="foreign_items">Название зала</th>
            <th class="foreign_items">Описание зала</th>
        </tr>';
    $db = Utils::getPDO();

    foreach ($db->query('select seats.id seats_pk, cinema_halls_id, row_index, seat_index, name_of_hall, description from kinos.seats join cinema_halls ch on ch.id = seats.cinema_halls_id order by seats_pk') as $row) {
        $html .= "<tr>
                      <th>{$row['seats_pk']}</th>
                      <th>{$row['row_index']}</th>
                      <th>{$row['seat_index']}</th>
                      <th class='foreign_items'>{$row['cinema_halls_id']}</th>
                      <th class='foreign_items'>{$row['name_of_hall']}</th>
                      <th class='foreign_items'>{$row['description']}</th>
                  </tr>";
    }
    $html .= "</table>";
    return $html;
}
