#include <cmath>
#include <iostream>
using namespace std;
int main() {
  double a;
  cout << "Введите  a ";
  cin >> a;
  // std::cout << tan(M_PI/2) << '\n';
  if (sin(2 * a) != 1)
    cout << "z1=" << (1 - 2 * sin(a) * sin(a)) / (1 + sin(2 * a)) << endl;
  else
    cout << "z1 не существует" << '\n';
  if (!(cos(a) == 0 || (tan(a) == -1)))
    cout << "z2=" << (1 - tan(a)) / (1 + tan(a)) << endl;
  else
    std::cout << "z2 не существует" << '\n';
  return 0;
}
