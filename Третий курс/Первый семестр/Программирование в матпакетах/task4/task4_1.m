function task4_1()
    y_result_greater = [];
    y_result_lessorequal = [];

    x_result_greater = [];
    x_result_lessorequal = [];

    for x = linspace(-2, 2)

        if (x <= -1)
            x_result_lessorequal = [x_result_lessorequal [x]];
            y_result_lessorequal = [y_result_lessorequal [lessOrEqual(x)]];
        else
            x_result_greater = [x_result_greater [x]];
            y_result_greater = [y_result_greater [greater(x)]];
        end

    end

    plot(x_result_lessorequal, y_result_lessorequal, 'r', x_result_greater, y_result_greater, 'r');
    legend('y = 2*ln(1+x^2), x <= -1', 'y = (1+cos(x)^2)^(3/5), x > 0');
end
