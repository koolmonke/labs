#include <iostream>
#include <random>
#include <time.h>

class outofbound : public std::exception {
public:
  const char *what() const noexcept { return "Index is out of bound"; }
};

class Massive {
private:
  float *Vector;
  int Count;
  int maxSize;

public:
  Massive() {
    std::cout << "Вызов конструктора без параметров" << '\n';
    Count = 0;
    maxSize = 10;
    Vector = new float[maxSize];
  }
  Massive(float source[], int size) {
    std::cout << "Вызов конструктора с указателем на массив" << '\n';
    Count = size;
    maxSize = size + 10;
    Vector = new float[maxSize];
    for (int i = 0; i < size; i++)
      Vector[i] = source[i];
  }
  Massive(int sizeToCreate, float value = 0) {
    std::cout << "Вызов конструктора с одним значением" << '\n';
    Count = sizeToCreate;
    maxSize = (int)1.05 * sizeToCreate + 10;
    Vector = new float[maxSize];
    for (int i = 0; i < Count; i++)
      Vector[i] = value;
  }
  Massive(int sizeToCreate, float leftEdgeRand, float rightEdgeRand) {}
  Massive(const Massive &toCopy) {
    std::cout << "Вызов конструктора копирования" << '\n';
    Count = toCopy.Count;
    maxSize = toCopy.maxSize;
    Vector = new float[maxSize];
    for (int i = 0; i < Count; i++)
      Vector[i] = toCopy.Vector[i];
  }
  ~Massive() {
    std::cout << "Вызов деструктора" << '\n';
    delete[] Vector;
  }
  void append(float value) {
    if (maxSize <= Count) {
      this->maxSize = maxSize + 10;
      float *newVector = new float[maxSize];
      for (int i = 0; i < Count; i++) {
        newVector[i] = Vector[i];
      }
      Vector = std::move(newVector);
    }
    Vector[Count++] = value;
  };
  void pop(int index) {
    if (index >= Count || index < 0) {
      throw outofbound();
    }
    float *newVector = new float[Count - 1];
    bool off = 0;
    for (int i = 0; i < Count; i++) {
      if (i == index) {
        i++;
        off = 1;
      } else
        newVector[i - off] = Vector[i];
    }
    this->Count = Count - 1;
    Vector = std::move(newVector);
  }
  void show() {
    if (Count != 0) {
      for (int i = 0; i < Count; i++)
        std::cout << Vector[i] << ' ';
      std::cout << std::endl;
    } else
      std::cout << "Массив пуст" << std::endl;
  }
  void showFull() {
    if (maxSize != 0) {
      for (int i = 0; i < maxSize; i++)
        std::cout << Vector[i] << ' ';
      std::cout << std::endl;
    } else
      std::cout << "Массив пуст" << std::endl;
  }
  float *getRawPointer() { return Vector; }

  int getCount() { return Count; }

  Massive operator++() {
    for (size_t i = 0; i < this->Count; i++)
      this->Vector[i]++;
    return *this;
  }
  Massive operator++(int) {
    Massive temp = *this;
    for (size_t i = 0; i < this->Count; i++)
      this->Vector[i]++;
    return temp;
  }

  float operator[](int index) {
    if (index >= Count || index < 0)
      throw outofbound();
    return this->Vector[index];
  }
  Massive &operator=(const Massive &right) {
    std::cout << "копиравние через оператор =" << '\n';
    delete[] this->Vector;
    this->Count = right.Count;
    this->maxSize = right.maxSize;
    this->Vector = new float[this->maxSize];
  }
  float sum();
};

float Massive::sum() {
  float sum = 0;
  for (int i = 0; i < Count; i++) {
    sum += Vector[i];
  }
  return sum;
}

int main() {
  srand(time(0));
  float randarr[4];
  for (int i = 0; i < 4; i++) {
    randarr[i] = rand() % 100;
  }
  for (auto &&i : randarr) {
    printf("%f\n\n", i);
  }

  Massive name(randarr, 4);
  name.show();
  for (int i = 0; i < 15; i++) {
    name.append(i);
  }
  try
  {
    std::cout << name[-10] << '\n';
  }
  catch(const std::exception& e)
  {
    std::cerr << e.what() << '\n';
  }

  name.show();
}