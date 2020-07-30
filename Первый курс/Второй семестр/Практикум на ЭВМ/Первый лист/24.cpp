#include "linkedlist.h"
#include <cstdio>
#include <iostream>
struct utf16_t {
  unsigned char a;
  unsigned char b;
};

std::ostream &operator<<(std::ostream &os, const utf16_t &t) {
  os << t.a << t.b;
  return os;
}

bool operator==(const utf16_t &l, const utf16_t &r) {
  return (l.a == r.a) && (l.b == r.b);
}

bool operator!=(const utf16_t &l, const utf16_t &r) {
  return !operator==(l, r);
}

using namespace std;

int main(int argc, char const *argv[]) {
  if (argc != 2) {
    cout << "Usage: " << argv[0] << " <filename>" << '\n';
    return 1;
  }
  FILE *inputfile = fopen(argv[1], "r");
  if (!inputfile) {
    cout << "Файл недоступен" << '\n';
    return 1;
  }
  char symbol[2], c;
  list<utf16_t> *listed = 0, *trashed = 0;
  utf16_t buf;
  size_t i = 0;
  while ((c = fgetc(inputfile)) != EOF) {
    if ((unsigned char)c >= 128)
      symbol[i++] = c;
    if (i == 2) {
      i = 0;
      buf.a = symbol[0], buf.b = symbol[1];
      if (!InList(listed, buf) && (!InList(trashed, buf)))
        listed = AddLast(listed, buf);
      else {
        if (InList(listed, buf)) {
          listed = DeleteByValue(listed, buf);
          if (!InList(trashed, buf))
            trashed = AddLast(trashed, buf);
        }
      }
    }
  }
  PrintList(listed);
  return 0;
}
