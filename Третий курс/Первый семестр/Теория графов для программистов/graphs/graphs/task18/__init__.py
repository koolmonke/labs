from dataclasses import dataclass
from typing import Dict, Set

from pprint import pprint


@dataclass(frozen=True)
class Watchman:
    start: int
    end: int

    def __post_init__(self):
        assert self.start < self.end, "start < end"

    def __contains__(self, key: "Watchman") -> bool:
        duty_range = range(self.start, self.end)
        return key.start in duty_range and key.end in duty_range


Graph = Dict[Watchman, Set[Watchman]]


@dataclass
class TimeTable:
    table: Graph

    head: Watchman

    def __post_init__(self):
        self.table = self.rebalance_graph(self.table)

    @staticmethod
    def rebalance_graph(graph: Graph) -> Graph:
        graph = graph.copy()
        for key in graph.keys():
            graph[key] = {duty for duty in graph if duty in key}

        return graph

    def append_watch(self, watchman: Watchman) -> "TimeTable":
        table = self.table.copy()
        for key, value in table.items():
            if watchman in key:
                value.add(watchman)

        table[watchman] = set()
        return TimeTable(self.rebalance_graph(table), self.head)

    def __getitem__(self, key: Watchman) -> "TimeTable":
        return self.__inner_change_head(key)

    def __inner_change_head(self, move_to: Watchman) -> "TimeTable":
        if move_to in self.table[self.head]:
            return TimeTable(self.table, move_to)
        else:
            raise ValueError(f"There no path between {self.head} and {move_to}")

    def step_a(self) -> bool:
        return all(map(lambda duties: len(duties) >= 2, self.table.values()))


def main() -> None:
    t = (
        TimeTable({Watchman(0, i): set() for i in range(1, 5)}, Watchman(0, 4))
        .append_watch(Watchman(1, 4))
        .append_watch(Watchman(2, 3))
    )
    pprint(t.table)


if __name__ == "__main__":
    main()