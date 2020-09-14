function output = task7_1()
    syms x;
    
    func = exp(-x) * cos(x);

    integral = int(func);
    derivative = diff(integral);
    
    output = [integral, isequal(factor(derivative), factor(func))];
end
