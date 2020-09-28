function task9()
    syms x;
    y(x) = 3 - sqrt(x) - 0.5 * log(x);

    disp('# 1. Domain');
    disp('Domain of the function is: ');
    disp('x > 0');

    disp('# 2. One-sided limits');
    disp('Limit at plus infinity');
    disp(limit(y, x, inf));

    disp('Right side limit at zero');
    disp(limit(y, x, 0, 'right'));

    disp('# 3. Intersections with axis');
    disp('Ox');
    disp(vpasolve(y == 0, x));
    disp('Oy');
    disp(y(0));

    disp('# 4. Parity');
    disp(OddOrEven(y));

    disp('# 5. Is periodic?');
    disp('No :)');

    disp('# 6. Extremums');
    dy(x) = diff(y, x);
    extr = solve(dy == 0, x);

    sgn_p = sign(dy(extr + rand()));
    sgn_m = sign(dy(extr - rand()));

    fprintf('     %0d      %d      %0d     \n', sgn_m, extr, sgn_p);

    if sgn_m < sgn_p
        disp('Local minimum: ');
    else
        disp('Local maximum: ');
    end

    disp(double(y(extr)));

    disp('# 7. Convexity')

    ddy = diff(dy, x);
    extr = solve(ddy == 0, x);

    sgn_p = sign(ddy(extr + rand()));
    sgn_m = sign(ddy(extr - rand()));
    fprintf('     %0d      %d      %0d     \n', sgn_m, extr, sgn_p);

    if sgn_m > 0
        fprintf('Strictly convex when x < %d\n', extr);
    else
        fprintf('Convex when x < %d\n', extr');
    end

    if sgn_m > 0
        fprintf('Strictly convex when x > %d\n', extr);
    else
        fprintf('Convex when x > %d\n', extr');
    end

    disp('# 8. Horizontal and vertiacal asymptotes');
    disp('No horizontal limits, because limit to +inf is -inf and -inf is undefined');

    disp('y = k*x + b');
    k = limit(y / x, x, inf);
    b = limit(y - k * x, x, inf);
    fprintf('y = %d * x + %d\n', k, b);

    disp('No inclined asymptotes');

    disp('# 9. Plot');
    a = input('Left edge of interval to plot\n');
    b = input('Right edge of interval to plot\n');
    task9_1(a, b)

    disp('# 10. Taylor series');

    disp('Taylor expansion at x = 1');
    pretty(taylor(y, x, 1));
end

function isOdd = OddOrEven(symfunc)

    if symfunc(-1) == symfunc(1)
        isOdd = 'Function is odd';
    elseif symfunc(-1) == -symfunc(1)
        isOdd = 'Function is even';
    else
        isOdd = 'Function isn`t odd or even';
    end

end
