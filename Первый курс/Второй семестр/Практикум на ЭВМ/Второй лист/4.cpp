#include <cmath>
#include <iostream>

using namespace std;

struct point {
  float x;
  float y;
};

class Triangle {
private:
  point point1;
  point point2;
  point point3;

public:
  Triangle(point i, point j, point k) {
    if (k.x * (j.y - i.y) - k.y * (j.x - i.x) == i.x * j.y - j.x * i.y)
      throw invalid_argument("this is straight line or one point");
    point1 = i;
    point2 = j;
    point3 = k;
  }

  void move(float byx = 0.0, float byy = 0.0) {
    point1.x += byx;
    point1.y += byy;
    point2.x += byx;
    point2.y += byy;
    point3.x += byx;
    point3.y += byy;
  }

  void resize(float times) {
    point1.x *= times;
    point1.y *= times;
    point2.x *= times;
    point2.y *= times;
    point3.x *= times;
    point3.y *= times;
  }

  void movebyangle(int deg) {
    long double rad = (deg * M_PI) / 180;
    point1.x = point1.x * cos(rad) - point1.y * sin(rad);
    point1.y = point1.x * sin(rad) + point1.y * cos(rad);
    point2.x = point2.x * cos(rad) - point2.y * sin(rad);
    point2.y = point2.x * sin(rad) + point2.y * cos(rad);
    point3.x = point3.x * cos(rad) - point3.y * sin(rad);
    point3.y = point3.x * sin(rad) + point3.y * cos(rad);
  }

  void print() {
    std::cout << '(' << point1.x << ',' << point1.y << ')' << '\n';
    std::cout << '(' << point2.x << ',' << point2.y << ')' << '\n';
    std::cout << '(' << point3.x << ',' << point3.y << ')' << '\n';
    std::cout << '\n';
  }
};

int main(int argc, char const *argv[]) {
  point a[3];
  std::cout << "Введите три точки" << '\n';
  for (size_t i = 0; i < 3; i++)
    std::cin >> a[i].x >> a[i].y;
  try {
    Triangle t1{a[0], a[1], a[2]};
    t1.print();
    std::cout << "resize 2" << '\n';
    t1.resize(2);
    t1.print();
    std::cout << "move 2 2" << '\n';
    t1.move(2, 2);
    t1.print();
    std::cout << "movebyangle 180" << '\n';
    t1.movebyangle(180);
    t1.print();
  } catch (exception &e) {
    cerr << e.what() << endl;
  };
  return 0;
}
