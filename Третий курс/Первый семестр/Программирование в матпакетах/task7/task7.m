function output = task7()
    disp('Символьный иниеграл');

    first = task7_1();

    disp('Интеграл:');
    first(1)

    disp('Равны ли производная и изначальная функция?:');
    disp(first(2));

    second = task7_2();
    third = task7_3()

    disp('Интегралы от второго и третьего:');
    second = double(second)

    disp('Они равны?:');
    disp(isequal(second, third));
    
    disp('Разница между вторым и первым');
    disp(second - third);
end
