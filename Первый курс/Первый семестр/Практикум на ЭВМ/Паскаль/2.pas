var
  fig1, fig2: boolean;
  x, y: Integer;

begin
  writeln('Введите x координату ');
  readln(x);
  writeln('Введите y координату ');
  readln(y);
  fig1 := not ((x - 3) * (x - 3) + (y - 4) * (y - 4) <= 9);
  fig2 := (x * x + y * y <= 64) and (x * y >= 0);
  if  (fig1 and fig2) then writeln('true')
  else writeln('false');
end.
