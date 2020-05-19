#include <exception>
#include <iomanip>
#include <iostream>
class DiffDim : public std::exception {
public:
  const char *what() const noexcept { return "Diff Dim"; }
};


class IndexError : public std::exception {
  const char *what() const noexcept { return "Index Error"; }
};


template <typename T> class Matrix {
private:
  T **matrix;
  size_t N, M;
  T *operator[](size_t index) { return this->matrix[index]; }
  void checkIndex(size_t _N, size_t _M) {
    if (_N < 0 || _M < 0 || _N > this->N || _M > this->M) {
      throw IndexError();
    }
  }

public:
  Matrix(size_t _N, size_t _M) : N(_N), M(_M) {
    this->matrix = new T *[this->N];
    for (size_t i(0); i < this->N; i++)
      this->matrix[i] = new T[this->M];
  }

  Matrix(Matrix<T> *copy) {
    N = copy->GetN();
    M = copy->GetM();
    this->matrix = new T *[this->N];
    for (size_t i(0); i < N; i++)
      this->matrix[i] = new T[this->M];
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        this->matrix[i][j] = copy->GetElement(i, j);
      }
    }
  }

  size_t GetN() { return N; }

  size_t GetM() { return M; }

  friend std::ostream &operator<<(std::ostream &os, Matrix &obj) {
    for (size_t i(0); i < obj.N; i++) {
      for (size_t j(0); j < obj.M; j++) {
        os << std::setw(5) << obj[i][j];
        if (j + 1 != obj.M)
          os << " ";
      }
      os << std::endl;
    }
    return os;
  }

  bool operator==(Matrix &other) {
    if (this->N != other.GetN()) {
      return false;
    }
    if (this->M != other.GetM()) {
      return false;
    }
    for (int i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        if (this->matrix[i][j] != other(i, j)) {
          return false;
        }
      }
    }
    return true;
  }
  Matrix<T> operator-(const T n) {
    Matrix copy = Matrix(this);
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        copy.SetElement(i, j, matrix[i][j] - n);
      }
    }
    return copy;
  }
  Matrix<T> operator-(Matrix &other) {
    if (other.GetM() != this->M || other.GetN() != this->N) {
      throw DiffDim();
    }
    Matrix copy = Matrix(this);
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        copy.SetElement(i, j, matrix[i][j] - other[i][j]);
      }
    }
    return copy;
  }
  
  T GetElement(const size_t _N, const size_t _M)  {
    checkIndex(_N, _M);
    return this->matrix[_N][_M];
  }

  T operator()(const size_t N, const size_t M)  {
    return GetElement(N, M);
  }
  void SetElement(const size_t _N, const size_t _M, T num)  {
    checkIndex(_N, _M);
    this->matrix[_N][_M] = num;
  }

  ~Matrix() {
    for (size_t i(0); i < this->N; i++)
      delete[] this->matrix[i];
    delete this->matrix;
  };
};

int main(void) {
  bool flag(true);
  const size_t N(5), M(5);
  //****** СОЗДАЕМ *********************************
  Matrix<int> matrix(N, M);
  Matrix<int> matrix2(N, M);
  if (flag)
    std::cout << "Object the class of the Mattrix - CREATED!" << std::endl;
  if (flag)
    std::cout << "Index Filling:" << std::endl;
  for (size_t i(0); i < N; i++)
    for (size_t j(0); j < M; j++)
      matrix2.SetElement(i, j, i + j);
  for (size_t i(0); i < N; i++)
    for (size_t j(0); j < M; j++)
      matrix.SetElement(i, j, i * j);
  //****** ВЫВОДИМ *********************************
  std::cout << matrix << std::endl;
  std::cout << matrix2 << '\n';
  bool matrixcmp = matrix == matrix2;
  std::cout << "matrixcmp " << matrixcmp << '\n';
  Matrix<int> diffMatrix(matrix2 - matrix);
  Matrix<int> diffNumMatrix(matrix - 3);
  std::cout << "-Число" << '\n';
  std::cout << diffNumMatrix << '\n';
  std::cout << "-матриц" << '\n';
  std::cout << diffMatrix << '\n';
  //****** SetElement ******************************
  if (flag)
    std::cout << "SetElement:" << std::endl;
  for (size_t i(0); i < N; i++)
    for (size_t j(0); j < M; j++)
      matrix.SetElement(i, j, i * j * 2);
  //****** ВЫВОДИМ *********************************
  std::cout << matrix << std::endl;
  //****** GetElement ******************************
  if (flag)
    std::cout << "GetElement:" << std::endl;
  for (size_t i(0); i < N; i++) {
    for (size_t j(0); j < M; j++)
      std::cout << std::setw(5) << matrix.GetElement(i, j) << " ";
    std::cout << std::endl;
  }
  try
  {
    matrix.GetElement(10,10);
  }
  catch(const std::exception& e)
  {
    std::cerr << e.what() << '\n';
  }
  Matrix<int> little_matrix(2,2);
  Matrix<int> try_to_sub_matrix(little_matrix - matrix);
  return 0;
}