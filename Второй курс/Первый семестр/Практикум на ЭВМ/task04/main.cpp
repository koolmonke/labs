#include <iomanip>
#include <iostream>

class IndexError : public std::exception {
public:
  const char *what() const noexcept {
    return "IndexError, index is out of bound";
  }
};


class Point {
private:
  int x, y;

public:
  int getX() { return x; }
  int getY() { return y; }
  Point() = default;
  Point(const int _x, const int _y) : x{_x}, y{_y} {}
  Point(const int arg) : x{arg}, y{arg} {}
  Point(const Point &copy) {
    x = copy.x;
    y = copy.y;
  }
  friend std::ostream &operator<<(std::ostream &os, const Point &obj) {
    os << "Point(x = ";
    os << obj.x;
    os << ", y = ";
    os << obj.y;
    os << ")";
    return os;
  }

  Point operator=(const Point &arg) {
    x = arg.x;
    y = arg.y;
    return *this;
  }

  Point operator=(int arg) {
    x = arg;
    y = arg;
    return *this;
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

  Point operator*(const Point &arg) {
    return Point(this->x * arg.x, this->y * arg.y);
  }

};

template <typename T> class array1d {
private:
  T *array;
  size_t N;
  void checkLenEq(const size_t _N) const {
    if (N != _N) {
      throw IndexError();
    }
  }

  void checkLenLessThan(const size_t _N) const {
    if (N <= _N) {
      throw IndexError();
    }
  }

public:
  array1d(size_t _N) : N{_N} {
    this->array = new T[N];
    for (size_t i = 0; i < N; i++) {
      array[i] = 0;
    }
  }

  array1d(T *arr, size_t len) : N{len} {
    for (size_t i = 0; i < N; i++) {
      array[i] = arr[i];
    }
  }

  array1d(array1d &tocopy) : N{tocopy.getN()} {
    array = new T[N];
    for (size_t i = 0; i < N; i++) {
      array[i] = tocopy.getByIndex(i);
    }
  }

  T getByIndex(size_t index) const {
    checkLenLessThan(index);
    return array[index];
  }

  void setByIndex(size_t index, T value) const {
    checkLenLessThan(index);
    array[index] = value;
  }

  size_t getN() { return N; }

  friend std::ostream &operator<<(std::ostream &os, array1d &obj) {
    os << obj.getByIndex(0);
    for (size_t i = 1; i < obj.N; i++) {
      os << " " << obj.getByIndex(i);
    }
    return os;
  }

  array1d &operator=(const array1d &tocopy) const;

  T operator[](const size_t);

  array1d operator*(const array1d<T> &tocopy) const {
    checkLenEq(tocopy.N);
    array1d<T> newobj(N);
    for (size_t i = 0; i < N; i++) {
      T val = tocopy.getByIndex(i);
      newobj.setByIndex(i, this->array[i] * val);
    }
    return newobj;
  }

  ~array1d() { delete[] array; }
};


template <typename T> T array1d<T>::operator[](const size_t index) {
  return getByIndex(index);
};

template <typename T>
array1d<T> &array1d<T>::operator=(const array1d &tocopy) const {
  N = tocopy.N;
  for (size_t i = 0; i < N; i++) {
    this->array[i] = tocopy.array[i];
  }
  return *this;
}

int main(int argc, char const *argv[]) {
  const int N = 5;
  array1d<int> arr(N);
  for (size_t i = 0; i < N; i++) {
    arr.setByIndex(i, (i + 1) * (i + 1));
  }
  auto newarr = arr;
  for (size_t i = 0; i < N; i++) {
    arr.setByIndex(i, i + i);
  }
  std::cout << arr << '\n';
  std::cout << newarr << '\n';
  array1d<int> arrmul = arr * newarr;
  std::cout << arrmul << '\n';
  array1d<Point> arrP(N);
  std::cout << '\n';
  for (size_t i = 0; i < N; i++) {
    arrP.setByIndex(i, Point(i, i));
  }
  std::cout << arrP << '\n';
  auto newarrP = arrP;
  std::cout << newarrP << '\n';
  for (size_t i = 0; i < N; i++) {
    newarrP.setByIndex(i, Point(2 * i));
  }
  std::cout << newarrP << '\n';
  array1d<Point> arrPmul = arrP * newarrP;

  std::cout << arrPmul << '\n';
  // Point cleararr[N];
  // for (int i = 0; i < N; i++) {
  //   // Point a = Point();
  //   cleararr[i] = Point(i);
  // }
  // for (size_t i = 0; i < N; i++) {
  //   std::cout << cleararr[i] << '\n';
  // }

  return 0;
}
