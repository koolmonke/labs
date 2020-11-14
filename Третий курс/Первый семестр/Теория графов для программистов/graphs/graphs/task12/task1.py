from graphs.graph_utils import find_cycles
from graphs.task12 import GRAPH


def main() -> None:
    print(max(find_cycles(GRAPH), key=list.__len__))


if __name__ == "__main__":
    main()
