var
  i: real;
  p: double;

begin
  i := 0.1;
  p := 1;
  while (i <= 10) do
  begin
    p := p * (1 + sin(i));
    i := i + 0.1;
  end;
  writeln(p)
end.
