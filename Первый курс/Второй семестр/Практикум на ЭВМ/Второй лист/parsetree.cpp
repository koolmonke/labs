#include "parsetree.hpp"
#include <iostream>
using namespace std;
int main(int argc, const char *argv[]) {
  Expr *expr = NULL;
  if (argc > 1) {
    expr = expression(argv[1]);
    print(expr);
    cout << evaluate(expr) << '\n';
    delete expr;
  }
  return 0;
}
