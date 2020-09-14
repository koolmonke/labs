function output = task7()
    disp('Symbolic integral');

    first = task7_1();

    disp('Integral:');
    first(1)

    disp('Is derivative same as start function?:');
    disp(first(2));

    second = task7_2();
    third = task7_3()

    disp('Integrals from second and third:');
    second = double(second)

    disp('Is equal?:');
    disp(isequal(second, third));
    
    disp('Difference between second and third:');
    disp(second - third);
end
