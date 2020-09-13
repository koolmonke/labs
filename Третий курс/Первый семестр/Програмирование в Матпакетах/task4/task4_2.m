function task4_2()
    x_less = linspace(-2, -1);
    x_greater = linspace(-1, 2);

    y_less = arrayfun(@(x) lessOrEqual(x), x_less);
    y_greater = arrayfun(@(x) greater(x), x_greater);

    plot(x_less, y_less, x_greater, y_greater);

end
