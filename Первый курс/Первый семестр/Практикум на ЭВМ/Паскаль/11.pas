const
  N = 10;

type
  mas = array[1..N] of integer;

var
  a: mas;
  i: integer;

procedure findandreplace(var array1: mas);
var
  min, i: integer;
begin
  min := abs(a[1]);
  for i := 1 to N do
    if min > abs(a[i]) then
      min := abs(array1[i]);
  i := 1;
  while i <= N do
  begin
    array1[i] := min;
    i := i + 2;
  end;
end;

begin
  for i := 1 to N do
  begin
    write('Введите ', i, ' элемент ');
    readln(a[i])
  end;
  findandreplace(a);
  for i := 1 to N do
    write(a[i], ' ');
  writeln();
end.
