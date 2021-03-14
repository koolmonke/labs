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
    a = np.array([[2 * p.x, 2 * p.y, 1] for p in points])
    b = np.array([p.x ** 2 + p.y ** 2 for p in points])
    c = np.linalg.solve(a.transpose() @ a, a.transpose() @ b)
    return Circle(center=Point(x=c[0], y=c[1]), radius=np.sqrt(c[2] + c[0] ** 2 + c[1] ** 2))


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
