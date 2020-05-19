#include <cmath>
#include <iostream>
int main() {
  double s = 1;
  float i = 0.1;
  while (i <= 10) {
    s *= (1 + sin(i));
    i += 0.1;
  }
  std::cout << s << '\n';
  return 0;
}
