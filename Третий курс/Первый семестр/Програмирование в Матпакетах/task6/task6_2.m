function Y = task6_2 (A)
  negative_indexes = find(A < 0);
  positive_indexes = find(A > 0);
  to_delete = []; % Нужные нам индексы negative_indexes(1) и positive_indexes(end)
  
  if ~isempty(negative_indexes)
    to_delete = [negative_indexes(1)];
  end
  
  if ~isempty(positive_indexes)
    to_delete = [to_delete positive_indexes(end)];
  end

  A(to_delete) = [];
  Y = A;

end
