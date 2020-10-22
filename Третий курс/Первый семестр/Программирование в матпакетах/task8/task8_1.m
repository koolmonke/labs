function output = task8_1()
    ode = @(x, y) [y(2);2 * y(2) - y(1) + 2 * x * exp(x) + exp(x) * sin(2*x)];
    interval = [0 2];
    conditions = [0; 0];

    output = ode23(ode, interval, conditions);
end
