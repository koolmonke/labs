import csv
from pathlib import Path

docs = Path("..") / "docs"

IMAGE_WEIGHT = 28


def main():
    with open(docs / "train.csv") as csv_file:
        csv_reader = csv.reader(csv_file)
        for row in csv_reader:
            print("n =", row[0])
            image = row[1:]
            for line in (image[i:i + IMAGE_WEIGHT] for i in range(0, len(image), IMAGE_WEIGHT)):
                print("\t".join(line))


if __name__ == '__main__':
    main()
