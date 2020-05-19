#include <iostream>
using namespace std;
int to10base(int *str, short int len) {
  int p = 1, n = 0;
  for (int i = len - 1; i >= 0; i--) {
    n += p * str[i];
    p *= 2;
  }
  return n;
}
bool is2base(char *str, short int len) {
  for (int i = 0; i != len; i++) {
    if (str[i] != '1')
      if (str[i] != '0')
        return 0;
  }
  return 1;
}
unsigned long int strlen(char *str) {
  unsigned long int i = 0;
  while (str[i] != '\0')
    ++i;
  return i;
}
int main() {
  char input[256];
  int inputtoi[256] = {};
  int len = 0;
  do {
    std::cin >> input;
    len = strlen(input);
  } while (!is2base(input, len));
  for (int i = 0; i < len; i++) {
    if (input[i] == '0')
      inputtoi[i] = 0;
    else if (input[i] == '1')
      inputtoi[i] = 1;
  }
  // DEBUG
  // std::cout << "strlen(input) = " << len << '\n';
  // std::cout << "is2base = " << is2base(input,len) << '\n';
  cout << to10base(inputtoi, len) << '\n';
  return 0;
}
