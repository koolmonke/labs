#include <cmath>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <ctime>
#include <iostream>

unsigned int str2uint(const char *string) {
    size_t out = 0;
    size_t base10 = 1;
    for (int i = std::strlen(string) - 1; i >= 0; i--) {
        out += (string[i] - '0') * base10;
        base10 *= 10;
    }
    return out;
}

int main(int argc, char const *argv[]) {
    if (argc != 2) {
        std::cout << "Usage: " << argv[0] << " <unsigned int>" << '\n';
        return 0;
    }
    std::srand(time(nullptr));
    FILE *output_file = std::fopen("file_A", "w");
    size_t count = 0;
    for (size_t i = 0; i < str2uint(argv[1]); i++) {
        unsigned int random_number = std::rand();
        fprintf(output_file, "%u \n", random_number);
    }
    fclose(output_file);
    FILE *input_file = fopen("file_A", "r");
    unsigned int t = 0;
    for (int status = 0; status != -1; status = fscanf(input_file, "%u", &t)) {
        if ((t % 8 == 1) && (std::pow((int)std::sqrt(t), 2) == t))
            count++;
    }
    std::cout << '\n';
    std::cout << "Количество квадратов нечетных чисел " << count << '\n';
    return 0;
}
