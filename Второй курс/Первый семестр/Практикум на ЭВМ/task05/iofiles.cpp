#include <exception>
#include <fstream>
#include <iostream>
#include <vector>

#include "complex.h"

Complex find(const std::string filename, const int index) {
  Complex finded;
  std::ifstream is(filename);
  for (size_t i = 0; i <= index; i++)
  {
    finded.read(is);
  }
  is.close();
  return finded;
}

void del(const std::string filename, const int index) {
  std::ifstream is(filename);
  std::vector<Complex> vec;
  Complex it;
  for (size_t i = 0; is.good(); i++) {
    it.read(is);
    if (i != index) {
      vec.push_back(it);
    }
  }
  is.close();
  std::ofstream os(filename);
  for (auto i : vec) {
    i.write(os);
  }
}

void repl(const std::string filename, const int index,
          const Complex toReplace) {
  std::ifstream is(filename);
  std::vector<Complex> vec;
  Complex it;
  for (size_t i = 0; is.good(); i++) {
    it.read(is);
    if (i != index) {
      vec.push_back(it);
    } else {
      vec.push_back(toReplace);
    }
  }
  is.close();
  std::ofstream os(filename);
  for (auto i : vec) {
    i.write(os);
  }
}

int main(int argc, char const* argv[]) {
  const std::string input_filename("input.txt");
  const std::string output_filename("output.txt");
  std::ifstream in(input_filename);
  std::ofstream out(output_filename);
  Complex x;
  while (in >> x)
  {
    std::cout << x << '\n'; 
    x.write(out);
  }
  std::cout << '\n' << '\n';
  in.close();
  out.close();
  Complex x2;
  std::ifstream is(output_filename);
  for (size_t i = 0; is.good(); i++) {
    x2.read(is);
    std::cout << x2 << '\n';
  }
  is.close();
  std::cout << '\n';
  del(output_filename, 1);
  is.open(output_filename);
  for (size_t i = 0; is.good(); i++) {
    x2.read(is);
    std::cout << x2 << '\n';
  }
  is.close();
  std::cout << '\n';
  const Complex toRepl(100,100);
  repl(output_filename, 1, toRepl);
  is.open(output_filename);
  for (size_t i = 0; is.good(); i++) {
    x2.read(is);
    std::cout << x2 << '\n';
  }
  return 0;
}
