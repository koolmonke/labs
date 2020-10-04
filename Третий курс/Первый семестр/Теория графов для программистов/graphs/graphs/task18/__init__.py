from dataclasses import dataclass, field
from typing import Dict, Set

from pprint import pprint


@dataclass(frozen=True)
class Duty:
    start: int
    end: int

    on_duty_counter: int = field(default=0)

    def __post_init__(self):
        assert self.start < self.end, "start < end"

    def __contains__(self, key: "Duty") -> bool:
        duty_range = range(self.start, self.end)
        return key.start in duty_range and key.end in duty_range


Graph = Dict[Duty, Set[Duty]]


@dataclass
class TimeTable:
    table: Graph

    head: Duty

    def __post_init__(self):
        self.table = self.rebalance_graph(self.table)

    @staticmethod
    def rebalance_graph(graph: Graph) -> Graph:
        graph = graph.copy()
        for key in graph.keys():
            graph[key] = {duty for duty in graph if duty in key}

        return graph

    def append(self, duty: Duty) -> "TimeTable":
        table = self.table.copy()
        for key, value in table.items():
            if duty in key:
                value.add(duty)

        table[duty] = set()
        return TimeTable(self.rebalance_graph(table), self.head)

    def __getitem__(self, key: Duty) -> "TimeTable":
        return self.__inner_change_head(key)

    def __inner_change_head(self, move_to: Duty) -> "TimeTable":
        if move_to in self.table[self.head]:
            return TimeTable(self.table, move_to)
        else:
            raise ValueError(f"There no path between {self.head} and {move_to}")


def main() -> None:
    t = (
        TimeTable({Duty(0, i): set() for i in range(1, 5)}, Duty(0, 4))
        .append(Duty(1, 4))
        .append(Duty(2, 3))
    )
    pprint(t.table)


if __name__ == "__main__":
    main()