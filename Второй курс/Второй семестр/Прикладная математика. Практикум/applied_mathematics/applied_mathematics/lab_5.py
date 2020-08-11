from typing import Optional, Tuple

import numpy as np


def main(n: Optional[int] = None):
    if n is None:
        n = int(input('Размерность квадратной матрицы = '))
    matrix = np.random.randint(0, 100, size=(n, n))
    print(matrix)
    print()
    replace = top_max_values_eq_size(matrix)
    for index, item in enumerate(replace):
        x, y = find_first_eq_by_value(matrix, item)
        matrix[x, y], matrix[index, index] = matrix[index, index], matrix[x, y]
    print(matrix)


def find_first_eq_by_value(m: np.ndarray, value: int) -> Optional[Tuple[int, int]]:
    for i in range(m.shape[0]):
        for j in range(m.shape[1]):
            if m[i, j] == value:
                return i, j
    return None


def top_max_values_eq_size(m: np.ndarray) -> np.ndarray:
    flat = m.flatten()
    flat.sort()
    return flat[::-1][:m.shape[0]]


if __name__ == '__main__':
    main()
