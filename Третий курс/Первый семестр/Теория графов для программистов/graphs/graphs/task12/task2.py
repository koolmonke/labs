from pprint import pprint

from graphs.graph_utils import dfs
from graphs.task12 import GRAPH

N = 3


def main() -> None:
    groups = sorted(
        (set([node] + path) for node in GRAPH for path in dfs(GRAPH, node, node)),
        key=set.__len__,
        reverse=True,
    )
    pprint(groups[:N])


if __name__ == "__main__":
    main()
