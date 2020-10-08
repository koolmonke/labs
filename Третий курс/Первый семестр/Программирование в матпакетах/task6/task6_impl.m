function o = task6_impl(i)
  negative_indexes = find(i < 0);
  positive_indexes = find(i > 0);
  to_delete = []; % Нужные нам индексы negative_indexes(1) и positive_indexes(end)
  
  if ~isempty(negative_indexes)
    to_delete = [negative_indexes(1)];
  end
  
  if ~isempty(positive_indexes)
    to_delete = [to_delete positive_indexes(end)];
  end

  i(to_delete) = [];
  o = i;
end