#include <cmath>
#include <iostream>
using namespace std;
int main() {
  int n, m;
  std::cout << "Enter n,m" << '\n';
  cin >> n >> m;
  int a[n][m];
  for (size_t i = 0; i < n; i++) {
    for (size_t j = 0; j < m; j++) {
      cin >> a[i][j];
    }
  }
  cout << "Matrix:" << '\n';
  for (size_t i = 0; i < n; i++) {
    for (size_t j = 0; j < m; j++) {
      cout << a[i][j] << '\t';
    }
    cout << '\n';
  }
  int i_max = 0, j_max = 0;
  for (size_t i = 0; i < n; i++) {
    for (size_t j = 0; j < m; j++) {
      if (abs(a[i][j]) > abs(a[i_max][j_max])) {
        i_max = i;
        j_max = j;
      }
    }
  }
  cout << "Max a[" << i_max + 1 << "][" << j_max + 1 << "]"
       << "=" << a[i_max][j_max] << '\n';
  int k;
  cout << "Enter k" << '\n';
  cin >> k;
  k--;
  int t;
  for (size_t i = 0; i < n; i++) {
    t = a[i][k];
    a[i][k] = a[i][j_max];
    a[i][j_max] = t;
  }
  for (size_t j = 0; j < m; j++) {
    t = a[k][j];
    a[k][j] = a[i_max][j];
    a[i_max][j] = t;
  }
  cout << "New Matrix" << '\n';
  for (size_t i = 0; i < n; i++) {
    for (size_t j = 0; j < m; j++) {
      cout << a[i][j] << '\t';
    }
    cout << '\n';
  }
  return 0;
}
