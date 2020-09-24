function task5_func()
    A = readmatrix('task5_input.csv')
    m = geomean(A)
    file = 'task5_output.csv';

    fid = fopen(file, 'wt');
    fprintf(fid, 'ИСХОДНАЯ МАТРИЦА\n');
    
    fclose(fid);
    writematrix(A, file, 'WriteMode', 'append');
    
    for i=1:length(A)
        A(i,i)=m(i);
    end
    fid = fopen(file, 'at');
    fprintf(fid, '\nПРЕОБРАЗОВАННАЯ МАТРИЦА\n');
    fclose(fid);

    writematrix(A, file, 'WriteMode', 'append');
end