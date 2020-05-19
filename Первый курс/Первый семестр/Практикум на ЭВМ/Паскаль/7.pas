var
  a: array[1..256, 1..256] of integer;
  n, m, i, j, k, k_min, i_max, j_max, t: integer;

begin
  repeat
    write('Enter n, m: ');
    readln(n, m);
  until (n in [1..256]) and (m in [1..256]);
  for i := 1 to n do
  begin
    for j := 1 to m do
    begin
      readln(a[i, j]);
    end;
    writeln();
  end;
  writeln('Matrix:');
  for i := 1 to n do
  begin
    for j := 1 to m do
    begin
      write(a[i, j], #9);
    end;
    writeln;
  end;
  i_max := 1; j_max := 1;
  for i := 1 to n do
    for j := 1 to m do
      if  abs(a[i, j]) > abs(a[i_max, j_max]) then
      begin
        i_max := i;
        j_max := j;
      end;
  writeln('Max = a[', i_max, ',', j_max, '] = ', a[i_max, j_max]);
  if n < m then k_min := n
  else k_min := m;
  repeat
    write('Enter k ');
    readln(k);
  until k in [1..k_min];
  for i := 1 to n do
  begin
    t := a[i, k];
    a[i, k] := a[i, j_max];
    a[i, j_max] := t;
  end;
  for j := 1 to m do
  begin
    t := a[k, j];
    a[k, j] := a[i_max, j];
    a[i_max, j] := t;
  end;
  writeln('New Matrix:');
  for i := 1 to n do
  begin
    for j := 1 to m do
      write(a[i, j], #9);
    writeln();
  end;
end.
