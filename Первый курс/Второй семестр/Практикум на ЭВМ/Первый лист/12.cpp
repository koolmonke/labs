#include "linkedlist.h"
#include <cstring>
#include <iostream>

using namespace std;

struct table {
    char word[256];
    int pages[10];
    size_t amount_of_pages;
};

enum Input {
    quit,
    input,
    output,
    by_word,
    by_page,
};


std::ostream &operator<<(std::ostream &os, const table &t) {
    os << "Слово " << t.word << '\n';
    os << "Страницы ";
    for (size_t i = 0; i < t.amount_of_pages; i++) {
        os << t.pages[i] << ' ';
    }
    return os;
}

Input menu() {
    cout << "Выберете пункт меню" << '\n';
    cout
            << "Вывод(O), Ввод(I), Найти по слову(W), Найти по странице(P), Выход (Q)"
            << '\n';
    while (true) {
        char ans;
        cin >> ans;
        if (ans == 'Q')
            return quit;
        else if (ans == 'O')
            return output;
        else if (ans == 'I')
            return input;
        else if (ans == 'W')
            return by_word;
        else if (ans == 'P')
            return by_page;
    }
}

bool exist_on_page(list<table> *current, int page) {
    bool exist = false;
    bool local_exist;
    while (current->next) {
        for (int i = 0; i < page; i++) {
            local_exist = false;
            if (current->data.pages[i] == page) {
                exist = true;
                local_exist = true;
            }
        }
        if (local_exist)
            cout << current->data << '\n';
        current = current->next;
    }
    return exist;
}

bool word_exist(list<table> *current, const char* word) {
    bool exist = false;
    while (current->next) {
        if (strncmp(current->data.word, word, 256) == 0) {
            cout << current->data << '\n';
            exist = true;
        }
        current = current->next;
    }
    return exist;
}

bool check_yes_no() {
    cout << "(y/n)" << '\n';
    while (true) {
        char ans;
        cin >> ans;
        if (ans == 'y')
            return true;
        else if (ans == 'n')
            return false;
    }
}

int main() {
    size_t len = 1;
    auto buf = table{};
    list<table> *current = nullptr;
    auto *listed = new list<table>(buf);
    while (true) {
        enum Input check = menu();
        if (check == Input::quit) {
            break;
        } else if (check == Input::output)
            PrintList(current);
        else if (check == Input::input) {
            while (true) {
                cout << "Введите слово номер " << len << '\n';
                cin >> buf.word;
                cout << "Введите кол-во страниц от 1 до 10 включительно" << '\n';
                do {
                    cin >> buf.amount_of_pages;
                } while (!((buf.amount_of_pages <= 10) && (buf.amount_of_pages >= 1)));
                cout << "Введите страницы" << '\n';
                for (size_t i = 0; i < buf.amount_of_pages; i++) {
                    cin >> buf.pages[i];
                }
                cout << buf << '\n';
                cout << "Верно?" << '\n';
                if (check_yes_no()) {
                    len++;
                    listed = AddFirst(listed, buf);
                    break;
                }
            }
        } else if ((check == Input::by_word) && !isEmpty(listed)) {
            char word[256];
            cin >> word;
            if (!word_exist(current, word)) {
                cout << "Нет таких слов" << '\n';
            }
        } else if ((check == Input::by_page) && !isEmpty(listed)) {
            int page;
            cin >> page;
            if (!exist_on_page(current, page))
                cout << "Нет таких страниц" << '\n';
        }
        if (isEmpty(listed))
            cout << "Ошибка сегментирования" << '\n';
        current = listed;
    }
    delete current;
    DeleteList(listed);
    return 0;
}
