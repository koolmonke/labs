function output = task7_2()
    syms x;
    a = 0;
    b = 2;

    func = exp(-x) * cos(x);
    integral = int(func, a, b);

    output = integral;
end
