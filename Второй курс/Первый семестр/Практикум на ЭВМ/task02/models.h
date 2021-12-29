#include <array>
#include <string>
#include <vector>

class Abstract_Model {

public:
  std::string name = "Абстракный базовый класс";
  virtual size_t all_5s() { return 0; }
};


class Professor : public Abstract_Model {
  Professor(std::string _name) { this->name = _name; }
  
};

class Student : public Abstract_Model {
private:
  static const size_t num_of_exams = 5;
  std::array<int, num_of_exams> marks;
  double avg_mark;
  static double calc_avg(std::array<int, num_of_exams> marks) {
    double avg = 0;
    for (auto mark : marks) {
      avg += mark;
    }
    return avg /= num_of_exams;
  }

public:
  Student(const std::string &_name, const std::array<int, num_of_exams> &_marks)
      : marks{_marks} {
    this->name = _name;
    this->avg_mark = calc_avg(marks);
  }

  Student() = default;

  double get_avg_mark() { return avg_mark; }
  size_t all_5s() { return avg_mark == 5; }
  int getMark(int index) { return marks[index]; }
};

class Abstract_Container : public std::vector<Abstract_Model *>,
                           public Abstract_Model {
public:
  std::string name = "Абстракный Контейнер";
  size_t all_5s() {
    size_t count = 0;
    for (auto model : *this) {
      count += model->all_5s();
    }
    return count;
  }
  ~Abstract_Container() {
    for (auto item : *this) {
      delete item;
    }
  }
};

class Faculty : public Abstract_Container {};

class Group : public Abstract_Container {};
