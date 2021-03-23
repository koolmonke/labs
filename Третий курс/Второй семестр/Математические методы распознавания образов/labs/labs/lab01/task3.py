from labs.lab01.task1 import Image, read_train_data, read_test_data
from labs.lab01.task2 import best_distance


def distance(some: Image, other: Image) -> int:
    some_data = some.data.reshape((28, 28))
    other_data = other.data.reshape((28, 28))
    return (some_data - other_data).sum()


def main():
    db = list(read_train_data("train.csv"))
    for image in read_test_data("test.csv"):
        print(best_distance(db, image, distance))


if __name__ == '__main__':
    main()
