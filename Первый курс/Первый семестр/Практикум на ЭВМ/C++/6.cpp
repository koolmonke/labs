#include <iostream>
using namespace std;
int main() {
  cout << "Введите порядок матрицы" << '\n';
  int n;
  cin >> n;
  int ar[n][n] = {};
  for (int i = 0; i != n; i++) {
    ar[i][i] = i + 1;
    ar[i][n - 1 - i] = n - i;
  }
  for (int i = 0; i != n; i++) {
    for (int j = 0; j != n; j++)
      cout << ar[i][j] << ' ';
    cout << endl;
  }
  return 0;
}
