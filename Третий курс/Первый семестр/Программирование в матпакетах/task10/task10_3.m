function [vectors, values, rank_arr] = task10_3()
    global A
	
    [vectors, values] = eig(A);
    rank_arr = rank(A);
end
