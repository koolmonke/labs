import matplotlib.pyplot as plt
import numpy as np

from labs.Image import read_test_data, read_train_data, KnownImage
from labs.lab01 import docs


def main():
    train_images = list(read_train_data(docs / "train.csv"))
    db = {digit: [image for image in train_images if image.number == digit] for digit in range(10)}
    avg_area_db = {digit: np.mean(np.array([image.area for image in train_images]), axis=0) for (digit, train_images) in
                   db.items()}

    cov_vec = np.zeros(10)
    for digit_all, images_all in db.items():
        cov_vec[digit_all] += sum((item.area - avg_area_db[digit_all]) ** 2 for item in images_all) / len(images_all)

    print(cov_vec)

    for image in read_test_data(docs / "test.csv"):
        possible_digit = min(
            (KnownImage(image.data, digit, (image.area - avg_area) ** 2 / cov_vec[digit]) for (digit, avg_area) in
             avg_area_db.items()),
            key=lambda x: x.distance)

        f, ax = possible_digit.visualize()
        plt.axes(ax)
        plt.show()


if __name__ == '__main__':
    main()
