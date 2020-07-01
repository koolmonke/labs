#include <iostream>

using namespace std;

int main() {
  float x, y;
  cout << "Введите координаты x и y ";
  cin >> x >> y;
  bool fig1 = !((x - 3) * (x - 3) + (y - 4) * (y - 4) <= 9);
  bool fig2 = (x * x + y * y <= 64) && (x * y >= 0);
  if ((fig1 && fig2))
    cout << "true" << endl;
  else
    cout << "false" << endl;
  return 0;
}
