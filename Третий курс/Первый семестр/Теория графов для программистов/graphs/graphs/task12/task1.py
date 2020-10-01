from dataclasses import dataclass
from typing import Dict, Sequence


@dataclass(frozen=True)
class Human:
    """
    Человек
    """

    name: str


def dfs(graph: Dict[Human, Sequence[Human]], start: Human) -> Sequence[Human]:
    visited, stack = [], [start]
    while stack:
        vertex = stack.pop()
        if vertex not in visited:
            visited.append(vertex)
            stack.extend(set(graph[vertex]) - set(visited))
    return visited


def main():
    graph: Dict[Human, Sequence[Human]] = {
        Human("A"): [Human("B"), Human("C")],
        Human("B"): [Human("A"), Human("D"), Human("E")],
        Human("C"): [Human("A"), Human("F")],
        Human("D"): [Human("B")],
        Human("E"): [Human("B"), Human("F")],
        Human("F"): [Human("C"), Human("E")],
    }
    print(dfs(graph, Human("A")))


if __name__ == "__main__":
    main()