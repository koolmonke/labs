var
  input: string;
  i, p, n, len: integer;

function is2base(input: string): boolean;
begin
  for i := 0 to len do
    if (ord(input[i]) - 48 > 1) then
      exit(false);
  exit(true);
end;

begin
  n := 0; p := 1;
  repeat
    readln(input);
    len := length(input);
  until (is2base(input) = True);
  for i := len downto 0 do
  begin
    if input[i] = '1' then n := n + p;
    p := p * 2;
  end;
  writeln(n);
end.
