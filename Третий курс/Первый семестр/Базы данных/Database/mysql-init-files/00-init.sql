use kinos;

create table workers(
    id int not null auto_increment,
    primary key (id),
    lastname varchar(256),
    firstname varchar(256) not null,
    middlename varchar(256)
);

create table movies(
    id int not null auto_increment,
    primary key (id),
    title varchar(256) not null,
    duration time not null,
    begin_film_release datetime not null,
    end_film_release datetime not null,
    distributor varchar(256) not null
);

create table cinema_halls(
    id int not null auto_increment,
    primary key (id),
    name_of_hall varchar(256) not null,
    description varchar(256)
);

create table seats(
    id int not null auto_increment,
    primary key (id),
    cinema_halls_id int not null references cinema_halls(id),
    foreign key (cinema_halls_id) references cinema_halls(id),
    row_index int not null,
    seat_index int not null
);

create table movie_shows(
    id int not null auto_increment,
    primary key (id),
    cinema_halls_id int not null,
    foreign key (cinema_halls_id) references cinema_halls(id),
    start_of_show datetime not null,
    movies_id int not null references movies(id),
    foreign key (movies_id) references movies(id)
);

create table ops_on_tickets(
    id int not null auto_increment,
    primary key (id),
    date_of_op datetime not null,
    op_type enum('бронь', 'оплата', 'отмена', 'возврат', 'проход'),
    workers_id int not null references workers(id),
    foreign key (workers_id) references workers(id),
    ticket_id int not null,
    foreign key (ticket_id) references tickets(id)
);

create table tickets(
    id int not null auto_increment,
    primary key (id),
    date_of_issue date,
    movie_show_id int not null references movie_shows(id),
    foreign key (movie_show_id) references movie_shows(id),
    seats_id int not null references seats(id),
    foreign key (seats_id) references seats(id),
    is_payed bool not null default (false),
    is_booked bool not null default (false),
    type_of_payment enum('картой', 'наличный расчет')
);