function output = task10_2()
    global A;
    global b;

    determinant = det(A);

    size_arr = size(A, 1);

    result = zeros(size_arr, 1);

    for i = 1:size_arr
        B = A;
        B(:, i) = b;
        result(i) = det(B) / determinant;
    end

    output = result;

end
