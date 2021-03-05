import json
from dataclasses import dataclass
from pathlib import Path
from typing import List, Sequence

import matplotlib.pyplot as plt
import numpy as np


@dataclass
class Point:
    x: float
    y: float

    def to_tuple(self):
        return self.x, self.y


@dataclass
class Circle:
    center: Point
    radius: float

    def to_tuple(self):
        return self.center.to_tuple(), self.radius


def load_points(path: Path) -> List[Point]:
    with open(path) as file:
        return json.load(file, object_hook=lambda point: Point(**point))


def fit_circle(points: Sequence[Point]):  # находим по мнк
    x = np.array([point.x for point in points])
    y = np.array([point.y for point in points])

    x_y = np.multiply(x, y)
    x_2 = np.square(x)
    y_2 = np.square(y)

    x_2_plus_y_2 = np.add(x_2, y_2)
    x__x_2_plus_y_2 = np.multiply(x, x_2_plus_y_2)
    y__x_2_plus_y_2 = np.multiply(y, x_2_plus_y_2)

    sum_x = x.sum(dtype=float)
    sum_y = y.sum(dtype=float)
    sum_x_2 = x_2.sum(dtype=float)
    sum_y_2 = y_2.sum(dtype=float)
    sum_x_y = x_y.sum(dtype=float)
    sum_x_2_plus_y_2 = x_2_plus_y_2.sum(dtype=float)
    sum_x__x_2_plus_y_2 = x__x_2_plus_y_2.sum(dtype=float)
    sum_y__x_2_plus_y_2 = y__x_2_plus_y_2.sum(dtype=float)

    inv_m3b3 = np.linalg.inv(np.array([[sum_x_2, sum_x_y, sum_x],
                                       [sum_x_y, sum_y_2, sum_y],
                                       [sum_x, sum_y, len(points)]]))
    m3b1 = np.array([sum_x__x_2_plus_y_2, sum_y__x_2_plus_y_2, sum_x_2_plus_y_2])
    a, b, c = np.dot(inv_m3b3, m3b1)
    return Circle(center=Point(x=a / 2, y=b / 2), radius=np.sqrt(4 * c + a ** 2 + b ** 2) / 2)


def main():
    points = load_points(Path("..") / "docs" / "task1.json")
    print(*points, sep="\n")
    circle = fit_circle(points)
    print(circle)
    plt.plot([p.x for p in points], [p.y for p in points], "o")
    plt.gca().add_patch(plt.Circle(*circle.to_tuple(), color="r", fill=False))
    plt.show()


if __name__ == '__main__':
    main()
