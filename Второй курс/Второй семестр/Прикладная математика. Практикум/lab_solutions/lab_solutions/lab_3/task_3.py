from math import log
from decimal import Decimal
from typing import Optional


def main(x: Optional[Decimal] = None):
    if x is None:
        x = Decimal(input('x='))
    res = n = Decimal(1)
    ln = Decimal(1)
    while abs(ln) > 1E-5:
        n += 1
        ln *= ((1 + n) * (-1 + x)) / ((2 + n) * (1 + x))
        res += ln

    print(f'Эталонный метод {-log(2 / (x + 1))}')
    print(f'Хороший метод {res}')
    print(f'Не самый хороший {sum((x - 1) ** (n + 1) / ((n + 1) * (x + 1) ** (n + 1)) for n in range(1000))}')


if __name__ == '__main__':
    main()
