#include <exception>
#include <iostream>

class BadFormat : public std::exception {
  const char *what() const noexcept { return "Неверный формат ввода"; }
};

class Complex {
 private:
  int real = 0, imag = 0;

 public:
  Complex() = default;

  Complex(const int _real, const int _imag) : real{_real}, imag{_imag} {}

  Complex(const Complex &other) : real{other.real}, imag{other.imag} {}

  Complex operator=(const Complex &other) {
    real = other.real;
    imag = other.imag;
    return *this;
  }

  Complex operator+(const Complex &other) const {
    return Complex(real + other.real, imag + other.imag);
  }

  bool operator==(const Complex &other) const {
    return (this->real == other.real) && (this->imag == other.imag);
  }

  bool operator!=(const Complex &other) const { return !(*this == other); }

  friend std::ostream &operator<<(std::ostream &out, const Complex &obj) {
    if (obj.real) {
      out << obj.real;
    }
    if (obj.imag) {
      if (obj.real && obj.imag > 0) {
        out << '+';
      }
      out << obj.imag;
      out << 'i';
    }
    return out;
  }

  std::ostream& write(std::ostream &os) {
      os.write((char *)this, sizeof(Complex));
      return os;
  }

  std::istream &read(std::istream &is) {
    is.read((char *)this, sizeof(Complex));
    return is;
  }

  friend std::istream &operator>>(std::istream &in, Complex &obj) {
    in >> obj.real >> obj.imag;
    if (in.bad()) throw BadFormat();
    return in;
  }
};