#include <algorithm>
#include <iostream>
#include <list>
#include <vector>

class Point {
private:
  int x, y;

public:
  int getX() { return x; }
  int getY() { return y; }
  Point(const int &_x, const int &_y) : x{_x}, y{_y} {}
  friend std::ostream &operator<<(std::ostream &os, Point &obj) {
    os << "Point(x = ";
    os << obj.x;
    os << ", y = ";
    os << obj.y;
    os << ")";
    return os;
  }

  bool operator==(const Point &arg) {
    return this->x == arg.x && this->y == arg.y;
  }

  bool operator>(const Point &arg) {
    return this->x > arg.x && this->y > arg.y;
  }

  bool operator<(const Point &arg) {
    return this->x < arg.x && this->y < arg.y;
  }

};


bool isOdd(Point n) { return n.getX() % 2 == 1 && n.getY() % 2 == 1; }

int main(int argc, char const *argv[]) {
  std::vector<Point> v;
  const int n = 5;
  for (size_t i = 0; i < n; i++) {
    Point tmp(i + 1, n - i);
    v.push_back(std::move(tmp));
  }

  std::cout << "Вектор" << '\n';
  for (auto a : v) {
    std::cout << a << '\n';
  }
  std::list<Point> ll;
  std::copy(v.cbegin(), v.cend(), std::back_inserter(ll));
  const Point replace(100, 100);
  std::replace_if(v.begin(), v.end(), isOdd, replace);
  std::cout << "Список" << '\n';
  for (auto a : ll) {
    std::cout << a << '\n';
  }
  std::cout << "Измененный вектор" << '\n';
  for (auto a : v) {
    std::cout << a << '\n';
  }
  return 0;
}
