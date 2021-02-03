from typing import Dict, Iterator, List, Mapping, Sequence, Tuple, TypeVar

T = TypeVar("T")

GraphIn = Mapping[T, Sequence[T]]

GraphOut = Dict[T, List[T]]

PathOut = List[T]


def dfs(graph: GraphIn[T], start: T, end: T) -> Iterator[PathOut[T]]:
    """Find all possible paths from start to end in graph"""
    fringe: List[Tuple[T, List[T]]] = [(start, [])]
    while fringe:
        state, path = fringe.pop()
        if path and state == end:
            yield path
            continue
        for next_state in graph[state]:
            if next_state not in path:
                fringe.append((next_state, path + [next_state]))


def find_cycles(graph: GraphIn[T]) -> Iterator[PathOut[T]]:
    """Find all possible cycles in graph"""
    return ([node] + path for node in graph for path in dfs(graph, node, node))
