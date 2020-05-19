#include "bst.hpp"
#include <iostream>
using namespace std;

int main() {
  BST t;
  int arr[] = {20,25,15,30};
  for (size_t i = 0; i < 4; i++) {
    t.insert(arr[i]);
  }
  t.display();
  std::cout << "max = " << t.max() << '\n';
}
