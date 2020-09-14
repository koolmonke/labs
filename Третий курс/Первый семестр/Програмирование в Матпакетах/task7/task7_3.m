function output = task7_3()
    func = @(x) (exp(-x) .* cos(x));

    a = 0;
    b = 2;

    output = integral(func, a, b, 'RelTol', 1e-6);
end
