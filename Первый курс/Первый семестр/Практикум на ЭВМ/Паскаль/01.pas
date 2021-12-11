
var
  a: real;
  z1, z2: real;

begin
  write('Введите целое a ');
  readln(a);
  if (sin(2 * a) <> 1) then
    z1 := (1 - 2 * sqr(sin(a))) / (1 + sin(2 * a))
  else writeln('z1 не существует');
  if not ((cos(a) = 0) or (tan(a) = -1)) then
    z2 := (1 - tan(a)) / (1 + tan(a))
  else writeln('z2 не существует');
  writeln('z1=', z1:2:4);
  writeln('z2=', z2:2:4);
end.
