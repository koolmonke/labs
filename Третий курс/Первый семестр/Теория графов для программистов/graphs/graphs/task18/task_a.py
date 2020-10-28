from graphs.task18 import TableIn


def task_a(table: TableIn) -> bool:
    return all(i >= 2 for i in table)
