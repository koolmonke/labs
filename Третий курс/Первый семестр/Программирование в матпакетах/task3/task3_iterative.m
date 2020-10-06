function count = task3_iterative()
  arr = readmatrix('task3_input.csv'); % Читаем одномерный массив
  disp_array(arr);
  count = 0;
  for i = 1:length(arr)
      if arr(i) < 1
          count = count + 1;
      end
  end
end