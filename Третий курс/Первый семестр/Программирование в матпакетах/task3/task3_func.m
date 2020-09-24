function count = task3_func()
  arr = readmatrix('task3_input.csv');
  count = sum(arr < 1);
end