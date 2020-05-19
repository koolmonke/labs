#include <cstring>
#include <iostream>
struct MARSH {
  char begin[256];
  char end[256];
  int bus;
};
void printstuct(MARSH t) {
  std::cout << "название начального пункта " << t.begin << '\n';
  std::cout << "название конечного пунка " << t.end << '\n';
  std::cout << "номер маршута " << t.bus << '\n';
}
int main() {
  const int lenmarshes = 8;
  MARSH marshes[lenmarshes];
  std::cout << "Введите маршуты" << '\n'; // Ввод маршутов
  for (size_t i = 0; i < lenmarshes; i++) {
    std::cout << i << "-й ввод" << '\n';
    std::cout << "Введите название начального пункта" << '\n';
    std::cin >> marshes[i].begin;
    std::cout << "Введите название конечного пунка" << '\n';
    std::cin >> marshes[i].end;
    std::cout << "Введите номер маршута" << '\n';
    std::cin >> marshes[i].bus;
  }
  for (int i = 0; i < lenmarshes; i++) {
    MARSH temp = marshes[i];
    int j = i - 1;
    while (j >= 0 && marshes[j].bus > temp.bus) {
      marshes[j + 1] = marshes[j];
      j--;
    }
    marshes[j + 1] = temp;
  }
  std::cout << "Введите пункт маршута, который нужно найти" << '\n';
  char point[256];
  bool any = 0;
  std::cin >> point;
  for (size_t i = 0; i < lenmarshes; i++) {
    if ((std::strncmp(marshes[i].begin, point, 256) == 0) ||
        (std::strncmp(marshes[i].end, point, 256) == 0)) {
      printstuct(marshes[i]);
      any = 1;
    }
  }
  if (!any)
    std::cout << "Нет таких" << '\n';
  // for (size_t i = 0; i < lenmarshes; i++) {
  //   printstuct(marshes[i]);
  // }
  return 0;
}
