#include <cstring>
#include <iostream>

struct MARSH {
    char begin[256];
    char end[256];
    int bus;
};

void print_struct(MARSH &t) {
    std::cout << "название начального пункта " << t.begin << '\n';
    std::cout << "название конечного пунка " << t.end << '\n';
    std::cout << "номер маршута " << t.bus << '\n';
}

int main() {
    const int len_marshes = 8;
    MARSH marshes[len_marshes];
    std::cout << "Введите маршуты" << '\n'; // Ввод маршутов
    for (size_t i = 0; i < len_marshes; i++) {
        std::cout << i + 1 << "-й ввод" << '\n';
        std::cout << "Введите название начального пункта" << '\n';
        std::cin >> marshes[i].begin;
        std::cout << "Введите название конечного пунка" << '\n';
        std::cin >> marshes[i].end;
        std::cout << "Введите номер маршута" << '\n';
        std::cin >> marshes[i].bus;
    }
    for (int i = 0; i < len_marshes; i++) {
        MARSH temp = marshes[i];
        int j = i - 1;
        while (j >= 0 && marshes[j].bus > temp.bus) {
            marshes[j + 1] = marshes[j];
            j--;
        }
        marshes[j + 1] = temp;
    }
    std::cout << "Введите пункт маршута, который нужно найти" << '\n';
    char point[256];
    bool any = false;
    std::cin >> point;
    for (auto &marsh : marshes) {
        if ((std::strncmp(marsh.begin, point, 256) == 0) ||
            (std::strncmp(marsh.end, point, 256) == 0)) {
            print_struct(marsh);
            any = true;
        }
    }
    if (!any)
        std::cout << "Нет таких" << '\n';

    return 0;
}
