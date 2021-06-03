#include <cmath>
#include <iostream>
#include <stdexcept>

using namespace std;

double f1(double a, double b, double c, double x) {
    if (c == 0) {
        throw invalid_argument("c == 0, но делить на ноль нельзя");
    }
    return a * x * x + b / c;
}

double f2(double a, double c, double x) {
    if ((x - c) == 0) {
        throw invalid_argument("x - c == 0, но делить на ноль нельзя");
    }
    return (x - a) / ((x - c) * (x - c));
}

double f3(double c, double x) {
    if (c == 0) {
        throw invalid_argument("c == 0, но делить на ноль нельзя");
    }
    return x * x / (c * c);
}

double F(double a, double b, double c, double x) {
    if ((x < 1) && (c != 0)) {
        return f1(a, b, c, x);
    } else if ((x > 1.5) && (c == 0)) {
        return f2(a, c, x);
    } else {
        return f3(c, x);
    }
}

int main() {
    double a, b, c, x_begin, x_end, x_step;
    cout << "Введите a,  b,  c,  X_нач,  X_кон,  dX" << '\n';
    cin >> a >> b >> c >> x_begin >> x_end >> x_step;
    const bool trigger = (((int) a & (int) b) ^ (int) c) != 0;
    while (x_begin <= x_end) {
        try {
            cout << x_begin << ' ';
            if (trigger) {
                cout << F(a, b, c, x_begin) << '\n';
            } else {
                cout << (int) F(a, b, c, x_begin) << '\n';
            }

        } catch (const std::exception &e) {
            std::cerr << e.what() << '\n';
        }

        x_begin += x_step;
    }
    return 0;
}
