function output = task9_2()
    syms x;

    func = (3 - sqrt(x) - 0.5 * log(x) == 1);

    output = solve(func, x, 'MaxDegree', 5);
end
