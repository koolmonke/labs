function output = task9_4()
    syms x;

    func = 3 - sqrt(x) - 0.5 * log(x);

    output = taylor(func, x, 1);
end
