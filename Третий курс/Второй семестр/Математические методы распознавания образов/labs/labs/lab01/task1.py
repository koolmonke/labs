import csv
from dataclasses import dataclass
from functools import cached_property
from pathlib import Path
from pprint import pprint

import numpy as np

docs = Path("../../docs")
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


def read_train_data(filename: str):
    with open(docs / filename) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            image = row[1:]
            yield TrainImage(np.array([int(i) for i in image]), int(row[0]))


def read_test_data(filename: str):
    with open(docs / filename) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            yield Image(np.array([int(i) for i in row]))


def main():
    train_images = list(read_train_data("train.csv"))
    db = {digit: [image for image in train_images if image.number == digit] for digit in range(10)}
    avg_area_db = {digit: sum(image.area for image in train_images) / len(train_images) for (digit, train_images) in
                   db.items()}
    pprint(avg_area_db)
    for image in read_test_data("test.csv"):
        possible_top_3_digits = sorted([(digit, image.area - avg_area) for (digit, avg_area) in avg_area_db.items()],
                                       key=lambda x: abs(x[1]))[:3]
        print(possible_top_3_digits)


if __name__ == '__main__':
    main()
