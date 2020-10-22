function task8()
    first = task8_1();
    second = task8_2();
    xx = linspace(0, 2);

    plot(first.x, first.y, xx, second(xx));
    legend('Численные методы','Первая производная','Символьный метод')
end
