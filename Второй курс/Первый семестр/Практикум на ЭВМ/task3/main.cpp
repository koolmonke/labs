#include <iostream>
#include <iomanip>
template <typename T> class Matrix {
private:
  T **matrix;
  size_t N, M;

public:
  Matrix(size_t _N, size_t _M) : N(_N), M(_M) {
    this->matrix = new T *[this->N];
    for (size_t i(0); i < this->N; i++)
      this->matrix[i] = new T[this->M];
  }

  Matrix(Matrix<T>* copy) {
    N = copy->GetN();
    M = copy->GetM();
    this->matrix = new T *[this->N];
    for (size_t i(0); i < N; i++)
      this->matrix[i] = new T[this->M];
    for (size_t i = 0; i < N; i++)
    {
        for (size_t j = 0; j < M; j++)
        {
          this->matrix[i][j] = copy->GetElement(i, j);
        }
    }
  }

  auto GetN() { return N; }

  auto GetM() { return M; }

  T *operator[](size_t index) { return this->matrix[index]; }
  
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
    Matrix copy = Matrix(this);
    for (size_t i = 0; i < N; i++) {
      for (size_t j = 0; j < M; j++) {
        copy.SetElement(i, j, matrix[i][j] - other[i][j]);
      }
    }
    return copy;
  }
  T GetElement(const size_t N, const size_t M) const {
    return this->matrix[N][M];
  }

  T operator()(const size_t N, const size_t M) const {
    return GetElement(N, M);
  }
  void SetElement(const size_t N, const size_t M, T num) const {
    this->matrix[N][M] = num;
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
  //****** ЗАПОЛНЯЕМ ЧЕРЕЗ СКОБКИ ПО ИНДЕКСУ *******
  if (flag)
    std::cout << "Index Filling:" << std::endl;
  for (size_t i(0); i < N; i++)
    for (size_t j(0); j < M; j++)
      matrix2[i][j] = i + j;
  for (size_t i(0); i < N; i++)
    for (size_t j(0); j < M; j++)
      matrix[i][j] = i * j;
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
  return 0;
}