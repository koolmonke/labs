function task4_2()
    x_less = linspace(-2, -1);
    x_greater = linspace(-1, 2);

    y_less = arrayfun(@(x) lessOrEqual(x), x_less);
    y_greater = arrayfun(@(x) greater(x), x_greater);

    plot(x_less, y_less, 'r', x_greater, y_greater, 'r');
    hold on
    scatter(-1, 1.181);
    hold off
    legend('y = 2*ln(1+x^2), x <= -1', 'y = (1+cos^2x)^0^.^6, x > -1');
end
