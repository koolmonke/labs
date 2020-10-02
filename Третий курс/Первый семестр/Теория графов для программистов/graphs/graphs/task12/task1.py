from dataclasses import dataclass
from typing import Dict, Iterable, Sequence


@dataclass(frozen=True)
class Human:
    """
    Человек
    """

    name: str


def dfs_paths(
    graph: Dict[Human, Sequence[Human]], start: Human, goal: Human
) -> Iterable[Sequence[Human]]:
    stack = [(start, [start])]  # (vertex, path)
    while stack:
        (vertex, path) = stack.pop()
        for next in set(graph[vertex]) - set(path):
            if next == goal and not next in path:
                yield path + [next]
            else:
                stack.append((next, path + [next]))


def main():
    graph: Dict[Human, Sequence[Human]] = {
        Human("A"): [Human("B"), Human("C")],
        Human("B"): [Human("A"), Human("D")],
        Human("C"): [Human("A"), Human("Z")],
        Human("D"): [Human("B"), Human("Z")],
        Human("Z"): [Human("C"), Human("D"), Human("A")],
    }
    t = sorted(
        list(dfs_paths(graph, Human("A"), Human("D"))),
        key=lambda x: len(x),
        reverse=True,
    )
    t1 = list(
        filter(
            lambda x: len(t) - len(x),
            sorted(
                list(dfs_paths(graph, Human("D"), Human("A"))), key=lambda x: len(x)
            ),
        )
    )
    print([t[0], t1[0]])


if __name__ == "__main__":
    main()