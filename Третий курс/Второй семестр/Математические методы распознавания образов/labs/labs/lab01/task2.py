import matplotlib.pyplot as plt
import numpy as np

from labs.Image import KnownImage, read_test_data, read_train_data
from labs.lab01 import docs


def distance(some: np.ndarray, other: np.ndarray) -> float:
    return ((some - other) ** 2).sum()


def main():
    train_images = list(read_train_data(docs / "train.csv"))
    db = {digit: [image for image in train_images if image.number == digit] for digit in range(10)}
    avg_vector_feature = {digit: np.mean(np.array([image.feature_vector for image in train_images]), axis=0) for
                          (digit, train_images)
                          in db.items()}
    for image in read_test_data(docs / "test.csv"):
        f, ax = min((KnownImage(image.data, digit, distance(image.feature_vector, avg_feature)) for (digit, avg_feature)
                     in avg_vector_feature.items()), key=lambda x: x.distance).visualize()
        plt.axes(ax)
        plt.show()


if __name__ == '__main__':
    main()
