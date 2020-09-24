function task5()
    task5_inner(@geomean, 'task5_output_matlab.csv')
    task5_inner(@my_geomean, 'task5_output_iter.csv')
end

function task5_inner(geomean_func, file)
    A = readmatrix('task5_input.csv');

    fid = fopen(file, 'wt');
    fprintf(fid, 'ИСХОДНАЯ МАТРИЦА\n');
    
    fclose(fid);
    writematrix(A, file, 'WriteMode', 'append');
    
    m = geomean_func(A);
    for i=1:length(A)
        A(i,i)=m(i);
    end
    
    fid = fopen(file, 'at');
    fprintf(fid, '\nПРЕОБРАЗОВАННАЯ МАТРИЦА\n');
    fclose(fid);

    writematrix(A, file, 'WriteMode', 'append');
end