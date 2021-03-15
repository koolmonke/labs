from math import ceil

TYPOS = 500
PAGES = 500


def f(symbols: int = 500) -> (int, int):
    minim = TYPOS if TYPOS <= PAGES else 0
    maxim = 1 if TYPOS <= symbols else ceil(TYPOS / symbols)

    return minim, maxim


def main() -> None:
    char_count = int(input('количество символов на странице '))
    minim, maxim = f(char_count)
    print(f'от {PAGES - minim} до {PAGES - maxim} страниц не содержат опечатки')


if __name__ == '__main__':
    main()
