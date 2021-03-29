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

    @cached_property
    def area(self):
        return np.count_nonzero(self.data > THRESHOLD)

    @cached_property
    def feature_vector(self) -> np.ndarray:
        image = self.data.reshape(28, 28)
        return np.array([sum(image[:, i] > THRESHOLD for i in range(28)),
                         sum(image[i] > THRESHOLD for i in range(28))]).flatten()


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
            assert len(image) == IMAGE_SIZE, "Image should be 784 vector"
            yield TrainImage(np.array(image), number)


def read_test_data(file_path: PathLike):
    with open(file_path) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            image = [int(i) for i in row]
            assert len(image) == IMAGE_SIZE, "Image should be 784 vector"
            yield Image(np.array(image))
