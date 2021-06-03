#include "linkedlist.h"
#include <cstdio>
#include <iostream>

struct utf16 {
    unsigned char a;
    unsigned char b;
};

std::ostream &operator<<(std::ostream &os, const utf16 &t) {
    os << t.a << t.b;
    return os;
}

bool operator==(const utf16 &l, const utf16 &r) {
    return (l.a == r.a) && (l.b == r.b);
}

bool operator!=(const utf16 &l, const utf16 &r) {
    return !operator==(l, r);
}

using namespace std;

int main(int argc, char const *argv[]) {
    if (argc != 2) {
        cout << "Usage: " << argv[0] << " <filename>" << '\n';
        return 1;
    }
    FILE *input_file = fopen(argv[1], "r");
    if (!input_file) {
        cout << "Файл недоступен" << '\n';
        return 1;
    }
    char symbol[2], c;
    list<utf16> *listed = nullptr, *trashed = nullptr;
    utf16 buf{};
    size_t i = 0;
    while ((c = fgetc(input_file)) != EOF) {
        if ((unsigned char) c >= 128)
            symbol[i++] = c;
        if (i == 2) {
            i = 0;
            buf.a = symbol[0], buf.b = symbol[1];
            if (!InList(listed, buf) && !InList(trashed, buf))
                listed = AddLast(listed, buf);
            else if (InList(listed, buf)) {
                listed = DeleteByValue(listed, buf);
                if (!InList(trashed, buf))
                    trashed = AddLast(trashed, buf);
            }
        }
    }
    PrintList(listed);
    return 0;
}
