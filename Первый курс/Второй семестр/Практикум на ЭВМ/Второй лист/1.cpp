
#include "bst.hpp"
#include <iostream>
using namespace std;

int main() {
  BST t;
  for (size_t i = 0; i < 12; i++) {
    int buf;
    std::cin >> buf;
    t.insert(buf);
  }
  // t.insert(-1);
  t.newPrint();
  // t.display();
  std::cout << "Mintreelen=" << t.mintreelen() << '\n';
}
