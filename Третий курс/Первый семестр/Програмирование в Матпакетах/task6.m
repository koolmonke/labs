function Y = task6 (arr)
  negative_indexes = find(arr < 0);
  positive_indexes = find(arr > 0);
  to_delete=[]; % ������ ��� ������� negative_indexes(1) � positive_indexes(end)
  
  if !isempty(negative_indexes) % ������ �������� �� �� ��� ����� ������� ������ ����������
  to_delete = [negative_indexes(1)];
  end;
  
  if !isempty(positive_indexes)
  to_delete=[to_delete positive_indexes(end)]
  end;

  arr(to_delete)=[];
  Y=arr;

endfunction
