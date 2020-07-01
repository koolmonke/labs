#include <cmath>
#include <iostream>

using namespace std;

int main() {
  int n = 0;
  long double x, eps = 0.000001, arth = 1, res = 1;
  cin >> x;
  if (fabs(x) >= 1) {
    while (fabs(arth) > eps) {
      arth *= (2 * n + 1) / ((2 * n + 3) * x * x);
      res += arth;
      n++;
    }
    cout << "arth " << x << " = " << res << '\n';
  } else
    cout << "Невозможно для |x|<1" << '\n';
  return 0;
}
