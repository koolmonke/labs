function disp_array(array_to_display)
  for i = 1:length(array_to_display)
      fprintf('A[%d]=%d\n', i, array_to_display(i))
  end
end

