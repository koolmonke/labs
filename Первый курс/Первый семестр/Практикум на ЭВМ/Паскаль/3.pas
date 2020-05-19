var
  x_begin, x_end, x_step, a, b, c, x: real;
  trigger, trigger1: boolean;

begin
  writeln('Введите a,  b,  c,  x_нач,  x_кон,  dx');
  readln(a, b, c, x_begin, x_end, x_step);
  trigger := ((trunc(a) and trunc(b)) xor trunc(c)) <> 0;
  while x_begin <= x_end do
  begin
    x := x_begin;
    trigger1 := not ((x_begin < 1) and (c <> 0)) and not ((x_begin > 1.5) and (c = 0));
    write('|', x_begin, '| ');
    if not trigger1 then
    begin
      if trigger then
      begin
        if (x < 1) and (c <> 0) then
        begin
          writeln(a * x * x + b / c);
        end
        else if (x > 1.5) and (c = 0) then
          writeln((x - a) / ((x - c) * (x - c)))
        else writeln((x * x) / (c * c));
      end
        else
      begin
        if (x < 1) and (c <> 0) then
        begin
          writeln(trunc(a * x * x + b / c));
        end
        else if (x > 1.5) and (c = 0) then
          writeln(trunc((x - a) / ((x - c) * (x - c))))
        else writeln(trunc((x * x) / (c * c)));
      end;
    end
    else
      writeln('Нельзя делить на ноль');
    x_begin := x_begin + x_step;
  end;
end.
