from dataclasses import dataclass
from typing import Dict, Sequence

from graphs.graph_utils import dfs


@dataclass(frozen=True)
class Human:
    """
    Человек
    """

    name: str


def main():
    graph: Dict[Human, Sequence[Human]] = {
        Human("A"): [Human("B"), Human("C")],
        Human("B"): [Human("A"), Human("D")],
        Human("C"): [Human("A"), Human("Z")],
        Human("D"): [Human("B"), Human("Z")],
        Human("Z"): [Human("C"), Human("D"), Human("A")],
    }

    cycles = ([node] + path for node in graph for path in dfs(graph, node, node))
    print(max(cycles, key=list.__len__))


if __name__ == "__main__":
    main()
