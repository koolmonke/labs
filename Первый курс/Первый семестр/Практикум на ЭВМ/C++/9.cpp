#include <iostream>
#include <cstring>

using namespace std;

int to10base(const char *str, size_t len) {
    int p = 1, n = 0;
    for (size_t i = len - 1; i != SIZE_MAX; i--) {
        n += p * (str[i] == '0' ? 0 : 1);
        p *= 2;
    }
    return n;
}

bool is2base(const char *str, size_t len) {
    for (size_t i = 0; i != len; i++) {
        if (str[i] != '1' && str[i] != '0')
            return false;
    }
    return true;
}

int main() {
    char input[256];
    size_t len;
    do {
        std::cin >> input;
        len = strlen(input);
    } while (!is2base(input, len));

    cout << to10base(input, len) << '\n';
    return 0;
}
