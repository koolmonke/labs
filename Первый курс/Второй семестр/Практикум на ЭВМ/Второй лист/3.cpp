#include "linkedlist.hpp"
#include <iostream>
using namespace std;
bool LessThan30InList(list<float> *first) {
    if (!first)
        return false;
    list<float> *current = first;
    while (current) {
        if (current->data <= 30)
            return true;
        current = current->next;
    }
    return false;
}

list<float> *DeleteLessThan30(list<float> *first) {
    if (!first)
        return first;
    else {
        list<float> *previous = nullptr;
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
    list<float> *listed = nullptr;
    float buf;
    while (true) {
        std::cin >> buf;
        if (buf != 0)
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
    while (LessThan30InList(listed))
        listed = DeleteLessThan30(listed);
    PrintList(listed);
    return 0;
}
