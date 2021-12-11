var
  n: integer;
  x, eps, arth, res: real;

begin
  eps := 0.000001;
  n := 0; arth := 1; res := 1;
  readln(x);
  if abs(x) >= 1 then
  begin
    while abs(arth) > eps do
    begin
      arth := arth * (2 * n + 1) / ((2 * n + 3) * x * x);
      res := res + arth;
      inc(n);
    end;
    writeln('arth ', x:2, ' = ', res);
  end
  else
    writeln('Невозможно для |x|<1')
end.
