from math import ceil


def solve(char_per_page: int = 500, typos: int = 500, pages: int = 500):
    maxim = min(typos, pages)
    minim = ceil(typos / char_per_page)

    return minim, maxim


def main() -> None:
    char_per_page = int(input("Количество символов на странице "))
    pages = int(input("Кол-во страниц "))
    typos = int(input("Кол-во опечаток "))

    minimum, maximum = solve(char_per_page, typos, pages)
    print(f"от {pages - maximum} до {pages - minimum} страниц не содержат опечатки")


if __name__ == '__main__':
    main()
