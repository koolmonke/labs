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

    plot(x_result_lessorequal, y_result_lessorequal, x_result_greater, y_result_greater);
end
