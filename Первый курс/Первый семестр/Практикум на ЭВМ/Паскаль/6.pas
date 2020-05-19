const
  n = 20;

var
  i, j: integer;
  ar: array[0..n - 1, 0..n - 1] of integer;

begin
  writeln('порядок матрицы n=', n);
  for i := 0 to n - 1  do
  begin
    ar[i, i] := i + 1;
    ar[i, n - i - 1] := n - i;
  end;
  for i := 0 to n - 1 do
  begin
    for j := 0 to n - 1 do
      write(ar[i, j]:4);
    writeln();
  end;
end.
