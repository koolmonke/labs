#include <algorithm>
#include <iostream>
#include <list>
#include <vector>

int IsOdd(const int n) { return n % 2 == 1; }

int main(int argc, char const *argv[]) {
  std::vector<int> v{1, 2, 3, 4, 5, 6, 7};
  std::cout << "Вектор" << '\n';
  for (int a : v) {
    std::cout << a << ' ';
  }
  std::cout << '\n';
  // std::list<int> ll;
  std::vector<int> v2{1, 2, 3, 4, 5, 6, 7};
  // std::copy(v.cbegin(), v.cend(), std::back_inserter(ll));
  // std::replace_if(v.begin(), v.end(), IsOdd, 0);
  for (size_t i = 0; i < 2; i++) {
    v2.erase(v.begin()+i);
  }
  
  std::cout << "Второй вектор" << '\n';
  for (int a : v2) {
    std::cout << a << ' ';
  }
  std::cout << '\n';
  std::cout << "Измен первый вектор" << '\n';
  for (int a : v) {
    std::cout << a << ' ';
  }
  std::cout << '\n';
  return 0;
}
