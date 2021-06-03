#include "bst.hpp"
#include <iostream>

using namespace std;

int main() {
    BST t;
    int arr[] = {20, 25, 15, 30};
    for (int i : arr) {
        t.insert(i);
    }
    t.display();
    std::cout << "max = " << t.max() << '\n';
}
