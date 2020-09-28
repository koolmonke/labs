function output = task10_2(A, b)
    [r, c] = size(A);
    determinant = det(A);

    if (r ~= c || determinant == 0)
        error('Unsolvable by  Cramer`s rule');
    end

    if (r ~= length(b))
        error('Vector length does not coincide with the matrix dimensions');
    end

    size_arr = size(A, 1);

    result = zeros(size_arr, 1);

    for i = 1:size_arr
        B = A;
        B(:, i) = b;
        result(i) = det(B) / determinant;
    end

    output = result;

end
