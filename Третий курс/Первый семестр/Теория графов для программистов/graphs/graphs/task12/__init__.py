from graphs.graph_utils import GraphIn
from dataclasses import dataclass


@dataclass(frozen=True)
class Human:
    """
    Человек
    """

    name: str


GRAPH: GraphIn[Human] = {
    Human("A"): [Human("B"), Human("C")],
    Human("B"): [Human("A"), Human("D")],
    Human("C"): [Human("A"), Human("Z")],
    Human("D"): [Human("B"), Human("Z")],
    Human("Z"): [Human("C"), Human("D"), Human("A")],
}
