import csv
from dataclasses import dataclass
from functools import cached_property
from pathlib import Path
from typing import Union

import numpy as np
from matplotlib import pyplot as plt

IMAGE_SIZE = 28 ** 2

THRESHOLD = 0


@dataclass(frozen=True)
class Image:
    data: np.ndarray

    def __post_init__(self):
        if self.data.shape != (IMAGE_SIZE,):
            raise ValueError("Image should be 784d vector")

    @cached_property
    def area(self):
        return np.count_nonzero(self.data > THRESHOLD)

    @cached_property
    def feature_vector(self) -> np.ndarray:
        image = self.data.reshape(28, 28) > THRESHOLD
        return np.append(image.sum(axis=0),
                         image.sum(axis=1))

    def get_squares(self):
        image = self.data.reshape(28, 28)
        for i in range(4):
            for j in range(4):
                index = (i * 4) + j
                if i == j == 0:
                    # 1 element
                    yield np.count_nonzero(image[0:7, 0:7] > 0), index
                elif i != 0 and j == 0:
                    # 1 row
                    yield np.count_nonzero(image[i * 7 + 1:(i + 1) * 7, 0:7] > 0), index
                elif i == 0 and j != 0:
                    # 1 column
                    yield np.count_nonzero(image[0:7, j * 7 + 1:(j + 1) * 7] > 0), index
                else:
                    yield np.count_nonzero(image[i * 7 + 1:(i + 1) * 7, j * 7 + 1:(j + 1) * 7] > 0), index


@dataclass(frozen=True)
class TrainImage(Image):
    number: int

    def visualize(self):
        f, ax = plt.subplots()
        ax.imshow(self.data.reshape(28, 28))
        ax.set_title(self.number)
        return f, ax


@dataclass(frozen=True)
class KnownImage(TrainImage):
    distance: float


PathLike = Union[str, Path]


def read_train_data(file_path: PathLike):
    with open(file_path) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            number, *image = [int(i) for i in row]
            yield TrainImage(np.array(image), number)


def read_test_data(file_path: PathLike):
    with open(file_path) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            image = [int(i) for i in row]
            yield Image(np.array(image))
