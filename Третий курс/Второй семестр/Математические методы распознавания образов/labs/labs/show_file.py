from pathlib import Path

import matplotlib.pyplot as plt

from labs.lab01.task1 import Image, read_test_data

docs = Path("..") / "docs"


def visualize(image: Image):
    f, ax = plt.subplots()
    ax.imshow(image.data.reshape(28, 28))
    return ax


def main():
    for i in read_test_data(docs / "test.csv"):
        ax = visualize(i)
        plt.show()


if __name__ == '__main__':
    main()
