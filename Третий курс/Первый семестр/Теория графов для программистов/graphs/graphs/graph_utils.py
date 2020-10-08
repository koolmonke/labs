from typing import Dict, Iterable, List, Sequence, Tuple, TypeVar

T = TypeVar("T")

Graph = Dict[T, Sequence[T]]

PathOut = List[T]


def dfs(graph: Graph[T], start: T, end: T) -> Iterable[PathOut]:
    """Find all possible pathes from start to end in graph"""
    fringe: List[Tuple[T, List[T]]] = [(start, [])]
    while fringe:
        state, path = fringe.pop()
        if path and state == end:
            yield path
            continue
        for next_state in graph[state]:
            if next_state in path:
                continue
            fringe.append((next_state, path + [next_state]))
