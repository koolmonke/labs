 #include <iostream>
template <typename T> struct list {
  list *next;
  T data;
  list(T a_data, list *a_next = 0) : next(a_next), data(a_data) {}
};

template <typename T> list<T> *AddFirst(list<T> *first, T in) {
  if (!first) {
    first = new list<T>(in);
    return first;
  } else {
    list<T> *Add = new list<T>(in);
    Add->next = first;
    first = Add;
  }
  return first;
}

template <typename T> list<T> *AddLast(list<T> *first, T in) {
  list<T> *Add = new list<T>(in);
  if (!first)
    return Add;
  else {
    list<T> *current = first;
    while (current->next)
      current = current->next;
    current->next = Add;
    return first;
  }
}

template <typename T> list<T> *InsertByNumber(list<T> *first, T in, int numb) {
  list<T> *current = first;
  int i = 0;
  while ((i < numb - 1) && current) {
    current = current->next;
    i++;
  }
  list<T> *Add = new list<T>(in);
  if ((i == numb - 1) && current) {
    Add->next = current->next;
    current->next = Add;
    return first;
  }
  if (numb == 0) {
    Add->next = first;
    return Add;
  }
  return first;
}

template <typename T> list<T> *DeleteByValue(list<T> *first, T search) {
  if (!first)
    return first;
  else {
    list<T> *previous = 0;
    list<T> *current = first;
    while ((current) && (current->data != search)) {
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

template <typename T> list<T> *DeleteByNumber(list<T> *first, int numb) {
  if (!first)
    return first;
  else {
    list<T> *previous = 0;
    list<T> *current = first;
    int i = 0;
    while ((i < numb) && current) {
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
}

template <typename T>
void PrintList(list<T> *first, const char sep = ' ', const char end = '\n') {
  if (!first)
    return;
  list<T> *current = first;
  while (current) {
    std::cout << current->data << sep;
    current = current->next;
  }
  std::cout << end;
  std::cout << std::flush;
}

template <typename T> bool InList(list<T> *first, T in) {
  if (!first)
    return 0;
  list<T> *current = first;
  while (current) {
    if (current->data == in)
      return 1;
    current = current->next;
  }
  return 0;
}

template <typename T> bool isEmply(list<T> *first) { return !first; }

template <typename T> void DeleteList(list<T> *first) {
  if (first) {
    list<T> *current = first->next;
    while (current->next) {
      delete first;
      first = current;
      if (current->next)
        current = current->next;
    }
  }
}

template <typename T> void Sorted(list<T> *first) {
  list<T> *current = first;
  while (current && current->next) {
    if (current->data > current->next->data)
      std::swap(current->data, current->next->data);
    current = current->next;
  }
}
