from dataclasses import dataclass
from typing import Dict, Set

from pprint import pprint


@dataclass(frozen=True)
class Duty:
    start: int
    end: int

    def __contains__(self, key: "Duty") -> bool:
        duty_range = range(self.start, self.end + 1)
        return key.start in duty_range and key.end in duty_range


@dataclass(frozen=True)
class TimeTable:
    table: Dict[Duty, Set[Duty]]

    head: Duty

    def append_duty(self, duty: Duty) -> "TimeTable":
        table = self.table.copy()
        for key, value in table.items():
            if duty in key:
                value.add(duty)

        table[duty] = {i for i in table if i in duty}
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
    t = (
        TimeTable({Duty(0, i): set() for i in range(5)}, Duty(0, 4))
        .append_duty(Duty(1, 3))
        .append_duty(Duty(2, 3))
    )
    pprint(t)


if __name__ == "__main__":
    main()