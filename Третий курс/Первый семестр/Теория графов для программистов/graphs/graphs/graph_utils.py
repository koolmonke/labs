from typing import Iterator, List, Mapping, Sequence, Tuple, TypeVar

T = TypeVar("T")

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


def find_cycles(graph: Graph[T]) -> Iterator[PathOut[T]]:
    """Find all possible cycles in graph"""
    return ([node] + path for node in graph for path in dfs(graph, node, node))