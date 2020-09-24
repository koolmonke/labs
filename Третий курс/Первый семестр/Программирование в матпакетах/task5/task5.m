function task5()
    task5_inner(@geomean,'task5_input.csv', 'task5_output_matlab.csv')
    task5_inner(@my_geomean, 'task5_input.csv', 'task5_output_iter.csv')
end

function task5_inner(geomean_func, file_in, file_out)
    A = readmatrix(file_in);
    [num_rows,num_columns] = size(A);
    if num_rows ~= num_columns
        return;
    end
    
    fid = fopen(file_out, 'wt');
    fprintf(fid, 'ИСХОДНАЯ МАТРИЦА\n');
    
    fclose(fid);
    writematrix(A, file_out, 'WriteMode', 'append');
    
    m = geomean_func(A);
    for i=1:length(A)
        A(i,i)=m(i);
    end
    
    fid = fopen(file_out, 'at');
    fprintf(fid, '\nПРЕОБРАЗОВАННАЯ МАТРИЦА\n');
    fclose(fid);

    writematrix(A, file_out, 'WriteMode', 'append');
end