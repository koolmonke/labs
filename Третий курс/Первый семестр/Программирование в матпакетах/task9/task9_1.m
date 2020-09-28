function task9_1(a, b)
    func = @(x) (3 - 0.3 * sqrt(x) + 0.5 * log(x));
    x = linspace(a, b, 5000);

    plot(x, func(x));
    title('$y(x)=3-\sqrt{x}-0.5\ln{x}$', 'Interpreter', 'latex', 'FontSize', 14)
end
