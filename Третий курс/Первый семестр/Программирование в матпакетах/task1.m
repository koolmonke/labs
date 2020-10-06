function task1()
    a = 4.72;
    b = 1.25;
    d = -0.01;
    x = 2.25;
    i = 2;
    k = 3;
    f(a, b, d, x, i, k)
end

function y = f(a, b, d, x, i, k)
    y = (a*x^2+abs(d))/(a+b)^2-10^4 * nthroot((k*x)/(a+b)^2, 5)-(cos(i))/(sin(k*x));
end