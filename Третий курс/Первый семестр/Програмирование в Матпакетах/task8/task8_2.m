function output = task8_2()
    syms y(x);
    Dy = diff(y);

    ode = (diff(y, x, 2) - 2 * diff(y, x) + y == 2 * x * exp(x) + exp(x) * sin(2*x));
    conds = [(y(0) == 0) (Dy(0) == 0)];
    ySol(x) = dsolve(ode, conds);

    output = simplify(ySol);

end
