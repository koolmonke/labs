#include <iostream>
using namespace std;
size_t strlen(const char *str) {
  size_t i = 0;
  while (str[i] != '\0')
    ++i;
  return i;
}
void printslice(char *str, size_t start, size_t end) {
  for (size_t i = start; i <= end; i++) {
    cout << str[i];
  }
}

int main() {
  char input[256];
  bool isk = 0;
  cin.getline(input, 256);
  size_t len = strlen(input);
  input[strlen(input)] = ' ';
  size_t start = 0, end = 0;
  for (size_t i = 0; i < len; i++) {
    if ((input[i] != ' ') || (input[i] != ',')) {
      end = i;
      if ((input[i] == 'k') || (input[i] == 'K'))
        isk = 1;
    } else {
      if (isk) {
        printslice(input, start, end);
        cout << " ";
      }
      cout << "start=" << start << " end=" << end << " size=" <<
      end-start+1 << " isk=" << isk <<'\n';
      start = i + 1;
      isk = 0;
    }
  }
  cout << '\n';
}
