from matplotlib import pyplot as plt

from labs.Image import Image, read_test_data


def visualize(some: Image):
    f, ax = plt.subplots()
    ax.imshow(some.data.reshape(28, 28))
    return f, ax


def main():
    for i in read_test_data("./../docs/test.csv"):
        f, ax = visualize(i)
        plt.axes(ax)
        plt.show()


if __name__ == '__main__':
    main()
