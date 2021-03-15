from math import ceil


def main() -> None:
    char_per_page = int(input("Количество символов на странице "))
    pages = int(input("Кол-во страниц "))
    typos = int(input("Кол-во опечаток "))

    print(f"от {pages - min(typos, pages)} до {pages - ceil(typos / char_per_page)} страниц не содержат опечатки")


if __name__ == '__main__':
    main()
