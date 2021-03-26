from typing import Callable, Sequence

import matplotlib.pyplot as plt

from labs.Image import Image, KnownImage, read_test_data, read_train_data, TrainImage
from labs.lab01 import docs


def distance(some: Image, other: Image) -> int:
    some_data = (some.data != 0).reshape((28, 28))
    other_data = (other.data != 0).reshape((28, 28))
    return (some_data ^ other_data).sum()


def best_distance(db: Sequence[TrainImage], some: Image, distance_f: Callable[[Image, Image], int]):
    return min((KnownImage(some.data, trained.number, distance_f(some, trained)) for trained in db),
               key=lambda known_image: known_image.distance)


def main():
    db = list(read_train_data(docs / "train.csv"))
    for image in read_test_data(docs / "test.csv"):
        f, ax = best_distance(db, image, distance).visualize()
        plt.axes(ax)
        plt.show()


if __name__ == '__main__':
    main()
