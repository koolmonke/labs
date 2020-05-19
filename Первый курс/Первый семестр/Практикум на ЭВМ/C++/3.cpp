#include <cmath>
#include <iostream>
using namespace std;
int main() {
  float a, b, c, x_begin, x_end, x_step;
  cout << "Введите a,  b,  c,  X_нач,  X_кон,  dX" << '\n';
  cin >> a >> b >> c >> x_begin >> x_end >> x_step;
  bool trigger = (((int)a & (int)b) ^ (int)c) != 0;
  while (x_begin <= x_end) {
    bool trigger1 =
        !((x_begin < 1) && (c != 0)) && !((x_begin > 1.5) && (c == 0));
    float x = x_begin;
    cout << "|" << x_begin << "| ";
    if (!trigger1) {
      if (trigger) {
        if ((x < 1) && (c != 0))
          cout << (a * x * x + b / c) << '\n';
        else if ((x > 1.5) && (c == 0))
          cout << ((x - a) / pow(x - c, 2.0)) << '\n';
        else
          cout << ((x * x) / (c * c)) << '\n';
      } else {
        if ((x < 1) && (c != 0))
          cout << (int)(a * x * x + b / c) << '\n';
        else if ((x > 1.5) && (c == 0))
          cout << (int)((x - a) / (pow(x - c, 2.0))) << '\n';
        else
          cout << (int)((x * x) / (c * c)) << '\n';
      }
    } else
      cout << "Нельзя делить на ноль" << '\n';
    x_begin += x_step;
  }
  return 0;
}
