function output = task10_1_2()
    global A;
    global b;

    syms x1 x2 x3 x4;

    SLAQ = A * [x1; x2; x3; x4] == b;

    solution = solve(SLAQ);

    output = [double(solution.x1); double(solution.x2); double(solution.x3); double(solution.x4)];
end
