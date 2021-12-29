#include "complex.h"

int main() {
  Complex complex;
  std::cout << "Введите комплексное число (действ. и комплексная часть должны "
               "быть разделены вайтспейсом)"
            << '\n';
  try {
    std::cin >> complex;
  } catch (const std::exception& e) {
    std::cerr << e.what() << '\n';
    return 0;
  }

  std::cout << "Комплексное число = " << complex << '\n';
  return 0;
}