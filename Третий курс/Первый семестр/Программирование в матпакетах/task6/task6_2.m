function Y = task6_2(A)
  Y = task6_impl(A);
  persistent n2
  if isempty(n2)
      n2 = 0;
  end
  n2 = n2+1;
  fprintf('task6_2 было запущено %d раз(а)\n', n2)
end
