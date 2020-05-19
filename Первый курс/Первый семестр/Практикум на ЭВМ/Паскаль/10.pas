
var
  a, b: string;

function str_ukaz(var a, b: string): integer;
var
  i, j: integer;
begin
  // bmax := 0;
  for i := length(a) downto 1  do
  begin
    for j := length(b) downto  1 do
    begin
      if (a[i] = b[j]) then
      begin
          // str_ukaz :=i;
        exit(i);
      end;
    end;
  end;
  str_ukaz := 0;
end;

begin
  readln(a);
  readln(b);
  writeln(str_ukaz(a, b));
  writeln('Finish')
end.
