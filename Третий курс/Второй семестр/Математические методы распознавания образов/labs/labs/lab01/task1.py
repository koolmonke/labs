import csv
from dataclasses import dataclass
from functools import cached_property
from pathlib import Path
from pprint import pprint
from typing import Optional

docs = Path("../../docs")
Data = list[int]
THRESHOLD = 0


@dataclass
class Image:
    supposed_number: Optional[int]
    data: Data

    @cached_property
    def area(self):
        return len([i for i in self.data if i > THRESHOLD])


def read_train_data(filename: str):
    with open(docs / filename) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            image = row[1:]
            yield Image(int(row[0]), [int(element) for element in image])


def read_test_data(filename: str):
    with open(docs / filename) as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            yield Image(None, [int(element) for element in row])


def main():
    train_images = list(read_train_data("train.csv"))
    db = {digit: [image for image in train_images if image.supposed_number == digit] for digit in range(10)}
    avg_area_db = {digit: (sum(image.area for image in train_images) / len(train_images)) for (digit, train_images) in
                   db.items()}
    pprint(avg_area_db)
    for image in read_test_data("test.csv"):
        possible_top_3_digits = dict(
            sorted([(digit, image.area - avg_area) for (digit, avg_area) in avg_area_db.items()],
                   key=lambda x: abs(x[1]))[:3])
        print(possible_top_3_digits)


if __name__ == '__main__':
    main()
