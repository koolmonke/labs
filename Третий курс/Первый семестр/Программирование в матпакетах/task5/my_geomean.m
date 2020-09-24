function vec_geomean = my_geomean(matrix)
    vec_geomean = [];
    for col = matrix
        prod_iter = 1;
        for i=1:size(col)
            item = col(i);
            prod_iter = prod_iter * item;
        end
        vec_geomean = [vec_geomean, nthroot(prod_iter, length(col))];
    end
end

