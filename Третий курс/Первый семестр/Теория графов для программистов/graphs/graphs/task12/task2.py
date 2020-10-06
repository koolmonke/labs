from graphs.graph_utils import dfs
from graphs.task12 import GRAPH

from pprint import pprint

N = 3


def main():
    cycles = sorted(
        (set([node] + path) for node in GRAPH for path in dfs(GRAPH, node, node)),
        key=lambda x: len(x),
        reverse=True,
    )
    pprint(cycles[:N])


if __name__ == "__main__":
    main()