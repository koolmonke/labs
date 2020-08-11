from random import randint

from applied_mathematics.lab_2.task_2 import Point
from applied_mathematics.lab_2.task_2 import f as target


def main():
    r = float(input('R='))
    shoots = [Point(randint(-5, 5), randint(-5, 5)) for _ in range(10)]
    for index, item in enumerate(shoots):
        print(f'Выстрел №{index} в {item}')
    hits = (target(point, r) for point in shoots)
    print(f'Кол-во попаданий {len([hit for hit in hits if hit])}/10')


if __name__ == '__main__':
    main()
