from labs.Image import Image, read_test_data, read_train_data
from labs.lab01 import docs
from labs.lab01.task2 import best_distance
import matplotlib.pyplot as plt


def distance(some: Image, other: Image) -> int:
    some_data = (some.data != 0).reshape((28, 28))
    other_data = (other.data != 0).reshape((28, 28))
    return (some_data ^ other_data).sum()


def main():
    db = list(read_train_data(docs / "train.csv"))
    for image in read_test_data(docs / "test.csv"):
        f, ax = best_distance(db, image, distance).visualize()
        plt.axes(ax)
        plt.show()


if __name__ == '__main__':
    main()
