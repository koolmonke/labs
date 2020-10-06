function count = task3_func()
  arr = readmatrix('task3_input.csv');
  disp_array(arr);
  count = sum(arr < 1);
end