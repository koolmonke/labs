function Y = task6 (arr)
  negative_indexes = find(arr < 0);
  positive_indexes = find(arr > 0);
  to_delete = []; % Нужные нам индексы negative_indexes(1) и positive_indexes(end)
  
  if !isempty(negative_indexes) % Делаем проверки на то что такие индексы вообще существуют
  to_delete = [negative_indexes(1)];
  end;
  
  if !isempty(positive_indexes)
  to_delete = [to_delete positive_indexes(end)]
  end;

  arr(to_delete) = [];
  Y = arr;

endfunction
