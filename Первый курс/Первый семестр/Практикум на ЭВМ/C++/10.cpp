#include <iostream>

using namespace std;

size_t strlen(const char *str) {
  size_t i = 0;
  while (str[i] != '\0')
    i++;
  return i;
}

char *str_ukaz(char *a, char *b) {
  for (size_t i = strlen(a) - 1; i > 0; i--)
    for (size_t j = strlen(b) - 1; j > 0; j--)
      if (a[i] == b[j])
        return &a[i];
  // cout << a[i] << ' ' << &a[i] << '\n';
  return NULL;
}

int main() {
  char a[256], b[256];
  cin.getline(a, 256);
  cin.getline(b, 256);
  // char b[]="122323";
  // char a[]="123535253";
  cout << str_ukaz(a, b) << '\n';
  return 0;
}
