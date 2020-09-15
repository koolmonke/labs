	function S = task2(x)
    table = [];
    S = 1;
    temp = 1;
    even_iter = 5; % Четные
    odd_iter = 2; % Не Четные
    
    while abs(temp) > eps
        temp = even_iter/odd_iter * -x * temp;

        table = [table; temp S];
        
        odd_iter = odd_iter + 2;
        even_iter = even_iter + 2;

        S = S + temp;
    end
    
    T = array2table(table, 'VariableNames', {'Член ряда', 'Сумма членов ряда'})
    writetable(T,'task2_output.csv','WriteRowNames',true);
end
