from pathlib import Path

import matplotlib.pyplot as plt

from labs.Image import Image, read_test_data

docs = Path("..") / "docs"


def visualize(image: Image):
    f, ax = plt.subplots()
    ax.imshow(image.data.reshape(28, 28))
    return ax


def main():
    for image in read_test_data(docs / "train.csv"):
        ax = visualize(image)
        plt.show()


if __name__ == '__main__':
    main()
