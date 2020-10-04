from dataclasses import dataclass
from typing import Dict, Set


@dataclass(frozen=True)
class Duty:
    start: int
    end: int

    def __contains__(self, key: "Duty") -> bool:
        return (key.start <= self.start) and (key.end <= self.end)


@dataclass(frozen=True)
class TimeTable:
    table: Dict[Duty, Set[Duty]]

    head: Duty

    def append_duty(self, duty: Duty) -> "TimeTable":
        table = self.table.copy()
        for key, value in table.items():
            if duty in key:
                value.add(duty)

        return TimeTable(table, self.head)

    def __getitem__(self, key: Duty) -> "TimeTable":
        return self.__inner_change_head(key)

    def __inner_change_head(self, move_to: Duty) -> "TimeTable":
        if move_to in self.table[self.head]:
            return TimeTable(self.table, move_to)
        else:
            raise ValueError(f"There no path between {self.head} and {move_to}")

    def step_a(self) -> bool:
        return all(map(lambda duties: len(duties) >= 2, self.table.values()))


def main() -> None:
    ...


if __name__ == "__main__":
    main()