function task6(arr)
    globals(arr);

    disp('result of globals');
    first = task6_1()

    disp('Result of parametrs');
    second = task6_2(arr)

    disp('Is the same?:');
    disp(isequal(first, second));

end
