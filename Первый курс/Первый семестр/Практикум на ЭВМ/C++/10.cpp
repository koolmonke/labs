#include <iostream>
#include <cstring>

using namespace std;


const char *str_ukaz(const char *a, const char *b) {
    for (size_t j = strlen(b) - 1; j > 0; j--)
        for (size_t i = strlen(a) - 1; i > 0; i--)
            if (a[i] == b[j])
                return &a[i];
    // cout << a[i] << ' ' << &a[i] << '\n';
    return nullptr;
}

int main() {
    char a[256], b[256];
    cin.getline(a, 256);
    cin.getline(b, 256);
//    char b[] = "122323";
//    char a[] = "123535253";
    cout << str_ukaz(a, b) << '\n';
    return 0;
}
