#include <cmath>
#include <iostream>

using namespace std;

void find_and_replace(int *array, int size) {
    int min = abs(array[0]);
    for (int i = 0; i < size; i++)
        if (min > abs(array[i]))
            min = abs(array[i]);
    for (int i = 0; i < size; i += 2) {
        array[i] = min;
    }
}

int main() {
    int n;
    cout << "Введите размерность массива" << '\n';
    cin >> n;
    int a[n];
    for (int i = 0; i < n; i++) {
        cout << "Введите " << i + 1 << " элемент массива ";
        cin >> a[i];
    }
    find_and_replace(a, n);
    for (int i = 0; i < n; i++) {
        cout << a[i] << ' ';
    }
    cout << '\n';
    return 0;
}
