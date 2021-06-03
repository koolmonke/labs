#include <iostream>
#include "linkedlist.h"

using namespace std;


list<int> *CreateList() {
    int in;
    list<int> *first = nullptr;
    do {
        std::cin >> in;
        if (in)
            first = AddLast(first, in);
    } while (in);
    return first;
}


void ToDelete(list<int> *listed) {
    list<int> *current = listed;
    int len = 1, to_delete = 0;
    int last = current->data;
    current = current->next;
    while (current) {
        if (current->data == last) {
            listed = DeleteByNumber(listed, len - to_delete);
            to_delete++;
        }
        last = current->data;
        current = current->next;
        len++;
    }
    if (to_delete != 0)
        ToDelete(listed);
}

int main() {
    list<int> *listed;
    listed = CreateList();
    ToDelete(listed);
    PrintList(listed);
    DeleteList(listed);
    return 0;
}
