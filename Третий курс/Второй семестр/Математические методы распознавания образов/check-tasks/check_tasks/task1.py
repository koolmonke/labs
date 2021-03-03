import json
from dataclasses import dataclass
from pathlib import Path
from typing import List

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
        return self.center, self.radius


def load_points(path: Path):
    with open(path) as file:
        return json.load(file, object_hook=lambda point: Point(**point))


def fit_circle(points: List[Point]):  # находим по мнк
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

    m3b3 = np.array([[sum_x_2, sum_x_y, sum_x],
                     [sum_x_y, sum_y_2, sum_y],
                     [sum_x, sum_y, len(points)]])
    invm3b3 = np.linalg.inv(m3b3)
    m3b1 = np.array([sum_x__x_2_plus_y_2, sum_y__x_2_plus_y_2, sum_x_2_plus_y_2])
    A = np.dot(invm3b3, m3b1)[0]
    B = np.dot(invm3b3, m3b1)[1]
    C = np.dot(invm3b3, m3b1)[2]
    center_x = A / 2
    center_y = B / 2
    radius = np.sqrt(4 * C + A ** 2 + B ** 2) / 2
    return Circle(center=Point(center_x, center_y), radius=radius)


def main():
    points = load_points(Path("..") / "docs" / "task1.json")
    print(points)
    circle_obj = fit_circle(points)
    print(circle_obj)
    plt.plot([p.x for p in points], [p.y for p in points], 'o')
    circle1 = plt.Circle(circle_obj.center.to_tuple(), circle_obj.radius, color='r', fill=False)
    plt.gca().add_patch(circle1)
    plt.show()


if __name__ == '__main__':
    main()
