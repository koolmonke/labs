from math import nan
from random import randint
from typing import List, Optional, Sequence


def count_grt0(some_list: Sequence[int]) -> int:
    return len([i for i in some_list if i > 0])


def sum_after_last0(some_list: Sequence[int]) -> float:
    try:
        last_zero_index = len(some_list) - some_list[::-1].index(0) - 1
        return sum(some_list[last_zero_index:])
    except ValueError:
        return nan  # В случае если нет 0


def transform(some_list: Sequence[int]) -> List[int]:
    return [i for i in some_list if i < 1] + [i for i in some_list if i >= 1]


def main(n: Optional[int] = None):
    if n is None:
        n = int(input("n="))
    random_values = [randint(-5, 5) for _ in range(n)]

    print(
        f"Список случайных чисел длинной {n=}: {random_values}",
        f"Количество положительных чисел в нем {count_grt0(random_values)}",
        f"Сумма всех элементов после нуля в нем {sum_after_last0(random_values)}",
        f"Трансформированный список со всеми числами у которых целая часть меньше единицы в начале {transform(random_values)}",
        sep="\n",
    )


if __name__ == "__main__":
    main()
