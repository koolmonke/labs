function disp_array(arr, col)
    len = length(arr);
    row = ceil(len / col);
    str = '';
    template = int2str(length(int2str(len)));
	template = strcat('\tA[%', template);
	template = strcat(template, 'd] = %5.3f\t');

    for i = 1:row

        for j = 1:col
            index = TwoToOne(i, j, row);

            if (index <= len)
                str = strcat(str, sprintf(template, index, arr(index)));

            end

        end

        disp(str);
        str = '';
    end

end

function index = TwoToOne(i, j, columns)
    index = 1 + (i - 1) + ((j - 1) * columns);
end