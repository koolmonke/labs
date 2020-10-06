from dataclasses import dataclass
from typing import Dict, Iterable, List, Tuple


@dataclass(frozen=True)
class Human:
    """
    Человек
    """

    name: str


def dfs(graph: Dict[Human, List[Human]], start: Human, end: Human) -> Iterable[List[Human]]:
    fringe: List[Tuple[Human, List[Human]]] = [(start, [])]
    while fringe:
        state, path = fringe.pop()
        if path and state == end:
            yield path
            continue
        for next_state in graph[state]:
            if next_state in path:
                continue
            fringe.append((next_state, path + [next_state]))


def main():
    graph: Dict[Human, List[Human]] = {
        Human("A"): [Human("B"), Human("C")],
        Human("B"): [Human("A"), Human("D")],
        Human("C"): [Human("A"), Human("Z")],
        Human("D"): [Human("B"), Human("Z")],
        Human("Z"): [Human("C"), Human("D"), Human("A")],
    }

    cycles = [[node] + path for node in graph for path in dfs(graph, node, node)]
    print(max(cycles, key=list.__len__))


if __name__ == "__main__":
    main()
