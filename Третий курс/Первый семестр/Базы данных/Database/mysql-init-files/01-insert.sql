use kinos;

insert into workers (lastname, firstname, middlename) values ('Иванов', 'Кирилл', 'Игоревич');

insert into workers (lastname, firstname, middlename) VALUES ('Примеров', 'Уран', 'Васильевич');

insert into workers (firstname, lastname) VALUES ('Рулон', 'Обоев');

insert into workers (firstname, lastname) VALUES ('Рекорд', 'Надоев');

insert into movies (duration, begin_film_release, end_film_release, distributor, title) VALUES ('01:26:00', '2020-09-15 19:30:10',
                                                                                                '2020-12-15 19:30:10', 'UIP',
                                                                                                'Мададаскар');

insert into movies (duration, begin_film_release, end_film_release, distributor, title) values ('01:48:00', '2020-09-15 19:30:10',
                                                                                                '2020-12-15 19:30:10', 'Двадцатый Век Фокс СНГ',
                                                                                                'Терминатор');

insert into movies (duration, begin_film_release, end_film_release, distributor, title) VALUES ('01:55:00', '2020-09-15 19:30:10',
                                                                                                '2020-12-15 19:30:10','Columbia/Sony',
                                                                                                'Ковбой Бипоп');

insert into cinema_halls (name_of_hall, description) VALUES ('Первый зал', 'Первый зал');

insert into seats (cinema_halls_id, row_index, seat_index) VALUES (1, 1, 1);

insert into seats (cinema_halls_id, row_index, seat_index) VALUES (1, 1, 2);

insert into seats (cinema_halls_id, row_index, seat_index) VALUES (1, 1, 3);

insert into seats (cinema_halls_id, row_index, seat_index) VALUES (1, 1, 4);

insert into seats (cinema_halls_id, row_index, seat_index) VALUES (1, 1, 5);

insert into movie_shows (start_of_show, movies_id, cinema_halls_id) VALUES ('2020-09-15 19:30:10', 1, 1);

