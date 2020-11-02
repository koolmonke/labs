from graphs.graph_utils import Graph
from dataclasses import dataclass


@dataclass(frozen=True)
class Human:
    """
    Человек
    """

    name: str


GRAPH: Graph[Human] = {
    Human("A"): [Human("B"), Human("C")],
    Human("B"): [Human("A"), Human("D")],
    Human("C"): [Human("A"), Human("Z")],
    Human("D"): [Human("B"), Human("Z")],
    Human("Z"): [Human("C"), Human("D"), Human("A")],
}
