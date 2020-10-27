function task9()
    syms x;
    y(x) = 3 - sqrt(x) - 0.5 * log(x);

    disp('# 1. Область опред');
    disp('Область определения функции: ');
    disp('x > 0');

    disp('# 2. Односторонние приделы');
    disp('Предел к бесконечности');
    disp(limit(y, x, inf));

    disp('Предел справа к нулю');
    disp(limit(y, x, 0, 'right'));

    disp('# 3. Пересечение с осями');
    disp('Ox');
    disp(vpasolve(y == 0, x));
    disp('Oy');
    disp(y(0));

    disp('# 4. Четность');
    disp('Функция ни четная ни нечетная');

    disp('# 5. Периодическая?');
    disp('Нет');

    disp('# 6. Экстремумы');
    dy(x) = diff(y, x);
    extr = solve(dy == 0, x);
    if isempty(extr)
        disp('Экстремумов нет');
    else
        extr = [0, extr, extr(end) + 1]; % Массив всех граничных точек
        for i = 1:length(extr) 
            if i == 1 || i == length(extr)
                continue;
            else
                sgn_m = sign(dy((extr(i)- extr(i-1))/2)); % Нашли точку между экстремумами либо экстр и границей
                sgn_p = sign(dy((extr(i+1) - extr(i))/2)); % Нашли точку справа от экстр до следующего экстремума, либо точку м/у экстремуом и границей
                
                fprintf('     %0d      %d      %0d     \n', sgn_m, extr(i), sgn_p);

                if sgn_m < sgn_p
                    disp('Локальный минимум: ');
                else
                    disp('Локальный максимум: ');
                end

                disp(double(y(extr(i))));
            end
                
        end
    end

    disp('# 7. Выпуклость')

    ddy = diff(dy, x);
    extr = solve(ddy == 0, x);

    if isempty(extr)
        disp('Точек перегиба нет');
        if sign(ddy(1)) > 0
            disp('Всюду вогнуто');
        else
            disp('Всюду выпукло');
        end
    else
        extr = extr(imag(extr) == 0);
        extr = [0, extr, extr(end) + 1]; % Массив всех граничных точек
        for i = 1:length(extr) 
            if i == 1 || i == length(extr)
                continue;
            else
                sgn_m = sign(ddy((extr(i)- extr(i-1))/2)); % Нашли точку между экстремумами либо экстр и границей
                sgn_p = sign(ddy((extr(i+1) - extr(i))/2)); % Нашли точку справа от экстр до следующего экстремума, либо точку м/у экстремуом и границей
                
                fprintf('     %0d      %d      %0d     \n', sgn_m, extr(i), sgn_p);

                if double(sgn_m) > 0
                       fprintf('Вогнута, когда x < %d\n', extr(i));
                else
                       fprintf('Выпукла, когда x < %d\n', extr(i));
                end

                if double(sgn_p) > 0
                       fprintf('Вогнута, когда x > %d\n', extr(i));
                else
                       fprintf('Выпукла, когда x > %d\n', extr(i));
                end

            end
        end     
    end

    disp('# 8. Горизонт и вертикальные асимптоты');
    disp('Нет горизонтальных придел, потому что предел к +inf это -inf и -inf это undefined');

    disp('y = k*x + b');
    k = limit(y / x, x, inf);
    b = limit(y - k * x, x, inf);
    fprintf('y = %d * x + %d\n', k, b);

    disp('f(x) -> inf, при x -> +0');

    disp('# 9. График');
    b = input('Правый край интервала для постройки\n');
    func = @(x) (3 -  sqrt(x) - 0.5 * log(x));

    plot(linspace(0, b, 5000000), func(linspace(0, b, 5000000)));
    title('$y(x)=3-\sqrt{x}-0.5\ln{x}$', 'Interpreter', 'latex', 'FontSize', 14)

    disp('# 10. ряд Тейлора');

    disp('Taylor expansion at x = 1');
    pretty(taylor(y, x, 1));
end
