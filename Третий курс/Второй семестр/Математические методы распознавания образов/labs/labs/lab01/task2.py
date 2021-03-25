from typing import Sequence, Callable

from labs.Image import Image, KnownImage, read_test_data, read_train_data, TrainImage
import matplotlib.pyplot as plt

from labs.lab01 import docs


def distance(some: Image, other: Image) -> int:
    return ((some.data - other.data) ** 2).sum()


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
