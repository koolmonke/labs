function task6_1()
    global A
    global output
    persistent n1
    if isempty(n1)
        n1 = 0;
    end
    n1 = n1+1;
    output = task6_impl(A);
    fprintf('task6_1 было запущено %d раз(а)\n', n1)
end
