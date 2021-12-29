#include "models.h"
#include <iostream>
#include <string>

int main(int argc, char const *argv[]) {
  const std::string names[] = {"A", "B", "C", "D", "E", "F", "G", "H", "I",
                               "J", "K", "L", "M", "N", "O", "P", "Q", "R",
                               "S", "T", "U", "V", "W", "X", "Y", "Z"};
  const std::array<int, 5> marks = {5, 5, 5, 5, 5};
  const std::array<int, 5> bad_marks = {2, 2, 2, 2, 2};
  Group *grp = new Group;
  for (auto name : names) {
    grp->push_back(new Student(name, marks));
    grp->push_back(new Student(name + name, bad_marks));
  }
  std::cout << "\n___________________ Группа___________________ \n\n";

  // for (auto student : *grp) {
  //   std::cout << "Студент: " <<  student->name <<  " " << student->all_5s()
  //   << '\n';
  // }

  std::cout << "Отличников в группе " << grp->all_5s() << '\n';
  std::cout << "Всего элементов в коллекции " << grp->size() << '\n';
  std::cout << "\n___________________ Факультет___________________ \n\n";
  Faculty *fcl = new Faculty;
  for (size_t i = 0; i < 10; i++) {
    fcl->push_back(grp);
  }
  std::cout << "Отличников на факультете " << fcl->all_5s() << '\n';
  std::cout << "Всего элементов в коллекции " << fcl->size() << '\n';
  return 0;
}
