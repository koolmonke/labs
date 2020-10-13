function task10()
    globals();
    global A b;

    disp('Численное решение:');
    first = task10_1_1();
    disp(first);

    disp('Символьное решение:');
    second = task10_1_2();
    disp(second);

    disp('Крамер:');
    third = task10_2(A, b);
    disp(third);

    disp('1?=2');
    disp(isequal(first, second));
    disp(first - second);

    disp('1?=3');
    disp(isequal(first, third));
    disp(first - third);

    disp('2?=3');
    disp(isequal(second, third));
    disp(second - third);

    [vectors, values, rang] = task10_3();
    disp('Собственные вектора');
    disp(vectors);
	
    disp('Собственные значения');
    disp(values);
	
	disp('Проверка собственных векторов:');
	for i = 1:length(values)
		disp('A*x =? l*x');
		disp(isequal(A*vectors(:,i), vectors(:,i).*values(i,i)));
		
		disp('Порядок разницы');
		disp(A*vectors(:,i) - vectors(:,i).*values(i,i));
	end
	
    disp('Ранг');
    disp(rang);
end
