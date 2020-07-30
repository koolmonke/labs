#include <iostream>

using namespace std;

struct list {
  int data;
  list *next;
};

list *AddFirst(list *first, int in) {
  if (!first) {
    first = new list;
    first->data = in;
    first->next = 0;
    return first;
  } else {
    list *Add = new list;
    Add->data = in;
    Add->next = first;
    first = Add;
  }
  return first;
}

list *AddLast(list *first, int in) {
  list *Add = new list;
  Add->data = in;
  Add->next = 0;
  if (!first)
    return Add;
  else {
    list *current = first;
    while (current->next)
      current = current->next;
    current->next = Add;
    return first;
  }
}

list *CreateList() {
  int in;
  list *first = 0;
  do {
    std::cin >> in;
    if (in)
      first = AddLast(first, in);
  } while (in);
  return first;
}

list *DeleteByNumber(list *first, int numb) {
  list *previous;
  list *current = first;
  int i = 0;
  while ((i != numb) && current) {
    previous = current;
    current = current->next;
    i++;
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

void DeleteList(list *first) {
  if (first->next) {
    list *current = first->next;
    while (current->next) {
      delete first;
      first = current;
      if (current->next)
        current = current->next;
    }
  }
}

void PrintList(list *first) {
  list *current = first;
  while (current) {
    cout << current->data << ' ';
    current = current->next;
  }
  cout << endl;
}

void Placestodelete(list *listed) {
  list *current = listed;
  int len = 1, todelete = 0;
  int last = current->data;
  current = current->next;
  while (current) {
    if (current->data == last) {
      listed = DeleteByNumber(listed, len - todelete);
      todelete++;
    }
    last = current->data;
    current = current->next;
    len++;
  }
  if (todelete != 0)
    Placestodelete(listed);
}

int main() {
  list *listed;
  listed = CreateList();
  Placestodelete(listed);
  PrintList(listed);
  DeleteList(listed);
  return 0;
}
