#include <algorithm>
#include <iostream>
#include <list>
#include <vector>

class Point {
private:
  int x, y;

public:
  int getX() const { return x; }
  int getY() const { return y; }
  Point(const int &_x, const int &_y) : x{_x}, y{_y} {}
  friend std::ostream &operator<<(std::ostream &os, Point &obj) {
    os << "Point(x = ";
    os << obj.x;
    os << ", y = ";
    os << obj.y;
    os << ")";
    return os;
  }
  // bool operator==(const Point &arg) {
  //   return this->x == arg.x && this->y == arg.y;
  // }
  // bool operator>(const Point &arg) {
  //   return this->x > arg.x && this->y > arg.y;
  // }
  // bool operator<(const Point &arg) {
  //   return this->x < arg.x && this->y < arg.y;
  // }
};

bool operator==(const Point &lhs, const Point &rhs) {
  return lhs.getX() == rhs.getX() && lhs.getY() == rhs.getY();
}

bool operator>(const Point &lhs, const Point &rhs) {
  return lhs.getX() > rhs.getX() && lhs.getY() > rhs.getY();
}

bool operator<(const Point &lhs, const Point &rhs) {
  return lhs.getX() < rhs.getX() && lhs.getY() < rhs.getY();
}


bool operator==(const Point &lhs, int rhs) {
  return lhs.getX() == rhs && lhs.getY() == rhs;
}

bool operator>(const Point &lhs, int rhs) {
  return lhs.getX() > rhs && lhs.getY() > rhs;
}

bool operator<(const Point &lhs, int rhs) {
  return lhs.getX() < rhs && lhs.getY() < rhs;
}


int main(int argc, char const *argv[]) {
  std::vector<Point> v;
  const int n = 5;
  for (size_t i = 0; i < n; i++) {
    Point tmp(i - n + 1, i - n + 1);
    v.push_back(std::move(tmp));
  }
  std::cout << "Вектор" << '\n';
  for (auto item : v) {
    std::cout << item << '\n';
  }
  std::sort(v.begin(), v.end(), std::greater<Point>());
  std::cout << "Отсортированный по убыванию вектор" << '\n';
  for (auto item : v) {
    std::cout << item << '\n';
  }
  std::list<Point> ll;
  std::copy_if(v.begin(), v.end(), std::back_inserter(ll),
               [](const Point &i) { return !(i < 0); });
  std::cout << "новый список" << '\n';
  for (auto item : ll) {
    std::cout << item << '\n';
  }
  std::sort(v.begin(), v.end(), std::less<Point>());
  ll.sort();
  std::cout << "отсортированный список" << '\n';
  for (auto item : ll) {
    std::cout << item << '\n';
  }
  std::cout << "отсортированный вектор" << '\n';
  for (auto item : v) {
    std::cout << item << '\n';
  }
  return 0;
}
