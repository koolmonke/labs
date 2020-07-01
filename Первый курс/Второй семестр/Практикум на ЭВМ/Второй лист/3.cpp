#include "linkedlist.hpp"
#include <iostream>
using namespace std;
bool lessthan30inlist(list<float> *first) {
  if (!first)
    return 0;
  list<float> *current = first;
  while (current) {
    if (current->data <= 30)
      return 1;
    current = current->next;
  }
  return 0;
}

list<float> *Deletelessthan30(list<float> *first) {
  if (!first)
    return first;
  else {
    list<float> *previous = 0;
    list<float> *current = first;
    while (current && (current->data > 30)) {
      previous = current;
      current = current->next;
    }
    if (current) {
      if (previous) {
        previous->next = current->next;
        delete current;
        return first;
      } else {
        first = current->next;
        delete current;
        return first;
      }
    } else
      return first;
  }
}

int main(int argc, char const *argv[]) {
  list<float> *listed = 0;
  float buf;
  while (true) {
    std::cin >> buf;
    if (buf)
      listed = AddFirst(listed, buf);
    else
      break;
  }
  list<float> *current = listed;
  float avg = 0;
  size_t count = 0;
  while (current) {
    if (current->data >= 15) {
      avg += current->data;
      count++;
    }
    current = current->next;
  }
  if (count)
    avg = avg / count;
  std::cout << "avg=" << avg << '\n';
  while (lessthan30inlist(listed))
    listed = Deletelessthan30(listed);
  PrintList(listed);
  return 0;
}
