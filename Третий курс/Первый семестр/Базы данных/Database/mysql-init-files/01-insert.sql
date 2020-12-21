use kinos;

insert into workers (lastname, firstname, dob)
values ('Иванов', 'Кирилл', '2000-12-05');

insert into workers (lastname, firstname, dob)
VALUES ('Примеров', 'Уран', '2000-12-05');

insert into workers (firstname, lastname, dob)
VALUES ('Рулон', 'Обоев', '2000-12-05');

insert into workers (firstname, lastname, dob)
VALUES ('Рекорд', 'Надоев', '2000-12-05');

insert into movies (duration, begin_film_release, end_film_release, distributor, title)
VALUES ('01:26:00', '2020-09-15 19:30:10',
        '2020-12-15 19:30:10', 'UIP',
        'Мададаскар');

insert into movies (duration, begin_film_release, end_film_release, distributor, title)
values ('01:48:00', '2020-09-15 19:30:10',
        '2020-12-15 19:30:10', 'Двадцатый Век Фокс СНГ',
        'Терминатор');

insert into movies (duration, begin_film_release, end_film_release, distributor, title)
VALUES ('01:55:00', '2020-09-15 19:30:10',
        '2020-12-15 19:30:10', 'Columbia/Sony',
        'Ковбой Бипоп');

insert into cinema_halls (name_of_hall, description)
VALUES ('Первый зал', 'Основной зал');

insert into cinema_halls (name_of_hall, description)
VALUES ('Второй зал', 'Малый зал');

insert into seats (cinema_halls_id, row_index, seat_index)
VALUES (1, 1, 1);

insert into seats (cinema_halls_id, row_index, seat_index)
VALUES (1, 1, 2);

insert into seats (cinema_halls_id, row_index, seat_index)
VALUES (1, 1, 3);

insert into seats (cinema_halls_id, row_index, seat_index)
VALUES (1, 1, 4);

insert into seats (cinema_halls_id, row_index, seat_index)
VALUES (1, 1, 5);

insert into seats (cinema_halls_id, row_index, seat_index)
VALUES (2, 1, 1);

insert into movie_shows (start_of_show, movies_id, cinema_halls_id)
VALUES ('2020-09-15 19:30:10', 1, 1);

insert into tickets (id, date_of_issue, movie_show_id, seats_id, is_payed, is_booked, type_of_payment)
VALUES (2, '2020-12-21', 1, 2, 1, 1, 'картой');

insert into kinos.ops_on_tickets (date_of_op, op_type, workers_id, ticket_id)
VALUES ('2020-12-21 16:40:48', null, 1, 2);
insert into kinos.ops_on_tickets (date_of_op, op_type, workers_id, ticket_id)
VALUES ('2020-12-21 16:41:27', null, 2, 2);
insert into kinos.ops_on_tickets (date_of_op, op_type, workers_id, ticket_id)
VALUES ('2020-12-21 16:41:31', null, 1, 2);
insert into kinos.ops_on_tickets (date_of_op, op_type, workers_id, ticket_id)
VALUES ('2020-12-21 17:00:22', null, 1, 2);
insert into kinos.ops_on_tickets (date_of_op, op_type, workers_id, ticket_id)
VALUES ('2020-12-21 17:00:34', null, 1, 2);



