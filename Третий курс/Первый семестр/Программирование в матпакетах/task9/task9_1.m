function task9_1()
    func = @(x) (3 - sqrt(x) - 0.5 * log(x));
    x = linspace(0, 500);

    plot(x, func(x));
end
