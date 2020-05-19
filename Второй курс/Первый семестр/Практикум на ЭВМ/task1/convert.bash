#!/usr/bin/env bash

for f in ./*; do
  cat $f | iconv -f CP1251 -t UTF8 -c -o $f;
  dos2unix $f;
done

