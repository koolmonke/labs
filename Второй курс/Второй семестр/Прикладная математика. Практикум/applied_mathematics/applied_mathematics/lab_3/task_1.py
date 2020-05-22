from lab_solutions.lab_2.task_1 import f


def main():
    x = x_begin = -5
    x_end = 7
    dx = 0.5
    print(f'{x_begin=}, {x_end=}, {dx=}')
    print('X=        Y=')
    while (x := x + dx) <= x_end:
        print(f'{x: .02f}    {f(x): .02f}')


if __name__ == '__main__':
    main()
