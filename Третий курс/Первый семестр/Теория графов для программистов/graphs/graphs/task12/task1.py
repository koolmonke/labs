from graphs.graph_utils import dfs
from graphs.task12 import GRAPH


def main() -> None:
    cycles = ([node] + path for node in GRAPH for path in dfs(GRAPH, node, node))
    print(max(cycles, key=list.__len__))


if __name__ == "__main__":
    main()
