function output = task9_5()
    syms x;

    func = 3 - sqrt(x) - 0.5 * log(x);

    plusinf = limit(func, x, +inf);
    minusinf = limit(func, x, -inf);

    output = [plusinf, minusinf];
end
