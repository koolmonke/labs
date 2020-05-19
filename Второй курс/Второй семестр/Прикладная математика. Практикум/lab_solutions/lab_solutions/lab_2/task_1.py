from math import sqrt


def f(x: float) -> float:
    if x <= -3:
        return 1
    elif x <= -1:
        return -sqrt(-x ** 2 - 2 * x + 3)
    elif -1 <= x <= 2:
        return -2
    else:
        return x - 4


def main():
    x = float(input('x='))
    print(f'{f(x)=}')


if __name__ == '__main__':
    main()
