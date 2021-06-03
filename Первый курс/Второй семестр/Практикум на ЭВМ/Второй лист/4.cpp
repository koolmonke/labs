#include <cmath>
#include <iostream>

using namespace std;

struct Point {
    double x;
    double y;
};

class Triangle {
private:
    double x[3]{};
    double y[3]{};

    friend std::ostream &operator<<(std::ostream &, const Triangle &);


public:
    Triangle(const Point &i, const Point &j, const Point &k) {
        if (k.x * (j.y - i.y) - k.y * (j.x - i.x) == i.x * j.y - j.x * i.y)
            throw invalid_argument("this is straight line or one Point");
        x[0] = i.x;
        x[1] = j.x;
        x[2] = k.x;
        y[0] = i.y;
        y[1] = j.y;
        y[2] = k.y;
    }

    void move(double by_x = 0.0, double by_y = 0.0) {
        for (double &i : x) {
            i += by_x;
        }
        for (double &i : y) {
            i += by_y;
        }
    }

    void resize(double times) {
        for (double &i : x) {
            i *= times;
        }
        for (double &i : y) {
            i *= times;
        }
    }

    void move_by_angle(double deg) {
        const double rad = (deg * M_PI) / 180;
        x[0] = x[0] * cos(rad) - y[0] * sin(rad);
        y[0] = x[0] * sin(rad) + y[0] * cos(rad);
        x[1] = x[1] * cos(rad) - y[1] * sin(rad);
        y[1] = x[1] * sin(rad) + y[1] * cos(rad);
        x[2] = x[2] * cos(rad) - y[2] * sin(rad);
        y[2] = x[2] * sin(rad) + y[2] * cos(rad);
    }
};

std::ostream &operator<<(ostream &stream, const Triangle &triangle) {
    stream << '(' << triangle.x[0] << ',' << triangle.y[0] << ')' << '\n';
    stream << '(' << triangle.x[1] << ',' << triangle.y[1] << ')' << '\n';
    stream << '(' << triangle.x[2] << ',' << triangle.y[2] << ')' << '\n';
    return stream;
}


int main() {
    Point a[3];
    std::cout << "Введите три точки" << '\n';
    for (auto &i : a)
        std::cin >> i.x >> i.y;
    try {
        Triangle t1{a[0], a[1], a[2]};
        std::cout << t1 << '\n';
        std::cout << "resize 2" << '\n';
        t1.resize(2);
        std::cout << t1 << '\n';
        std::cout << "move 2 2" << '\n';
        t1.move(2, 2);
        std::cout << t1 << '\n';
        std::cout << "move_by_angle 180" << '\n';
        t1.move_by_angle(180);
        std::cout << t1 << '\n';
    } catch (exception &e) {
        cerr << e.what() << endl;
    }
    return 0;
}
