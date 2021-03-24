import csv
from pathlib import Path

docs = Path("..") / "docs"

IMAGE_WEIGHT = 28


def main():
    with open(docs / "test.csv") as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)
        for row in csv_reader:
            image = row
            for line in (image[i:i + IMAGE_WEIGHT] for i in range(0, len(image), IMAGE_WEIGHT)):
                print("\t".join(line))
            print()


if __name__ == '__main__':
    main()
