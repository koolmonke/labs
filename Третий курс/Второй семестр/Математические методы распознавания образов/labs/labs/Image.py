import csv
from dataclasses import dataclass
from functools import cached_property

import numpy as np
from matplotlib import pyplot as plt

THRESHOLD = 0


@dataclass(frozen=True)
class Image:
    data: np.ndarray

    @cached_property
    def area(self):
        return np.count_nonzero(self.data > THRESHOLD)


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
    distance: int


def read_train_data(filename: str):
    with open(filename) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            image = row[1:]
            yield TrainImage(np.array([int(i) for i in image]), int(row[0]))


def read_test_data(filename: str):
    with open(filename) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            yield Image(np.array([int(i) for i in row]))
