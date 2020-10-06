from typing import Dict, Iterable, List, Sequence, Tuple, TypeVar

T = TypeVar("T")

Graph = Dict[T, Sequence[T]]


def dfs(graph: Dict[T, Sequence[T]], start: T, end: T) -> Iterable[List[T]]:
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
