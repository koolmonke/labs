function task4_1()
    y_result_greater = [];
    y_result_less_or_equal = [];

    x_result_greater = [];
    x_result_less_or_equal = [];

    for x = linspace(-2, 2, 300000)

        if (x <= -1)
            x_result_less_or_equal = [x_result_less_or_equal [x]];
            y_result_less_or_equal = [y_result_less_or_equal [less_or_equal(x)]];
        else
            x_result_greater = [x_result_greater [x]];
            y_result_greater = [y_result_greater [greater(x)]];
        end

    end

    plot(x_result_less_or_equal, y_result_less_or_equal, 'r', x_result_greater, y_result_greater, 'r');
    hold on
    scatter(-1, 1.181);
    hold off
    legend('y = 2*ln(1+x^2), x <= -1', 'y = (1+cos^2x)^0^.^6, x > -1');
    
end
