from typing import List

from graphs.task18 import TableIn, Time, Minute
from graphs.task18.task_b import task_b


def task_c(table: TableIn) -> List[Time]:
    minutes_to_add_watchman = task_b(table)
    prev_list = minutes_to_add_watchman[:-1]
    cur_list = minutes_to_add_watchman[1:]
    fix_time = fixed_time(table)

    new_watchmen = []
    prev_insert_was = None
    for prev, item in zip(prev_list, cur_list):
        if item - prev <= 0 and (prev_insert_was is None or prev_insert_was < item):
            prev_insert_was = item - fix_time
            new_watchmen.append((item, item - fix_time))
    return new_watchmen


def fixed_time(table: TableIn) -> Minute:
    def inner():
        count = 0
        for prev, item in zip(prev_list, cur_list):
            if item - prev > 0:
                count += 1
            else:
                yield count
                count = 0

    minutes_to_add_watchman = task_b(table)
    prev_list = minutes_to_add_watchman[:-1]
    cur_list = minutes_to_add_watchman[1:]
    return max(inner())
