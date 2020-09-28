function task10()
    globals();
    global A b;

    disp('Numeric solution in matlab:');
    first = task10_1_1();
    disp(first);

    disp('Symbolic solution in matlab:');
    second = task10_1_2();
    disp(second);

    disp('Cramer`s rule:');
    third = task10_2(A, b);
    disp(third);

    disp('Are the same?:');

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
    disp('Eigenvectors');
    disp(vectors);
	
    disp('Eigenvalues');
    disp(values);
	
	disp('Eigenvectors check:');
	for i = 1:length(values)
		disp('A*x =? l*x');
		disp(isequal(A*vectors(:,i), vectors(:,i).*values(i,i)));
		
		disp('Order of difference');
		disp(A*vectors(:,i) - vectors(:,i).*values(i,i));
	end
	
    disp('Rank');
    disp(rang);
end
