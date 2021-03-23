from typing import Sequence, Callable

from labs.lab01.task1 import Image, read_test_data, read_train_data, TrainImage


def distance(some: Image, other: Image) -> int:
    return ((some.data - other.data) ** 2).sum()


def best_distance(db: Sequence[TrainImage], some: Image, distance_f: Callable[[Image, Image], int]):
    return min([(trained.number, distance_f(some, trained)) for trained in db], key=lambda x: x[1])


def main():
    db = list(read_train_data("train.csv"))
    for image in read_test_data("test.csv"):
        print(best_distance(db, image, distance))


if __name__ == '__main__':
    main()
