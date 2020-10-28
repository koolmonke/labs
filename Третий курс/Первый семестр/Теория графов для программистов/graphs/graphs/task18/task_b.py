from typing import List

from graphs.task18 import TableIn, Minute


def task_b(table: TableIn) -> List[Minute]:
    return [minute for minute, number_of_watchman in enumerate(table) if number_of_watchman < 2]
