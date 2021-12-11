var
  input:string;
  i,len,start,endl:integer;
  isk:boolean;
  
begin
  isk:=False;
  start:=1;
  readln(input);
  input:=input+' ';
  len:=Length(input);
  for i := 1 to len do
  begin
    if input[i] <> ' ' then
    begin
      endl := i;
      if (input[i] = 'k') or (input[i] = 'K') then isk := True;
    end
    else
    begin
      if isk then
        write(input[start..endl],' ');
      start := i+1;
      isk := False;
    end;
  end;
  writeln();
end.
