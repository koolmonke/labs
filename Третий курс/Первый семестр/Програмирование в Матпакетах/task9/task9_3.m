function output = task9_3()
    syms x;

    func = 3 - sqrt(x) - 0.5 * log(x);

    output = double(solve(diff(func) == 0, x));
end
