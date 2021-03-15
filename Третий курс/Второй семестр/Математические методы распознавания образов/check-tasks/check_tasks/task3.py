from math import ceil

TYPOS = 500
PAGES = 500


def main(symbols: int = 500) -> (int, int):
    minim = TYPOS if TYPOS <= PAGES else 0
    maxim = 1 if TYPOS <= symbols else ceil(TYPOS/symbols)

    return minim, maxim


if __name__ == '__main__':
    inp = int(input('количество символов на странице '))
    minim, maxim = main(inp)

    print(f'от {PAGES - minim} до {PAGES - maxim} страниц не содержат опечатки')