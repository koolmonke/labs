function count = task3_iterative()
  arr = readmatrix('task3_input.csv'); % Читаем одномерный массив
  for i = 1:length(arr)
      fprintf('index %d value %d\n', i, arr(i))
  end
  count = 0;
  for i = 1:length(arr)
      if arr(i) < 1
          count = count + 1;
      end
  end
end