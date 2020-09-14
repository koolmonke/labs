	function S = task2(x)
    table = [];
    S = 1;
    sign = true;
    temp = 1;
    counter_index = 1;
    even_iter = 5; % Четные
    odd_iter = 2; % Не Четные
    
    while temp > eps
        temp = even_iter/odd_iter * x * temp;

        table = [table; temp S];
        
        
        counter_index = counter_index + 1;
        odd_iter = odd_iter + 2;
        even_iter = even_iter + 2;
        if sign
            S = S + -temp;
        else
            S = S + temp;
        end
        sign = ~sign;
    end
    
    T = array2table(table, 'VariableNames', {'Член ряда', 'Сумма членов ряда'})
    writetable(T,'task2_output.csv','WriteRowNames',true);
end
