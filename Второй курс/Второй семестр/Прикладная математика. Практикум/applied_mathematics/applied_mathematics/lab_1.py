from math import sqrt
from typing import Optional

def main(m: Optional[float] = None):
    if m is None:
        m = float(input('m='))
    z_1 = sqrt((3 * m + 2) ** 2 - 24 * m) / (3 * sqrt(m) - 2 / sqrt(m))
    z_2 = sqrt(m)
    print(f'{z_1=}, {z_2=}')


if __name__ == '__main__':
    main()
