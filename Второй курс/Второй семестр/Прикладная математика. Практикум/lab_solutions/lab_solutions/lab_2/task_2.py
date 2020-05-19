from typing import NamedTuple

Point = NamedTuple('Point', [('x', float), ('y', float)])


def f(p: Point, r: float) -> bool:
    if r < 0:
        raise ArithmeticError('Radius can\'t be less than zero')
    if 0 <= p.x <= r and p.y <= 0:
        return ((p.x - r) ** 2 + p.y ** 2) <= r ** 2
    elif -r <= p.x <= r and p.y >= 0:
        return ((p.x + r) ** 2 + p.y ** 2) <= r ** 2
    else:
        return False


def main():
    p = Point(x=float(input('x=')), y=float(input('y=')))
    r = float(input('r='))
    if f(p, r):
        print('Входит')
    else:
        print('Не входит')


if __name__ == '__main__':
    main()
