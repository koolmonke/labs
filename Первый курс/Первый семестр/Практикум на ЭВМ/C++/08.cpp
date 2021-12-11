#include <iostream>
#include <cstring>

using namespace std;

void print_slice(const char *str, size_t start, size_t end) {
    for (size_t i = start; i <= end; i++) {
        cout << str[i];
    }
}

int main() {
    char input[256];
    bool is_k = false;
    cin.getline(input, 255);
    size_t len = strlen(input) + 1;
    input[strlen(input)] = ' ';
    input[strlen(input)+1] = '\0';
    size_t start = 0, end = 0;
    for (size_t i = 0; i < len; i++) {
        if ((input[i] != ' ') && (input[i] != ',')) {
            end = i;
            if ((input[i] == 'k') || (input[i] == 'K')) {
                is_k = true;
            }
        } else {
            if (is_k) {
                print_slice(input, start, end);
                cout << " ";
                cout << "start=" << start << " end=" << end << " size=" << end - start + 1
                     << " is_k=" << is_k << '\n';
            }
            start = i + 1;
            is_k = false;
        }
    }
    cout << '\n';
}
