#include <cstring>
#include <iostream>
#include "linkedlist.h"
using namespace std;

struct table {
  char word[256];
  int pages[10];
  size_t amountofpages;
};

std::ostream &operator<<(std::ostream &os, const table &t) {
  os << "Слово " << t.word << '\n';
  os << "Страницы ";
    for (size_t i = 0; i < t.amountofpages; i++) {
      os << t.pages[i] << ' ';
    }
  return os;
}
int checkme() {
  const char exit = 'E';
  const char printlist = 'O';
  const char inputlist = 'I';
  const char findbyword = 'W';
  const char findbypage = 'P';
  cout << "Выберете пункт меню" << '\n';
  cout
      << "Вывод(O), Ввод(I), Найти по слову(W), Найти по странице(P), Выход (E)"
      << '\n';
  while (true) {
    char ans;
    cin >> ans;
    if (ans == exit)
      return 0;
    else if (ans == printlist)
      return 1;
    else if (ans == inputlist)
      return 2;
    else if (ans == findbyword)
      return 3;
    else if (ans == findbypage)
      return 4;
  }
}
bool findbypage(list<table> *current, int page) {
  bool exist = 0;
  bool localexist;
  while (current->next) {
    for (int i = 0; i < page; i++) {
      localexist = 0;
      if (current->data.pages[i] == page) {
        exist = 1;
        localexist = 1;
      }
    }
    if (localexist)
      cout << current->data << '\n';
    current = current->next;
  }
  return exist;
}
bool findbyword(list<table> *current, const char word[256]) {
  bool exist = 0;
  while (current->next) {
    if (strncmp(current->data.word, word, 256) == 0) {
      cout << current->data << '\n';
      exist = 1;
    }
    current = current->next;
  }
  return exist;
}
bool checkq() {
  cout << "(y/n)" << '\n';
  while (true) {
    char ans;
    cin >> ans;
    if ((ans == 'y') || (ans == 'y'))
      return ans == 'y';
  }
}
int main() {
  size_t len = 1;
  table buf;
  list<table> *current = 0;
  list<table> *listed = new list<table>(buf);
  bool emplylist = 1;
  while (true) {
    int check = checkme();
    if (check == 0) {
      break;
    } else if ((check == 1) && !(emplylist))
      PrintList(current);
    else if (check == 2) {
      while (true) {
        cout << "Введите слово номер " << len << '\n';
        cin >> buf.word;
        cout << "Введите кол-во страниц от 1 до 10 включительно" << '\n';
        do {
          cin >> buf.amountofpages;
        } while (!((buf.amountofpages <= 10) && (buf.amountofpages >= 1)));
        cout << "Введите страницы" << '\n';
        for (size_t i = 0; i < buf.amountofpages; i++) {
          cin >> buf.pages[i];
        }
        std::cout << buf << '\n';
        cout << "Верно?" << '\n';
        if (checkq()) {
          len++;
          listed = AddFirst(listed, buf);
          emplylist = 0;
          break;
        }
      }
    } else if ((check == 3) && !(emplylist)) {
      char word[256];
      cin >> word;
      if (!findbyword(current, word)) {
        cout << "Нет таких слов" << '\n';
      }
    } else if ((check == 4) && !(emplylist)) {
      int page;
      cin >> page;
      if (!findbypage(current, page))
        cout << "Нет таких страниц" << '\n';
    }
    if (emplylist)
      cout << "Ошибка сегментирования" << '\n';
    current = listed;
  }
  delete current;
  DeleteList(listed);
  return 0;
}
