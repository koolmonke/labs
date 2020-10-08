from typing import Iterator, List, Mapping, Sequence, Tuple, TypeVar

T = TypeVar("T", covariant=True)

Graph = Mapping[T, Sequence[T]]

PathOut = List[T]


def dfs(graph: Graph[T], start: T, end: T) -> Iterator[PathOut[T]]:
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
